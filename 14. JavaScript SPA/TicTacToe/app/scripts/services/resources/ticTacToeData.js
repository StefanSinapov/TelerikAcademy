/* global ticTacToeApp */

ticTacToeApp.factory('ticTacToeData', function ($resource, $http, $q, authorization, baseServiceUrl) {
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
        getUsers: function () {
            var deferred = $q.defer();

            $http.get(baseServiceUrl + 'api/Users/')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.resolve(data);
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
                    deferred.resolve(data);
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
        }

    };
});