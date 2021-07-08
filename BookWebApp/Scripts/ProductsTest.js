$("#searchBtn").on("click", function () {

    var searchStringJS = $("#textBox1").val();
    console.log(searchStringJS);

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