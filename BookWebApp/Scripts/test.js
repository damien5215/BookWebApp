$(document).ready(function () {

    //var bla = $('#txt_name').val("Tuna goes here!");
    //$('#tuna').val("Tuna goes here!");
    //$('#tuna').text('test');
    console.log("Page Loaded!");

    //$('.button_action').click(function (index){
    //    $('#tuna').text('test');
    //    console.log("Tuna Set!");
    //})

    $('.button_action').click(function (index) {

        $('#tuna').text('test');

        var x1 = this.href;
        console.log(this.href);

        console.log("Button Clicked!");


        //$.ajax({
        //    url: this.href,
        //    contentType: 'application/html; charset=utf-8',
        //    type: 'GET',
        //    success: function (result) {

        //        //$('#showEditProd').html(result);
        //        $("#cartDiv").load();
        //        console.log("AJAX Sucess!");
        //    }
        //});
        //return false;
    });

})