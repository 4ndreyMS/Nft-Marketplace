const { Swal } = require("../sweetalert2");
//Sweet alert not working
/*
 Uncaught ReferenceError: Cannot access 'Swal' before initialization
    at CreateNft.RegisterNFT (CreateNft.js:26:13)
    at HTMLButtonElement.<anonymous> (RegisterNFT:234:22)
    at HTMLButtonElement.dispatch (jquery-3.3.1.min.js:2:41772)
    at HTMLButtonElement.y.handle (jquery-3.3.1.min.js:2:39791)
 */

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

        } else if (frmNFTRegister.Image == "") {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please upload image',
            })
        } else if (frmNFTRegister.IdCategory == "") {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please select a category',
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
    return true;

});

