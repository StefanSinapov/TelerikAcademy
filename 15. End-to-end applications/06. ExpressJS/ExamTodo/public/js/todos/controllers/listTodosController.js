/* global app */

'use strict';

app.controller('ListTodosController', function ($scope, $rootScope, TodosResource, identity) {

    findTodos();

    var filters = {
        orderBy: '-published',
        query: $rootScope.searchQuery || '',
        page: $scope.currentPage
    };

    $scope.identity = identity;
    $scope.filters = filters;

    $scope.findTodos = findTodos;

    function findTodos() {
//        $scope.filters.page = $scope.currentPage;
        $scope.todos = TodosResource.query();
    }
});