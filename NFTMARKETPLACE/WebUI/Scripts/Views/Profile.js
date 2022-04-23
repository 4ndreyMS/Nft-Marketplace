function Profile() {

    this.validateLogin = function() {


        if (sessionStorage.getItem('UserCedula') === null || sessionStorage.getItem('UserCedula') === undefined ) {
            window.location.href = "Login";
            return false;
        }
        return true;
    }

    //var solo dentro del scope

    //let block scope parecido al var

    //const global pero se puede reasignar el valor


    const ctrlActions = new ControlActions();
    const service = "User";
    const walletService = "Wallet";


    let User = new Object();
    let WalletRet = new Object();


    /*let UserLog = { Cedula: sessionStorage.getItem('UserCedula') */


    this.LoadInfo = function () {

        let UserLog = { Cedula: sessionStorage.getItem('UserCedula') }


        ctrlActions.PostToAPI(service + "/RetrieveUser", UserLog, function (response) {
            
            User = response;

            document.getElementById('userName').innerHTML = User.Name + " " + User.SureName;
            document.getElementById('userCedula').innerHTML = User.Cedula;
            document.getElementById('profilePic').innerHTML = `<img src="${User.UserPic}" alt="" class="img-fluid avatar-xl border border-4 border-white rounded-circle">`;

            document.getElementById('facebookName').innerHTML = "Facebook / "+User.Name;
            document.getElementById('messengerName').innerHTML = "Email / " + User.Email;
            document.getElementById('phoneNumber').innerHTML = "Phone / " + User.Phone;
            document.getElementById('ytName').innerHTML = "YouTube / " + User.Email;

            let Wallet = { UserId: sessionStorage.getItem('UserCedula') }

            ctrlActions.PostToAPI(walletService + "/RetriveWalletByUserId", Wallet, function (response) {

                WalletRet = response;

                document.getElementById('walletId').innerHTML = WalletRet.Identifier;
                document.getElementById('walletAmount').innerHTML = WalletRet.Amount+' CFC';

            });
        });




    }


}



$(document).ready(function () {

    var load = new Profile();

    if (load.validateLogin()) {
        load.LoadInfo();
    }

});
