/* global app, angular */

'use strict';

app.controller('SettingsController', function SettingsController($scope, $location, $window, identity, auth, notifier, UsersResource) {

    $scope.user = {
        username: identity.currentUser.username,
        firstName: identity.currentUser.firstName,
        lastName: identity.currentUser.lastName
    };

    $scope.submit = function (updatedUser) {
        auth.update(updatedUser).then(function () {
            notifier.success('Updated successfully!');
            $location.path('/');
        }, function (error) {
            notifier.error(error.message || error);
        });
    };


    $scope.deleteAccount = function () {
        var response = $window.prompt('Are you sure, Please enter your username to confirm');

        if (response) {
            if (response === identity.currentUser.username) {
                UsersResource.delete().$promise
                    .then(function (response) {
                        notifier.success('Account deleted successfully');
                        identity.currentUser = undefined;
                        $location.path('/');
                    },
                    function (error) {
                        notifier.success('Failed to delete account' + error.message || error);
                    }
                );
            }
            else {
                notifier.warning("Wrong username");
            }
        }
        else {
            notifier.warning('Please be more careful next time!');
        }
    };
});