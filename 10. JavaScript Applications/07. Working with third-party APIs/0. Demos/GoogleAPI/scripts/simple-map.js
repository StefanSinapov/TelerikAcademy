var map;
var x = 43;
var y = 25;
var z = 7;

function initialize() {
    var mapOptions = {
        zoom: z,
        center: new google.maps.LatLng(x, y),
        mapTypeId: google.maps.MapTypeId.SATELLITE //ROADMAP
    };
    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);
}

document.getElementById('get-coordinates').addEventListener('click', function () {
    x = document.getElementById('coor-x').value;
    y = document.getElementById('coor-y').value;
    z = document.getElementById('zoom').value;

    x = parseInt(x);
    y = parseInt(y);
    z = parseInt(z);

    if (isNaN(x) || isNaN(y) || isNaN(z)) {
        alert("Invalid parameters. Please, enter numbers!");
    }
    else {
        var pos = new google.maps.LatLng(x, y);
        map.panTo(pos);
        map.setZoom(z);
    }
}, false);

google.maps.event.addDomListener(window, 'load', initialize());

console.log(map);