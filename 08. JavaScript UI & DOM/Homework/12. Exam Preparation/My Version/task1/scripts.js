function createCalendar(container, events){
    var monthContainer = document.querySelector(container);
    var DAYS = 30;
    var fragment = document.createDocumentFragment();
    var day = document.createElement('div');
    var dayTitle = document.createElement('strong');
    var dayContent = document.createElement('div');
    var daysOfWeek = ['Sun', 'Mon', 'Tue', 'Wen', 'Thu', 'Fri', 'Sat'];

    dayTitle.className += ' day-title';
    dayContent.className += ' day-content';
    dayContent.innerHTML = '&nbsp;';

    day.appendChild(dayTitle);
    day.appendChild(dayContent);

    applyStyles(day);

    //apply data
    for (var i = 0; i < DAYS; i++) {
       date.innerHTML = daysOfWeek[i%daysOfWeek.length];

    }

    monthContainer.appendChild(fragment);
}

function applyStyles(day)
{
    day.style.width = "150px";
    day.style.height = '120px';
    day.style.display = 'inline-block';
}