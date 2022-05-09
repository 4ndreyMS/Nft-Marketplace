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
    const serviceNFT = "NFT";
    const walletService = "Wallet";
    const nftSection = document.getElementById("NFTInProperty")

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
        
            document.getElementById('messengerName').innerHTML = "Email / " + User.Email;
            document.getElementById('phoneNumber').innerHTML = "Phone / " + User.Phone;

            let Wallet = { UserId: sessionStorage.getItem('UserCedula') }

            ctrlActions.PostToAPI(walletService + "/RetriveWalletByUserId", Wallet, function (response) {

                WalletRet = response;

                document.getElementById('walletId').innerHTML = WalletRet.Identifier;
                document.getElementById('walletAmount').innerHTML = WalletRet.Amount+' CFC';

            });
        });
    }


    this.LoadNFTs = function () {

        let CompanyID = { IdOwner: sessionStorage.getItem('UserCompany'), SaleState: "InPropiety" }

        ctrlActions.PostToAPI(serviceNFT + "/RetrieveAllNFTInProperty", CompanyID, function (response) {

            response.forEach((card) => {

                var date = new Date(card.CreationDate).toLocaleDateString('en-us', { year: 'numeric', month: 'long', day: 'numeric' })

                nftSection.innerHTML += `
                        <div class="col-lg-4 mt-4">
                                    <div class="tab-box p-4 border-0">                                    
                                        <div class="card-image mt-2 position-relative">
                                            <a href="NFTSaleManager" onclick="SaveNFT('${card.Id}')"><img src="${card.Image}" alt="" class="img-fluid"></a>
                                        </div>
                                        <div class="body-content mt-3">
                                            <h6 class="fw-bold">${card.NftName}</h6>
                                            <div class="d-flex align-items-center justify-content-start mt-3">
                                                <div class=" slider-content-image d-flex ">
                                                    <p class="text-success mb-0 fw-semibold">Creator: ${card.IdCreator}</p>
                                                </div>
                                                <div class="ms-auto">
                                                    <p class="text-success mb-0 fw-semibold">Price: ${card.Price} CFC</p>
                                                </div>
                                            </div>
                                            <hr class="my-3">
                                            <div class="blog-slider-footer">
                                                <h6 class="f-14"><i class="mdi mdi-calendar f-18 text-primary me-2 align-middle"></i><span class="text-muted ms-2">${date}</span></h6>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    `

            })

        });
    }

    this.LoadNFTOnSale = function () {

        let CompanyID = { IdOwner: sessionStorage.getItem('UserCompany'), SaleState: "OnSale" }

        ctrlActions.PostToAPI(serviceNFT + "/RetrieveAllNFTInProperty", CompanyID, function (response) {

            response.forEach((card) => {

                var date = new Date(card.CreationDate).toLocaleDateString('en-us', { year: 'numeric', month: 'long', day: 'numeric' })

                NFTOnSale.innerHTML += `
                        <div class="col-lg-4 mt-4">
                                    <div class="tab-box p-4 border-0">                                    
                                        <div class="card-image mt-2 position-relative">
                                            <img src="${card.Image}" alt="" class="img-fluid">
                                        </div>
                                        <div class="body-content mt-3">
                                            <h6 class="fw-bold">${card.NftName}</h6>
                                            <div class="d-flex align-items-center justify-content-start mt-3">
                                                <div class=" slider-content-image d-flex ">
                                                    <p class="text-success mb-0 fw-semibold">Creator: ${card.IdCreator}</p>
                                                </div>
                                                <div class="ms-auto">
                                                    <p class="text-success mb-0 fw-semibold">Price: ${card.Price} CFC</p>
                                                </div>
                                            </div>
                                            <hr class="my-3">
                                            <div class="blog-slider-footer">
                                                <h6 class="f-14"><i class="mdi mdi-calendar f-18 text-primary me-2 align-middle"></i><span class="text-muted ms-2">${date}</span></h6>
                                            </div>
                                            <div class="blog-slider-footer">
                                                <button class="btn btn-primary" type="button" onclick="CancelSale('${card.Id}', ${card.Price})">Cancel</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                `

            })

        });
    }

    this.LoadNFTInOffer = function () {

        let CompanyID = { IdOwner: sessionStorage.getItem('UserCompany'), SaleState: "InOffer" }

        ctrlActions.PostToAPI(serviceNFT + "/RetrieveAllNFTInProperty", CompanyID, function (response) {        

            response.forEach((card) => {

                var date = new Date(card.CreationDate).toLocaleDateString('en-us', { year: 'numeric', month: 'long', day: 'numeric' })

                NFTOnSale.innerHTML += `
                        <div class="col-lg-4 mt-4">
                                    <div class="tab-box p-4 border-0">                                    
                                        <div class="card-image mt-2 position-relative">
                                            <img src="${card.Image}" alt="" class="img-fluid">
                                        </div>
                                        <div class="body-content mt-3">
                                            <h6 class="fw-bold">${card.NftName}</h6>
                                            <div class="d-flex align-items-center justify-content-start mt-3">
                                                <div class=" slider-content-image d-flex ">
                                                    <p class="text-success mb-0 fw-semibold">Creator: ${card.IdCreator}</p>
                                                </div>
                                                <div class="ms-auto">
                                                    <p class="text-success mb-0 fw-semibold">Price: ${card.Price} CFC</p>
                                                </div>
                                            </div>
                                            <hr class="my-3">
                                            <div class="blog-slider-footer">
                                                <h6 class="f-14"><i class="mdi mdi-calendar f-18 text-primary me-2 align-middle"></i><span class="text-muted ms-2">${date}</span></h6>
                                            </div>
                                            <div class="blog-slider-footer">
                                                <button class="btn btn-primary" type="button" onclick="CancelOffer('${card.Id}', ${card.Price})">Cancel</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    `

            })

        });


    }

    this.LoadNFTOnAuction = function () {

        let CompanyID = { IdOwner: sessionStorage.getItem('UserCompany'), SaleState: "OnAuction" }

        ctrlActions.PostToAPI(serviceNFT + "/RetrieveAllNFTInProperty", CompanyID, function (response) {

            response.forEach((card) => {

                var date = new Date(card.CreationDate).toLocaleDateString('en-us', { year: 'numeric', month: 'long', day: 'numeric' })

                NFTOnSale.innerHTML += `
                        <div class="col-lg-4 mt-4">
                                    <div class="tab-box p-4 border-0">                                    
                                        <div class="card-image mt-2 position-relative">
                                            <img src="${card.Image}" alt="" class="img-fluid">
                                        </div>
                                        <div class="body-content mt-3">
                                            <h6 class="fw-bold">${card.NftName}</h6>
                                            <div class="d-flex align-items-center justify-content-start mt-3">
                                                <div class=" slider-content-image d-flex ">
                                                    <p class="text-success mb-0 fw-semibold">Creator: ${card.IdCreator}</p>
                                                </div>
                                                <div class="ms-auto">
                                                    <p class="text-success mb-0 fw-semibold">Price: ${card.Price} CFC</p>
                                                </div>
                                            </div>
                                            <hr class="my-3">
                                            <div class="blog-slider-footer">
                                                <h6 class="f-14"><i class="mdi mdi-calendar f-18 text-primary me-2 align-middle"></i><span class="text-muted ms-2">${date}</span></h6>
                                            </div>
                                            <div class="blog-slider-footer">
                                                <button class="btn btn-primary" type="button" onclick="CancelAuction('${card.Id}', ${card.Price})">Cancel</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                    `

            })

        });


    }

    this.LoadEveryNFTOnSale = function () {
        this.LoadNFTOnSale();
        this.LoadNFTInOffer();
        this.LoadNFTOnAuction();
    }
}


var CancelSale = function (IdNFT, NFTPrice) {
    var NFT = { Id: IdNFT, Price: NFTPrice, SaleState: "InPropiety" }
    var ctrlActions = new ControlActions();
    ctrlActions.PostToAPI("NFT" + "/PutOnSale", NFT, function (response) { });
    window.location.href = "profile";
}

var CancelAuction = function (IdNFT, NFTPrice) {
    var NFTId = { Id: IdNFT}
    var Auction = {Nft: NFTId};
    var NFT = { Id: IdNFT, Price: NFTPrice, SaleState: "InPropiety" }
    var ctrlActions = new ControlActions();
    ctrlActions.DeleteToAPI("Auction" + "/DeleteAuction", Auction, function (response) { })
    ctrlActions.PostToAPI("NFT" + "/PutOnSale", NFT, function (response) { });
    window.location.href = "profile";
}

var CancelOffer = function (IdNFT, NFTPrice) {
    var NFT = { Id: IdNFT, Price: NFTPrice, SaleState: "InPropiety" }
    var Offer = {NFT: IdNFT}
    var ctrlActions = new ControlActions();
    ctrlActions.PostToAPI("NFT" + "/PutOnSale", NFT, function (response) { });
    ctrlActions.DeleteToAPI("Offer" + "/DeleteALLOffers", Offer, function (response) { });
    window.location.href = "profile";
}

var SaveNFT = function (NFT) {
    sessionStorage.setItem("NFTSelected", NFT)
}

$(document).ready(function () {

    var load = new Profile();

    if (load.validateLogin()) {
        load.LoadInfo();
        load.LoadNFTs();
        load.LoadEveryNFTOnSale();
    }
});
