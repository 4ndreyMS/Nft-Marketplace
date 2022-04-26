function ShoppingCart() {

    //todo: estos valores deben de ser cambiados para la creacion del nft
    const totalAmount = 3;

    const ctrlActions = new ControlActions();
    const service = "Wallet";
    const serviceCompany = "Company";
    const serviceValidation = "SendValidations";

    const companyId = sessionStorage.getItem("UserCompany");
    const frmPin = ctrlActions.GetDataForm("frmPayProceed");
    const frmId = document.getElementById("frmPayProceed");

    let walletInfo = { CompanyId: companyId };
    let walletResponse = {};


    this.PayProceed = function () {

        //verifica que no hayan campos vacíos
        if (frmPin.walletPin != "") {
            
            document.getElementById("txtWalletId").classList.remove('fillAllBlanks');

            //realiza peticion al wallet segun el codigo de la compania
            ctrlActions.PostToAPI(service + "/WalletInfoByCompnay", walletInfo, function (response) {
                walletResponse = response;

                //verifica que el pin sea igual que viene del wallet
                if (walletResponse.WalletPin === parseInt(frmPin.walletPin)) {

                    //virifica que la cuenta tenga fondos suficientes
                    if (walletResponse.Amount >= totalAmount) {

                        var element = document.getElementById("otpShopping");
                        element.style.display = "block";

                        var Company = {id: walletResponse.CompanyId}
                        ctrlActions.PostToAPI(serviceCompany + "/retriveCompanyInfo", Company, function (response) {

                            var validationObj = {
                                EmailTo: response.email,
                                PhoneTo: sessionStorage.getItem("UserPhone"),
                                Title: "Validate your transaction",
                                Msj: "Hi, verify your transaction with this security code"
                            }
                            ctrlActions.PostToAPI(serviceValidation + "/SendDymanicValidation", validationObj, function(response) {
                                console.log(response);
                            })


                        })


                    } else {
                        frmId.reset();
                        Swal.fire({
                            title: 'Not enough funds!',
                            text: 'Buy more CFC',
                            icon: 'alert',
                            confirmButtonText: 'Try Again!',
                            confirmButtonColor: "#DD6B55",
                        })
                    }


                } else {
                    frmId.reset();
                    Swal.fire({
                        title: 'Error!',
                        text: 'Wrong wallet pin',
                        icon: 'error',
                        confirmButtonText: 'Try another!',
                        confirmButtonColor: "#DD6B55",
                    })
                }
            })
        } else {
            frmId.reset();
            document.getElementById("txtWalletId").classList.add('fillAllBlanks');
            Swal.fire({
                title: 'Error!',
                text: 'Fill all the blanks',
                icon: 'error',
                confirmButtonText: 'Try Again!',
                confirmButtonColor: "#DD6B55",
            })
        }




    }






}