var loadAJAX = function (url,Type) {
    $.getJSON(url, { type: Type }, function (response) {
        $("#nameDemo").empty();
        $.each(response, function (index, item) {
            $("#nameDemo").append($('<option></option>').text(item).val(item));
        });
    });
};

$(function () {
    $("#typeDemo").change(function () {
        // var url = '@Url.Action("LoadName","ChooseType")';
        var url = 'ChooseType/LoadName';
        var Type = $(this).val();
        loadAJAX(url, Type);
    });
});

