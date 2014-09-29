/* global app */

app.directive('drivers', function () {
    'use strict';

    return {
        restrict: 'A',
        templateUrl: 'views/directives/lists/drivers.html',
        replace: true,
        scope: false
    };
});