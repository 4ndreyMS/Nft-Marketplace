const cfcPerDolar = 66.0;
const ctrlActions = new ControlActions();
const walletService = "Wallet";
let frmValue = 0.0
const userCompany = sessionStorage.getItem('UserCompany');

function ConvertDolarToCFC(val) {
    var op = val / cfcPerDolar;
    op = op.toFixed(3);
    return op;
}

function BuyCFC() {
    paypal.Buttons({
        createOrder: function (data, actions) {
            frmValue = parseFloat(document.getElementById("txtBuyCFC").value);
            document.getElementById("frmAmount").reset();
            if (frmValue > 0) {
                return actions.order.create({
                    purchase_units: [{
                        amount: {
                            value: frmValue /*`${val}`*/
                        }
                    }]
                });
            }
            return null;
        },
        onApprove: function (data, actions) {
            return actions.order.capture().then(function (details) {
                console.log(details);
                valor = details.purchase_units[0].amount.value;
                parseFloat(valor);
                BuyCoins();
            });
        }

    }).render('#paypal-payment');


}

function BuyCoins () {

    let ccAmount = ConvertDolarToCFC(frmValue);
    let wallet = {
        CompanyId: userCompany,
        Amount: 0.0,
        Identifier: ""
    }
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

function name(parameters) {
    paypal.Buttons({
        // Set up the transaction
        createOrder: function (data, actions) {
            return actions.order.create({
                purchase_units: [{
                    amount: {
                        value: ConvertDolarToCFC(frmValue.DolarAmount)
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
                BuyCoins();
            });

        }


    }).render('#paypal-payment');
}

$(window).on("load", function () {

    if (!sessionStorage.getItem('UserCedula') || !sessionStorage.getItem('UserCompany')) {
        window.location.href = "Login";
        return false;
    }
    BuyCFC();
    buyCFC.BuyCoins();
    return true;
});

