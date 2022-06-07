'use strict';

/*
    Plan:
    1. make the user input the first number, log the first input
    2. when the user presses any sign key, end logging and convert logged number into an int. Tell JS that the 2nd input and 1st input with add/subtract/multiply/divide
    3. let user enter second number, log the second input
    4. when the user presses 
*/


// Getting elements (Numbers)
const one = document.getElementById('one');
const two = document.getElementById('two');
const three = document.getElementById('three');
const four = document.getElementById('four');
const five = document.getElementById('five');
const six = document.getElementById('six');
const seven = document.getElementById('seven');
const eight = document.getElementById('eight');
const nine = document.getElementById('nine');
const zero = document.getElementById('zero');

// Getting elements (Symbols)
const clear = document.getElementById('clear');
const backSpace = document.getElementById('backSpace');
const plus = document.getElementById('plus');
const minus = document.getElementById('minus');
const decimal = document.getElementById('decimal');
const multiply = document.getElementById('multiply');
const divide = document.getElementById('division');
const calculate = document.getElementById('equal');

// Getting elements (output & display)
const output = document.getElementById('output');
const log = document.getElementById('log');


// Variables
let input = '';
let optionSelected = 'none';
let savedInput = '';

// Hide log for now
log.style.display = 'none';

// number input
one.addEventListener('click', function () {
    input = input + 1;
    output.innerText = input;
});
two.addEventListener('click', function () {
    input = input + 2;
    output.innerText = input;
});
three.addEventListener('click', function () {
    input = input + 3;
    output.innerText = input;
});
four.addEventListener('click', function () {
    input = input + 4;
    output.innerText = input;
});
five.addEventListener('click', function () {
    input = input + 5;
    output.innerText = input;
});
six.addEventListener('click', function () {
    input = input + 6;
    output.innerText = input;
});
seven.addEventListener('click', function () {
    input = input + 7;
    output.innerText = input;
});
eight.addEventListener('click', function () {
    input = input + 8;
    output.innerText = input;
});
nine.addEventListener('click', function () {
    input = input + 9;
    output.innerText = input;
});
zero.addEventListener('click', function () {
    input = input + 0;
    output.innerText = input;
});


decimal.addEventListener('click', function () {
    if (!input.includes('.') && input.length > 0) {
        input = input + '.';
        output.innerText = input;
    }
});
clear.addEventListener('click', function () {
    input = '';
    savedInput = '';
    output.innerText = input;
    log.innerText = '';
    log.style.display = 'none';
    optionSelected = 'none';
});
backSpace.addEventListener('click', function () {
    input = input.substring(0, input.length - 1);
    output.innerText = input;
});

// Buttons (symbols)
plus.addEventListener('click', function () {
    if (optionSelected == 'none') {
        savedInput = parseFloat(input);
        input = '';
        optionSelected = 'Addition';

        log.style.display = 'block';
        log.innerText = `${savedInput} + `;
        output.innerText = '';
    }
    else {
        log.innerText = `${savedInput} + `;
        output.innerText = '';
        optionSelected = 'Addition';
    }
});
minus.addEventListener('click', function () {
    if (optionSelected == 'none') {
        savedInput = parseFloat(input);
        input = '';
        optionSelected = 'Subtraction';

        log.style.display = 'block';
        log.innerText = `${savedInput} - `;
        output.innerText = '';
    }
    else {
        log.innerText = `${savedInput} - `;
        output.innerText = '';
        optionSelected = 'Subtraction';
    }
});
multiply.addEventListener('click', function () {
    if (optionSelected == 'none') {
        savedInput = parseFloat(input);
        input = '';
        optionSelected = 'Multiplication';

        log.style.display = 'block';
        log.innerText = `${savedInput} x `;
        output.innerText = '';
    }
    else {
        log.innerText = `${savedInput} x `;
        output.innerText = '';
        optionSelected = 'Multiplication';
    }
});
divide.addEventListener('click', function () {
    if (optionSelected == 'none') {
        savedInput = parseFloat(input);
        input = '';
        optionSelected = 'Division';

        log.style.display = 'block';
        log.innerText = `${savedInput} / `;
        output.innerText = '';
    }
    else {
        log.innerText = `${savedInput} / `;
        output.innerText = '';
        optionSelected = 'Division';
    }
});


// Equal button
calculate.addEventListener('click', function () {
    input = parseFloat(input);

    if (isNaN(input) && savedInput =='') {
        output.innerText = 'input needed';

        // Making sure to clear inputs
        input = '';
        savedInput = '';
    }
    else if (isNaN(input) && savedInput != '') {
        output.innerText = 'Second input needed';

        // Making sure to clear input
        input = '';
    }
    else {
        switch (optionSelected) {
            case 'Addition':
                log.innerText = `${savedInput} + ${input}`;
                savedInput = savedInput + input;
                output.innerText = savedInput;
                input = '';
                optionSelected = '';
                break;
            case 'Subtraction':
                log.innerText = `${savedInput} - ${input}`;
                savedInput = savedInput - input;
                output.innerText = savedInput;
                input = '';
                optionSelected = '';
                break;
            case 'Multiplication':
                log.innerText = `${savedInput} x ${input}`;
                savedInput = savedInput * input;
                output.innerText = savedInput;
                input = '';
                optionSelected = '';
                break;
            case 'Division':
                log.innerText = `${savedInput} / ${input}`;
                savedInput = savedInput / input;
                output.innerText = savedInput;
                input = '';
                optionSelected = '';
                break;
            default:
                log.style.display = 'block';
                log.innerText = 'ERROR DETECTED';
                output.innerText = 'CLEAR OR REFRESH PAGE';
                break;
        }
    }
});