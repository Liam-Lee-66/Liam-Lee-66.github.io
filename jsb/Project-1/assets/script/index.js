// Gathering up IDs

// Dark mode toggle
const bG = document.querySelector('body');
const modeSwitch = document.getElementById('modeSwitcher');

// C -> F
const convertUno = document.getElementById('convert-1');
const answerUno = document.getElementById('answer-1');

// C <- F
const convertDos = document.getElementById('convert-2');
const answerDos = document.getElementById('answer-2');



// Dark mode toggle button Code
modeSwitch.onclick = function () {
    bG.classList.toggle('dark-mode');

    if (bG.classList == 'dark-mode') {
        this.innerText = 'Click to switch into Light mode';
    } 
    else {
        this.innerText = 'Click to switch into Dark mode';
    }
}

// C -> F Code
convertUno.onclick = function () {
    let input = document.getElementById('input-1').value;
    input = parseInt(input);

    if (isNaN(input)) {
        answerUno.innerText = 'That is not a number. Try again.';
    }
    else {
        input = input * 1.8 + 32;
        input = input.toFixed(2);

        answerUno.innerText = `${input}°F`;
    }
}

// C <- F Code
convertDos.onclick = function () {
    let input2 = document.getElementById('input-2').value;
    input2 = parseInt(input2);

    if (isNaN(input2)) {
        answerDos.innerText = 'That is not a number. Try again.';
    }
    else {
        input2 = input2 - 32;
        input2 = input2 / 1.8;
        input2 = input2.toFixed(2);
        
        answerDos.innerText = `${input2}°C`;
    }
}