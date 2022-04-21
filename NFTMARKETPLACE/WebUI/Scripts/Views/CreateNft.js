function CreateNft() {

    this.ctrlActions = new ControlActions();
    this.service = 'NFT';
    const catService = 'Category'
    const collService = 'Collection'
    imagenCloudnary = sessionStorage.getItem("imagenLocal");

    const slct = document.getElementById("slctCategory");
    const slctCollection = document.getElementById("slctCollection");

    let collection = { "CompanyId": sessionStorage.getItem("UserCompany")}
    
    this.loadDropdownColl = function () {
        this.ctrlActions.PostToAPI(collService + "/", collection, function (response) {
            response.forEach((val) => {
                slctCollection.innerHTML += `<option value="${val.Id}" >${val.CollectionName}</option>`;
            })
        });
    }

    this.loadDropdownCat = function () {
        this.ctrlActions.PostToAPI(catService + "/RetrieveCategories", "values", function (response) {
            response.forEach((val) => {
                slct.innerHTML += `<option value="${val.Id}" >${val.CategoryName}</option>`;
            })
        });
    }

    this.RegisterNFT = function () {

        var frmNFTRegister = this.ctrlActions.GetDataForm("frmNFTRegister");
        var cloudinary = new CloudinaryManager();

        var NFT = {
            NftName: frmNFTRegister.NameNFT,
            Price: frmNFTRegister.Precio,
            Image: sessionStorage.getItem("imagenLocal"),
            IdCollection: frmNFTRegister.Collection,
            IdOwner: sessionStorage.getItem("UserCompany"),
            IdCategory: frmNFTRegister.CategotyId
        }

        if (frmNFTRegister.NameNFT == "") {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'FILL ALL THE BLANKS ',

            })

        } else {
            this.ctrlActions.PostToAPI(this.service + "/CreateNFT", NFT, function (response) { });

            Swal.fire(
                'NFT created!',
                'success'
            )
        }

        this.OpenWidget = function (image) {
            var cloudinary = new CloudinaryManager(image);
            cloudinary.OpenWidget();
        }
    }
}

$(window).on("load", function () {

    if (!sessionStorage.getItem('UserCedula') || !sessionStorage.getItem('UserCompany')) {
        window.location.href = "Login";
        return false;
    }
    var nft = new CreateNft();
    nft.loadDropdownCat();
    return true;

});

