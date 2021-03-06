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
			// custom routes here
            .when('/users', {
                templateUrl: 'views/partials/lists/users.html'
            })
            .when('/games', {
                templateUrl: 'views/partials/lists/games.html',
                resolve: routeUserChecks.authenticated
            })
            .otherwise({redirectTo: '/'});
    })
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:55713/')
    .constant('technologies', ["ASP.NET WebAPI", "AngularJS", "Bootstrap"])
    .constant('author', 'Stefan Sinapov')
    .constant('copyright', 'Telerik Academy')
    .constant('gitAccount', 'StefanSinapov')
    .constant('gitRepository', 'TelerikAcademy');

app.run(function ($rootScope, $location) {
    'use strict';
    $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
        if (rejection === 'not authorized') {
            $location.path('/');
        }
        if (rejection === 'is logged in') {
            $location.path('/');
        }
    });
});