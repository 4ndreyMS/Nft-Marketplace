function BuyCFC () {

    const ctrlActions = new ControlActions();
    const walletService = "Wallet";
    const frmValue = ctrlActions.GetDataForm("frmAmount");
    const frmId = document.getElementById("frmAmount");
    const cfcPerDolar = 66.0;

    this.ConvertDolarToCFC = function(val) {

        var op = val / cfcPerDolar;
        op = op.toFixed(3);
        return op;
    }

    this.BuyCoins = function () {

        let ccAmount = this.ConvertDolarToCFC(frmValue.DolarAmount);
        let wallet = {
            CompanyId: sessionStorage.getItem('UserCompany'),
            Amount: 0.0,
            Identifier: ""
        }
        
        Swal.fire({
            title: 'Are you sure?',
            text: "You want to buy " + ccAmount +" CFC!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes!'
        }).then((result) => {
            if (result.isConfirmed) {

                if (ccAmount>0) {
                    ctrlActions.PostToAPI(walletService + "/WalletInfoByCompnay", wallet, function (response) {

                        let result = response;
                        wallet.Identifier = response.Identifier;
                        wallet.Amount = ccAmount;


                        if (result != null) {
                            ctrlActions.PostToAPI(walletService + "/addAmount", wallet, function (response) { })
                            frmId.reset();
                        }

                    })

                    Swal.fire({
                        title: 'Success!',
                        text: 'You have bought ' + ccAmount + ' CFC.',
                        width: 600,
                        padding: '3em',
                        color: '#000',
                        background: '#fff',
                        confirmButtonColor: "#DD6B55",
                        icon: 'success'
                    })
                    

                } else {

                    Swal.fire({
                        title: 'Error!',
                        text: 'Enter a valid amount',
                        width: 600,
                        padding: '3em',
                        color: '#000',
                        background: '#fff',
                        confirmButtonColor: "#DD6B55",
                        icon: 'error'
                    })
                }
            }
        })

    }
}

$(window).on("load", function () {

    if (!sessionStorage.getItem('UserCedula') || !sessionStorage.getItem('UserCompany')) {
        window.location.href = "Login";
        return false;
    }
    return true;
});