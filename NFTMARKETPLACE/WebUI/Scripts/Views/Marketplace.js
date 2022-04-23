function ManagerNFTCard() {


 
    const card = "nav-card"

    const nftSection = document.getElementById("row-cards")
    this.service = 'NFT';
    const cntrlAction = new ControlActions();

 

    this.RetrieveAllNfts = () => {
        cntrlAction.PostToAPI(this.service + "/RetrieveAllNFTWithOwner", card, function (response) {

            

            response.forEach((card) => {


                    nftSection.innerHTML += `
                             <div class="col-lg-3 mt-4" >
                                <div class="tab-content p-4 border-0">
                                    <div class="header d-flex align-items-center justify-content-start">
                                        <div class="avatar-xs">
                                            <img src="" alt="" class="img-fluid rounded-circle">
                                        </div>
                                        <h6 class="mb-0 ms-2 fw-semibold text-muted f-14">${card.OwnerName}</h6>
                                    </div>
                                    <div class="card-image mt-3">
                                        <img src="${card.Image}" alt="" class="img-fluid">
                                    </div>
                                    <div class="body-content mt-3">
                                        <h6 class="fw-bold">  ${card.NftName}</h6>
                                        <div class="d-flex">
                                            <p class="text-muted">1 in stock</p>
                                            <p class="ms-auto text-muted">
                                                Price : <span class="text-success">
                                                   ${card.Price}
                                                    CFC
                                                </span>
                                            </p>
                                        </div>
                                        <hr>
                                        <div class="d-flex mt-3 align-items-center">
                                            <div class="history">
                                                <i class="mdi mdi-restart f-20 align-middle"></i>View History
                                            </div>
                                            <div class="bid-button ms-auto">
                                                <button class="btn btn-sm btn-primary rounded-pill">Bid</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
    `
                })
            })
    }
}

$(document).ready(function () {
    var tblLoad = new ManagerNFTCard();
    tblLoad.RetrieveAllNfts();
});