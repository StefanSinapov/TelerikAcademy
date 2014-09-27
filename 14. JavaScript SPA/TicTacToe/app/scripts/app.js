/* global angular toastr  */

var ticTacToeApp = angular.module('ticTacToeApp', ['ngResource', 'ngRoute', 'ngCookies'])
    .config(function ($routeProvider) {
        'use strict';
        $routeProvider
            .when('/', {
                templateUrl: 'views/home.html'
            })
            .when('/register', {
                templateUrl: 'views/partials/auth/register.html'
            })
            .when('/login', {
                templateUrl: 'views/partials/auth/login.html'
            })
            .when('/users', {
                templateUrl: 'views/partials/lists/users.html'
            })
            .when('/scores', {
                templateUrl: 'views/partials/lists/scores.html'
            })
            .when('/games', {
                templateUrl: 'views/partials/lists/games.html'
            })
            .otherwise({redirectTo: '/'});
    })
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:55713/')
    .constant('technologies', ["ASP.NET WebAPI", "AngularJS", "Bootstrap"])
    .constant('author', 'Stefan Sinapov')
    .constant('copyright', 'Telerik Academy')
    .constant('gitAccount', 'StefanSinapov')
    .constant('gitRepository', 'Tic-Tac-Toe-WebAPI-and-SPA');