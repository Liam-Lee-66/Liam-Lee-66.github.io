'use strict';

// Getting elements

// Header
const signUp = document.getElementById('sign-up');
const login = document.getElementById('login');

// Main 
const description = document.getElementById('description');
const searchBar = document.getElementById('search-bar');
const googleButton = document.getElementById('google');
const bingButton = document.getElementById('bing');

// Overlay
const overlay = document.getElementById('overlay');
const titleThingyForForm = document.getElementById('titleThingy');

const formExit = document.getElementById('X');

const idInput = document.getElementById('ID');
const pwInput = document.getElementById('PW');

const submitButton = document.getElementById('submit');

// Admin Username and Password
const validID = 'ciscoadmin';
const validPW = 'cisco123';

// Check if user logged in
let loggedIn = false;

// Toggle overlay
formExit.onclick = function () {
    overlay.style.display = 'none';
    idInput.value = '';
    pwInput.value = '';
}
login.onclick = function () {
    if (!loggedIn) {
        overlay.style.display = 'flex';
        titleThingyForForm.innerHTML = 'Login';
        idInput.style.display = 'block';
        pwInput.style.display = 'block';
        submitButton.value = 'Submit';
    }
    else if (loggedIn) {
        overlay.style.display = 'flex';
        titleThingyForForm.innerHTML = 'Wish to sign out?';
        submitButton.value = 'Yes';

        idInput.style.display = 'none';
        pwInput.style.display = 'none';
    }
}

// Overlay form
submitButton.onclick = function () {
    if (!loggedIn) {
        console.log(idInput.value + ' ' + pwInput.value);

        // ID input validation
        if (idInput.value == '') {
            idInput.placeholder = 'Username is required';
        }

        // PW input validation
        if (pwInput.value == '') {
            pwInput.placeholder = 'User password is required';
        }

        if (idInput.value == validID && pwInput.value == validPW) {
            titleThingyForForm.innerHTML = `Welcome, ${idInput.value}`;
            setTimeout(loggingIn, 2000);
        } else {
            titleThingyForForm.innerHTML = 'Username or Password is incorrect';
        }

        function loggingIn() {
            overlay.style.display = 'none';
            idInput.value = '';
            pwInput.value = '';
            loggedIn = true;
        }
    }

    if (loggedIn) {
        overlay.style.display = 'flex';
        titleThingyForForm.innerHTML = 'Wish to sign out?';
        loggedIn = false;
        overlay.style.display = 'none';
    }
}

// Search Bar
function descriptionDefault () {
    description.innerHTML = 'Type what you wish to search in the bar and click on either buttons for search engines.';
}

googleButton.onclick = function () {
    if (loggedIn) {
        if (searchBar.value == '') {
            window.location.href = "https://www.google.com/";
        } else {
            window.location.href = "https://www.google.com/search?q=".concat(searchBar.value);
        }
    }
    else if (!loggedIn) {
        description.innerHTML = 'You need to login to use the search bar!';
        setTimeout(descriptionDefault, 3000);
    }
}

bingButton.onclick = function () {
    if (loggedIn) {
        if (searchBar.value == '') {
            window.location.href = "https://www.bing.com/";
        } else {
            window.location.href = "https://www2.bing.com/search?q=".concat(searchBar.value);
        }
    }
    else if (!loggedIn) {
        description.innerHTML = 'You need to login to use the search bar!';
        setTimeout(descriptionDefault, 3000);
    }
}