define(['http-request', 'sha1'], function (request, sha1) {
    'use strict';
    var MainPersistor = (function () {
        function MainPersistor(url) {
            this.url = url;
            this.user = new UserPersistor(this.url);
            this.post = new PostPersistor(this.url);
        }

        return MainPersistor;
    }());

    var UserPersistor = (function () {
        function UserPersistor(url) {
            this.url = url;
            this.username = localStorage.getItem('username');
            this.sessionKey = localStorage.getItem('sessionKey');
            this.isUserLoggedIn = checkIfLoggedIn;
        }

        UserPersistor.prototype.register = function (username, password) {
            var url = this.url + 'user',
                userData = {
                    "username": username,
                    "authCode": sha1.SHA1(username + password).toString()
                };
            return request.postJSON(url, userData);
        };

        UserPersistor.prototype.login = function (username, password) {
            var url = this.url + 'auth',
                userData = {
                    "username": username,
                    "authCode": sha1.SHA1(username + password).toString()
                };
            var self = this;
            return request.postJSON(url, userData)
                .then(function (data) {
                    localStorage.setItem('sessionKey', data.sessionKey);
                    localStorage.setItem('username', data.username);
                    self.username = localStorage.getItem('username');
                    self.sessionKey = localStorage.getItem('sessionKey');
                    return data;
                });
        };

        UserPersistor.prototype.logout = function () {
            var url = this.url + 'user',
                header = { 'X-SessionKey': localStorage.getItem('sessionKey')};
            var self = this;
            return request.putHeaders(url, header)
                .then(function (data) {
                    localStorage.removeItem('sessionKey');
                    localStorage.removeItem('username');
                    self.username = localStorage.getItem('username');
                    self.sessionKey = localStorage.getItem('sessionKey');
                    return data;
                });
        };

        function checkIfLoggedIn()
        {

            return localStorage.getItem('username') != null && localStorage.getItem('sessionKey')!= null;
        }

        return UserPersistor;
    }());

    var PostPersistor = (function () {
        function PostPersistor(url) {
            this.url = url
        }

        PostPersistor.prototype.getAll = function(){
            var url = this.url + 'post';
            return request.getJSON(url);
        };

        PostPersistor.prototype.add = function(title, body){
            var url = this.url + 'post';
            var postData = {
                "title": title,
                "body": body
                },
                header = { 'X-SessionKey': localStorage.getItem('sessionKey')};

            return request.postJSONWithHeaders(url, postData, header);
        };

        return PostPersistor;
    }());

    return MainPersistor;
});