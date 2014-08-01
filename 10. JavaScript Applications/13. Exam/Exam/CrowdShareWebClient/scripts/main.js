define(function () {
    'use strict';
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.1.1',
            'sammy': 'libs/sammy',
            'q': 'libs/q.min',
            'mustache': 'libs/mustache',
            'sha1': 'libs/sha1',
            'http-request': 'http-request',
            'validation-controller': 'controllers/validation-controller',
            'ui-controller': 'controllers/ui-controller',
            'controller': 'controllers/controller',
            'persister': 'persister'
        }
    });

    require(['jquery', 'sammy', 'controller'], function ($, sammy, Controller) {

//        var serviceUrl = 'http://localhost:3000/';
        var serviceUrl = 'http://jsapps.bgcoder.com/';
        var contentSelector = '#page-content';
        var controller = new Controller(serviceUrl, contentSelector);
        controller.addEventHandlers();

//        var persistor = new Persister(serviceUrl);
//        persistor.user.logout()
//            .then(function(data){
//                console.log('success ' + data)
//            },function(reason){
//                alert("error");
//                console.log('error during registration: ' + reason)
//            });



        var app = sammy('#page-content', function () {

            this.get('#/', function(){
                controller.loadMainPage();
            });

            this.get("#/login", function () {
                 controller.loadLoginForm();
            });


            this.get("#/register", function () {
                controller.loadRegisterForm();
            });

            this.get("#/account", function () {
                controller.loadAccountForm();
            });
        });

        app.run('#/');
    });

});