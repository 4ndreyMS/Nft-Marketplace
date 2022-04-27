function Register() {


    const upperCaseLetters = /[A-Z]/g;
    const numbers = /[0-9]/g;
    const lowerCaseLetters = /[a-z]/g;
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const service = 'User';
    const serviceCompany = 'Company';
    const ctrlActions = new ControlActions();


    this.CreateContentUser = function () {

        let frmUser = ctrlActions.GetDataForm("frmUserCustomer");



        let fName = document.getElementById('txtName');
        let fCedula = document.getElementById('txtCedula');
        let fSureNames = document.getElementById('txtSurename');
        let fNickname = document.getElementById('txtNickname');
        let fPhone = document.getElementById('txtPhone');
        let fEmail = document.getElementById('txtEmail');
        let fPassword = document.getElementById('txtPassword');
        let btnImage = localStorage.getItem('UserPhoto');
        let fWalletPin = document.getElementById('txtWalletId');


        let company = {
            walletPin: frmUser.walletId
        }
        let UserCust = {
            Name: frmUser.name,
            Cedula: frmUser.cedula,
            Password: frmUser.password,
            SureName: frmUser.sureName,
            NickName: frmUser.nickname,
            Phone: frmUser.phone,
            Email: frmUser.email,
            UserPic: btnImage,
            Company: company
        }

        if (UserCust.Name === "") {
            fName.classList.add('fillAllBlanks');
        } else {
            fName.classList.remove('fillAllBlanks');
        }

        if (UserCust.Cedula === "") {
            fCedula.classList.add('fillAllBlanks');
        } else {
            fCedula.classList.remove('fillAllBlanks');
        }

        if (UserCust.Password === "") {
            fPassword.classList.add('fillAllBlanks');
        } else {
            fPassword.classList.remove('fillAllBlanks');
        }

        if (UserCust.SureName === "") {
            fSureNames.classList.add('fillAllBlanks');
        } else {
            fSureNames.classList.remove('fillAllBlanks');
        }

        if (UserCust.NickName === "") {
            fNickname.classList.add('fillAllBlanks');
        } else {
            fNickname.classList.remove('fillAllBlanks');
        }

        if (UserCust.Phone === "") {
            fPhone.classList.add('fillAllBlanks');
        } else {
            fPhone.classList.remove('fillAllBlanks');
        }

        if (UserCust.Email === "") {
            fEmail.classList.add('fillAllBlanks');
        } else {
            fEmail.classList.remove('fillAllBlanks');
        }

        if (UserCust.Company.walletPin.length === 0) {
            fWalletPin.classList.add('fillAllBlanks');
        } else {
            fWalletPin.classList.remove('fillAllBlanks');
        }

        if (UserCust.Name === "" || UserCust.Cedula === "" || UserCust.Password === "" ||
            UserCust.SureName === "" || UserCust.NickName === "" || UserCust.Phone === "" || UserCust.Email === "" || btnImage === null
            || UserCust.Company.walletPin.length === 0) {

            Swal.fire({
                title: 'Error!',
                text: 'Fill All the blanks, and remember to upload you profile photo.',
                icon: 'error',
                confirmButtonText: 'Try Again!',
                confirmButtonColor: "#DD6B55",
            })

        } else {
            ctrlActions.PostToAPI(service + "/ExistUserByMail", UserCust, function (response) {

                if (!response) {
                    if (UserCust.Password.length > 12 &&
                        UserCust.Password.match(this.upperCaseLetters) &&
                        UserCust.Password.match(this.numbers) &&
                        UserCust.Password.match(this.lowerCaseLetters) &&
                        UserCust.Password.match(this.specialChars)) {

                        ctrlActions.PostToAPI(service + "/CreateUserCustomer", UserCust, function (response) {
                                console.log(response);
                                var responseUserOrgId = response.IdOrganization;
                                var responseUserOtp = response.Otp;


                                localStorage.setItem("Otp", responseUserOtp);
                                localStorage.setItem("CompanyLog", responseUserOrgId);

                                var element = document.getElementById("OtpVal");
                                element.style.display = "block";
                            });


                    } else {
                        fPassword.classList.add('fillAllBlanks');


                        Swal.fire({
                            title: 'The password is incorrect!!',
                            text: "\n\n" +
                                "It must contains :\n" +
                                "- Upper Cases\n" +
                                "- Lower Cases\n" +
                                "- More than 12 characters\n" +
                                "- Special Characters",
                            icon: 'error',
                            confirmButtonText: 'Try Again!',
                            confirmButtonColor: "#DD6B55",
                        })
                    }
                } else {
                    fEmail.classList.add('fillAllBlanks');

                    Swal.fire({
                        title: 'Error!',
                        text: 'The email is already in use',
                        icon: 'error',
                        confirmButtonText: 'Try another!',
                        confirmButtonColor: "#DD6B55",
                    })
                }

            });

        }
    }


    this.ValidateOpt = function () {
        var frmUser = ctrlActions.GetDataForm("frmUserCustomer");
        var userRegisterForm = document.getElementById("frmUserCustomer");
        var localOtp = localStorage.getItem("Otp");
        var localCed = localStorage.getItem("CompanyLog");
        var Company = {
            id: localCed,
            status: "Valid"
        }

        if (frmUser.Otp === localOtp) {

            ctrlActions.PostToAPI(serviceCompany + "/UpdateCompanyStatus", Company, function (response) { });
            Swal.fire({
                title: 'Succesfull register!',
                icon: 'success',
                confirmButtonText: 'Cool',
                confirmButtonColor: "#DD6B55",
            })
            userRegisterForm.reset();
            window.location.href = "Login"

        } else {
            Swal.fire({
                title: 'Error!',
                text: 'Incorrect code!',
                icon: 'error',
                confirmButtonText: 'Try Again!',
                confirmButtonColor: "#DD6B55",
            })
        }
    }
}

$(document).ready(function () {
    localStorage.removeItem('UserPhoto');

});
