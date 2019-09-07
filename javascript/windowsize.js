// Viewport dimensions used for conditional logic
// vanilla JS window width and height
function getWindowSize() {
	var w=window,
		d=document,
		e=d.documentElement,
		g=d.getElementsByTagName('body')[0];
	var x = w.innerWidth||e.clientWidth||g.clientWidth||null;
	var y = w.innerHeight||e.clientHeight||g.clientHeight||null;
	conlog('Your currently viewing at ' + x + 'x' + y);
	return [x, y];
}
var windowSize = getWindowSize();

// Listener: Wait for Final Event
var waitForFinalEvent = (function () {
	var timers = {};
	return function (callback, ms, uniqueId) {
		if (!uniqueId) uniqueId = "Don't call this twice without a uniqueId";
		if (timers[uniqueId]) clearTimeout (timers[uniqueId]);
		timers[uniqueId] = setTimeout(callback, ms);
	};
})();

// Listener: Window Resize
window.addEventListener('resize', function(event){
	waitForFinalEvent(function(){
		getWindowSize();
	}, 1000, 'WindowResize');
});
