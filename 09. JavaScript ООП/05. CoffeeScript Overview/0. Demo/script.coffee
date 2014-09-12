class Shape
	constructor: (x, y) ->
	setX
	getX: () ->

class Rect extends Shape
	constructor: (x, y, w, h) ->
		super x, y
		@width = w
		@height = h
