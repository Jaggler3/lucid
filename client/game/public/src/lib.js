var _LIB = {
	Internal: {
		imported_scripts: [],
		imported_script_paths: []
	}
}

function KeyCode(c) {
	return c.charCodeAt(0) - 32;
}

var Input = Input || {
	getKey: function(key) {
		return KEYS_DOWN.indexOf(key) != -1;
	},
	getKeyDown: function(key) {
		return KEYS_FIRST_DOWN.indexOf(key) != -1;
	},
};

function WindowSize()
{
	return new Vector2(window.innerWidth, window.innerHeight);
}
function WindowWidth()
{
	return window.innerWidth;
}
function WindowHeight()
{
	return window.innerHeight;
}

function Import(path)
{
	var index = 0;
	if((index = _LIB.Internal.imported_script_paths.indexOf(path)) != -1)
	{
		return _LIB.Internal.imported_scripts[index];
	}

	var module = (function concealedEval() { eval(GetSourceSync(path)); return exports; })();

	console.log("[ENGINE] Importing type of (" + module.constructor.name + ")");

	_LIB.Internal.imported_scripts.push(module);
	_LIB.Internal.imported_script_paths.push(path);

	return module;
}

function ImportJson(path)
{
	var module = (function concealedEval() {
		return JSON.parse(GetSourceSync(path));
	})();

	console.log("[ENGINE] Importing type of (JSON)");

	return module;
}

function ImportFile(path)
{
	return GetSourceSync(path);
}

function GetSourceSync(path)
{
	var p = window.location.protocol + '//' + __dirname + '/' + path;
	console.log(p);
	var request = new XMLHttpRequest();
	request.open('GET', p, false);
	request.send();

	return request.responseText;
}
