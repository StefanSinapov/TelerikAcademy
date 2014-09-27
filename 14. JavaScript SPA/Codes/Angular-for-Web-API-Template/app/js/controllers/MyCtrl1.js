'use strict';

app.controller('MyCtrl1', ['$scope', 'notifier', function($scope, notifier) {
    notifier.success('Partial 1!');
    notifier.error('Partial 1');
}]);