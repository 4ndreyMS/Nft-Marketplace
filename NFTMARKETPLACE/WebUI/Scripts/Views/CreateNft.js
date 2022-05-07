function CreateNft() {

    this.ctrlActions = new ControlActions();
    this.service = 'NFT';
    const catService = 'Category'
    const collService = 'Collection'
    imagenCloudnary = sessionStorage.getItem("imagenLocal");

    const slct = document.getElementById("slctCategory");
    const slctCollection = document.getElementById("slctCollection");


    //metodos para llenar los dropdowns
    let collection = { "CompanyId": sessionStorage.getItem("UserCompany") }/*   '9066'*/
    
    this.loadDropdownColl = function () {
        this.ctrlActions.PostToAPI(collService + "/RetrieveAllCollectionByCompany", collection, function (response) {
            response.forEach((val) => {
                slctCollection.innerHTML += `<option value="${val.Id}">${val.CollectionName}</option>`;
            })
        });
    }
    //metodos para llenar los dropdowns
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
            IdCollection: slctCollection.value,
            IdOwner: sessionStorage.getItem("UserCompany"),
            IdCategory: slct.value,
            SaleState: "InPropiety"
        }

        if (frmNFTRegister.NameNFT == "") {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please fill the Nft name',

            })
        } else if (frmNFTRegister.Precio == "") {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please insert price',
            })

        } else if (sessionStorage.getItem("imagenLocal") == "") {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please upload image',
            })
        } else if (slct.value == "") { //Categoria
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please select a category',
            })
        } else if (slctCollection.value == "") { //Collection
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please select a collection',
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

    if (!sessionStorage.getItem('UserCedula') || !sessionStorage.getItem('UserCompany') || sessionStorage.getItem('UserRole') != 3) {
        window.location.href = "Login";
        return false;
    }
    var nft = new CreateNft();
    nft.loadDropdownCat();
    nft.loadDropdownColl();
    return true;

});

