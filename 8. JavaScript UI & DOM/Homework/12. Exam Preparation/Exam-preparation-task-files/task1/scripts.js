function createCalendar(selector, events) {
    var container = document.querySelector(selector);

    var dayBox = document.createElement('div');
    var dayBoxTitle = document.createElement('strong');
    var dayBoxContent = document.createElement('div');

    var daysOfWeek = ["Sun", 'Mon', 'Tue', 'Wed', "Thu", 'Fri', 'Sat'];
    var DAYS_IN_MOUNT_COUNT=30;
    dayBoxContent.innerHTML = "&nbsp;";

    dayBoxTitle.className = 'day-title';
    dayBoxContent.className = "day-content";

    dayBox.appendChild(dayBoxTitle);
    dayBox.appendChild(dayBoxContent);

    var selectedBox = null;

   // Styles
    container.style.width = (150 * 7.5) + 'px';
    dayBox.style.margin = 0;
    dayBox.style.padding = 0;
    dayBox.style.border = '1px solid black';
    dayBox.style.width = "150px";
    dayBox.style.height = "120px";
    dayBox.style.display = 'inline-block';
    dayBoxTitle.style.display = 'inline-block';
    dayBoxTitle.style.width = '100%';
    dayBoxTitle.style.background = 'gray';
    dayBoxTitle.style.textAlign= 'center';
    dayBoxTitle.style.color = 'white';

    function createmonthBoxes(){
        var dayBoxes = [];

        for(var i = 0; i < DAYS_IN_MOUNT_COUNT; i += 1) {
            //var day = new Date(2014, 5, i).toDateString();
            var dayOfWeek = daysOfWeek[i%daysOfWeek.length];
            dayBoxTitle.innerHTML = dayOfWeek + " " + (i + 1) + ' June 2014';
            dayBoxes.push(dayBox.cloneNode(true));
        }

        return dayBoxes;
    }
    function addEvents(boxes, events) {
        for(var i = 0; i < events.length; i+=1){
            var event = events[i];
            var content = boxes[event.date -1].querySelector('.day-content');
            content.innerHTML = event.hour + ' ' + event.title;
        }
    }
    function onBoxMouseover(ev){
        if(selectedBox !== this){
            this.style.background = 'gold';
        }
    }
    function onBoxMouseout(ev){
        if(selectedBox !== this){
            this.style.background = '';
        }
    }
    function onBoxClick(ev){
        if(selectedBox){
            selectedBox.style.background ='';
        }
        if(selectedBox && selectedBox === this)
        {
            selectedBox = null;
        }
        else {
            this.style.background = 'yellowgreen';
            selectedBox = this;
        }
    }

    var boxes = createmonthBoxes();
    addEvents(boxes, events);

    var docFragment = document.createDocumentFragment();

    for(var i = 0; i < boxes.length; i += 1){
        boxes[i].addEventListener('click', onBoxClick);
        boxes[i].addEventListener('mouseover', onBoxMouseover);
        boxes[i].addEventListener('mouseout', onBoxMouseout);
        docFragment.appendChild(boxes[i]);
    }
    container.appendChild(docFragment);
}