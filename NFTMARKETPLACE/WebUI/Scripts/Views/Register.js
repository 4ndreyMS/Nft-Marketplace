function Register() {


    this.upperCaseLetters = /[A-Z]/g;
    this.numbers = /[0-9]/g;
    this.lowerCaseLetters = /[a-z]/g;
    this.specialChars = /[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    this.service = 'User';
    this.serviceCompany = 'Company';
    this.ctrlActions = new ControlActions();


    this.CreateContentUser = function () {

        var frmUser = this.ctrlActions.GetDataForm("frmUserCustomer");
        

        var UserCust = {
            Name: frmUser.name,
            Cedula: frmUser.cedula,
            Password: frmUser.password,
            SureName: frmUser.sureName,
            NickName: frmUser.nickname,
            Phone: frmUser.phone,
            Email: frmUser.email
        }
        console.log(UserCust);

        if (UserCust.Name === "" || UserCust.Cedula === "" || UserCust.Password === "" ||
            UserCust.SureName === "" || UserCust.NickName === "" || UserCust.Phone === "" || UserCust.Email === "") {

            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'FILL ALL THE BLANKS ',

            })
        } else
        {
            if (UserCust.Password.length > 12 && UserCust.Password.match(this.upperCaseLetters) &&
                UserCust.Password.match(this.numbers) && UserCust.Password.match(this.lowerCaseLetters)
                && UserCust.Password.match(this.specialChars)) {

                this.ctrlActions.PostToAPI(this.service + "/CreateUserCustomer", UserCust, function (response) {
                    console.log(response);
                    var responseUserOrgId = response.IdOrganization;
                    var responseUserOtp = response.Otp;

                    

                    localStorage.setItem("Otp", responseUserOtp);
                    localStorage.setItem("CompanyLog", responseUserOrgId);
                    
                    var element = document.getElementById("OtpVal");
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


    this.ValidateOpt = function() {
        var frmUser = this.ctrlActions.GetDataForm("frmUserCustomer");
        var localOtp = localStorage.getItem("Otp");
        var localCed = localStorage.getItem("CompanyLog");
        var Company = {
            id: localCed,
            status: "Valid"
        }

        if (frmUser.Otp === localOtp) {

            this.ctrlActions.PostToAPI(this.serviceCompany + "/UpdateCompanyStatus", Company, function (response) { });
            Swal.fire({
                title:'Succesfull register!',
                icon: 'success',
                confirmButtonText: 'Cool',
                confirmButtonColor: "#DD6B55",
            })
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
