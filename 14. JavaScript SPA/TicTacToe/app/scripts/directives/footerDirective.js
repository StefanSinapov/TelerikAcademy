app.directive('footer', function () {
    'use strict';

    return {
        restrict: 'A',
        templateUrl: 'views/directives/footer.html',
        replace: true,
        scope: false
    };
});