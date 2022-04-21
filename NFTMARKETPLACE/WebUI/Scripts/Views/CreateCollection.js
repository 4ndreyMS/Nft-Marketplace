function CreateCollection() {
    this.validationCollection = "";
    this.ctrlActions = new ControlActions();
    this.service = 'Collection';
    this.serviceCategory = 'Category';
    this.serviceCollectionCategory = 'Collection_Category';

    this.RegisterCollection = function () {

        var frmCreateCollection = this.ctrlActions.GetDataForm("frmCreateCollection")
        var NameId = {
            CompanyId: sessionStorage.getItem("UserCompany"),
            CollectionName: frmCreateCollection.CollectionName,
            CategoryId: frmCreateCollection.CollectionCategoryId
        }
        this.ctrlActions.PostToAPI(this.service + "/CreateCollection", NameId, function (response) {

            var responseApi = response;
            console.log(responseApi.Id)
            
            Swal.fire(
                'Collection created!',
                'success'
            )

        });

    }
}

$(window).on("load", function () {

    if (!sessionStorage.getItem('UserCedula') || !sessionStorage.getItem('UserComapny')) {
        window.location.href = "Login";
        return false;
    }
    return true;

});