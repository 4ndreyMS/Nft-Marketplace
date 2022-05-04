function BuyCFC() {

    const ctrlActions = new ControlActions();
    const walletService = "Wallet";
    const frmValue = ctrlActions.GetDataForm("frmAmount");
    const cfcPerDolar = 66.0;
    const userCompany = sessionStorage.getItem('UserCompany');

    this.ConvertDolarToCFC = function (val) {

        var op = val / cfcPerDolar;
        op = op.toFixed(3);
        return op;
    }

    this.BuyCoins = function () {

        let ccAmount = this.ConvertDolarToCFC(frmValue.DolarAmount);
        let wallet = {
            CompanyId: userCompany,
            Amount: 0.0,
            Identifier: ""
        }

        Swal.fire({
            title: 'Are you sure?',
            text: "You want to buy " + ccAmount + " CFC!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes!'
        }).then((result) => {
            if (result.isConfirmed) {

                if (ccAmount > 0) {
                    ctrlActions.PostToAPI(walletService + "/WalletInfoByCompnay", wallet, function (response) {

                        let result = response;
                        wallet.Identifier = response.Identifier;
                        wallet.Amount = ccAmount;


                        if (result != null) {
                            ctrlActions.PostToAPI(walletService + "/addAmount", wallet, function (response) {

                            })
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

    paypal.Buttons({

        // Set up the transaction
        createOrder: function (data, actions) {
            return actions.order.create({
                purchase_units: [{
                    amount: {
                        value: ccAmount
                    }
                }]
            });
        },

        // Finalize the transaction
        onApprove: function (data, actions) {
            return actions.order.capture().then(function (orderData) {
                // Successful capture! For demo purposes:
                console.log(orderData);
                var transaction = orderData.purchase_units[0].amount.value;
                parseFloat(transaction);
                alert('Transaction ' + transaction.status + ': ' + transaction.id + '\n\nSee console for all available details');
                //if (sessionStorage.getItem('UserCedula') == "aquieltipoderole") 
                var transaccionData = { "Amount": valor, "UserCedula": sessionStorage.getItem('UserCedula'), "IdOrganizacion": sessionStorage.getItem('UserCompany') };

                this.ctrlActions.PostToAPI(this.service + "/PostPaypalTransaction", transaccionData, function (data) {
                    Swal.fire({
                        title: 'Success!',
                        text: 'You have bought ' + ccAmount + ' CFC.',
                        width: 600,
                        padding: '3em',
                        color: '#000',
                        background: '#fff',
                        confirmButtonColor: "#DD6B55",
                        icon: 'success'
                    }).then((result) => {
                    });
                });
                // Replace the above to show a success message within this page, e.g.
                // const element = document.getElementById('paypal-button-container');
                // element.innerHTML = '';
                // element.innerHTML = '<h3>Thank you for your payment!</h3>';
                // Or go to another URL:  actions.redirect('thank_you.html');
            });

        }


    }).render('#paypal-button-container');


}


$(window).on("load", function () {

    if (!sessionStorage.getItem('UserCedula') || !sessionStorage.getItem('UserCompany')) {
        window.location.href = "Login";
        return false;
    }
    var buyCFC = new BuyCFC();
    buyCFC.BuyCoins();
    return true;
});