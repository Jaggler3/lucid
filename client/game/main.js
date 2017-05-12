const electron = require('electron');
const app = electron.app;
const BrowserWindow = electron.BrowserWindow;

const path = require('path');
const url = require('url');

let window

function init () {
	window = new BrowserWindow({width: 800, height: 600});
	window.toggleDevTools();
	window.setMenu(null);
	window.loadURL(url.format({
		pathname: path.join(__dirname, '/public/index.html'),
		protocol: 'file:',
		slashes: true
	}));
	window.on('closed', function () { window = null });
}

app.on('ready', init);

app.on('window-all-closed', function () {
	if (process.platform !== 'darwin') {
		app.quit();
	}
});

app.on('activate', function () {
	if (mainWindow === null) {
		init();
	}
});
