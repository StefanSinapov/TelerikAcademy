/* global define, kendo */

define([
  'views/layout/layout',
  'views/todos/todos',
  'views/add-todo/add-todo',
  'data/data'
], function (layout,
  todos,
  addTodo,
  data) {
  'use strict';

  data.users.login('Minkov', '123456q')
    .then(function () {
      alert('User registered');
    });

  var router = new kendo.Router({
    init: function () {
      //load layout inside the element with #root
      layout.render('#root');
    }
  });

  router.route('/', function () {
    todos.buildView()
      .then(function (view) {
        layout.showIn('#view', view);
      }, function (err) {
        alert(JSON.stringify(err));
      });
  });

  router.route('/add-todo', function () {
    layout.showIn('#view', addTodo.buildView());
  });

  var init = function () {
    router.start();
  };

  return {
    init: init
  };

});