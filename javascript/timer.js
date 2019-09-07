// Timer
var timeStart = (new Date()).getTime();
if (window && window.console) window.console.log('Welcome!');

// Console logging with protection & timing
function conlog(msg) {
	if (window && window.console) window.console.log((new Date()).getTime()-timeStart + "ms: " + msg);
  setTimeout(function(){ conlog("really, again?") }, 3000);
}

setTimeout(function(){ conlog("delayed console event") }, 1000);
