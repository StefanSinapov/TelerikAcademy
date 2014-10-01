require.config({
	paths: {
		'text': '../bower_components/requirejs-text/text'
	}
});

require([
	'app'
], function (app) {
	window.todos = [{
		text: 'Wash the dishes',
		responsible: 'Pesho',
		toString: function () {
			return this.text;
		}
	}, {
		text: 'Clean the toilet',
		responsible: 'Mariika',
		toString: function () {
			return this.text;
		}
	}];
	app.init();

});