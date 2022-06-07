'use strict';

// Getting elements (output & display)
const log1 = document.getElementById('log');
const log2 = document.getElementById('output');

// Getting Numbers & Symbols
const numbers = document.getElementsByClassName('number');
const symbols = document.getElementsByClassName('symbols');

// Getting others
const clear = document.getElementById('clear');
const equal = document.getElementById('equal');
const backSpace = document.getElementById('backSpace');


// Num Saver
let input1 = '';

// Hiding line 2 for now
log2.style.display = 'none';

// Number interation
for (let i of numbers) {
    i.addEventListener('click', function () {
        if (log2.style.display == 'block') {
            log2.style.display = 'none';

            input1 = input1 + i.innerText;
            log1.innerText = input1;
        }
        else {
            input1 = input1 + i.innerText;
            log1.innerText = input1;
        }
    });
}

// Symbol interaction
for (let i of symbols) {
    i.addEventListener('click', function () {
        if (input1 == '') {
            input1 = log2.innerText;
            log2.style.display = 'none';

            input1 = input1 + i.value;
            log1.innerText = input1;
        }
        else {
            input1 = input1 + i.value;
            log1.innerText = input1;
        }
    });
}

// Others interaction
equal.addEventListener('click', function () {
    log2.style.display = 'block';
    log2.innerText = eval(input1);

    // Dialouge
    if (log2.innerText == 'Infinity') {
        log2.innerText = 'Error';
    }
    else if (input1 == '') {
        log2.innerText = 'Number needed';
    }
    else if (log2.innerText == 'NaN') {
        log2.innerText = 'Not a number';
    }
    input1 = '';
});

clear.addEventListener('click', function () {
    log1.innerText = '';
    log2.style.display = 'none';
    log2.innerText = '';
    input1 = '';
});
backSpace.addEventListener('click', function () {
    input1 = input1.substring(0, input1.length - 1);
    log1.innerText = input1;
});



