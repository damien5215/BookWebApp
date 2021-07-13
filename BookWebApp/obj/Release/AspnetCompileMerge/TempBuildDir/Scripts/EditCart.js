$(document).ready(function () {
    
    $("#filterBooks").on("click", function () {

        $("#filterBooks").css('background-color', 'darkblue');

        var x1 = $("#authorList").val()
        console.log("ID selected is " + x1);

        $.ajax({
            url: "/Test/_Book/" + x1,
            type: "POST"
        })
            .done(function (partialViewResult) {
                $("#bookTable").html(partialViewResult);
            });

    });

    $("#resetFilter").on("click", function () {

        $("#filterBooks").css('background-color', '#337ab7');

        $.ajax({
            url: "/Test/_Book/",
            type: "GET"
        })
            .done(function (partialViewResult) {
                $("#bookTable").html(partialViewResult);
            });

    });

});