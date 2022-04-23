
function RecoveryPassword() {
    const ServiceController = 'Password';
    const ctrlActions = new ControlActions();

    this.UpdatePassword = function () {
        var Password = ctrlActions.GetDataForm("frmRecoveryPassword")
        console.log(Password)
        var idUser = JSON.parse(localStorage.getItem("IdUser"));
        console.log(idUser)
        var UserPassword = { Cedula: idUser, Password: Password.NewPassword };
        console.log(UserPassword)

        if (idUser != null || UserPassword.Cedula != "") {
            ctrlActions.PostToAPI(ServiceController + "/RetrieveAllPasswordById", UserPassword, function (response) {

                if (response == 1) {
                    alert("success")
                    ctrlActions.PostToAPI(ServiceController + "/CreatePassword", UserPassword, function (response) { });


                } else if (response == 0) {


                    alert("enter a password you haven't used ")
                }

            });

        } else {
            alert("Enter an email")
        }


    }

}