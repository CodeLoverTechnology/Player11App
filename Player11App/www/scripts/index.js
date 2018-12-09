// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkID=397704
// To debug code on page load in cordova-simulate or on Android devices/emulators: launch your app, set breakpoints, 
// and then run "window.location.reload()" in the JavaScript Console.
(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );


    function onDeviceReady() {
        document.removeEventListener('deviceready', onDeviceReady, false);
        //admob.setOptions({
        //    publisherId: "ca-app-pub-3940256099942544/6300978111",  // Required
        //    interstitialAdId: "ca-app-pub-3940256099942544/1033173712"  // Optional
        //});

        //// Start showing banners (atomatic when autoShowBanner is set to true)
        //admob.createBannerView();

        //// Request interstitial (will present automatically when autoShowInterstitial is set to true)
        //admob.requestInterstitialAd();
       // initAd();
         //Set AdMobAds options:
         //Handle the Cordova pause and resume events
        document.addEventListener( 'pause', onPause.bind( this ), false );
        document.addEventListener( 'resume', onResume.bind( this ), false );
        
        // TODO: Cordova has been loaded. Perform any initialization that requires Cordova here.
        var parentElement = document.getElementById('deviceready');
        var listeningElement = parentElement.querySelector('.listening');
        var receivedElement = parentElement.querySelector('.received');
        listeningElement.setAttribute('style', 'display:none;');
        receivedElement.setAttribute('style', 'display:block;');
        
        //document.addEventListener("deviceready", onDeviceReady, false);
        //GetAllTeamInfo();
    };
    
//    document.addEventListener('deviceready', onDeviceReady, false);


    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        
        // TODO: This application has been reactivated. Restore application state here.
    };
    function doAdmob()
    {
        document.addEventListener("deviceready", onDeviceReady, false);
    } 
} )();