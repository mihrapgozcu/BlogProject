$(document).ready(function () {

    $("#btnSave").click(function (event) {
        event.preventDefault();

        var createUrl = app.Urls.categoryCreateUrl;
        var redirectUrl = app.Urls.articleCreateUrl;

        var categoryCreateVM = {
            Name: $("input[id=categoryName]").val()
        }

        var jsonData = JSON.stringify(categoryCreateVM);
        console.log(jsonData);

        $.ajax({
            url: createUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl;
                }, 1500);
            },
            error: function () {
                toast.error("Bir hata oluştu!", "Hata");
            }
        });
    });
});