/* global app */
'use strict';

app.controller("UploadController", function($scope, notifier){

    $scope.counter = [0];
    $scope.addFile = function(){
        $scope.counter.push($scope.counter.length);
        console.log($scope.counter);
    };

    $scope.submit = function(uploadForm){
        console.log(uploadForm);
    };
});