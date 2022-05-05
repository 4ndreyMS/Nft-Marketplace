const ctrlActions = new ControlActions();
const serviceUser = "User";
const retRole = sessionStorage.getItem("UserRole");
let responseUser = {}
let UserLog = { Cedula: sessionStorage.getItem('UserCedula') }
const serviceCompany = "Company";

function EditProfile() {

    

    this.UpdProfile = function () {
        let btnImage = localStorage.getItem('UserPhoto');
        let retForm = ctrlActions.GetDataForm("frmUpdInfo");
        let formId = document.getElementById("frmUpdInfo");
        let User = {
            Cedula: sessionStorage.getItem("UserCedula"),
            Name: "",
            SureName: "",
            Phone: "",
            Nickname: "",
            UserPic: "",
            Company: {
                id: sessionStorage.getItem("UserCompany"),
                name: "",
                walletPin :0
            }
        }

        if (retForm.name === "" && retForm.sureName === "" && retForm.nickname === ""
            && retForm.phone === "" && retForm.WalletPin === "" && btnImage === null) {

            Swal.fire({
                title: 'You have to fill at least one blank',
                text: '',
                icon: 'error',
                confirmButtonText: 'Try Again!',
                confirmButtonColor: "#DD6B55",
            })
        } else {

            if (retForm.name === "" || retForm.name === " ") {
                User.Name = responseUser.Name
            } else {
                User.Name = retForm.name
            }
            if (retForm.sureName === "" || retForm.sureName === " ") {
                User.SureName = responseUser.SureName
            } else {
                User.SureName = retForm.sureName
            }
            if (retForm.nickname === "" || retForm.nickname === " ") {
                User.Nickname = responseUser.Nickname
            } else {
                User.Nickname = retForm.nickname
            }
            if (retForm.phone === "" || retForm.phone === " ") {
                User.Phone = responseUser.Phone
            } else {
                User.Phone = retForm.phone
            }
            if (retForm.WalletPin === "" || retForm.WalletPin === " ") {
                User.Company.walletPin = 0
            } else {
                User.Company.walletPin = parseInt(retForm.WalletPin)
            }
            if (btnImage === "" || btnImage === null || btnImage === undefined) {
                User.UserPic = responseUser.UserPic
            } else {
                User.UserPic = btnImage
            }

            var Company = { id: responseUser.IdOrganization }
            ctrlActions.PostToAPI(serviceCompany + "/retriveCompanyInfo", Company, function (response) {
                if (retForm.companyName === "" || retForm.companyName === " ") {
                    User.Company.name = response.name;
                } else {
                    User.Company.name = retForm.companyName
                }
                console.log(User);

                ctrlActions.PostToAPI(serviceUser + "/updateUserInfo", User, function(response) {
                    formId.reset();
                    Swal.fire({
                        title: 'Success!',
                        text: 'You have update your profile info',
                        width: 600,
                        padding: '3em',
                        color: '#000',
                        background: '#fff',
                        confirmButtonColor: "#DD6B55",
                        icon: 'success'
                    })
                });
            });
        }
    }
}

function loadUserInfo() {

            ctrlActions.PostToAPI(serviceUser + "/RetrieveUser", UserLog, function(response) {
                responseUser = response;
                document.getElementById("UserUpd").src = responseUser.UserPic;
            })
}
function showFrm() {
    var element = document.getElementById("updOnlyContentCretor");
    if (parseInt(retRole)===3) {
        element.style.display = "block";
    }


}

$(window).on("load", function () {

    if (!sessionStorage.getItem('UserCedula') || !sessionStorage.getItem('UserCompany')) {
        window.location.href = "Login";
        return false;
    } else {
        sessionStorage.removeItem("UserPhoto");
        showFrm();
        loadUserInfo();
    }
});