define(['jquery', 'mustache'], function ($, Mustache) {
    'use strict';
    var UiController = (function () {
        function UiController() {
            this.loginFormPath = 'views/login-template.html';
            this.registerFormPath = 'views/register-template.html';
            this.accountFormPath = 'views/account-template.html';
            this.mainPagePath = 'views/post-template.html';
            this.postMessagePath = 'views/post-message-template.html';


        }

        UiController.prototype.renderLoginForm = function (container) {
            $(container).load(this.loginFormPath);
        };

        UiController.prototype.renderRegistrationForm = function (container) {
            $(container).load(this.registerFormPath);
        };
        UiController.prototype.renderAccountForm = function (container) {
            $(container).load(this.accountFormPath);
        };

        UiController.prototype.renderMainPage = function (container) {
            $(container).load(this.mainPagePath);
        };

        UiController.prototype.renderAllPosts = function (container, data) {
            data = [
                {
                    "id": 47,
                    "title": "borisov90",
                    "body": "Вилии Вуцов - Овча Глава, Овча глава",
                    "postDate": "2014-07-29T12:19:32.562Z",
                    "user": {
                        "id": 72,
                        "username": "pencho"
                    }
                },
                {
                    "id": 48,
                    "title": "sto godini",
                    "body": "vechno vtori",
                    "postDate": "2014-07-29T12:20:55.971Z",
                    "user": {
                        "id": 46,
                        "username": "kirilt"
                    }
                },
                {
                    "id": 49,
                    "title": "borisov90",
                    "body": "Също така, Лилчо Арсов - татарско кюфте. Татарско кюфте. Татарско кюфте!",
                    "postDate": "2014-07-29T12:22:40.340Z",
                    "user": {
                        "id": 72,
                        "username": "pencho"
                    }
                },
                {
                    "id": 50,
                    "title": "borisov90",
                    "body": "Също така, Лилчо Арсов - татарско кюфте. Татарско кюфте. Татарско кюфте!",
                    "postDate": "2014-07-29T12:22:41.744Z",
                    "user": {
                        "id": 72,
                        "username": "pencho"
                    }
                }
            ];
            var template = this.postMessagePath;
            var messageCount = 50;
            var $allMessages = $('<div/>'),
                len;
            for (var i = data.length - 1; i > len - messageCount, i >= 0; i--) {
                var post = data[i];
                var title = post.title.trim();
                var body = post.body.trim();
                var username = post.user.username;
                var date = post.postDate;

                if (!title || !body) {
                    continue;
                }
                var message = buildMessage({title: title, body: body, username: username, postDate: date}, template);
                $allMessages.append(message);
            }
            $('#post-box').html($allMessages.html());
        };

        function buildMessage(data, template) {
            var renderedMessage = Mustache.render(template, data);

            return renderedMessage;
        }

        UiController.prototype.isUserLoggedIn = function (username) {
            $('#user-name-holder').text(username);
//            $('#registration-link').hide();
//            $('#login-link').hide();

        };
        UiController.prototype.renderLoggedOutUser = function () {
//            $('#registration-link').show();
//            $('#login-link').show();
        };

        return UiController;
    })();

    return UiController;
});