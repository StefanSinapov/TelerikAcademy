/* global app */

app.directive('trips', function () {
    'use strict';

    return {
        restrict: 'A',
        templateUrl: 'views/directives/lists/trips.html',
        replace: true,
        scope: false
    };
});