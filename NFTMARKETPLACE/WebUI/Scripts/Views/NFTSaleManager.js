const ctrlActions = new ControlActions();
const serviceNFT = "NFT";

function NFTSaleManager() {

    let price;

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

        var NFT = { Id: sessionStorage.getItem('NFTSelected')}
        
        ctrlActions.PostToAPI(serviceNFT + "/RetrieveAllNFTINFO", NFT, function (response) {

            response.forEach((card) => {
                let date = new Date(card.CreationDate).toLocaleDateString('en-us', { year: 'numeric', month: 'long', day: 'numeric' })
                NFTInformation.innerHTML += `
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
                            <img src="${card.Image}" alt="" class=" image-fill">
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="backhome-content mt-4 mt-lg-0">
                            <h2 class="fw-bold">${card.NftName}</h2>
                            <div class="tab-box my-4">
                                <ul class="nav nav-pills" id="pills-tab" role="tablist">
                                    <li class="nav-item" role="presentation">
                                        <button class="nav-link active" id="pills-home-tab" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab" aria-controls="pills-home" aria-selected="true">Details</button>
                                    </li>
                                </ul>
                                <div class="tab-content mt-4 ps-3" id="pills-tabContent">
                                    <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab">
                                       <p class="text-muted"><i class="mdi mdi-information-outline f-24 align-middle"></i> NFT Identification: ${card.Id}</p>
                                           <div>
                                                 <p class="text-muted"><i class="mdi mdi-folder-image f-24 align-middle"></i> Collection name:
                                                    <select id="slctCollection" class="dropDowns">
                                                    <option value="" disabled selected hidden>Choose a collection</option>
                                                </select>
                                                    </p>
                                        <button class="changeCollection" id="changeCollection" onclick="updateCollection()">Change Collection </button>
                                            <div>
<p class="text-muted"><i class="mdi mdi-calendar f-24 align-middle"></i> Creation date: ${date}</p>
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
                                                <img src="${card.CreatorImage}" alt="" class="img-fluid rounded-circle">
                                            </div>
                                        </div>
                                        <div class="flex-grow-1 ms-2">
                                            <p class="mb-0 f-14 fw-semibold">${card.CreatorName}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="my-4">
                            <div class="row ">
                                <div class="col-lg-6">
                                    <h6 class="fw-bold mb-1">Last Price:</h6>
                                    <p class="fw-semibold">${card.Price} CFC</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                    `
                price = card.Price;


                let collection = { "CompanyId": sessionStorage.getItem("UserCompany") }/*   '9066'*/

                    const collService = 'Collection'

                    const slctCollection = document.getElementById("slctCollection");
            

                    

                  ctrlActions.PostToAPI(collService + "/RetrieveAllCollectionByCompany", collection, function (response) {
                        response.forEach((val) => {
                            slctCollection.innerHTML += `<option value="${val.Id}">${val.CollectionName}</option>`;
                        })
                   
                  });



                console.log(document.getElementById("slctCollection").value)

                
            })

        });

       
   

    
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

}

function updateCollection() {
    let value = document.getElementById("slctCollection").value
    let nftSelected = { "Id": sessionStorage.getItem("NFTSelected"), "IdCollection": value } 

    ctrlActions.PostToAPI(serviceNFT + "/UpdateNftCollection", nftSelected, function (response) {

    });

}

$(document).ready(function () {

    var load = new NFTSaleManager();

    if (load.validateLogin()) {
        load.Information();
       
    }

  
});