function RegisterContentCreator() {

    const ctrlActions = new ControlActions();
    const upperCaseLetters = /[A-Z]/g;
    const numbers = /[0-9]/g;
    const lowerCaseLetters = /[a-z]/g;
    const specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    const service = 'User';
    const serviceCompany = 'Company';

    //todo: validar que el valor que me devuelva no sea 0
    this.CreateContentUser = function () {

        let frmUserContent = ctrlActions.GetDataForm("frmUserContent");

        let company = {
            name: frmUserContent.companyName,
            email: frmUserContent.companyEmail
        }



        let fName = document.getElementById('txtNameContent');
        let fCedula = document.getElementById('txtCedulaContent');
        let fSureNames = document.getElementById('txtInputContent');
        let fNickname = document.getElementById('txtNicknameContent');
        let fPhone = document.getElementById('txtPhoneContent');
        let fEmail = document.getElementById('txtEmailContent');
        let fPassword = document.getElementById('txtPasswordContent');
        let fCompnayName = document.getElementById('txtCompanyName');
        let fCNameEmail = document.getElementById('txtEmailCompany');
        let btnImage = localStorage.getItem('UserPhoto');

        let UserContent = {
            Name: frmUserContent.name,
            Cedula: frmUserContent.cedula,
            Password: frmUserContent.password,
            SureName: frmUserContent.sureName,
            NickName: frmUserContent.nickname,
            Phone: frmUserContent.phone,
            Email: frmUserContent.email,
            Company: company,
            UserPic: btnImage
        }

        if (UserContent.Name === "") {
            fName.classList.add('fillAllBlanks');
        } else {
            fName.classList.remove('fillAllBlanks');
        }

        if (UserContent.Cedula === "") {
            fCedula.classList.add('fillAllBlanks');
        } else {
            fCedula.classList.remove('fillAllBlanks');
        }

        if (UserContent.Password === "") {
            fPassword.classList.add('fillAllBlanks');
        } else {
            fPassword.classList.remove('fillAllBlanks');
        }

        if (UserContent.SureName === "") {
            fSureNames.classList.add('fillAllBlanks');
        } else {
            fSureNames.classList.remove('fillAllBlanks');
        }

        if (UserContent.NickName === "") {
            fNickname.classList.add('fillAllBlanks');
        } else {
            fNickname.classList.remove('fillAllBlanks');
        }

        if (UserContent.Phone === "") {
            fPhone.classList.add('fillAllBlanks');
        } else {
            fPhone.classList.remove('fillAllBlanks');
        }

        if (UserContent.Email === "") {
            fEmail.classList.add('fillAllBlanks');
        } else {
            fEmail.classList.remove('fillAllBlanks');
        }

        if (company.name === "") {
            fCompnayName.classList.add('fillAllBlanks');
        } else {
            fCompnayName.classList.remove('fillAllBlanks');
        }

        if (company.email === "") {
            fCNameEmail.classList.add('fillAllBlanks');
        } else {
            fCNameEmail.classList.remove('fillAllBlanks');
        }




        if (UserContent.Name === "" || UserContent.Cedula === "" || UserContent.Password === "" ||
            UserContent.SureName === "" || UserContent.NickName === "" || UserContent.Phone === "" || UserContent.Email === "" || company.name === "" ||
            company.email === "" || btnImage === null) {

            Swal.fire({
                title: 'Error!',
                text: 'Fill All the blanks, and remember to upload you profile photo.',
                icon: 'error',
                confirmButtonText: 'Try Again!',
                confirmButtonColor: "#DD6B55",
            })

        } else {

            ctrlActions.PostToAPI(service + "/ExistUserByMail", UserContent, function (response) {
                if (!response) {
                    if (UserContent.Password.length > 12 && UserContent.Password.match(upperCaseLetters) &&
                        UserContent.Password.match(numbers) && UserContent.Password.match(lowerCaseLetters)
                        && UserContent.Password.match(specialChars)) {

                        ctrlActions.PostToAPI(service + "/CreateUserContentCreator", UserContent, function (response) {
                            console.log(response);
                            var responseUserOrgId = response.IdOrganization;
                            var responseUserOtp = response.Otp;

                            localStorage.setItem("OtpContent", responseUserOtp);
                            localStorage.setItem("CompanyLogContent", responseUserOrgId);

                            var element = document.getElementById("OtpValContent");
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
            })



        }

    }

    this.ValidateOptContent = function () {
        var frmUser = ctrlActions.GetDataForm("frmUserContent");
        var userRegisterForm = document.getElementById("frmUserContent");
        var localOtp = localStorage.getItem("OtpContent");
        var localCed = localStorage.getItem("CompanyLogContent");
        var Company = {
            id: localCed,
            status: "Valid"
        }

        if (frmUser.otpContent === localOtp) {
            ctrlActions.PostToAPI(serviceCompany + "/UpdateCompanyStatus", Company, function (response) { });
            Swal.fire({
                title: 'Succesfull Register!',
                width: 600,
                padding: '3em',
                color: '#000',
                background: '#fff',
                confirmButtonColor: "#DD6B55"

            })
            userRegisterForm.reset();
            window.location.href = "Login"
        } else {
            Swal.fire({
                title: 'Error!',
                text: 'Incorrect code!',
                icon: 'error',
                confirmButtonText: 'Cool',
                confirmButtonColor: "#DD6B55",
            })
        }

    }

}