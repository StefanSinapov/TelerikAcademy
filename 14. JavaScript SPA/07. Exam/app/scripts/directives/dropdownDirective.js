/* global app */

app.directive('dropdown', function () {
    'use strict';

    return {
        restrict: 'A',
        templateUrl: 'views/directives/dropdown.html',
        replace: true,
        scope: {
            options: '=',
            selectValue: '=value'
        }
    };
});