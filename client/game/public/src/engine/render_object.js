var RenderContent = Import('src/engine/render_content.js');
var Vector2 = Import('src/engine/vector2.js');

function RenderObject()
{
	this.position = new Vector2(0, 0);
	this.size = new Vector2(64, 64);
	this.rotation = 0;
	this.content = new RenderContent();
}

RenderObject.prototype.setPosition = function(position)
{
	this.position = position;
	return this;
}

RenderObject.prototype.setSize = function(size)
{
	this.size = size;
	return this;
}

RenderObject.prototype.setRotation = function(rotation)
{
	this.rotation = rotation;
	return this;
}

RenderObject.prototype.setContent = function(content)
{
	this.content = content;
	return this;
}

this.exports = RenderObject;
