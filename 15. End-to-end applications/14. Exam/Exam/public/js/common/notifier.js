/* global app */

'use strict';

app.factory('notifier', function (toastr) {
    return {
        success: function (msg) {
            toastr.success(msg);
        },
        warning: function (msg) {
            toastr.warning(msg);
        },
        error: function (msg) {
            toastr.error(msg);
        }
    };
});