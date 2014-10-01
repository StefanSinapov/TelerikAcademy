/* global define, kendo */

define([
		'text!views/add-todo/add-todo.html',
		'data/data'
	],
	function (
		viewHtml,
		data) {
		'use strict';

		function build() {

			var viewModel = kendo.observable({
				title: 'Add new TODO',
				text: 'TEst',
				responsible: 'Pesho',
				addTodo: function () {
					var text = this.get('text'),
						responsible = this.get('responsible');

					data.todos.add(text, responsible);
				}
			});

			var view = new kendo.View(viewHtml, {
				model: viewModel
			});
			return view;
		}

		return {
			buildView: build
		};
	});