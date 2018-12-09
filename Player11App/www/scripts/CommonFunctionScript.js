function GetAdd() {
    var admob = require("nativescript-admob");

    admob.createBanner({
        // if this 'view' property is not set, the banner is overlayed on the current top most view
        // view: ..,
        testing: true, // set to false to get real banners
        size: size, // anything in admob.AD_SIZE, like admob.AD_SIZE.SMART_BANNER
        iosBannerId: "ca-app-pub-6837998194719753/7479721731", // add your own
        androidBannerId: "ca-app-pub-6837998194719753/7479721731", // add your own
        // Android automatically adds the connected device as test device with testing:true, iOS does not
        //iosTestDeviceIds: ["yourTestDeviceUDIDs", "canBeAddedHere"],
        margins: {
            // if both are set, top wins
            //top: 10
            bottom: 50
        },
        keywords: ["Cricket", "Cricket in India"] // add keywords for ad targeting
    }).then(
        function () {
            console.log("admob createBanner done");
        },
        function (error) {
            console.log("admob createBanner error: " + error);
        }
        )
};