const input = document.getElementById('input');
const checkButton = document.getElementById('checkButton');
const output1 = document.getElementById('output1');
const output2 = document.getElementById('output2');
const output3 = document.getElementById('output3');
const output4 = document.getElementById('output4');

// 2005-05-14

function checkAge(givenDate) {
    const currentDate = new Date();
    console.log(currentDate);

    let age = currentDate.getFullYear() - givenDate.getFullYear();
    age = parseInt(age);

    if (givenDate.getMonth() > currentDate.getMonth()) {
        if (givenDate.getDate() > currentDate.getMonth()) {
            age = age - 1;
        }
    }

    console.log(age);
    return age;
}

function checkDaysOld(givenDate) {
    const currentDate = new Date();

    let daysOld = (currentDate - givenDate) / (1000 * 60* 60 * 24);
    daysOld = Math.trunc(daysOld);
    
    console.log((daysOld));
    return daysOld;
}

function checkBdayLeft(givenDate) {
    const currentDate = new Date();

    let dayLeft = (givenDate.setFullYear(0) - currentDate.setFullYear(0)) / (1000 * 60* 60 * 24);
    dayLeft = Math.trunc(dayLeft);

    return dayLeft;
}

checkButton.onclick = function () {
    // Birth Date confirm
    console.log(input.value);

    if (input.value == '') {
        output1.innerHTML = 'Input is empty. Enter something.';
        output2.innerHTML = '';
        output3.innerHTML = '';
        output4.innerHTML = '';

    } else if (input.value.length != 10) {
        output1.innerHTML = 'Input is invalid. Try again.';
        output2.innerHTML = '';
        output3.innerHTML = '';
        output4.innerHTML = '';
    } else {
        let bday = new Date(input.value);
        bday.setDate(bday.getDate() + 1);

        prepOutput = bday.toString();
        prepOutput = prepOutput.slice(0, 16)

        output1.innerHTML = `Your birthday is ${prepOutput}.`;

        // Years old
        output2.innerHTML = `You are ${checkAge(bday)} year(s) old this year.`;

        // Days old
        output3.innerHTML = `You are ${checkDaysOld(bday)} days old.`;

        // Days left till Bday
        output4.innerHTML = `There are/is ${checkBdayLeft(bday)}(s) left till your birthday!`;
    }
}