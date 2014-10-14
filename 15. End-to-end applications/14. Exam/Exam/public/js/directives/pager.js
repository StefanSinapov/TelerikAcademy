/* global app */

'use strict';

app.directive('pager', [function() {
    return {
        restrict: 'A',
        templateUrl: '/partials/directives/pager',
        link: function(scope) {
            scope.previousPage = function() {
                if (scope.request.page > 1) {
                    scope.request.page--;
                    scope.filter(scope.request);
                }
            };

            scope.nextPage = function() {
                scope.request.page++;
                scope.filter(scope.request);
            };
        }
    };
}]);