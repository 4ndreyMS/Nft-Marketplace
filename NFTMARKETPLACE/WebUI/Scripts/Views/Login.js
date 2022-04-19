
function Login() {

    //controller que va a buscar en el api
    const ServiceController = 'User';
    const ServiceControllerUserRole = 'RoleUser';
    const ServicePass = 'Loggin';
    const ctrlActions = new ControlActions();

    this.validateUser = function () {

    }

    this.LoginUser = function () {

        let RoleUser = { UserId: "" };
        let validation = false;
        sessionStorage.removeItem('UserCedula');
        sessionStorage.removeItem('UserCompany');

        //lee la informacion del form con el id = frmLogin
        var userLog = ctrlActions.GetDataForm("frmLogin");
        let validMail = false;
        let userRequest = { Email: userLog.UserEmail, Status: "" };
        let UserPass = { Cedula: "", Password: userLog.UserPass }


        if (userLog.UserEmail === "" || userLog.UserPass === "") {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'FILL ALL THE BLANKS ',

            })
        } else {
            
            //verifica que exista un usuario con ese mismo correo
            ctrlActions.PostToAPI(ServiceController + "/RetriveUserByMail", userRequest, function (response) {
                console.log(response);
                if (response != null) {
                    UserPass.Cedula = response.Cedula;
                    userRequest.Status = response.Status;
                    sessionStorage.setItem("UserCompany", response.IdOrganization);
                    validMail = true;

                } else {
                    validMail = false;

                }
                //verfica que el usuario esté activo y que si exista el correo
                if (validMail && userRequest.Status === "Active") {

                    //consulta la clave con el id del usuario con el correo
                    ctrlActions.PostToAPI(ServicePass + "/RetrieveLoggin", UserPass, function (response) {

                        if (response === 1) {
                            sessionStorage.setItem("UserCedula", UserPass.Cedula);
                            RoleUser.UserId = UserPass.Cedula;
                            validation = true;
                            Swal.fire({
                                title: 'Succesfull Login!',
                                width: 600,
                                padding: '3em',
                                color: '#000',
                                background: '#fff',
                                confirmButtonColor: "#DD6B55"

                            })

                        } else {
                            validation = false;

                            Swal.fire({
                                title: 'Error!',
                                text: 'Incorrect Password',
                                icon: 'error',
                                confirmButtonText: 'Try again!',
                                confirmButtonColor: "#DD6B55"
                            })
                        }

                        if (validation) {
                            //se realiza el post a un api si la validasion es verdera
                            ctrlActions.PostToAPI( ServiceControllerUserRole + "/RetriveUserRoleByUserId", RoleUser, function (response) {

                                if (response === 1) {
                                    window.location.href = "Manager";
                                } else if (response === 2) {

                                    window.location.href = "Profile";


                                } else if (response === 3) {

                                    window.location.href = "Profile";
                                }
                            });
                        }
                    });
                } else {
                    Swal.fire({
                        title: 'Error!',
                        text: 'Incorrect User Id or Password',
                        icon: 'error',
                        confirmButtonText: 'Try again!',
                        confirmButtonColor: "#DD6B55",
                    })
                }

            });


        }
    }

}
