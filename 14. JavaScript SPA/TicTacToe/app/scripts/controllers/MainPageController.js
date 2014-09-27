/* global ticTacToeApp */

ticTacToeApp.controller('MainPageController',
    function HomeController($scope, $rootScope, auth, author, copyright, gitAccount, gitRepository) {
        'use strict';

        $scope.author = author;
        $scope.copyright = copyright;
        $scope.gitAccount = gitAccount;
        $scope.gitRepository = gitRepository;
        $scope.technologies = ["ASP.NET WebAPI", "AngularJS", "Bootstrap"];


        if (auth.isAuthenticated()) {
            $rootScope.isLoggedIn = true;
            $rootScope.username = auth.getUsername();
        }
    });