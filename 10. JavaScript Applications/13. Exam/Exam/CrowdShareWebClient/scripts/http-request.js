define(['jquery', 'q'], function($, Q) {
    'use strict';
    var HttpRequester = (function() {
        var makeHttpRequest = function(url, type, data, headers) {
            var deferred = Q.defer();

            $.ajax({
                url: url,
                type: type,
                data: data ? JSON.stringify(data) : "",
                headers: headers,
                contentType: "application/json",
                timeout: 5000,
                success: function(resultData) {
                    deferred.resolve(resultData);
                },
                error: function(errorData) {
                    deferred.reject(errorData);
                }
            });

            return deferred.promise;
        };

        var getJSON = function(url) {
            return makeHttpRequest(url, "GET");
        };

        var postJSON = function(url, data) {
            return makeHttpRequest(url, "POST", data);
        };

        function putHeaders(url, headers){
            return makeHttpRequest(url, 'PUT', null, headers);
        }

        function postJSONWithHeaders(url, data, headers){
            return makeHttpRequest(url, 'POST', data, headers);
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            putHeaders: putHeaders,
            postJSONWithHeaders: postJSONWithHeaders
        }
    }());

    return HttpRequester;
});