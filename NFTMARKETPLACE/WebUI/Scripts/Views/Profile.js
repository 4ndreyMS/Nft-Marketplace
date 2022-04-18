function Profile() {

    //var solo dentro del scope

    //let block scope parecido al var

    //const global pero se puede reasignar el valor


    this.ctrlActions = new ControlActions();
    const service = "User";
    const walletService = "Wallet";


    let User = new Object();
    let WalletRet = new Object();


    let UserLog = { Cedula: sessionStorage.getItem('UserCedula') }



    if (localStorage.getItem('UserCedula') != null) {
        load.LoadInfo();
    }

    this.LoadInfo = function () {
        
        this.ctrlActions.PostToAPI(service + "/RetrieveUser", UserLog, function (response) {
            
            User = response;

            document.getElementById('userName').innerHTML = User.Name + " " + User.SureName;
            document.getElementById('userCedula').innerHTML = User.Cedula;


            document.getElementById('facebookName').innerHTML = "Facebook / "+User.Name;
            document.getElementById('messengerName').innerHTML = "Email / " + User.Email;
            document.getElementById('phoneNumber').innerHTML = "Phone / " + User.Phone;
            document.getElementById('ytName').innerHTML = "YouTube / " + User.Email;


        });

        let Wallet = { UserId: sessionStorage.getItem('UserCedula') }

        this.ctrlActions.PostToAPI(walletService + "/RetriveWalletByUserId", Wallet, function (response) {

            WalletRet = response;

            document.getElementById('walletId').innerHTML = WalletRet.Identifier;
            document.getElementById('walletAmount').innerHTML = WalletRet.Amount;

        });


    }


    this.logOut = function () {
        sessionStorage.clear();
        window.location.href = "Index"
    }

}

window.onload = function () {
    var load = new Profile();

    if (localStorage.getItem('UserCedula') !== null) {
        load.LoadInfo();
    }
}


$(document).ready(function () {

    var load = new Profile();

    if (localStorage.getItem('UserCedula') !== null) {
        load.LoadInfo();
    }

});
