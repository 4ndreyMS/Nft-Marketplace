function Login() {

    //controller que va a buscar en el api
    this.ServiceController = 'User';
    this.ServiceControllerUserRole = 'RoleUser';
    this.ServicePass = 'Loggin';
    this.ctrlActions = new ControlActions();

    this.LoginUser = function () {


        var validation = false;

        //lee la informacion del form con el id = frmLogin
        var userLog = this.ctrlActions.GetDataForm("frmLogin");

        if (userLog.UserId === "" || userLog.UserPass === "") {
            alert("FILL ALL THE BLANKS");
        } else {
            //creacion de un objeto personalizado
            var UserPass = { Cedula: userLog.UserId, Password: userLog.UserPass }

            var RoleUser = { UserId: userLog.UserId }

            this.ctrlActions.PostToAPI(this.ServicePass + "/RetrieveLoggin", UserPass, function (response) {
                if (response === 0) {
                    alert("Incorrect User Id or Password, Try again!");
                } else if (response === 1) {

                    sessionStorage.setItem("UserCedula", UserPass.Cedula);
                    alert("Login sucessfull");
                    validation = true;
                }

            });

            //se realiza el post a un api
            this.ctrlActions.PostToAPI(this.ServiceControllerUserRole + "/RetriveUserRoleByUserId", RoleUser, function (response) {

                if (validation === true) {


                    if (response === 1) {
                        window.location.href = "Manager"
                    } else if (response === 2) {

                        window.location.href = "Profile"


                    } else if (response === 3) {

                        window.location.href = "Profile"
                    }

                } else {
                    alert("Incorrect User Id or Password, Try again!");
                }
            });


            

        }
    }

}