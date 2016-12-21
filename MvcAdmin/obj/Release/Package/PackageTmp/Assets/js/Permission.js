$(document).ready(function () {

    var loadAJAX = function (url, ID, act) {
        $.getJSON(url, { id: ID, act: act }, function (response) {
            //$("#nameDemo").empty();

            // get response object
            var obj = response;
            var rID = "r" + ID;
            $("#" + rID).find(".permissionDisplay").html(obj.Permission);
            $("#" + rID).find(".logDisplay").html(obj.LogStatus);
            return obj;
        });
    };

    $(function () {
        $(".IDcontain").click(function () {
            //var url = '@Url.Action("LoadName","ChooseType")';
            var url = 'ViewPermissions/LoadList';
            var ID = $(this).find(".ID").val();
            var rID = "r" + ID;
            // edit selected element row id
            var row = $(this).parents(".table-row");
            row.attr("id", rID); // 

            var act = $(this).find("button").val();
            var obj = $(function () {
                loadAJAX(url, ID, act);
            });
           
        });
    });
});
