function Login() {

    //controller que va a buscar en el api
    this.ServiceController = 'User';
    this.ServiceControllerUserRole = 'RoleUser';
    this.ServicePass = 'Loggin';
    this.ctrlActions = new ControlActions();

    this.LoginUser = function () {


        var validation = false;
        sessionStorage.removeItem('UserCedula');

        //lee la informacion del form con el id = frmLogin
        var userLog = this.ctrlActions.GetDataForm("frmLogin");

        if (userLog.UserId === "" || userLog.UserPass === "") {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'FILL ALL THE BLANKS ',

            })
        } else {
            //creacion de un objeto personalizado
            var UserPass = { Cedula: userLog.UserId, Password: userLog.UserPass }

            var RoleUser = { UserId: userLog.UserId }

            this.ctrlActions.PostToAPI(this.ServicePass + "/RetrieveLoggin", UserPass, function (response) {
                if (response === 0) {
                    Swal.fire({
                        title: 'Error!',
                        text: 'Do you want to continue',
                        icon: 'error',
                        confirmButtonText: 'Cool',
                        confirmButtonColor: "#DD6B55",
                    })
                } else if (response === 1) {

                    sessionStorage.setItem("UserCedula", UserPass.Cedula);
                    Swal.fire({
                        title: 'Succesfull Login!',
                        width: 600,
                        padding: '3em',
                        color: '#000',
                        background: '#fff',
                        confirmButtonColor: "#DD6B55"

                    })
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
                    Swal.fire({
                        title: 'Error!',
                        text: 'Incorrect User Id or Password, Try again!',
                        icon: 'error',
                        confirmButtonText: 'Cool',
                        confirmButtonColor: "#DD6B55",
                    })
                }
            });




        }
    }

    this.forgotPassword = function () {
        var element = document.getElementById("forgotPass");
        element.style.display = "block";

    }

    this.RecoveryPassword = function () {
        var User = this.ctrlActions.GetDataForm("forgotPass");

        if (User != null && User.Cedula != "") {
            this.ctrlActions.PostToAPI(this.ServiceController + "/retriveUser", User, function (_response) {

                if (_response == null) {
                    alert("Invalid Id")

                } else if (_response.Cedula == User.Cedula && _response.Cedula != null) {
                    alert("Check your email")
                    window.location.href("PasswordRecovery")
                }

            });

        } else {
            alert("Enter an ID")
        }


    }

}