/* global kendo, define */

define([
	'text!views/layout/layout.html'
], function (template) {
	'use strict';

	var layout = new kendo.Layout(template);

	return layout;

});