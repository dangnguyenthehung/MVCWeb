function SyncResult() {
    var controllerName = currentController();
    var address = controllerName + "/" + "SyncResult";
    $.get(address, function (data) {
        for (var i = 0; i < data.length; i++);
        showResult(data);
    });

}
$(function () {

    setInterval("SyncResult()", 1000 * 3); // 3s gửi request một lần

});

function showResult(data){
    $.each(data, function(i, item) {
        if (item == "normal")
        {
            // do nothing
        }
        else
        {
            show_notification(item);
            play_sound();
            console.log(item);
        }
        
    });
}

function play_sound() {
    var baseUrl = "Assets/Audio/";
    var audio = ["new-message.mp3"];

    new Audio(baseUrl + audio[0]).play();

};

function show_notification(noti) {
    $.bootstrapGrowl(noti, {
        type: 'success',
        offset: {
            from: "bottom",
            amount: 20
        },
        width: 400,
        delay: 20000, // 20s
    });
};

// test
//$(function () {
    
//$(".success").click(function () {
//    $.bootstrapGrowl('Nộp bài: Đặng Nguyễn Thế Hưng - 10 điểm', {
//        type: 'success',
//        offset: {
//            from: "bottom",
//            amount: 20
//        },
//        width: 400,
//        delay: 20000,
//    });
//    play_sound();
//});

//$(".error").click(function () {
//    $.bootstrapGrowl('You Got Error', {
//        type: 'danger',
//        delay: 2000,
//    });
//});

//$(".info").click(function () {
//    $.bootstrapGrowl('It is for your kind information', {
//        type: 'info',
//        delay: 2000,
//    });
//});

//$(".warning").click(function () {
//    $.bootstrapGrowl('It is for your kind warning', {
//        type: 'warning',
//        delay: 2000,
//    });
//});

//});