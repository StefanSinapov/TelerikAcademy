/* global app */

app.factory('appData', function ($resource, $http, $q, authorization, baseServiceUrl, identity) {
    'use strict';

    var usersApi = baseServiceUrl + 'api/account';

    function getGames(type) {
        var deferred = $q.defer();

        var headers = authorization.getAuthorizationHeader();
        $http.get(baseServiceUrl + 'api/Games/' + type,
            {
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj) {
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    }
                    return str.join("&");
                },
                headers: headers
            })
            .success(function (data) {
                deferred.resolve(data);
            })
            .error(function (data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    function register(user) {
        var deferred = $q.defer();

        $http.post(usersApi + '/register',
            {
                email: user.email,
                password: user.password,
                confirmPassword: user.confirmPassword
            },
            {
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            })
            .success(function (data) {
                deferred.resolve(data);
            })
            .error(function (data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    function login(user) {
        var deferred = $q.defer();

        user.grant_type = 'password';

        $http.post(baseServiceUrl + 'Token', user,
            {
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj)
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            })
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
    }

    function logout() {
        var deferred = $q.defer();
        var headers = authorization.getAuthorizationHeader();

        $http.post(usersApi + '/logout', {}, {
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            headers: headers
        })
            .success(function () {
                identity.setCurrentUser(undefined);
                deferred.resolve();
            })
            .error(function () {
                identity.setCurrentUser(undefined);
                deferred.reject();
            });

        return deferred.promise;
    }

    return {
        user: {
            register: register,
            login: login,
            logout: logout
        },
        getUsers: function () {
            var deferred = $q.defer();

            $http.get(baseServiceUrl + 'api/Users/')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        getScores: function () {
            var deferred = $q.defer();

            $http.get(baseServiceUrl + 'api/Scores/')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },

        getMyGames: function () {
            return getGames('MyGames');
        },
        getAvailableGames: function () {
            return getGames('AvailableGames');
        },
        getJoinedGames: function () {
            return getGames('JoinedGames');
        },

        joinGame: function (gameId) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.post(baseServiceUrl + 'api/Games/Join', {
                    GameId: gameId
                },
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: headers
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        createGame: function (gameName) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();

            $http.post(baseServiceUrl + 'api/Games/Create',
                {
                    Name: gameName
                }, {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: headers
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (reason) {
                    deferred.reject(reason);
                });

            return deferred.promise;
        },
        getGameStatus: function (gameId) {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();

            $http.post(baseServiceUrl + 'api/Games/Status',
                {
                    GameId: gameId
                }, {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: headers
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (reason) {
                    deferred.reject(reason);
                });

            return deferred.promise;
        },
        playGame: function (gameId, row, col) {
            var deferred = $q.defer();
            var headers = authorization.getAuthorizationHeader();

            $http.post(baseServiceUrl + 'api/Games/Play',
                {
                    GameId: gameId,
                    Row: row,
                    Col: col
                }, {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: headers
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (reason) {
                    deferred.reject(reason);
                });

            return deferred.promise;
        }
    };
});