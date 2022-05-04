paypal.Buttons({
    style: {
        color: 'blue',
        shape: 'pill'
    },
    createOrder: function (data, actions) {
        return actions.order.create({
            purchase_units: [{
                amount: {
                    value: '16.03'
                }
            }]
        });
    },
    onApprove: function (data, actions) {
        return actions.order.capture().then(function (details) {
            console.log(details);
            valor = details.purchase_units[0].amount.value;
            parseFloat(valor);




        });
    },
    onCancel: function (data, actions)
    {
        window.location.replace("https://localhost:44377/Home/BuyCFC")
    }
}).render('#paypal-payment');