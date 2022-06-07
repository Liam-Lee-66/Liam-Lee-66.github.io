'use strict';

// Getting elements
const clock = document.getElementById('clock');
const alarmSet = document.getElementById('alarmSet');
const input = document.getElementById('input');
const setAlarmButton = document.getElementById('setAlarmButton');

// Getting Audio
const audio = new Audio('assets/audio/alarm.wav');

function showCurrentTime() {
    // Get current time
    const currentTime = new Date();
    // Get current H
    const Hr = currentTime.getHours().toString().padStart(2, '0');
    const Mn = currentTime.getMinutes().toString().padStart(2, '0');
    const Sc = currentTime.getSeconds().toString().padStart(2, '0');

    clock.innerHTML = `${Hr}:${Mn}:${Sc}`;
    console.log('Running');
}

function compareTime() {
    // Get current time
    const currentTime = new Date();
    // Get current H
    const Hr = currentTime.getHours().toString().padStart(2, '0');
    const Mn = currentTime.getMinutes().toString().padStart(2, '0');
    const Sc = currentTime.getSeconds().toString().padStart(2, '0');    

    let IdkWhatToNameThis = Hr + ':' + Mn + ':' + Sc;
    console.log(IdkWhatToNameThis);

    let IdkWhatToNameThis2 = alarmSet.innerHTML.toString();
    IdkWhatToNameThis2 += ':00';

    if (IdkWhatToNameThis == IdkWhatToNameThis2) {
        audio.play();
        console.log('play Audio');
    }
}

function getInput() {
    let userInput = input.value;

    const filter = /^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$/;

    if (userInput.match(filter)) {
        console.log('input success'); 
        return userInput;
    } else {
        userInput = 'Invalid Input.';
        return userInput;
    }
}

function loop() {
    showCurrentTime();
    compareTime()
}

// Actual Work
setAlarmButton.onclick = function () {
    let userTimeSet = getInput();
    alarmSet.innerHTML = userTimeSet;
    input.value = '';
}


setInterval(loop, 1000);