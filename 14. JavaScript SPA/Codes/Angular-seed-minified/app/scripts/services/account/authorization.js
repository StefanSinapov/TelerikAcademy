/* global app */

app.factory('authorization', ['identity', function(identity) {
    'use strict';
    return {
        getAuthorizationHeader: function() {
            return {
                'Content-Type': 'application/x-www-form-urlencoded',
                'Authorization': 'Bearer ' + identity.getCurrentUser().access_token
            };
        }
    };
}]);