function CreateCollection() {
    this.validationCollection = "";
    this.ctrlActions = new ControlActions();
    this.service = 'Collection';
    this.serviceCategory = 'Category';
    this.serviceCollectionCategory = 'Collection_Category';

    sessionStorage.setItem("Id", "7858");

    this.RegisterCollection = function () {

        var frmCreateCollection = this.ctrlActions.GetDataForm("frmCreateCollection")
        var NameId = {
            CompanyId: sessionStorage.getItem("Id"),
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