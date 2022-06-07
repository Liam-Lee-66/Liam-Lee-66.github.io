const api = 'https://randomuser.me/api/?nat=CA&results=15&seed=1ccb580bbecef1e9';

const options = {
  method: 'GET',
  mode: 'cors'
};

function spawnAcc(person) {
  const accspace = document.createElement('div');
  accspace.classList.add('accSpace');
  document.getElementById('accounts').appendChild(accspace);
  // console.log('accSpace made');

  const accpfp = document.createElement('div');
  accpfp.classList.add('accPfp');
  accpfp.style.backgroundImage = `url('${person.picture.medium}')`;
  accspace.appendChild(accpfp);
  // console.log('accpfp made');

  const contactinfo = document.createElement('div');
  contactinfo.classList.add('info');
  accspace.appendChild(contactinfo);
  // console.log('infodiv made');

  const name = document.createElement('h4');
  name.innerHTML = `${person.name.first} ${person.name.last}`;
  contactinfo.appendChild(name);

  const accemail = document.createElement('p');
  accemail.innerHTML = `${person.email}`;
  contactinfo.appendChild(accemail);
}

const getUsers = async () => {
  try {
    const response = await fetch(api, options);
    let randoNummo = Math.floor(Math.random() * 11);

    if (response.ok) {
      const data = await response.json();
      const friends = data.results;

      for (let i = 0; i < 5; i++) {
        spawnAcc(friends[i + randoNummo]);
      }
    }
  } catch (error) {
    console.log(error);
  }
};

getUsers();