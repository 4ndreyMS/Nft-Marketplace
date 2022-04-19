function Logout() {
    this.logOut = function () {
        sessionStorage.clear();
        window.location.href = "Index"
    }

}
