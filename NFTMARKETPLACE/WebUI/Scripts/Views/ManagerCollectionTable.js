function ManagerCollectionTable() {

    this.tblCollection = 'collectionList';
    this.service = 'Collection';
    this.cntrlAction = new ControlActions();

    this.columns = "ID,Collection Name, ID Company, Category";

    this.RetrieveAllCollections = function () {
        this.cntrlAction.FillTable(this.service + "/RetrieveAllCollectionWithCategory", this.tblCollection, false);
    }
}

$(document).ready(function () {
    var tblLoad = new ManagerCollectionTable();
    tblLoad.RetrieveAllCollections();
});