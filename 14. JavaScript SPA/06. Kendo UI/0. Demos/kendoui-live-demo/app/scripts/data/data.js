/* global define, Everlive */

define([], function () {
	'use strict';

	var apiKey = 'bvzIA966kNWzZglr';

	var bs = new Everlive(apiKey);

	function getAllTodos() {
		var todos = bs.data('TODOs');
		return todos.get();
	}

	function addTodo(text, responsible) {
		var todos = bs.data('TODOs');
		return todos.create({
			Text: text,
			Responsible: responsible
		});
	}

	function registerUser(username, password) {

		//GET END_POINT

		$.ajaxSetup({
			enableCors: true
		});
		$.ajax({
			url: 'localhost:XXXXX/token',
			headers: {
				Authentication: 'Bearer ' + token
			},
			beforeSend: function (request) {
				request.setRequestHeader("Authorization", 'Bearear ' + token);
			},
			success: function () {

			},
			error: function () {

			}
		});
	}

	function loginUser(username, password) {
		return bs.Users.login(username, password);

	}

	return {
		todos: {
			all: getAllTodos,
			add: addTodo
		},
		users: {
			register: registerUser,
			login: loginUser
		}
	};



});