$(document).ready(function () {
    $(".btnAdd").on("click", function () {

        $('#totalCost').hide();
        console.log("Add button clicked, ID is " + this.id);

        $.ajax({
            url: "/Cart/AddToCart/" + this.id,
            type: "GET"
        }).done(function () {

            $.ajax({
                url: "/Cart/_Cart",
                type: "GET"
            }).done(function (partialViewResult) {
                $("#refTable").html(partialViewResult);

                $.ajax({
                    url: "/Cart/_TotalCost",
                    type: "GET"
                }).done(function (partialViewResult) {
                    $("#totalCost").html(partialViewResult);
                    $('#totalCost').show();
                });

            });
        });
    });

    
    $("#filterBooks").on("click", function () {

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

});