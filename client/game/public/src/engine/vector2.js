function Vector2(x, y)
{
	this.x = x;
	this.y = y;
}

Vector2.prototype.divide = function(d)
{
	return new Vector2(this.x / d, this.y / d);
};

this.exports = Vector2;
