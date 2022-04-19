function ManagerPriceTable() {

    this.tblPrice = 'priceList';
    this.service = 'Prices';
    this.PType = "";
    this.ctrlActions = new ControlActions();

    this.columns = "ID,Price,Type";

    this.RetrieveAllPrices = function () {
        this.ctrlActions.FillTable(this.service + "/ShowPrices", this.tblPrice, false);
    }

    this.Prueba = function (Price) {
        PType = Price.Type;
        console.log(PType);
    }

    this.UpdatePrice = function () {

        var priceInfo = this.ctrlActions.GetDataForm("priceForm");
        var Price = { Amount: priceInfo.Amount, Type: PType }

        if (PType == "" && priceInfo.Amount == "") {

           
            Swal.fire({
                title: 'Error!',
                text: 'Please select and item in the table',
                icon: 'error',
                confirmButtonText: 'Cool',
                confirmButtonColor: "#DD6B55",
            })

        } else {

            this.ctrlActions.PostToAPI(this.service + "/UpadatePrices", Price, function (response) { });

            PType = "";

            window.location.reload();
        }
    }
}

$(document).ready(function () {
    var tblLoad = new ManagerPriceTable();
    tblLoad.RetrieveAllPrices();
});