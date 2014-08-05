define(['jquery', 'persister', 'ui-controller', 'validation-controller'], function ($, Persister, UI, Validator) {
    'use strict';
    var Controller = (function () {

        function Controller(url, container) {

            this.$container = $(container);
            this.persister = new Persister(url);
            this.ui = new UI();
        }

        Controller.prototype.addEventHandlers = function () {
            var self = this;
            this.$container.on('click', '#logout-btn', function () {
                if (self.persister.user.isUserLoggedIn()) {
                    self.persister.user.logout()
                        .then(function (data) {
                            alert('Successful logged out');
                            window.location = '#/';
                        }, function (reason) {
                            alert("error");
                            console.log('error during logout: ' + reason)
                        });
                }
                else {
                    alert('You are already logged out');
                }
            });
            this.$container.on('click', '#register-btn', function () {
                var username = $('#register-name').val();
                var password = $('#register-pass').val();
                if (self.persister.user.isUserLoggedIn()) {
                    alert('please logout first');
                    window.location = '#/account';
                    return;
                }
                if (Validator.isValidUsername(username) && password !== '') {
                    self.persister.user.register(username, password)
                        .then(function (data) {
                            alert('Successful registration');
                            window.location = '#/';
                        },
                        function (data) {
                            alert('Username and password must be more than 5 chars')
                        });
                }
                else {
                    alert('Username and password must be more than 5 chars');
                }
            });
            this.$container.on('click', '#login-btn', function () {
                var username = $('#login-name').val();
                var password = $('#login-pass').val();
                if (self.persister.user.isUserLoggedIn()) {
                    alert('You are already logged in, please logout first');
                    window.location = '#/account';
                    return;
                }
                if (Validator.isValidUsername(username) && password !== '') {
                    self.persister.user.login(username, password)
                        .then(function (data) {
                            alert('Successful logged in');
                            window.location = '#/';
                        },
                        function (data) {
                            alert('Username and password must be more than 5 chars')
                        });
                }
                else {
                    alert('Username and password must be more than 5 chars');
                }
            });

            this.$container.on('click', '#send-post-btn', function () {
                var $title = $('#user-post-title'),
                    $body = $('#user-post-body'),
                    titleVal = $title.val(),
                    bodyVal = $body.val();

                if (!self.persister.user.isUserLoggedIn()) {
                    alert('You must be login to post');
                    window.location = '#/login';
                    return;
                }
                if (titleVal && bodyVal) {
                    $title.removeClass('error');
                    $body.removeClass('error');


                    self.persister.post.add(titleVal, bodyVal)
                        .then(function () {
                            $title.val('');
                            $body.val('');
                            alert('Post successfully added');
                        }, function (reason) {
                            console.log(reason);
                        });
                }
                else {
                    alert('Both title and body of post must be filled');
                    $title.addClass('error');
                    $body.addClass('error');
                }
            });

        };

        Controller.prototype.loadRegisterForm = function () {
            this.ui.renderRegistrationForm(this.$container);
        };

        Controller.prototype.loadLoginForm = function () {
            this.ui.renderLoginForm(this.$container);
        };

        Controller.prototype.loadAccountForm = function () {
            this.ui.renderAccountForm(this.$container);
        };

        Controller.prototype.loadMainPage = function () {
            var self = this;
            this.ui.renderMainPage(this.$container);
            this.persister.post.getAll()
                .then(function (data) {
                    self.ui.renderAllPosts(self.$container, data);
                }, function (reason) {
                    console.log(reason);
                });

        };


        return Controller;
    }());

    return Controller;
});