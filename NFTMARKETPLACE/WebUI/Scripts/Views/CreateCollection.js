function CreateCollection() {
    this.validationCollection = "";
    this.ctrlActions = new ControlActions();
    this.service = 'Collection';
    this.serviceCategory = 'Category';
    this.serviceCollectionCategory = 'Collection_Category';

    const slct = document.getElementById("slctCollCategory");
    this.loadDropdownCat = function () {
        this.ctrlActions.PostToAPI(this.serviceCategory + "/RetrieveCategories", "values", function (response) {
            response.forEach((val) => {
                slct.innerHTML += `<option value="${val.Id}" >${val.CategoryName}</option>`;
            })
        });
    }

    this.RegisterCollection = function () {

        var frmCreateCollection = this.ctrlActions.GetDataForm("frmCreateCollection")
        var NameId = {
            CompanyId: sessionStorage.getItem("UserCompany"),
            CollectionName: frmCreateCollection.CollectionName,
            CategoryId: slct.value
        }

        if (NameId.CategoryId != '') {
            this.ctrlActions.PostToAPI(this.service + "/CreateCollection", NameId, function (response) {

                var responseApi = response;
                console.log(responseApi.Id)
                document.getElementById("frmCreateCollection").reset();
                Swal.fire(
                    'Collection created',
                    'success'
                )

            });
        } else {

            Swal.fire({
                title: 'Something is missing',
                text: 'Select a category',
                confirmButtonText: 'Try again!',
                confirmButtonColor: "#DD6B55"
            })
        }
    }
}

$(window).on("load", function () {

    if (!sessionStorage.getItem('UserCedula') || !sessionStorage.getItem('UserCompany') || sessionStorage.getItem('UserRole') != 3) {
        window.location.href = "Login";
        return false;
    }
    var coll = new CreateCollection();
    coll.loadDropdownCat();
    return true;

});