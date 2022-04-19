
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

        if (frmNFTRegister.NameNFT == "" ||    alert("FILL ALL THE BLANKS");
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

