app.directive('navigationBar', function () {
    'use strict';

    return {
        restrict: 'A',
        templateUrl: 'views/directives/navigation-bar.html',
        replace: true,
        scope: false
    };
});