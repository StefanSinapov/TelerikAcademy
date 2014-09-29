/* global angular, toastr  */

var app = angular.module('app', ['ngResource', 'ngRoute', 'ngCookies'])
    .config(function ($routeProvider) {
        'use strict';

        var routeUserChecks = {
            adminRole: {
                authenticate: function (auth) {
                    return auth.isAuthorizedForRole('admin');
                }
            },
            authenticated: {
                authenticate: function (auth) {
                    return auth.isAuthenticated();
                }
            },
            loggedOut: {
                authenticate: function (auth) {
                    return auth.isLoggedOut();
                }
            }
        };

        $routeProvider
            .when('/', {
                templateUrl: 'views/home.html'
            })
            .when('/register', {
                templateUrl: 'views/partials/auth/register.html',
                resolve: routeUserChecks.loggedOut
            })
            .when('/login', {
                templateUrl: 'views/partials/auth/login.html',
                resolve: routeUserChecks.loggedOut
            })
            .when('/unauthorized', {
                templateUrl: '/views/partials/auth/unauthorized.html',
                resolve: routeUserChecks.loggedOut
            })
			// custom routes here
            .when('/drivers', {
                templateUrl: 'views/partials/lists/drivers.html'
            })
            .when('/drivers/:id', {
                templateUrl: 'views/partials/driver-details.html',
                resolve: routeUserChecks.authenticated
            })
            .when('/trips', {
                templateUrl: 'views/partials/lists/trips.html'
            })
            .when('/trips/create', {
                templateUrl: 'views/partials/create-trip.html',
                resolve: routeUserChecks.authenticated
            })
            .when('/trips/:id', {
                templateUrl: 'views/partials/trip-details.html',
                resolve: routeUserChecks.authenticated
            })
            .when('/games', {
                templateUrl: 'views/partials/lists/games.html',
                resolve: routeUserChecks.authenticated
            })
            .otherwise({redirectTo: '/'});
    })
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://spa2014.bgcoder.com/')
    .constant('copyright', 'Telerik Academy');

app.run(function ($rootScope, $location) {
    'use strict';
    $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
        if (rejection === 'not authorized') {
            $location.path('/unauthorized');
        }
        if (rejection === 'is logged in') {
            $location.path('/');
        }
    });
});