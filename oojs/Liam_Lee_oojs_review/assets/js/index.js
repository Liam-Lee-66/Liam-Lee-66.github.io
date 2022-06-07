'use strict';

const optionShape = document.getElementById('shape');
const optionColour = document.getElementById('colour');
const dispenseBtn = document.getElementById('dispenseBtn');
const feedBacc = document.getElementById('feedBacc');

// Fake database
let DataBase = [];

class Shape {
    constructor(shape, colour) {
        this._shape = shape;
        this._colour = colour;
    }

    set shape(value) {
        this._shape = value;
    }
    set colour(value) {
        this._colour = value;
    }

    get shape() {
        return this._shape.charAt(0).toUpperCase() + this._shape.slice(1);
    }
    get colour() {
        return this._colour.charAt(0).toUpperCase() + this._colour.slice(1);
    }

    info() {
        return `${this.colour}, ${this.shape}`;
    }
}

function buildingTheShape(newShape) {
    const shapeInBuild = document.createElement('div');
    shapeInBuild.classList.add('getSpawned');
    shapeInBuild.classList.add(newShape._shape);
    shapeInBuild.style.backgroundColor = newShape._colour;

    document.getElementById('dispenseOutput').appendChild(shapeInBuild);

    shapeInBuild.setAttribute('dispenseOrder', DataBase.length - 1);

    shapeInBuild.addEventListener('click', (e) => {
        console.log(e.target.getAttribute("dispenseOrder"));

        feedBacc.innerHTML = `${DataBase[e.target.getAttribute("dispenseOrder")].colour} ${DataBase[e.target.getAttribute("dispenseOrder")].shape}`;
    });
}

dispenseBtn.onclick = function () {
    if (optionShape.value == '' || optionColour.value == '') {
        feedBacc.innerHTML = 'Input is invalid. Try again.'
    } else if (DataBase.length < 20) {
        feedBacc.innerHTML = 'Dispense success!';
        let newShape = new Shape(optionShape.value, optionColour.options[optionColour.selectedIndex].text)
        DataBase.push(newShape);
        console.log(newShape.info());

        buildingTheShape(newShape);
    } else {
        feedBacc.innerHTML = 'Box is full! Refresh page!';
    }
}

