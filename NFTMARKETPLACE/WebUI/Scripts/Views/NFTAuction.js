﻿let auctionResponse = {};
let priceBid = 0;
let timeFinish = false;
const serviceWallet = "Wallet"
const serviceValidation = "SendValidations";
const serviceUser = "User";
const serviceNFT = "NFT";
const serviceAuction = "Auction";
const ctrlActions = new ControlActions();
const serviceCompany = "Company"

function moveToSameOwner() {
    let AUCTION = {
        Nft: { Id: sessionStorage.getItem('NFTSelected') }
    }
    ctrlActions.PostToAPI(serviceAuction + "/DeleteAuctions", AUCTION, function (response) {
        let nftState = { Id: sessionStorage.getItem('NFTSelected'), SaleState: "InPropiety" }
        ctrlActions.PostToAPI(serviceNFT + "/UpdateStateNft", nftState, function (response) {
            window.location.href = "Marketplace";
        });
    });
}

function WhenTimeEnds() {
    let walletResponse = {}

    //nadie oferta
    if (auctionResponse.IdBuyer === auctionResponse.IdOwner) {
        moveToSameOwner();
    } else {
        let walletInfo = { CompanyId: auctionResponse.IdBuyer };
        ctrlActions.PostToAPI(serviceWallet + "/WalletInfoByCompnay",
            walletInfo,
            function(response) {
                walletResponse = response;
                //si es menor al monto de lo ofertado no la acepta
                if (walletResponse.Amount < auctionResponse.Amount) {
                    moveToSameOwner();
                } else {
                    //el monto es mayor
                    let moveMoneyWallet = { Identifier: walletResponse.Identifier, Amount: auctionResponse.Amount }
                    ctrlActions.PostToAPI(serviceWallet + "/restAmount",
                        moveMoneyWallet,
                        function(response) {

                            walletInfo.CompanyId = auctionResponse.IdOwner;
                            ctrlActions.PostToAPI(serviceWallet + "/WalletInfoByCompnay",
                                walletInfo,
                                function(response) {
                                    moveMoneyWallet = {
                                        Identifier: response.Identifier,
                                        Amount: auctionResponse.Amount
                                    }
                                    //se realiza el aumento del precio en cada una de las cuentas
                                    ctrlActions.PostToAPI(serviceWallet + "/addAmount",
                                        moveMoneyWallet,
                                        function(response) {
                                            var updNft = {
                                                Id: auctionResponse.Nft.Id,
                                                Price: auctionResponse.Amount,
                                                IdCollection: null,
                                                IdOwner: auctionResponse.IdBuyer,
                                                SaleState: "InPropiety"
                                            }

                                            let Company = { id: auctionResponse.IdBuyer }
                                            ctrlActions.PostToAPI(serviceCompany + "/retriveCompanyInfo", Company, function(response) {
                                                let validationObj = {
                                                    EmailTo: response.email,
                                                    Title: "Your NFT purchase verification",
                                                    Msj: "Thanks for your purchase!",
                                                    NFTAsset: auctionResponse.Nft.Image
                                                }

                                                    ctrlActions.PostToAPI(serviceNFT + "/UpdateWhenBuyNft", updNft, function(response) {

                                                        ctrlActions.PostToAPI(serviceValidation + "/SendQR", validationObj, function (response) {
                                                            let AUCTION = {
                                                                Nft: { Id: auctionResponse.Nft.Id}
                                                            }
                                                                ctrlActions.PostToAPI(serviceAuction + "/DeleteAuctions", AUCTION, function (response) {
                                                                    window.location.href = "Marketplace";
                                                                })
                                                            
                                                                })
                                                        })
                                                })
                                        })
                                })
                        })
                }
            })
    }
}

function NFTAuction() {
    let price;

    this.Information = function () {
        let AUCTION = {
            Nft: {
                Id: sessionStorage.getItem('NFTSelected')
            }
        }
      
        ctrlActions.PostToAPI(serviceAuction + "/RetrieveAllByNft", AUCTION, function (response) {
            auctionResponse = response;
        
                NFTAuctionInformation.innerHTML += `
                         <div class="row align-items-center justify-content-center">
                    <div class="col-lg-8">
                        <div class="inner-heading text-center">
                            <div class="mt-4">
                                <h1 class="fw-bold">NFT Information</h1>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mt-5 align-items-center">
                    <div class="col-lg-6">
                        <div class="back-home-image pe-4">
                            <img src="${response.Nft.Image}" alt="" class=" image-fill">
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="backhome-content mt-4 mt-lg-0">
                            <h2 class="fw-bold">${response.Nft.NftName}</h2>
                            <div class="tab-box my-4">
                                <ul class="nav nav-pills" id="pills-tab" role="tablist">
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link active" id="pills-home-tab" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home" aria-selected="true">Details</button>
                                    </li>
                                </ul>
                                <div class="tab-content mt-4 ps-3" id="pills-tabContent">
                                    <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                                       <p class="text-muted"><i class="mdi mdi-information-outline f-24 align-middle"></i> NFT Identification: ${response.Nft.Id}</p>
                                       <p class="text-muted"><i class="mdi mdi-folder-image f-24 align-middle"></i> Collection name: ${response.Nft.CollectionName}</p>
                                       <p class="text-muted"><i class="mdi mdi-calendar f-24 align-middle"></i> Creation date: ${response.Nft.CreationDate}</p>
<p  class="text-muted"><i class="mdi mdi-av-timer f-24 align-middle"></i> This auction ends in:</p>

<p style="font-size: 35px; margin-left: 25px;" class="text-muted" id="timer"></p>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="d-flex align-items-center">
                                        <div class="flex-grow-1 ms-2">
                                            <p class="mb-0 f-14 fw-semibold">Creator:</p>
                                        </div>
                                        <div class="flex-shrink-0">
                                            <div class="avatar-xs border rounded-circle border-3 border-white">
                                                <img src="${response.Nft.CreatorImage}" alt="" class="img-fluid rounded-circle">
                                            </div>
                                        </div>
                                        <div class="flex-grow-1 ms-2">
                                            <p class="mb-0 f-14 fw-semibold">${response.Nft.CreatorName}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="my-4">
                            <div class="row ">
                                <div class="col-lg-6">
                                    <h6 class="fw-bold mb-1">Last Price:</h6>
                                    <p class="fw-semibold">${response.Amount} CFC</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                    `
            price = response.Price;

            const timer = new Date(response.EndDate).getTime()
            const timerElement = document.getElementById("timer")
            const updateSec = setInterval(function () {
                let now = new Date().getTime();
                let timeleft = timer - now;
                let days = Math.floor(timeleft / (1000 * 60 * 60 * 24));
                let hours = Math.floor((timeleft % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                let minutes = Math.floor((timeleft % (1000 * 60 * 60)) / (1000 * 60));
                let seconds = Math.floor((timeleft % (1000 * 60)) / 1000);
               

                timerElement.innerHTML = `${days} d ${hours} h ${minutes} min ${seconds} secs`

                if (timeleft < 0) {
                    timeFinish = true;
                    clearInterval(updateSec)
                    timerElement.innerHTML = "This auction is over :( "
                    WhenTimeEnds();
                }

            }, 1000)


           
            })

    }

    this.SendAuctionBid = function () {

        if (sessionStorage.getItem('UserCedula') === null || sessionStorage.getItem('UserCedula') === undefined) {
            window.location.href = "Login";
            return false;
        }
        let valueForm = ctrlActions.GetDataForm("acutionForm");
        let idCompany = sessionStorage.getItem('UserCompany');
        
        if (!timeFinish) {
            
            if (auctionResponse.IdOwner === idCompany) {
                Swal.fire({
                    title: 'Error!',
                    text: "You can't bid to your own NFT",
                    icon: 'error',
                    confirmButtonText: 'Error',
                    confirmButtonColor: "#DD6B55",
                })
            } else {
                if (valueForm.Amount === "" || valueForm.Amount === null) {
                    Swal.fire({
                        title: 'Error!',
                        text: 'Please insert a valid amount',
                        icon: 'error',
                        confirmButtonText: 'Error',
                        confirmButtonColor: "#DD6B55",
                    })

                } else {
                    let wallet = { CompanyId: idCompany}
                    ctrlActions.PostToAPI(serviceWallet + "/WalletInfoByCompnay", wallet, function (response) {

                        if (auctionResponse.Amount < parseFloat(valueForm.Amount)) {
                            if (response.Amount >= auctionResponse.Amount) {

                                let User = { Cedula: sessionStorage.getItem('UserCedula')}
                                ctrlActions.PostToAPI(serviceUser + "/RetrieveUser", User, function (response) {

                                    let sendMail = { EmailTo: response.Email, PhoneTo: response.Phone, Title: "About your bid", Msj: "Your offer has been exceeded, the highest bid is " + valueForm.Amount+" CFC"}
                                    ctrlActions.PostToAPI(serviceValidation + "/SendSmsMail", sendMail, function(response) {
                                        let AUCTION = {
                                            Amount: valueForm.Amount,
                                            IdBuyer: idCompany,
                                            Nft: {
                                                Id: sessionStorage.getItem('NFTSelected'),
                                            }
                                        }   
                                        ctrlActions.PostToAPI(serviceAuction + "/UpdateAuction", AUCTION, function (response) {
                                            Swal.fire({
                                                title: 'Success!',
                                                text: 'Your bid has been aproved',
                                                width: 600,
                                                padding: '3em',
                                                color: '#000',
                                                background: '#fff',
                                                confirmButtonColor: "#DD6B55",
                                                icon: 'success'
                                            }).then(function () {
                                                location.reload();
                                            });
                                        })
                                    })
                                })

                            } else {
                                Swal.fire({
                                    title: 'Not enough funds!',
                                    text: 'Buy more CFC',
                                    icon: 'alert',
                                    confirmButtonText: 'Try Again!',
                                    confirmButtonColor: "#DD6B55",
                                })
                            }
                        } else {
                            Swal.fire({
                                title: 'Error!',
                                text: 'Please increase the amount of your bid',
                                icon: 'error',
                                confirmButtonText: 'Error',
                                confirmButtonColor: "#DD6B55",
                            })
                        }
                    })
                }
            }
        } else {
            Swal.fire({
                title: 'Error!',
                text: 'The offer time has ended',
                icon: 'error',
                confirmButtonText: 'Error',
                confirmButtonColor: "#DD6B55",
            })
        }
        

        

    }

    setTimeout(function () {
        location.reload();
    }, 300000);
}

$(document).ready(function () {

    var load = new NFTAuction();

    load.Information();
    
});