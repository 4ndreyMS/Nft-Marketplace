function ManagerNFTTable() {

    this.tblNFT = 'nftList';
    this.service = 'NFT';
    this.cntrlAction = new ControlActions();

    this.columns = "Name,Price, Creator, Owner, Category";

    this.RetrieveAllCollections = function () {
        this.cntrlAction.FillTable(this.service + "/RetrieveAllNFTWithCategory", this.tblNFT, false);
    }
}

$(document).ready(function () {
    var tblLoad = new ManagerNFTTable();
    tblLoad.RetrieveAllCollections();
});