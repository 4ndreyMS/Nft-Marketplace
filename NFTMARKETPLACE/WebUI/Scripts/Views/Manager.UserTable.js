function Manager() {

    this.idUser = "";
    this.UserOldStatus = "";
    this.UserNewStatus = "";
    this.tbluser = 'userList';
    this.service = 'User';
    this.cntrlAction = new ControlActions();

    this.columns = "Identification,Name,Email,Status";

    this.RetrieveAllUsers = function () {
        this.cntrlAction.FillTable(this.service +"/RetriveAll", this.tbluser, false);
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
            alert("Por favor seleccione un usuario antes de cambiar su estado")
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
    var tblLoad = new Manager();
    tblLoad.RetrieveAllUsers();
});


