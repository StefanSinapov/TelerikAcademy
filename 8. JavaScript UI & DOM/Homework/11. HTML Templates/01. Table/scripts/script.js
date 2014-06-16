var courses = [{
    title: 'Course Introduction',
    firstDate: new Date(),
    secondDate: new Date()
}, {
    title: 'Document Object Model',
    firstDate: new Date(),
    secondDate: new Date()
}, {
    title: 'HTML5 Canvas',
    firstDate: new Date(),
    secondDate: new Date()
}, {
    title: 'Kinetic.js Overview',
    firstDate: new Date(),
    secondDate: new Date()
}, {
    title: 'SVG and Raphael.js',
    firstDate: new Date(),
    secondDate: new Date()
}, {
    title: 'DOM Operations',
    firstDate: new Date(),
    secondDate: new Date()
}];

window.onload = function() {


    Handlebars.registerHelper('each', function(items, options) {
        var html = "";

        for (var index in items) {
            var item = items[index];
            html += options.fn({
                index: index,
                title: item.title,
                firstDate: item.firstDate.toUTCString(),
                secondDate: item.secondDate.toUTCString()
            });
        }

        return html;
    });

    var tableTemplateHTML = document.getElementById('table-body-template').innerHTML;
    var tableTemplate = Handlebars.compile(tableTemplateHTML);

    document.getElementById('table-body-container').innerHTML = tableTemplate({
        courses: courses
    });
};