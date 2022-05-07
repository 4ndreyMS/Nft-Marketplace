function ManagerOffersTable() {
    const cntrlAction = new ControlActions();
    let Owner = sessionStorage.getItem("UserCompany");
    this.tblOffer = 'offerList';
    const service = 'Offer';
    this.columns = "NFT,BidderID,Amount";
    const service2 = 'NFT';

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
            var OfferInfo = {
                BidderID: bidder,
                NFT: nft,
                Amount: amount
            };
            var wallet = {
                CompanyId: bidder,
                Amount: amount
            }
            cntrlAction.PostToAPI(service + "/WalletInfoByCompnay", wallet, function (response) {
                console.log(response)


            });






            // cntrlAction.DeleteToAPI(service2 + "/UpdateNFTOwner", OfferInfo, function (response) { });
            //cntrlAction.DeleteToAPI(service + "/DeleteOffer", OfferInfo, function (response) { });


        }

        bidder = "";
        nft = "";
        //window.location.reload();
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

$(document).ready(function () {
    var tblLoad = new ManagerOffersTable();
    tblLoad.validateLogin();
    tblLoad.RetrieveAllOffers();
});