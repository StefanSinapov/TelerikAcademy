/* global angular */

var ticTacToeApp = angular.module('ticTacToeApp', ['ngResource', 'ngRoute'])
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
            .otherwise({redirectTo: '/'});
    })
    .constant('author', 'Stefan Sinapov')
    .constant('copyright', 'Telerik Academy')
    .constant('gitAccount', 'StefanSinapov')
    .constant('gitRepository', 'Tic-Tac-Toe-WebAPI-and-SPA');