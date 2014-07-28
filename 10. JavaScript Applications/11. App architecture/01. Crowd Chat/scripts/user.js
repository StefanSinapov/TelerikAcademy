define(function () {
    'use strict';
    var User = (function () {
        var storage = sessionStorage;

        function setName(username, isRememberMe) {
            if (isRememberMe) {
                storage = localStorage;
            }
            else {
                storage = sessionStorage;
            }
            storage.setItem('username', username);
        }

        function getName() {
            return sessionStorage.getItem('username') || localStorage.getItem('username');
        }

        function deleteName() {
            storage.clear();
        }

        function isLoggedIn() {
            return getName() != null;
        }

        return {
            setName: setName,
            getName: getName,
            deleteName: deleteName,
            isLoggedIn: isLoggedIn
        }
    }());

    return User;
});