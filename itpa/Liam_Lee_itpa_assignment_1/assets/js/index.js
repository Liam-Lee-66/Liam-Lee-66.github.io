'use strict';

// Overlay & popup
const overlay = document.getElementById('overlay');
const popup1 = document.getElementById('popup1');
const popup2 = document.getElementById('popup2');

// popup1 buttons
const popup1Btn1 = document.getElementById('popup1-btn1');
const popup1Btn2 = document.getElementById('popup1-btn2');

// popup2 buttons
const popup2Btn1 = document.getElementById('popup2-btn1');

// slide switches
const slideBrowser = document.getElementById('slideBrowser');
const slideOS = document.getElementById('slideOS');
const slideSW = document.getElementById('slideSW');
const slideSH = document.getElementById('slideSH');









let options = {}









// Functions
function getBrowserName() {
    let userAgent = navigator.userAgent;
    let browserName;

    if (userAgent.match(/chrome|chromium|crios/i)) {
        browserName = "chrome";
    } else if (userAgent.match(/firefox|fxios/i)) {
        browserName = "firefox";
    } else if (userAgent.match(/safari/i)) {
        browserName = "safari";
    } else if (userAgent.match(/opr\//i)) {
        browserName = "opera";
    } else if (userAgent.match(/edg/i)) {
        browserName = "edge";
    } else {
        browserName = "No browser detection";
    }

    // console.log(browserName);
    return browserName;
}

function getOSName() {
    let userAgent = navigator.platform;
    let OSName;

    if (userAgent.match(/Win/g)) {
        OSName = 'Windows';
    } else if (userAgent.match(/Mac/g)) {
        OSName = 'Mac OS';
    } else {
        OSName = 'JS cannot recognised';
    }

    // console.log(OSName);
    return OSName;
}

function getSW() {
    const body = document.getElementsByTagName('body')[0];
    // console.log(body.clientWidth);
    return body.clientWidth;
}

function getSH() {
    const body = document.getElementsByTagName('body')[0];
    // console.log(body.clientHeight);
    return body.clientHeight;
}



function setCookie(name, value) {
    let limit = new Date();
    limit.setSeconds(limit.getSeconds() + 10);
    limit = limit.toUTCString();

    const options = {
        path: '/',
        SameSite: 'Lax',
        expires: limit
    };

    let updatedCookie = encodeURIComponent(name) + "=" + encodeURIComponent(value);

    for (let optionKey in options) {
        updatedCookie += "; " + optionKey;
        let optionValue = options[optionKey];
        if (optionValue !== true) {
            updatedCookie += "=" + optionValue;
        }
    }
    document.cookie = updatedCookie;
}

function setupCookie(browser, OS, SW, SH) {
    if (!browser && !OS && !SW && !SH) {
        setCookie('Cookie rejected', 'rejected');
    } else {

        if (browser) {
            setCookie('Browser', getBrowserName());
        }

        if (OS) {
            setCookie('Operating System', getOSName());
        }

        if (SW) {
            setCookie('Screen Width', getSW());
        }

        if (SH) {
            setCookie('Screen Height', getSH());
        }
    }
}

function getCookie() {
    if (document.cookie) {
        // console.log(document.cookie);
        const cookies = document.cookie.split('; ');
        for (let i = 0; i < cookies.length; i++) {
            console.log(
                decodeURIComponent(cookies[i].split('=')[0]) + ': ' +
                decodeURIComponent(cookies[i].split('=')[1])
            );
        }
    } else {
        console.log('No cookies found');
        overlay.style.display = 'grid';
        popup1.style.display = 'grid';
        popup2.style.display = 'none';
    }
}





overlay.style.display = 'none';
popup1.style.display = 'none';
popup2.style.display = 'none';

getCookie();

// Accept all
popup1Btn1.onclick = function () {
    popup1.style.display = 'none';
    overlay.style.display = 'none';

    // some code for indication to check that all is selected
    setupCookie(slideBrowser.checked, slideOS.checked, slideSW.checked, slideSH.checked);
}

// Manage
popup1Btn2.onclick = function () {
    popup1.style.display = 'none';
    popup2.style.display = 'flex';
}

//Save Preferences
popup2Btn1.onclick = function () {
    popup2.style.display = 'none';
    overlay.style.display = 'none';

    // some code for indication to check that is selected
    setupCookie(slideBrowser.checked, slideOS.checked, slideSW.checked, slideSH.checked);
}