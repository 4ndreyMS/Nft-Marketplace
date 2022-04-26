function ShoppingCart() {

    //todo: estos valores deben de ser cambiados para la creacion del nft
    const totalAmount = 10;

        const ctrlActions = new ControlActions();
    const service = "Wallet";

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
                        console.log("puede comprar");

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