var Renderer = {
	background: "#000000",
	pixels: [],
	initialize: function()
	{

	},
	render: function(state)
	{
		Renderer.pixels = [];
		var _ws = WindowSize();
		for(var i = 0; i < _ws.x; i++)
		{
			Renderer.pixels.push(Array(_ws.y));
		}
		var renderData = {
			offset: new Vector2(50, 50),
			pixels: Renderer.pixels,
			screen_width: _ws.x,
			screen_height: _ws.y,
			draw: Renderer.draw
		}

		state.objects.forEach(function(obj){
			obj.render(renderData);
		});

		updateData(Renderer.pixels);
	},
};

this.exports = Renderer;
