var RenderObject = Import('src/engine/render_object.js');
function Box()
{
	RenderObject.call(this);
	this.background_color = [255, 0, 0, 255];
	this.render = function(renderData)
	{
		for(var x = 0; x < this.size.x; x++)
		{
			for(var y = 0; y < this.size.y; y++)
			{
				let pr = new Vector2(
					x + renderData.offset.x + this.position.x,
					y + renderData.offset.y + this.position.y);
				if(pr.x >= 0 && pr.y >= 0 && pr.x <= renderData.pixels.length && pr.y <= renderData.pixels[0].length)
				{
					renderData.pixels[pr.x][pr.y] = this.background_color;
				}
			}
		}
	};
}

this.exports = Box;
