$(document).ready(function () {

    var loadAJAX = function (url, ID, examNum) {
        $.getJSON(url, { id: ID, examNumber: examNum }, function (response) {
            // get response object
            var obj = response;
            var rID = "r" + ID;
            $("#" + rID).find(".currentNumberDisplay").html(obj.IndividualExam);
            //$("#" + rID).find(".logDisplay").html(obj.LogStatus);
            return obj;
        });
    };

    $(function () {
        $(".IDcontain").click(function () {
            //var url = '@Url.Action("LoadName","ChooseType")';
            var url = 'IndividualExams/LoadList';
            var ID = $(this).find(".ID").val();
            var rID = "r" + ID;
            // edit selected element row id
            var row = $(this).parents(".table-row");
            row.attr("id", rID); // 

            var act = $(this).find("button").val();
            var examNum = row.find("#examSelectList").val();
            var obj = $(function () {
                loadAJAX(url, ID, examNum);
            });

        });
    });
});
