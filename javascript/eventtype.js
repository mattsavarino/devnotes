// Event Type (click events cause a 300 ms delay after the event fires on touch devices)
var eventType = ((document.ontouchstart !== null) ? 'click' : 'touchstart');
