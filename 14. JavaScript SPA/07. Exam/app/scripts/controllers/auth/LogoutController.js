/* global app */

app.controller('LogoutController',
    function LogoutController($rootScope, $scope, $resource, $location, auth, notifier, appData) {
        'use strict';
        $scope.logout = function () {
            appData.user.logout()
                .then(function () {
                    notifier.success('Successful logout!');
                    $rootScope.isLoggedIn = false;
                    $location.path('/');
                }, function(reason){
					notifier.error('Something wrong with server connection: ' + reason);
                    $rootScope.isLoggedIn = false;
                    $location.path('/');
				});
        };
    });