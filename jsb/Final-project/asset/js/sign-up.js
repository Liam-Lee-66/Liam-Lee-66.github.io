// Overlay
const titleThingyForForm = document.getElementById('titleThingy');

const idInput = document.getElementById('ID');
const pwInput = document.getElementById('PW');
const rePwInput = document.getElementById('rePW');
const description = document.getElementById('description');

const submitButton = document.getElementById('submit');

// form
submitButton.onclick = function () {
    // ID input validation
    if (idInput.value == '') {
        idInput.placeholder = 'Username is required';
    }

    // PW input validation
    if (pwInput.value == '') {
        pwInput.placeholder ='Password is required';
    }
}
