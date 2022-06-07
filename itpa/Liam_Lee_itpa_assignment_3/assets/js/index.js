'use strict';

const errOutput = document.getElementById('ERRoutput');
const iframe = document.querySelector('iframe');
const point = document.getElementById('point');

function showLocation(position) {
    const { longitude, latitude } = position.coords;

    console.log(longitude);
    console.log(latitude);

    iframe.src = `https://api.mapbox.com/styles/v1/zzachariad/cl1wh10uf000s14rz3o1bqusl.html?title=view&access_token=pk.eyJ1IjoienphY2hhcmlhZCIsImEiOiJjbDF3Z205bnYwZ210M2VxY3kxaXh5dHlyIn0.dj12CYh-M0ZX6XRVenx_Rw&zoomwheel=true&fresh=true#12/${latitude}/${longitude}`     

    // mapboxgl.accessToken = `pk.eyJ1IjoienphY2hhcmlhZCIsImEiOiJjbDF3Z205bnYwZ210M2VxY3kxaXh5dHlyIn0.dj12CYh-M0ZX6XRVenx_Rw`;
    // const map = new mapboxgl.Map({
    //     container: 'map',
    //     style: `mapbox://styles/zzachariad/cl1wh10uf000s14rz3o1bqusl`,
    //     center: [longitude, latitude],
    //     zoom: 9
    // });    

    point.style.display = 'block';
}

function errorHandler() {
    errOutput.innerHTML = `Location permission is needed for the map to display your location. <br> Refresh page to see the permission request.`;
}

window.onload = function () {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showLocation, errorHandler, { enableHighAccuracy: true });
    } else {
        console.log(`Geolocation is not supported by your browser`);
    }
}