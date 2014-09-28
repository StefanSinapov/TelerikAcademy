/* global app */

app.filter("boardSignFilter", function () {
    'use strict';

    return function (sign) {
        switch (sign) {
            case "-": {
                return "";
            }
            case "X":
            {
                return "images/x-sign.png";
            }
            case "O":
            {
                return "images/o-sign.png";
            }
        }
    };
});