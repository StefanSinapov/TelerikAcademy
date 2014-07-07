(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery-2.1.1.min",
            'handlebars': 'libs/handlebars-v1.3.0',
            'data': 'data',
            'controls': 'controls'
        }
    });

    require(['handlebars', 'jquery', 'data', 'controls'], function(Handlebars, $, data, Controls){
        var PERSON_TEMPLATE_ID = '#person-template',
            COMBOBOX_CONTAINER_ID = '#combo-box';

        var container = $(COMBOBOX_CONTAINER_ID),
            htmlTemplate = $(PERSON_TEMPLATE_ID).html(),
            comboBoxTemplate = Handlebars.compile(htmlTemplate);

        var comboBox = new Controls.ComboBox({
            container: container,
            data: data,
            template: comboBoxTemplate
        });
    })
}());