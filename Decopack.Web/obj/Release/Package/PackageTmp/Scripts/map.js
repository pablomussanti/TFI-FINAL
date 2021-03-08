//let myMap = L.map('myMap').setView([-34.61, -58.50], 8)

//L.tileLayer(`https://maps.wikimedia.org/osm-intl/{z}/{x}/{y}.png`, {
//    maxZoom: 18,
//}).addTo(myMap);

//let marker = L.marker([-34.61, -58.50]).addTo(myMap)
//let marker3 = L.marker([-32.88, -68.87]).addTo(myMap)

//let iconMarker = L.icon({
//    iconUrl: 'https://efectocolibri.com/wp-content/uploads/2018/11/n%C3%BAmero-uno-valores-efecto-colibr%C3%AD-1024x576.jpg',
//    iconSize: [60, 60],
//    iconAnchor: [30, 60]
//})

//let marker2 = L.marker([-34.61, -58.50], { icon: iconMarker }).addTo(myMap)


//myMap.doubleClickZoom.disable()
//myMap.on('dblclick', e => {
//    let latLng = myMap.mouseEventToLatLng(e.originalEvent);

//    L.marker([latLng.lat, latLng.lng], { icon: iconMarker }).addTo(myMap)
//})

//navigator.geolocation.getCurrentPosition(
//    (pos) => {
//        const { coords } = pos
//        const { latitude, longitude } = coords
//        L.marker([latitude, longitude], { icon: iconMarker }).addTo(myMap)

//        setTimeout(() => {
//            myMap.panTo(new L.LatLng(latitude, longitude))
//        }, 5000)
//    },
//    (error) => {
//        console.log(error)
//    },
//    {
//        enableHighAccuracy: true,
//        timeout: 5000,
//        maximumAge: 0
//    })