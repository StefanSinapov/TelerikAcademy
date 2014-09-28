/* global app */

app.factory('appData', function ($resource, $http, $q, authorization, baseServiceUrl) {
    'use strict';

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
        login: function (username, password) {
            var deferred = $q.defer();

            $http.post(url + 'Token', {
                username: username,
                password: password,
                grant_type: "password"
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
        },
		logout: function () {
			var deferred = $q.defer();

			var headers = authorization.getAuthorizationHeader();
			$http.post(usersApi + '/logout', {}, { headers: headers })
				.success(function () {
					identity.setCurrentUser(undefined);
					deferred.resolve();
				})
				.error(function(){
					identity.setCurrentUser(undefined);
					deferred.reject();
				});

			return deferred.promise;
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
        createGame: function(gameName){
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();

            $http.post(baseServiceUrl + 'api/Games/Create',
                {
                    Name: gameName
                },{
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: headers
                })
                .success(function(data){
                    deferred.resolve(data);
                })
                .error(function(reason){
                    deferred.reject(reason);
                });

            return deferred.promise;
        },
        getGameStatus: function(gameId){
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();

            $http.post(baseServiceUrl + 'api/Games/Status',
                {
                    GameId: gameId
                },{
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: headers
                })
                .success(function(data){
                    deferred.resolve(data);
                })
                .error(function(reason){
                    deferred.reject(reason);
                });

            return deferred.promise;
        },
        playGame: function(gameId, row, col){
            var deferred = $q.defer();
            var headers = authorization.getAuthorizationHeader();

            $http.post(baseServiceUrl + 'api/Games/Play',
                {
                    GameId: gameId,
                    Row: row,
                    Col: col
                },{
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: headers
                })
                .success(function(data){
                    deferred.resolve(data);
                })
                .error(function(reason){
                    deferred.reject(reason);
                });

            return deferred.promise;
        }
    };
});