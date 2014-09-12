
window.onload = function() {

    var items = [{
        value: 1,
        text: 'One'
    }, {
        value: 2,
        text: 'Two'
    }, {
        value: 3,
        text: 'Three'
    }, {
        value: 4,
        text: 'Four'
    }, {
        value: "pesho",
        text: 'Pesho'
    }
    ];

    var optionsTemplateHTML = document.getElementById('options-template').innerHTML;
    var optionsTemplate = Handlebars.compile(optionsTemplateHTML);

    document.getElementById('select-container').innerHTML = optionsTemplate({
        options: items
    });
};