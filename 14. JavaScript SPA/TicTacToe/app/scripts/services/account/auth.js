/* global app */
app.factory('auth', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl',
    function ($http, $q, identity, authorization, baseServiceUrl) {
        'use strict';
        var usersApi = baseServiceUrl + '/api/account';

        return {
            register: function (user) {
                var deferred = $q.defer();

                $http.post(usersApi + '/register', user)
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (response) {
                        deferred.reject(response);
                    });

                return deferred.promise;
            },
            login: function (user) {
                var deferred = $q.defer();
                user['grant_type'] = 'password';
                $http.post(baseServiceUrl + '/Token', 'username=' + user.username + '&password=' + user.password + '&grant_type=password', { headers: {'Content-Type': 'application/x-www-form-urlencoded'} })
                    .success(function (response) {
                        if (response["access_token"]) {
                            identity.setCurrentUser(response);
                            deferred.resolve(true);
                        }
                        else {
                            deferred.reject(false);
                        }
                    })
                    .error(function (response) {
                        deferred.reject(response);
                    });

                return deferred.promise;
            },
            logout: function () {
                var deferred = $q.defer();

                var headers = authorization.getAuthorizationHeader();
                $http.post(usersApi + '/logout', {}, { headers: headers })
                    .success(function () {
                        identity.setCurrentUser(undefined);
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

            isLoggedOut: function () {
                if (identity.isAuthenticated()) {
                    return $q.reject('is logged in');
                }
                else {
                    return true;
                }
            }
        };
    }]);