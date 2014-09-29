/* global app */

app.directive('datePicker', function () {
    'use strict';

    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            element.datepicker();
        }
    };
});