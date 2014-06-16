function createCalendar(container, events){
    var container = document.querySelector(container);
    var DAYS = 30;
    var fragment = document.createDocumentFragment();
    var day = document.createElement('div');
    var date = document.createElement('div');
    var content = document.createElement('div');
    var daysOfWeek = ['Sun', 'Mon', 'Tue', 'Wen', 'Thu', 'Fri', 'Sat'];
    applyStyles(day);

    //apply data
    for (var i = 0; i < DAYS; i++) {
       date.innerHTML = daysOfWeek[i%7]

    }

    container.appendChild(fragment);
}

function applyStyles(day)
{
    day.style.width = "150px";
    day.style.height = '120px';
    day.style.display = 'inline-block';
}