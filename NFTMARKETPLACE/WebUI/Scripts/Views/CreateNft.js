function CreateNft() {

    this.ctrlActions = new ControlActions();
    this.service = 'NFT';

    imagenCloudnary = sessionStorage.getItem("imagenLocal");

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

        if (frmNFTRegister.NameNFT == ""){
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

    if (!sessionStorage.getItem('UserCedula') || !sessionStorage.getItem('UserCompany') || sessionStorage.getItem('UserRole') != 3) {
        window.location.href = "Login";
        return false;
    }
    return true;

});

