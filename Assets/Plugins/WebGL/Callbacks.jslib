mergeInto(LibraryManager.library, {
    DistanceCallback: function(distance) {
        // ここでReact側の関数を呼び出す
        if (window.ReactUnityBridge && window.ReactUnityBridge.onDistance) {
            window.ReactUnityBridge.onDistance(distance);
        }
    },
    TimeCallback: function(time) {
        if (window.ReactUnityBridge && window.ReactUnityBridge.onTime) {
            window.ReactUnityBridge.onTime(time);
        }
    },
    SpeedCallback: function(speed) {
        if (window.ReactUnityBridge && window.ReactUnityBridge.onSpeed) {
            window.ReactUnityBridge.onSpeed(speed);
        }
    }
});