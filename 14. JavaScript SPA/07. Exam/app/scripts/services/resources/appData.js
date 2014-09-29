/* global app */

app.factory('appData', function ($resource, $http, $q, authorization, baseServiceUrl, identity) {
    'use strict';

    var usersApi = baseServiceUrl + 'api/users';

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
            user,
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
            .error(function (reason) {
                deferred.reject(reason);
            });

        return deferred.promise;
    }

    function login(user) {
        var deferred = $q.defer();

        user.grant_type = 'password';

        $http.post(usersApi + '/login', user,
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

    function getInfo() {
        var deferred = $q.defer();
        var headers = authorization.getAuthorizationHeader();
        $http.get(usersApi + '/userInfo', {
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


    /* Drivers: */

    var driversApi = baseServiceUrl + 'api/drivers';

    function getLatestDrivers() {
        var deferred = $q.defer();

        $http.get(driversApi)
            .success(function (data) {
                deferred.resolve(data);
            })
            .error(function (data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    function getDriversById(id) {

        var deferred = $q.defer();

        var headers = authorization.getAuthorizationHeader();

        $http.get(driversApi + '/' + id,
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

    function filterDrivers(page, username) {

        var deferred = $q.defer();
        var headers = authorization.getAuthorizationHeader();

        $http.get(driversApi + '?page=' + page + "&username=" + username, {
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

    /* Trips: */

    var tripsApi = baseServiceUrl + 'api/trips';

    function getLatestTrips() {
        var deferred = $q.defer();

        $http.get(tripsApi)
            .success(function (data) {
                deferred.resolve(data);
            })
            .error(function (data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    function cities() {
        var deferred = $q.defer();

        $http.get(baseServiceUrl + 'api/cities')
            .success(function (data) {
                deferred.resolve(data);
            })
            .error(function (data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    function create(trip) {
        var deferred = $q.defer();

        var headers = authorization.getAuthorizationHeader();

        $http.post(tripsApi + '/Create', trip,
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
            .error(function (reason) {
                deferred.reject(reason);
            });

        return deferred.promise;
    }

    function filterTrips(filterOptions) {

        var deferred = $q.defer();
        var headers = authorization.getAuthorizationHeader();

        $http.get(tripsApi + '?page=' + filterOptions.page + '&orderBy=' + filterOptions.orderBy +
            '&orderType=' + filterOptions.orderType + '&from=' + filterOptions.from +
            '&to=' + filterOptions.to +
            '&finished=' + filterOptions.finished + '&onlyMine=' + filterOptions.onlyMine, {
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

    function getTripsById(id) {

        var deferred = $q.defer();
        var headers = authorization.getAuthorizationHeader();

        $http.get(tripsApi + "/" + id, {
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

    function joinTrip(id) {

        var deferred = $q.defer();
        var headers = authorization.getAuthorizationHeader();

        $http.put(tripsApi + "/" + id, {}, {
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

    function getStats(){
        var deferred = $q.defer();

        $http.get(baseServiceUrl + 'api/stats')
            .success(function (data) {
                deferred.resolve(data);
            })
            .error(function (data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    return {
        user: {
            register: register,
            login: login,
            logout: logout,
            getInfo: getInfo
        },
        drivers: {
            latest: getLatestDrivers,
            getById: getDriversById,
            filter: filterDrivers
            // TODO: more here
        },
        trips: {
            latest: getLatestTrips,
            cities: cities,
            create: create,
            filter: filterTrips,
            getById: getTripsById,
            join: joinTrip
            //TODO: rest here
        },
        stats: getStats,
    };
});