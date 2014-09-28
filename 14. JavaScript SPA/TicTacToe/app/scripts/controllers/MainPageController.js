/* global app */

app.controller('MainPageController',
    function HomeController($scope, $rootScope, auth, identity, technologies, author, copyright, gitAccount, gitRepository) {
        'use strict';

        $scope.author = author;
        $scope.copyright = copyright;
        $scope.gitAccount = gitAccount;
        $scope.gitRepository = gitRepository;
        $scope.technologies = technologies;


        $scope.identity = identity;

        if (identity.isAuthenticated()) {
            $rootScope.isLoggedIn = true;
        }
        else{
            $rootScope.isLoggedIn = false;
        }
    });