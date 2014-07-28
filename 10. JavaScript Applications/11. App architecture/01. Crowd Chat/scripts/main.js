define(function () {
    'use strict';
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.1.1',
            'sammy': 'libs/sammy',
            'q': 'libs/q.min',
            'mustache': 'libs/mustache',
            'http-request': 'http-request',
            'validation-controller': 'controllers/validation-controller',
            'user-controller': 'controllers/user-controller',
            'chat-controller': 'controllers/chat-controller',
            'user': 'user'
        }
    });

    require(['jquery', 'sammy', 'user-controller', 'chat-controller'], function ($, sammy, userController, chatController) {

        chatController.init('http://crowd-chat.herokuapp.com/posts', '#wrapper');

        var app = sammy('#wrapper', function () {
            this.get("#/login", function () {
                if (userController.user.isLoggedIn()) {
                    window.location = '#/chat';
                    return;
                }
                userController.loadLoginFrom();
            });


            this.get("#/chat", function () {
                if (!userController.user.isLoggedIn()) {
                    window.location = '#/login';
                    return;
                }
                chatController.loadChatBox();
            });
        });

        app.run('#/login');
    });

});