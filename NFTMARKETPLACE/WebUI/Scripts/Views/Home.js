function HomeData() {
    this.service = 'NFT';
   const cntrlAction = new ControlActions();
    let nftBannerSlider = { SaleState: "BannerSlider" }

    let homeNFTS = { SaleState: "HomeNFTS" }


    this.RetrieveHomeSlider = () => {
        const bannerSlider = document.getElementById("bannerSlider")

        cntrlAction.PostToAPI(this.service + "/RetrieveNftBySaleState", nftBannerSlider, function (response) {
            console.log(response)
            response.forEach((card) => {
                bannerSlider.innerHTML += `
                           <div class="item" style="width: 75%; padding: 0 25px;margin: 0;">

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


        })

    }

   
  
    this.RetrieveHomeNFTs = () => {

        cntrlAction.PostToAPI(this.service + "/RetrieveNftBySaleState", homeNFTS, function (response) {
            console.log(response)
            response.forEach((card) => {
                homeNftSection.innerHTML += `
                                  <div class="col-lg-3 col-md-6" style="padding-bottom: 30px">
                    <div class="card border-0">
                        <div class="blog-image">
                            <img src="${card.Image}" alt="" class="img-fluid">
                        </div>
                        <div class="card-body ">
                            <div class="d-flex">
                                <h6 class="fw-bold mb-0">${card.NftName}</h6>
                                <p class="text-success ms-auto fw-bold mb-0">${card.Price} CFC</p>
                            </div>
                            <p class="text-muted">Identification: ${card.Id}</p>
                            <div class="d-flex align-items-baseline">
                                <div class="slider-content-image d-flex">
                                    <div class="avatar-sm">
                                        <img src="../../Content/images/slider/user/img-7.jpg" alt="" class="img-fluid">
                                    </div>

                                    <div class="avatar-sm top-child">
                                        <img src="../../Content/images/slider/user/img-6.jpg" alt="" class="img-fluid">
                                    </div>

                                    <div class="avatar-sm top-child position-relative">
                                        <img src="../../Content/images/slider/user/img-5.jpg" alt="" class="img-fluid">
                                    </div>

                                    <div class="avatar-sm top-child position-relative">
                                        <img src="../../Content/images/slider/user/img-4.jpg" alt="" class="img-fluid">
                                    </div>

                                </div>

                                <div class="blog-profile-content ms-auto">
                                    <span class="align-middle fw-bold text-muted">241 Editional</span>
                                </div>
                            </div>
                            <div class="blog-footer mt-4">
                                <div class="bid-content d-flex">
                                    <h6 class="mb-0">On the top 10</h6>
                                    <h6 class="ms-auto mb-0 f-14">On fire <img src="../../Content/images/blog/danger.png" alt="" class="img-fluid"></h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>`

            })
          


        })

    }

}


$(document).ready(function () {
    var tblLoad = new HomeData();
    tblLoad.RetrieveHomeSlider();
    tblLoad.RetrieveHomeNFTs();
});