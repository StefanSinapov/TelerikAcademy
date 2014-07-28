define(['jquery'], function ($) {
    'use strict';
    var HttpRequest = (function () {


        function makeHTTPRequest(url, type, data, headers) {
            var $deferred = $.Deferred();

            var stringifiedData = '';
            if (data) {
                stringifiedData = JSON.stringify(data);
            }

            $.ajax({
                url: url,
                type: type,
                data: stringifiedData,
                headers: headers,
                contentType: 'application/json',
                timeout: 5000,
                success: function(result){
                    $deferred.resolve(result);
                },
                error: function(reason){
                    $deferred.reject(reason);
                }
            });

            return $deferred.promise();
        }


        function getJSON(url) {
            return makeHTTPRequest(url, 'GET');
        }

        function postJSON(url, data){
            return makeHTTPRequest(url, 'POST', data);
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON
        }
    }());

    return HttpRequest;
});