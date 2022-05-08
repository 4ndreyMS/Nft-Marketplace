function HomeData() {
    this.service = 'NFT';
   const cntrlAction = new ControlActions();
    let nftBannerSlider = { SaleState: "BannerSlider" }


    this.RetrieveHomeSlider = () => {

        cntrlAction.PostToAPI(this.service + "/RetrieveNftBySaleState", nftBannerSlider, function (response) {
            console.log(response)
            response.forEach((card) => {
                bannerSlider.innerHTML += `
                           <div class="item">

                            <div class="card position-relative overflow-hidden m-2 m-lg-0">
                                <img src="${card.Image}" alt="logo-img" class="img-fluid">
                                <div class="card-body slider-content position-relative">
                                    <p class="mb-2">${card.NftName}</p>
                                    <h5 class="fw-bold">${card.Price} CFC</h5>

                                    <div class="d-flex">
                                        <div class=" slider-content-image d-flex mt-3">
                                            <div class="avatar-sm">
                                                <img src="../../Content/images/slider/user/img-1.jpg" alt="" class="img-fluid">
                                            </div>

                                            <div class="avatar-sm top-child">
                                                <img src="../../Content/images/slider/user/img-4.jpg" alt="" class="img-fluid">
                                            </div>

                                            <div class="avatar-sm top-child position-relative">
                                                <img src="../../Content/images/slider/user/img-8.jpg" alt="" class="img-fluid">

                                                <span class="content-image-check">
                                                    <span class="visually-visible">
                                                        <i class="mdi mdi-check f-12"></i>
                                                    </span>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="slider-content-button">
                                            <button class="btn btn-dark pe-5">Bid</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </div>`

            })
            console.log(bannerSlider)


        })

    }

  


}


$(document).ready(function () {
    var tblLoad = new HomeData();
    tblLoad.RetrieveHomeSlider();
   
});