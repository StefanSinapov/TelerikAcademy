/* global app */

'use strict';

app.controller('ProfileController', function ProfileController($scope, $location, identity, notifier) {

    $scope.user = identity.currentUser;

});