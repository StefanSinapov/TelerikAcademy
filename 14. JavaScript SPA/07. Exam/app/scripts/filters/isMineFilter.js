/* global app */

app.filter("isMineFilter", function () {
    'use strict';

    return function (isMine) {
        if(isMine){
            return 'glyphicon glyphicon-ok';
        }
        else{
            return 'glyphicon glyphicon-remove';
        }
    };
});