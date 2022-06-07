'use strict';

const userInput = document.getElementById('userInput');
const addButton = document.getElementById('addButton');
const feedBacc = document.getElementById('feedBacc');

let saveContact = [];
const emailPattern = /^(?=^.{8,}$)[-_A-Za-z0-9]+([_.-][a-zA-Z0-9]+)*@[A-Za-z0-9]+([.-][a-zA-Z0-9]+)*\.[A-Za-z]{2,}$/;

class Contact {
    constructor(name, city, email) {
        this.name = name;
        this.city = city;
        this.email = email;
    }

    toString() {
        return `${this.name}\n${this.city}\n${this.email}`;
    }
}

function printContacts(saveContact) {
    document.getElementById('contactListSpace').innerHTML = '';

    for (let i = 0; i < saveContact.length; i++) {
        const div = document.createElement('div');
        div.classList.add('contact');
        div.setAttribute('spawnOrder', i);
        // div.setAttribute('onclick', removeContact(this));
        document.getElementById('contactListSpace').appendChild(div);

        const printName = document.createElement('p');
        const printCity = document.createElement('p');
        const printEmail = document.createElement('p');
        div.appendChild(printName);
        div.appendChild(printCity);
        div.appendChild(printEmail);

        printName.innerHTML = `Name: ${saveContact[i].name}`;
        printCity.innerHTML = `City: ${saveContact[i].city}`;
        printEmail.innerHTML = `Email: ${saveContact[i].email}`;

        // function removeContact(contact)
        div.addEventListener('click', (e) => {
            console.log(e.target.getAttribute("spawnOrder"));

            if (e.target.getAttribute("spawnOrder") == null) {
                feedBacc.innerHTML = 'Deletion unsuccessful. Try again.';
            } else {
                saveContact.splice(e.target.getAttribute("spawnOrder"), 1);
                console.log(saveContact);
                printContacts(saveContact);
                feedBacc.innerHTML = 'Delete success.';
            }
        });
    }
}

addButton.onclick = function () {
    let input = userInput.value;
    let testArray = input.split(', ');
    console.log(testArray);

    if (testArray.length != 3) {
        feedBacc.innerHTML = 'Invalid input. Try again.';
    } else {
        if (!testArray[2].match(emailPattern)) {
            feedBacc.innerHTML = 'Invalid email input. Try again.';
        } else {
            // Empty input
            userInput.value = '';
            feedBacc.innerHTML = 'Contact saved!';

            // Create Object
            let inputContact = new Contact(testArray[0], testArray[1], testArray[2]);

            saveContact.unshift(inputContact);

            printContacts(saveContact);
            console.log(saveContact);
        }
    }
}
