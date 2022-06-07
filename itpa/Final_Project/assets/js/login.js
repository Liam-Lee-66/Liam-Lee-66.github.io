'use strict';

const loginBtn = document.getElementById('loginBtn');
const idInput = document.getElementById('idInput');
const pwInput = document.getElementById('pwInput');
const errOutput = document.getElementById('errOutput');
const rememberJe = document.getElementById('rememberJe');

const overlay = document.getElementById('overlay');

// id setup
// localStorage.setItem('id', 'memeLord');
// localStorage.setItem('pw', 'memeLord123');

// localStorage.clear();

function spawnSpinnyThingy() {
    errOutput.style.color = '#50C878';
    errOutput.innerHTML = `Welcome Back.`;

    overlay.style.display = 'grid';
    setTimeout(function () {
        // location.replace('../index.html');
    }, 2000);
}

if (localStorage.getItem('rememberJe')) {
    spawnSpinnyThingy();
} else {

    loginBtn.onclick = function () {
        errOutput.innerHTML = '';

        if (idInput.value == '' || pwInput.value == '') {
            console.log('user input empty');
            errOutput.innerHTML = 'One or both of user input is empty. Try again.';
        } else {
            if (idInput.value == localStorage.getItem('id') && pwInput.value == localStorage.getItem('pw')) {

                localStorage.setItem('rememberJe', rememberJe.checked);

                spawnSpinnyThingy();
            }
            else {
                errOutput.innerHTML = 'Entered user information is incorrect. Try again.';
            }
        }
    }
}