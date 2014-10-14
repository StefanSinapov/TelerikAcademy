/* global angular, toastr */

'use strict';

var app = angular.module('app', ['ngResource', 'ngRoute']).value('toastr', toastr);

app.config(function($routeProvider, $locationProvider) {

    var routeUserChecks = {
        adminRole: {
            authenticate: function(auth) {
                return auth.isAuthorizedForRole('admin');
            }
        },
        authenticated: {
            authenticate: function(auth) {
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
            templateUrl: '/partials/main/home',
            controller: 'MainController'
        })
        .when('/login', {
            templateUrl: '/partials/account/login',
            controller: 'LoginController',
            resolve: routeUserChecks.loggedOut
        })
        .when('/register', {
            templateUrl: '/partials/account/register',
            controller: 'RegisterController',
            resolve: routeUserChecks.loggedOut
        })
        .when('/profile', {
            templateUrl: '/partials/account/profile',
            controller: 'ProfileController',
            resolve: routeUserChecks.authenticated
        })
        .when('/settings',{
            templateUrl: '/partials/account/settings',
            controller: 'SettingsController',
            resolve: routeUserChecks.authenticated
        })
        .when('/files/upload', {
            templateUrl: '/partials/files/upload',
            controller: 'UploadController',
            resolve: routeUserChecks.authenticated
        })
        .when('/files/upload-results', {
            templateUrl: '/partials/files/upload-results',
            resolve: routeUserChecks.authenticated
        });
});

app.run(function($rootScope, $window, notifier) {
    $rootScope.$on('$routeChangeError', function(ev, current, previous, rejection) {
        if (rejection === 'not authorized') {
            notifier.error('You are not authorized!');
            $window.history.back();
        }
        if (rejection === 'is logged in') {
            notifier.error('You are already sign in, please logout first!');
            $window.history.back();
        }
    });
});
