function NFTAuction() {

    const serviceNFT = "NFT";
    const ctrlActions = new ControlActions();
    let price;
    const serviceAuction = "Auction"

    this.validateLogin = function () {
        if (sessionStorage.getItem('UserCedula') === null || sessionStorage.getItem('UserCedula') === undefined) {
            window.location.href = "Login";
        } else {
            if (sessionStorage.getItem('UserRole') != 3) {
                window.location.href = "profile";
            }
            return true;
        }
        return true;
    }

    this.Information = function () {
        let AUCTION = {
            Nft: {
                Id: sessionStorage.getItem('NFTSelected')
            }
        }
      
        ctrlActions.PostToAPI(serviceAuction + "/RetrieveAllByNft", AUCTION, function (response) {
           
        
                NFTAuctionInformation.innerHTML += `
                         <div class="row align-items-center justify-content-center">
                    <div class="col-lg-8">
                        <div class="inner-heading text-center">
                            <div class="mt-4">
                                <h1 class="fw-bold">NFT Information</h1>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row mt-5 align-items-center">
                    <div class="col-lg-6">
                        <div class="back-home-image pe-4">
                            <img src="${response.Nft.Image}" alt="" class=" image-fill">
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="backhome-content mt-4 mt-lg-0">
                            <h2 class="fw-bold">${response.Nft.NftName}</h2>
                            <div class="tab-box my-4">
                                <ul class="nav nav-pills" id="pills-tab" role="tablist">
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link active" id="pills-home-tab" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home" aria-selected="true">Details</button>
                                    </li>
                                </ul>
                                <div class="tab-content mt-4 ps-3" id="pills-tabContent">
                                    <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                                       <p class="text-muted"><i class="mdi mdi-information-outline f-24 align-middle"></i> NFT Identification: ${response.Id}</p>
                                       <p class="text-muted"><i class="mdi mdi-folder-image f-24 align-middle"></i> Collection name: ${response.Nft.CollectionName}</p>
                                       <p class="text-muted"><i class="mdi mdi-calendar f-24 align-middle"></i> Creation date: ${response.Nft.CreationDate}</p>
<p  class="text-muted"><i class="mdi mdi-av-timer f-24 align-middle"></i> This auction ends in:</p>

<p style="font-size: 35px; margin-left: 25px;" class="text-muted" id="timer"></p>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-6">
                                    <div class="d-flex align-items-center">
                                        <div class="flex-grow-1 ms-2">
                                            <p class="mb-0 f-14 fw-semibold">Creator:</p>
                                        </div>
                                        <div class="flex-shrink-0">
                                            <div class="avatar-xs border rounded-circle border-3 border-white">
                                                <img src="${response.Nft.CreatorImage}" alt="" class="img-fluid rounded-circle">
                                            </div>
                                        </div>
                                        <div class="flex-grow-1 ms-2">
                                            <p class="mb-0 f-14 fw-semibold">${response.Nft.CreatorName}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="my-4">
                            <div class="row ">
                                <div class="col-lg-6">
                                    <h6 class="fw-bold mb-1">Last Price:</h6>
                                    <p class="fw-semibold">${response.Nft.Price} CFC</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                    `
            price = response.Price;

            const timer = new Date(response.EndDate).getTime()
            const timerElement = document.getElementById("timer")
            const updateSec = setInterval(function () {
                let now = new Date().getTime();
                let timeleft = timer - now;
                let days = Math.floor(timeleft / (1000 * 60 * 60 * 24));
                let hours = Math.floor((timeleft % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
                let minutes = Math.floor((timeleft % (1000 * 60 * 60)) / (1000 * 60));
                let seconds = Math.floor((timeleft % (1000 * 60)) / 1000);
               

                timerElement.innerHTML = `${days} d ${hours} h ${minutes} min ${seconds} secs`

                if (timeleft < 0) {

                    clearInterval(updateSec)
                    timerElement.innerHTML = "This auction is over :( "
                }

            }, 1000)


           
            })

    }

    this.PutOnSale = function () {
        var ctrlActions = new ControlActions();
        var saleInfo = ctrlActions.GetDataForm("saleForm");
        var NFT = { Id: sessionStorage.getItem('NFTSelected'), Price: saleInfo.Amount, SaleState: "OnSale" }

        if (saleInfo.Amount == "") {

            Swal.fire({
                title: 'Error!',
                text: 'Please insert a price',
                icon: 'error',
                confirmButtonText: 'Cool',
                confirmButtonColor: "#DD6B55",
            })

        } else {
            var ctrlActions = new ControlActions();
            ctrlActions.PostToAPI("NFT" + "/PutOnSale", NFT, function (response) { });
            window.location.href = "profile";
        }
    }

    this.PutInOffer = function () {
        var ctrlActions = new ControlActions();
        var NFT = { Id: sessionStorage.getItem('NFTSelected'), price, SaleState: "InOffer" }
        ctrlActions.PostToAPI("NFT" + "/PutOnSale", NFT, function (response) { });
        window.location.href = "profile";
    }

    this.PutOnAuction = function () {
        var ctrlActions = new ControlActions();
        var AuctionInfo = ctrlActions.GetDataForm("auctionForm");
        var NFTId = { Id: sessionStorage.getItem('NFTSelected') }
        var Auction = { IdOwner: sessionStorage.getItem('UserCompany'), IdBuyer: sessionStorage.getItem('UserCompany'), Amount: AuctionInfo.Amount, Nft: NFTId, EndDate: AuctionInfo.Date };

        if (AuctionInfo.Amount == "") {

            Swal.fire({
                title: 'Error!',
                text: 'Please insert an initial price',
                icon: 'error',
                confirmButtonText: 'Cool',
                confirmButtonColor: "#DD6B55",
            })

        } else if (AuctionInfo.Date == "") {

            Swal.fire({
                title: 'Error!',
                text: 'Please insert a deadline',
                icon: 'error',
                confirmButtonText: 'Cool',
                confirmButtonColor: "#DD6B55",
            })

        } else {
            var ctrlActions = new ControlActions();
            ctrlActions.PostToAPI("Auction" + "/CreateAuction", Auction, function (response) { });
            var NFT = { Id: sessionStorage.getItem('NFTSelected'), price, SaleState: "OnAuction" }
            ctrlActions.PostToAPI("NFT" + "/PutOnSale", NFT, function (response) { });
            window.location.href = "profile";
        }
    }
}

$(document).ready(function () {

    var load = new NFTAuction();

    if (load.validateLogin()) {
        load.Information();
    }
});