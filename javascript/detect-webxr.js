if (navigator.xr) {
  checkForXR(); // New WebXR API
}
else if (navigator.getVRDisplays){
  checkForVR(); // Old WebVR API
}
else {
  console.log('WebVR and WebXR APIs are not supported.');
}

//
// New WebXR API
//
async function checkForXR() {
  try {
    console.log('WebXR available?!?!');
  } catch (err) {
    console.log(err);
  }
}

//
// Old WebVR API
//
async function checkForVR() {
  try {
    const displays = await navigator.getVRDisplays()

    if (!displays.length) {
      throw 'VR supported, but no VR displays available';
    }

    displays.forEach(function (display) {
      console.log(display.displayName + ' (' + display.displayId + ')');
    })
  } catch (err) {
    console.log(err);
  }
}
