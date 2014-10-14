/* global app, angular */

'use strict';


app.factory('auth', function ($http, $q, identity, UsersResource, notifier) {

    return {
        update: function (user) {
            var deferred = $q.defer();

            var updatedUser = new UsersResource(user);
            updatedUser._id = identity.currentUser._id;
            updatedUser.$update()
                .then(function () {
                    identity.currentUser.firstName = updatedUser.firstName;
                    identity.currentUser.lastName = updatedUser.lastName;
                    deferred.resolve();
                }, function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        register: function (user) {
            var deferred = $q.defer();

            $http.post('/auth/register', user)
                .success(function (user) {
                    identity.currentUser = user;
                    deferred.resolve(user);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },
        login: function (user) {
            var deferred = $q.defer();

            $http.post('/auth/login', user).success(function (response) {
                if (response.success) {
                    var user = new UsersResource();
                    angular.extend(user, response.user);
                    identity.currentUser = user;
                    deferred.resolve(true);
                }
                else {
                    deferred.resolve(false);
                }
            });

            return deferred.promise;
        },
        logout: function () {
            var deferred = $q.defer();

            $http.get('/auth/logout')
                .success(function () {
                    identity.currentUser = undefined;
                    deferred.resolve();
                });

            return deferred.promise;
        },
        isAuthenticated: function () {
            if (identity.isAuthenticated()) {
                return true;
            }
            else {
                return $q.reject('not authorized');
            }
        },
        isAuthorizedForRole: function (role) {
            if (identity.isAuthorizedForRole(role)) {
                return true;
            }
            else {
                return $q.reject('not authorized');
            }
        },
        isLoggedOut: function () {
            if (identity.isAuthenticated()) {
                return $q.reject('is logged in');
            }
            else {
                return true;
            }
        }
    };
});