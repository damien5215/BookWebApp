﻿$("#searchBtn").on("click", function () {

    var searchStringJS = $("#textBox1").val();
    console.log(searchStringJS);

    $("#SBmessage").css('color', 'darkblue');
    
    $.ajax({
        url: "/Test/_ProductsTestBooks/",
        type: "POST",
        data: { searchString: searchStringJS },
        success: successFunc
    })
        .done(function (partialViewResult) {
            $("#bookTable3").html(partialViewResult);
        });

    function successFunc(data, status) {
        console.log("Ajax Success: " + searchStringJS);
    }

});

$("#resetBtn").on("click", function () {

    $("#SBmessage").css('color', '#333');

    $.ajax({
        url: "/Test/_ProductsTestBooks/",
        type: "GET"
    })
        .done(function (partialViewResult) {
            $("#bookTable3").html(partialViewResult);
        });
});
