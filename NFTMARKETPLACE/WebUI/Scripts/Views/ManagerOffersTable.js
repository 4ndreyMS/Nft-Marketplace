const cntrlAction = new ControlActions();
const serviceCompany = "Company";
const serviceNFT = 'NFT';
const serviceValidation = "SendValidations";

function ManagerOffersTable() {
    let Owner = sessionStorage.getItem("UserCompany");
    this.tblOffer = 'offerList';
    const service = 'Offer';
    const serviceWallet = "Wallet";
    this.columns = "NFT,BidderID,Amount";
    let walletResponse = {};
    let OfferInfo = {};
    let validationObj = {};
    this.validateLogin = function () {

        if (sessionStorage.getItem('UserCedula') === null || sessionStorage.getItem('UserCedula') === undefined) {
            window.location.href = "Login";
            return false;
        }
        return true;
    }

    this.RetrieveAllOffers = function () {
        cntrlAction.FillTableWithString(service + "/RetrieveAllOffersByOwner", Owner, this.tblOffer, false);
    }

    this.Prueba = function (Offer) {
        bidder = Offer.BidderID;
        nft = Offer.NFT;
        amount = Offer.Amount;
    }

    this.StatusApprove = function () {
        if (bidder == "" && nft == "") {
            Swal.fire({
                title: 'Error!',
                text: 'Please select an offer before approving it',
                icon: 'error',
                confirmButtonText: 'Cool',
                confirmButtonColor: "#DD6B55",
            })
        } else {
            OfferInfo = {
                BidderID: bidder,
                NFT: nft,
                Amount: amount
            };

            let walletBidder = { CompanyId: bidder, Amount: amount, Identifier: "" }
            let walletOwner = { CompanyId: Owner, Amount: amount, Identifier: "" }

            //se consulta el wallet de la bidder
            cntrlAction.PostToAPI(serviceWallet + "/WalletInfoByCompnay", walletBidder, function (response) {
                walletResponse = response;
                walletBidder.Identifier = response.Identifier;
                
                //se valida si el usuario tiene monto suficiente
                if (amount <= response.Amount) {
                    //se rebaja el montp del nft en la cuenta del bidder
                    cntrlAction.PostToAPI(serviceWallet + "/restAmount", walletBidder, function (response) {
                        cntrlAction.PostToAPI(serviceWallet + "/WalletInfoByCompnay", walletOwner, function (response) {

                            //se realiza la suma del dinero al quien acepta la oferta
                            walletOwner.Identifier = response.Identifier;
                            cntrlAction.PostToAPI(serviceWallet + "/addAmount", walletOwner, function (response) {

                                var updNft = {
                                    Id: OfferInfo.NFT,
                                    Price: OfferInfo.Amount,
                                    IdCollection: null,
                                    IdOwner: OfferInfo.BidderID,
                                    SaleState: "InPropiety"
                                }
                                //se actualizan los parametros del nft, quien pertenece, monto
                                cntrlAction.PostToAPI(serviceNFT + "/UpdateWhenBuyNft", updNft, function (response) {
                                    //se elimina la oferta
                                    cntrlAction.DeleteToAPI(service + "/DeleteOffer", OfferInfo, function (response) {
                                        let OwnerCompany = { id: Owner };
                                        //se devuelve la informacion de la compania
                                        cntrlAction.PostToAPI(serviceCompany + "/retriveCompanyInfo", OwnerCompany, function (response) {

                                            validationObj = {
                                                EmailTo: response.email,
                                                Title: "Your NFT purchase verification",
                                                Msj: "Thanks for your purchase!",
                                                NFTAsset: response.Image
                                            };

                                            var nft = { Id: OfferInfo.NFT }
                                            //se consulta la imagen del nft para enviar el qr
                                            cntrlAction.PostToAPI(serviceNFT + "/RetrieveNFT", nft, function(response) {
                                                validationObj.NFTAsset = response.Image;
                                                //se envia el qr
                                                cntrlAction.PostToAPI(serviceValidation + "/SendQR", validationObj, function(response) {
                                                    Swal.fire({
                                                        title: 'Success!',
                                                        text: 'You accept the offer of your product',
                                                        width: 600,
                                                        padding: '3em',
                                                        color: '#000',
                                                        background: '#fff',
                                                        confirmButtonColor: "#DD6B55",
                                                        icon: 'success'
                                                    }).then(function () {
                                                        location.reload();
                                                    });
                                                });
                                            });
                                        });
                                    });
                                });

                            });
                        });
                    });

                } else {
                    Swal.fire({
                        title: 'Error!',
                        text: "This user don't have enough CFC!",
                        icon: 'error',
                        confirmButtonText: 'Try Again!',
                        confirmButtonColor: "#DD6B55",
                    });
                }
            });
        }

        bidder = "";
        nft = "";
    }


    this.StatusDecline = function () {

        if (bidder == "" && nft == "") {
            Swal.fire({
                title: 'Error!',
                text: 'Please select an offer before declining it',
                icon: 'error',
                confirmButtonText: 'Cool',
                confirmButtonColor: "#DD6B55",
            })
        } else {
            var OfferInfo = {
                BidderID: bidder,
                NFT: nft
            };
            cntrlAction.DeleteToAPI(service + "/DeleteOffer", OfferInfo, function (response) { });
        }
        bidder = "";
        nft = "";
        // window.location.reload();
    }

}

function quit(parameters) {

    let OwnerCompany = { id: "565" };
    cntrlAction.PostToAPI(serviceCompany + "/retriveCompanyInfo", OwnerCompany, function (response) {

       let validationObj = {
            EmailTo: response.email,
            Title: "Your NFT purchase verification",
            Msj: "Thanks for your purchase!",
            NFTAsset: response.Image
        };

        var nft = { Id: "A47CD3A62A" }
        cntrlAction.PostToAPI(serviceNFT + "/RetrieveNFT", nft, function (response) {
            validationObj.NFTAsset = response.Image;

            cntrlAction.PostToAPI(serviceValidation + "/SendQR", validationObj, function(response) {
                console.log("qr sendt");
            })


        });
    });
}

$(document).ready(function () {
    var tblLoad = new ManagerOffersTable();
    tblLoad.validateLogin();
    tblLoad.RetrieveAllOffers();
});