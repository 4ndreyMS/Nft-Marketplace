function ManagerUserTable() {

    this.idUser = "";
    this.UserOldStatus = "";
    this.UserNewStatus = "";
    this.tbluser = 'userList';
    this.service = 'User';
    this.cntrlAction = new ControlActions();

    this.columns = "Identificacion,Nombre,Correo,Estado";

    this.RetrieveAllUsers = function () {
        this.cntrlAction.FillTable(this.service + "/RetriveAll", this.tbluser, false);
    }

    this.Prueba = function (User) {
        idUser = User.Cedula;
        UserOldStatus = User.Status;
    }

    this.StatusUser = function () {
    
        if (UserOldStatus == "Active") {
            UserNewStatus = "Inactive"
        } else {
            UserNewStatus = "Active"
        }

        if (idUser == "" && UserOldStatus == "") {
            Swal.fire({
                title: 'Error!',
                text: 'Please select an user before changing their state',
                icon: 'error',
                confirmButtonText: 'Cool',
                confirmButtonColor: "#DD6B55",
            })
        } else {
            var UserInfo = {
                Cedula: idUser,
                Status: UserNewStatus
            };

            this.cntrlAction.PostToAPI(this.service + "/UpdateUserStatus", UserInfo, function (response) {});
        }

        idUser = "";
        UserNewStatus = "";
        UserOldStatus = "";

        window.location.reload();
    }
}

$(document).ready(function () {
    var tblLoad = new ManagerUserTable();
    tblLoad.RetrieveAllUsers();
});


