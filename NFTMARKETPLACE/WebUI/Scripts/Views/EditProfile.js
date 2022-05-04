const ctrlActions = new ControlActions();
const serviceUser = "User";

function EditProfile() {

    this.UpdProfile = function () {
        let retForm = ctrlActions.GetDataForm("frmUpdInfo");

        let User = {
            Name: retForm.name || "hola",
            SureName: retForm.sureName,
            Phone: retForm.phone,
            Nickname: retForm.nickname
        }

        console.log(User);

    }

}