var State = Import('src/engine/state.js');
var Box = Import('src/engine/box.js');
var Vector2 = Import('src/engine/vector2.js');
var Renderer = Import('src/subsystems/renderer.js');

var MainState = function(){
	var state = new State();

	var testSquare = new Box(new Vector2(100, 100));

	state.addObject(testSquare);

	return state;
};

Renderer.initialize();
var cs = new MainState();
setInterval(function(){
	resize();
	Renderer.render(cs);

	if(Input.getKey(KeyCode('w')))
	{
		cs.objects[0].position.y -= 1;
	}
}, 1000 / 60);
