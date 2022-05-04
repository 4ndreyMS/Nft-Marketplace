function Activity() {
    const cntrlAction = new ControlActions();
    const notificationService = 'Notifications';
   



    this.Offer = () => {
        const offersSection = document.getElementById("offers")

        let notification = { ReceiverId: sessionStorage.getItem('UserCompany') }

        cntrlAction.PostToAPI(notificationService + "/RetrieveNotifUserByCompany", notification, function (response) {



            response.forEach((notification) => {
                offersSection.innerHTML += `
                            <div class="activity-box activityBox-spacing">
                               <div class="d-flex align-items-center" >
                                    <div class="flex-shrink-0">
                                        <div class="avatar">
                                            <img src="../../Content/images/inner-image/creator/img-5.png" alt="" class="img-fluid rounded-circle avatar-lg">
                                        </div>
                                    </div>
                                    <div class="flex-grow-1 ms-3">
                                        <div class="d-flex align-items-center">
                                            <div class="profile-info">
                                                <h6 class="fw-bold mb-0">Creative Art collection</h6>
                                                <p class="f-16 mb-0"> ${notification.SenderId}
                                                   ${notification.Msj}
                                                    </span>
                                                </p>
                                            </div>
                                            <div class="laft-day ms-auto">
                                                <p class="fw-semibold mb-0 text-muted">${notification.ReceiverId}</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                `
            }
            )
        }


        )
    }

}


    $(document).ready(function () {
        var tblLoad = new Activity();
        tblLoad.Offer();
    });