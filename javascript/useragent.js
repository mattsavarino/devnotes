// User agent used for conditional logic
var userAgent      = navigator && navigator.userAgent,
    userAgentLower = userAgent.toLowerCase(),
    isIE           = ( userAgentLower.match(/(msie)/i) ) ? true : false, // note IE11 no longer references MSIE
    isIOS          = ( userAgentLower.match(/(ipad|iphone|ipod)/i) ) ? true : false,
    isAndroid      = ( userAgentLower.match(/android/i) ) ? true : false,
    isWebOS        = ( userAgentLower.match(/webos/i) ) ? true : false;

if (window && window.console) window.console.log("You're browsing from " + userAgent);
