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
            var self = this;
            $(container).load(this.mainPagePath);
            $.get(this.postMessagePath)
                .then(function(data){
                    self.template = data;
                });
        };

        UiController.prototype.renderAllPosts = function (container, data) {
            var messageCount = 50;
            var $allMessages = $('<div/>'),
                len = data.length;
            console.log(data);
            for (var i = 0; i < len ; i++) {
                var post = data[i];
                var title = post.title.trim();
                var body = post.body.trim();
                var username = post.user.username;
                var date = post.postDate.toString();

                var postData = {
                    title: title,
                    body: body,
                    username: username,
                    postDate: date
                };

                if (!title || !body) {
                    continue;
                }
                var message = buildMessage(postData, this.template);
                $allMessages.append(message);
            }

            $('#post-box').html($allMessages.html());
        };

        function buildMessage(data, template) {
            var renderedMessage = Mustache.render(template, data);
            console.log('rendered: ' + renderedMessage);
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