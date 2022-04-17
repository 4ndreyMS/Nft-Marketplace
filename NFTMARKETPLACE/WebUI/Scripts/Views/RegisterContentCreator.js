function RegisterContentCreator() {

    this.ctrlActions = new ControlActions();
    this.upperCaseLetters = /[A-Z]/g;
    this.numbers = /[0-9]/g;
    this.lowerCaseLetters = /[a-z]/g;
    this.specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    this.service = 'User';
    this.serviceCompany = 'Company';

    //todo: validar que el valor que me devuelva no sea 0
    this.CreateContentUser = function() {

        var frmUserContent = this.ctrlActions.GetDataForm("frmUserContent");

        var company = {
            name: frmUserContent.companyName,
            email: frmUserContent.companyEmail
        }

        var UserContent = {
            Name: frmUserContent.name,
            Cedula: frmUserContent.cedula,
            Password: frmUserContent.password,
            SureName: frmUserContent.sureName,
            NickName: frmUserContent.nickname,
            Phone: frmUserContent.phone,
            Email: frmUserContent.email,
            Company: company
        }

        console.log(UserContent);

        if (UserContent.Name === "" || UserContent.Cedula === "" || UserContent.Password === "" ||
            UserContent.SureName === "" || UserContent.NickName === "" || UserContent.Phone === "" || UserContent.Email === "" || company.name === "" ||
            company.email === "") {

            alert("FILL ALL THE BLANKS");
        } else {

            if (UserContent.Password.length > 12 && UserContent.Password.match(this.upperCaseLetters) &&
                UserContent.Password.match(this.numbers) && UserContent.Password.match(this.lowerCaseLetters)
                && UserContent.Password.match(this.specialChars)) {

                this.ctrlActions.PostToAPI(this.service + "/CreateUserContentCreator", UserContent, function (response) {
                    console.log(response);
                    var responseUserOrgId = response.IdOrganization;
                    var responseUserOtp = response.Otp;

                    localStorage.setItem("OtpContent", responseUserOtp);
                    localStorage.setItem("CompanyLogContent", responseUserOrgId);

                    var element = document.getElementById("OtpValContent");
                    element.style.display = "block";
                });
                
            } else {
                alert("Password is incorrect!\n\n" +
                    "It must contains :\n" +
                    "- Upper Cases\n" +
                    "- Lower Cases\n" +
                    "- More than 12 characters\n" +
                    "- Special Characters");
            }
        }

    }

    this.ValidateOptContent = function (){
        var frmUser = this.ctrlActions.GetDataForm("frmUserContent");
        var localOtp = localStorage.getItem("OtpContent");
        var localCed = localStorage.getItem("CompanyLogContent");
        var Company = {
            id: localCed,
            status: "Valid"
        }

        if (frmUser.otpContent === localOtp) {
            this.ctrlActions.PostToAPI(this.serviceCompany + "/UpdateCompanyStatus", Company, function (response) { });
            alert("Successful Register!");
            window.location.href = "Login"
        } else {
            alert("Incorrect code!");
        }

    }

}