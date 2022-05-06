function ManagerOffersTable() {
    this.validateLogin = function () {


        if (sessionStorage.getItem('UserCedula') === null || sessionStorage.getItem('UserCedula') === undefined) {
            window.location.href = "Login";
            return false;
        }
        return true;
    }

    let Offer = { OwnerID: sessionStorage.getItem("UserCompany") };

    this.tblOffer = 'offerList';
    this.service = 'Offer';
    this.cntrlAction = new ControlActions();

    this.columns = "NFT,BidderId,Amount";

    this.RetrieveAllOffers = function () {
        this.cntrlAction.FillTable(this.service + "/RetrieveAllOffersByOwner", this.tblOffer, false);
    }
}

$(document).ready(function () {
    var tblLoad = new ManagerOffersTable();
    tblLoad.validateLogin();
    tblLoad.RetrieveAllOffers();
});