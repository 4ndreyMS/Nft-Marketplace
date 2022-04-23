function NavBar() {

    const manager = document.querySelectorAll(".nav-item.manager-links");
    const contentCreator = document.getElementsByClassName("content-creator");
    const user = document.querySelectorAll(".user");
    const userValue = sessionStorage.getItem("UserRole");


    /* 
     
       1 = Manager, 
       2 = User, 
       3 = Content Creator
    
    */


    const contentCreatorFunction = () => {
        for (var i = 0; i < contentCreator.length; i += 1) {
            contentCreator[i].style.display = 'none';
        }
    }


    const managerFunction = () => {
        for (var i = 0; i < manager.length; i += 1) {
            manager[i].style.display = 'none';
        }
    }


    const userFunction = () => {
        for (var i = 0; i < user.length; i += 1) {
            user[i].style.display = 'none';
        }
    }


    if (userValue == 1) {

        contentCreatorFunction()
        userFunction()

    } else if (userValue == 2) {
       
        managerFunction()
        contentCreatorFunction()


    } else if (userValue == 3) {
        managerFunction()
        userFunction()

    } else if (userValue === null) {

        contentCreatorFunction()
        managerFunction()
        userFunction() 
      
    }

}
