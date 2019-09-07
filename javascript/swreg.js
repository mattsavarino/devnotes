if ('serviceWorker' in navigator) {
  window.addEventListener('load', function() {
    navigator.serviceWorker.register('/sw.js').then(function(registration) {
      // Registration was successful
      console.log('ServiceWorker is here for you at ', registration.scope);
    }, function(err) {
      // registration failed :(
      console.log('ServiceWorker failed to register. ', err);
    });
  });
}
