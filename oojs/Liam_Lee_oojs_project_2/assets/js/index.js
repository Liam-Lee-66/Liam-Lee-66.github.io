// Popup tools 
const userProfilePicture = document.getElementById('userProfilePicture');
const closePopup = document.getElementById('closePopup');
const popup = document.getElementById('popup');

const userName = document.getElementById('userName');
const userInfo = document.getElementById('userInfo');

const profileImg = document.getElementById('profileImg');

// Post tools 
const textarea = document.getElementById('textarea');
const imageUpload = document.getElementById('imageUpload');
const postBtn = document.getElementById('postBtn');
const customImageUpload = document.getElementById('custom-imageUpload');

// Popup initiate 
class User {
    constructor(fullName, id, email, pfp) {
        this.fullName = fullName;
        this.id = id;
        this.email = email;
        this._pfp = pfp;
    }

    set pfp(value) {
        this._pfp = value;
    }
    get pfp() {
        return 'assets/other/' + this._pfp;
    }

    info() {
        return 'ID: ' + this.id + '<br>' + 'Email: ' + this.email + '<br>';
    }
}
class PremiumUser extends User {
    constructor(fullName, id, email, pages, groups, pfp) {
        super(fullName, id, email, pfp);
        this.pages = pages;
        this.groups = groups;
    }

    set pfp(value) {
        this._pfp = value;
    }
    get pfp() {
        return 'assets/other/' + this._pfp;
    }

    info() {
        return 'ID: ' + this.id + '<br>' + 'Email: ' + this.email + '<br>' + 'My pages: ' + pageNum + '<br>' + 'My groups: ' + this.groups;
    }
}

// Hardcoding User
let pageNum = 0;
const defaultUser = new PremiumUser('Liam Lee', '0001', 'liamsjlee@gmail.com', pageNum, 0, 'pfp.jpg');

// Popup buttons
userProfilePicture.onclick = function () {
    console.log(defaultUser.pfp);
    console.log(defaultUser._pfp);
    profileImg.style.backgroundImage = `url(${defaultUser.pfp})`;
    userName.innerHTML = defaultUser.fullName;
    userInfo.innerHTML = defaultUser.info();

    popup.style.display = 'grid';
}
closePopup.onclick = function () {
    popup.style.display = 'none';
}

// Post initiate 
class Post {
    constructor(userpfp, username, text, image) {
        this.userpfp = userpfp;
        this.username = username;
        this.text = text;
        this.image = image;
    }

    imgNameOnly() {
        this.image.slice(12);
        console.log(image);
    }
}

function printPostPlz(postingData) {
    // Create + editing div element
    const postInBuild = document.createElement('div');
    postInBuild.classList.add('post');
    document.getElementById('uploads').appendChild(postInBuild);

    const postUser = document.createElement('div');
    postUser.classList.add('postUser');
    postInBuild.appendChild(postUser);

    // Create + edit pfp and name
    const pfpDiv = document.createElement('div');
    pfpDiv.classList.add('popupProfile');
    pfpDiv.style.width = '50px';
    pfpDiv.style.height = '50px';
    pfpDiv.style.margin = '0px';
    pfpDiv.style.backgroundImage = `url('${defaultUser.pfp}')`;
    postUser.appendChild(pfpDiv);

    const pfName = document.createElement('p');
    pfName.innerHTML = defaultUser.fullName;
    postUser.appendChild(pfName);

    // Create + editing text
    if (postingData.text != '') {
        const textInBuild = document.createElement('p');
        textInBuild.innerHTML = postingData.text;
        postInBuild.appendChild(textInBuild);

        if (postingData.image !='') {
            textInBuild.style.marginBottom = '5px';
        }
    }

    // Create + image text
    if (postingData.image != '') {
        const imageInBuild = document.createElement('img');

        imageInBuild.src = `assets/other/${postingData.image.slice(12)}`;

        postInBuild.appendChild(imageInBuild);
    }
}

postBtn.onclick = function () {
    console.log(`text: ${textarea.value}`);
    console.log(`image: ${imageUpload.value}`);

    if (textarea.value == '' && imageUpload.value == '') { }
    else {
        const postingData = new Post(defaultUser.pfp, defaultUser.userName, textarea.value, imageUpload.value);

        console.log('printing');
        printPostPlz(postingData);

        textarea.value = '';
        imageUpload.value = '';
        pageNum++;
        console.log('print complete');
    }
}


// Loop for checking file 
function checkFile () {
if (imageUpload.value != '') {
    customImageUpload.innerHTML = '<i class="fa fa-image"></i>' + imageUpload.value.slice(12);
} else {
    customImageUpload.innerHTML = '<i class="fa fa-image"></i>Image';
}
}

setInterval(checkFile, 1000);