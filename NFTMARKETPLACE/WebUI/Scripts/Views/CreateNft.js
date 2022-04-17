
function CreateNft() {

    this.ctrlActions = new ControlActions();
    this.service = 'NFT';

    sessionStorage.setItem("Id", "7858");
    imagenCloudnary = sessionStorage.getItem("imagenLocal");

    this.RegisterNFT = function () {

        var frmNFTRegister = this.ctrlActions.GetDataForm("frmNFTRegister");
        var cloudinary = new CloudinaryManager();
        //var collection = new CreateCollection();

        var NFT = {
            NftName: frmNFTRegister.NameNFT,
            Price: frmNFTRegister.Precio,
            Image: "UrlExample",
            IdCollection: frmNFTRegister.Collection,
            IdOwner: sessionStorage.getItem("Id"),
            IdCategory: frmNFTRegister.CategotyId
        }

        if (frmNFTRegister.NameNFT == "" || frmNFTRegister.Precio == "" || frmNFTRegister.Collection == "") {
            alert("FILL ALL THE BLANKS");

        } else {
            this.ctrlActions.PostToAPI(this.service + "/CreateNFT", NFT, function (response) { });
            alert("NFT created")
        }



        this.OpenWidget = function (image) {
            var cloudinary = new CloudinaryManager(image);
            cloudinary.OpenWidget();
        }
    }
}

