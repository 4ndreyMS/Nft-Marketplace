﻿function NavBar() {

    const manager = document.querySelectorAll(".nav-item.manager-links");
    const contentCreator = document.getElementsByClassName("content-creator");
    const user = document.querySelectorAll(".user");
    const showLogOut = document.querySelectorAll(".logOut");
    const userValue = sessionStorage.getItem("UserRole");
    const loggedIn = document.querySelectorAll(".logIn");

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

    const showLogOutFunction = () => {
        for (var i = 0; i < showLogOut.length; i += 1) {
            showLogOut[i].style.display = 'none';
        }
    }

    const showLogInFunction = () => {
        for (var i = 0; i < loggedIn.length; i += 1) {
            loggedIn[i].style.display = 'none';
        }
    }

    if (userValue == 1) {
        showLogInFunction()
        contentCreatorFunction()
        userFunction()

    } else if (userValue == 2) {
        showLogInFunction()
        managerFunction()
        contentCreatorFunction()


    } else if (userValue == 3) {
        showLogInFunction()
        managerFunction()
        userFunction()

    } else if (userValue === null) {
        showLogOutFunction()
        contentCreatorFunction()
        managerFunction()
        userFunction()

    } 
}
