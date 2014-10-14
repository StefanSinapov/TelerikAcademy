/* global app */
'use strict';

app.service('fileUpload', ['$http', '$q', function ($http, $q) {

    var uploadFile = function(formData){

        var deferred = $q.defer();

        $http.post('/api/files/', formData, {
            transformRequest: angular.identity,
            headers: {'Content-Type': undefined}
        })
            .success(function(data){
                deferred.resove(data);
            })
            .error(function(error){
                deferred.reject(error);
            });

        return deferred.promise;
    };

    return {
        uploadFile: uploadFile
    };
}]);