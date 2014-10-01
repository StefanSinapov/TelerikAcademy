/* global define, kendo */

define([
		'text!views/todos/todos.html',
		'data/data'
	],
	function (viewHtml, data) {
		'use strict';

		function build() {
			return data.todos.all()
				.then(function (todos) {
					debugger;
					var todosModels = todos.result;
					var viewModel = kendo.observable({
						title: 'TODOs',
						todos: todosModels
					});

					var view = new kendo.View(viewHtml, {
						model: viewModel
					});
					return view;
				}, function (err) {
					alert(JSON.stringify(err));
				});
		}

		return {
			buildView: build
		};



	});