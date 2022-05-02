﻿let totalAmount = 0.0;
let itemsOnCart = sessionStorage.getItem("productsInCart")
const serviceNFT = "NFT";

function ShoppingCart() {
    
    

    const ctrlActions = new ControlActions();
    const service = "Wallet";
    const serviceCompany = "Company";
    const serviceValidation = "SendValidations";

    const companyId = sessionStorage.getItem("UserCompany");
    const frmPin = ctrlActions.GetDataForm("frmPayProceed");
    const frmId = document.getElementById("frmPayProceed");

    let walletInfo = { CompanyId: companyId };
    let walletResponse = {};
    let validationObj = {}

    this.PayProceed = function () {
        let optResponse = 0;

        //verifica que no hayan campos vacíos
        if (frmPin.walletPin != "") {
            
            document.getElementById("txtWalletId").classList.remove('fillAllBlanks');

            //realiza peticion al wallet segun el codigo de la compania
            ctrlActions.PostToAPI(service + "/WalletInfoByCompnay", walletInfo, function (response) {
                walletResponse = response;
                localStorage.setItem('WalletIdentifier',walletResponse.Identifier);
                //verifica que el pin sea igual que viene del wallet
                if (walletResponse.WalletPin === parseInt(frmPin.walletPin)) {

                    //virifica que la cuenta tenga fondos suficientes
                    if (walletResponse.Amount >= totalAmount) {

                        var element = document.getElementById("otpShopping");
                        element.style.display = "block";

                        var Company = {id: walletResponse.CompanyId}
                        ctrlActions.PostToAPI(serviceCompany + "/retriveCompanyInfo", Company, function (response) {
                            
                            validationObj = {
                                EmailTo: response.email,
                                PhoneTo: sessionStorage.getItem("UserPhone"),
                                Title: "Validate your transaction",
                                Msj: "Hi, verify your transaction with this security code"
                            }

                            ctrlActions.PostToAPI(serviceValidation + "/SendDymanicValidation", validationObj, function (response) {
                                localStorage.setItem('OptTrans', parseInt(response));
                                //si es correcto entonces acá es cuando se realiza el rebajo del monto y el intercambio de nft

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

    this.AfterValidation = function () {

        //valida que el otp sea igual al que se le envia
        if (localStorage.getItem('OptTrans') === frmPin.Otp) {
            frmId.reset();


            let moveMoneyWallet = { Identifier: localStorage.getItem('WalletIdentifier'), Amount: totalAmount, IdOwner:""}

            //se realiza el rebajo del monto total de los nft al wallet que está realizando la compra
            ctrlActions.PostToAPI(service + "/restAmount", moveMoneyWallet, function (response) { })

            //se itera por la cantidad de nfts que haya en el carrito
            Object.values(itemsOnCart).forEach((element) => {

                var wallet = { CompanyId: element.IdOwner }

                //se obtiene la identificacion del id de la compania
                ctrlActions.PostToAPI(service + "/WalletInfoByCompnay", wallet, function (response) {

                    moveMoneyWallet = { Identifier: response.Identifier, Amount: element.Price }
                    //se realiza el aumento del precio en cada una de las cuentas
                    const addAmount = ctrlActions.PostToAPI(service + "/addAmount", moveMoneyWallet, function(response) {

                    })

                    //se realiza el cambio de duenio
                    var updNft = { Id: element.Id, Price: element.Price, IdCollection: null, IdOwner: sessionStorage.getItem("UserCompany"), SaleState: "InPropiety"}
                    const updOwner = ctrlActions.PostToAPI(serviceNFT + "/UpdateWhenBuyNft", updNft, function (response) { })
                    addAmount().then(r => { updOwner() });
                })

            });

        } else {
            Swal.fire({
                title: 'Error!',
                text: 'Incorrect code!',
                icon: 'error',
                confirmButtonText: 'Try Again!',
                confirmButtonColor: "#DD6B55",
            })
        }

    }

  


 
}


function displayCart() {

    let cartItems = sessionStorage.getItem("productsInCart")
    cartItems = JSON.parse(cartItems)

    let nftContainer = document.querySelector(".card-body.nftContainer")

    if (cartItems && nftContainer) {
        nftContainer.innerHTML = "";
        Object.values(cartItems).map(nft => {
            nftContainer.innerHTML += `
                            <div class="row d-flex justify-content-between align-items-center nftContainerCard">
                                <div class="col-md-2 col-lg-2 col-xl-2">
                                    <img src=" ${nft.Image}"
                                         class="img-fluid rounded-3" alt="">
                                </div>
                                <div class="col-md-3 col-lg-3 col-xl-3">
                                    <p class="lead fw-normal mb-2"> ${nft.NftName}</p>
                                  
                                </div>
                                <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                                    <h5 class="mb-0"> ${nft.Price} CFC</h5>
                                </div>

                                <button class="col-md-1 col-lg-1 col-xl-1 text-end deleteButton" id="${nft.Id}" >
                                </button>
                            </div>
`


        }
              
           

        )
       


           
       
    }

  

    let carts = document.querySelectorAll(".deleteButton")
    let items = Object.values(cartItems)

    for (let i = 0; i < carts.length; i++) {
        carts[i].addEventListener('click', () => {
            let btnId = event.target.id
            for (i = 0; i < items.length; i++) {
                if (items[i].Id == btnId) {
                    items.splice(i, 1);
                }
            }
            sessionStorage.productsInCart = JSON.stringify(items);
            window.location.reload();
        })
    }
}

function cartNumbers(product) {

    console.log("The product clicked is: ", product)
    let productNumbers = sessionStorage.getItem('NftName');
    productNumbers = parseInt(productNumbers)


    if (productNumbers) {
        sessionStorage.setItem('NftName', productNumbers + 1)
        document.querySelector('.cart span').textContent = productNumbers + 1
    } else {
        sessionStorage.setItem('NftName', 1)
        document.querySelector('.cart span').textContent = 1

    }

}




function totalAmout() {
    itemsOnCart = JSON.parse(itemsOnCart);
    Object.values(itemsOnCart).forEach((element) => {
        totalAmount += element.Price;
    });
    document.getElementById("totalAmount").innerHTML += totalAmount + " CFC";
}

$(document).ready(function () {
    displayCart();
    cartNumbers()
    totalAmout();
});

