function ManagerNFTCard() {


 

    const nftSection = document.getElementById("row-cards")
    this.service = 'NFT';
    const cntrlAction = new ControlActions();
    let nft = { SaleState: "OnSale" }

 
    //inicio de la funcion
    this.RetrieveAllNfts = () => {

        //devuelve toda la informacion de los nft
        cntrlAction.PostToAPI(this.service + "/RetrieveNftBySaleState", nft, function (response) {

            //itera segun los nft que hayan en la bd
            response.forEach((card) => {

                //si el estado del nft esta en venta imprime
                nftSection.innerHTML += `
                             <div class="col-lg-3 mt-4 nftCard">
                                <div class="tab-content p-4 border-0">
                                    <div class="header d-flex align-items-center justify-content-start">
                                        <div class="avatar-xs">
                                            <img src="${card.UserPic}" alt="" class="img-fluid rounded-circle">
                                        </div>
                                        <h6 class="mb-0 ms-2 fw-semibold text-muted f-14">By: ${card.OwnerName}</h6>
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
                                         
                                            <div class="bid-button ms-auto">
                                                <button class="btn btn-sm btn-primary rounded-pill addToCart">Add to cart</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>`
                })


            let carts = document.querySelectorAll(".addToCart")
          

            for (let i = 0; i < carts.length; i++) {
                    carts[i].addEventListener('click', () => {
                        cartNumbers(response[i])
                        totalCosts(response[i])
                    })
                }

            function onLoadCardNumbers() {
                let productNumbers = sessionStorage.getItem('NftName');

                if (productNumbers) {
                  
                    document.querySelector('.cart span').textContent = productNumbers 
                }

            }

           function cartNumbers(product) {

               
                    let productNumbers = sessionStorage.getItem('NftName');
                    productNumbers = parseInt(productNumbers)


                    if (productNumbers) {
                        sessionStorage.setItem('NftName', productNumbers + 1)
                        document.querySelector('.cart span').textContent = productNumbers + 1
                    } else {
                        sessionStorage.setItem('NftName', 1)
                        document.querySelector('.cart span').textContent = 1

                    }

                setItems(product)
            }


            function setItems(product) {


                let cartItems = sessionStorage.getItem("productsInCart")
                cartItems = JSON.parse(cartItems)

                if (cartItems != null) {

                    if (cartItems[product.NftName] == undefined) {
                        cartItems = {
                            ...cartItems,
                            [product.NftName]: product

                        }
                    }

                    cartItems[product.NftName].inCart += 1




                } else {
                    product.inCart = 1
                    cartItems = {
                        [product.NftName]: product
                    }

                }


             
                sessionStorage.setItem("productsInCart", JSON.stringify(cartItems))

            }


            function totalCosts(product) {

                let cartCost = sessionStorage.getItem("totalCost")

                if (cartCost != null) {
                    cartCost = parseInt(cartCost)
                    sessionStorage.setItem("totalCost", cartCost + product.Price)

                } else {
                    sessionStorage.setItem("totalCost", product.Price)

                }
            }

            onLoadCardNumbers()
            
        })

    }

    this.RetrieveAllNftsInOffer = () => {

        let NFTO = { SaleState: "InOffer" }

        //devuelve toda la informacion de los nft
        cntrlAction.PostToAPI(this.service + "/RetrieveNftBySaleState", NFTO, function (response) {

            //itera segun los nft que hayan en la bd
            response.forEach((card) => {

                //si el estado del nft esta en venta imprime
                NFTInOffer.innerHTML += `
                             <div class="col-lg-3 mt-4 nftCard">
                                <div class="tab-content p-4 border-0">
                                    <div class="header d-flex align-items-center justify-content-start">
                                        <div class="avatar-xs">
                                            <img src="${card.UserPic}" alt="" class="img-fluid rounded-circle">
                                        </div>
                                        <h6 class="mb-0 ms-2 fw-semibold text-muted f-14">By: ${card.OwnerName}</h6>
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
                                            <div class="bid-button ms-auto" style="width: 60%;">
                                                <input type="number" class="form-control" id="${card.Id}">
                                            </div>
                                            <div class="bid-button ms-auto" >
                                                <button class="btn btn-sm btn-primary rounded-pill" onclick="MakeAnOffer('${card.Id}', '${card.IdOwner}')">Offer</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>`
            })                                        
        })
    }
}

function MakeAnOffer(Id, IdOwner) {
    let cntrlAction = new ControlActions();
    var price = document.getElementById(Id).value;
    if (sessionStorage.getItem('UserCedula') === null) {
        window.location.href = "Login";
    } else {
        if ((sessionStorage.getItem('UserCompany') == IdOwner)) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'You can not offer for your own NFT.',
            })
        } else {
            if (price == "") {
                Swal.fire({
                    icon: 'error',
                    title: 'You miss something',
                    text: 'Please insert an amount to make the offer',
                })
            } else {
                let Offer = { NFT: Id, BidderID: sessionStorage.getItem('UserCompany'), OwnerID: IdOwner, Amount: price}
                cntrlAction.PostToAPI("Offer" + "/CreateOffer", Offer, function (response) { })
                window.getElementById(Id).value = "";
            }
        }
    }
}

$(document).ready(function () {
    var tblLoad = new ManagerNFTCard();
    tblLoad.RetrieveAllNfts();
    tblLoad.RetrieveAllNftsInOffer();
});