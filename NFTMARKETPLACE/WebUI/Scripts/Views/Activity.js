function Activity() {

    const cntrlAction = new ControlActions();
    const notificationService = 'Notifications';
  
    this.Offer = () => {
        const offersSection = document.getElementById("offers")

        let notification = { ReceiverId: sessionStorage.getItem('UserCompany') }

        cntrlAction.PostToAPI(notificationService + "/RetrieveNotifUserByCompany", notification, function (response) {
            response.forEach((notification) => {
                let date = new Date(notification.SentDate).toLocaleDateString('en-us', { weekday: "long" })         
                offersSection.innerHTML += `
                            <div class="activity-box activityBox-spacing">
                               <div class="d-flex align-items-center" >
                                    <div class="flex-shrink-0">
                                        <div class="avatar">
                                            <img src="${notification.Nft.Image}" alt="" class="img-fluid rounded-circle avatar-lg">
                                        </div>
                                    </div>
                                    <div class="flex-grow-1 ms-3">
                                        <div class="d-flex align-items-center">
                                            <div class="profile-info">
                                                <h6 class="fw-bold mb-0"> ${notification.Nft.NftName}</h6>
                                                <p class="f-16 mb-0"> ${notification.SenderName}
                                                 would like to make an offer
                                                    </span>
                                                </p>
                                            </div>
                                            <div class="laft-day ms-auto">
                                                <p class="fw-semibold mb-0 text-muted">${date}</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                `

            }
            )
            console.log(response)
            if (Object.keys(response).length < 1) {
                offersSection.innerHTML += `
                    <p style="padding-left: 80px;">
                       Ups!! There are not offers at this point
                    </p>
                          
                `
            }
        }

        )
    }

}


    $(document).ready(function () {
        var tblLoad = new Activity();
        tblLoad.Offer();
    });