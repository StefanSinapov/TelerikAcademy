/* global app */

app.factory('notifier', ['toastr', function (toastr) {
    'use strict';
    return {
        success: function (msg) {
            toastr.success(msg);
        },
        error: function (msg) {
            toastr.error(msg);
        }
    };
}]);