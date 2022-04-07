// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('.js-example-basic-single').select2();
    $.get('https://v6.exchangerate-api.com/v6/641a1ac9a894b4abd3d39b90/codes', function (data) {
        //console.log(data.supported_codes);
        var dat = data.supported_codes;
        let div = "";
        for (var x = 0; x < dat.length; x++) {
            
            div += "<option value=" + dat[x][0] + ">" +dat[x][0] + " - " + dat[x][1] + "</option>";
        }

        $('.js-example-basic-single').append(div);
       
    });
  
});

function convert() {

    var value = parseFloat($("#amountFrom").val()).toFixed(2);
    var from = $("#currencyFrom").val();
    var to = $("#currencyTo").val();

    var url = "https://v6.exchangerate-api.com/v6/641a1ac9a894b4abd3d39b90/pair/" + from + "/" + to + "/" + value;

    $.ajax({
        url: url,
        type: "GET",
        success: function (data) {
           
            data1 = data;
            let div = "";
            console.log(data);
            $("#conversion_rate").val(data.conversion_rate);
            $("#conversion_result").val(data.conversion_result);
            $("#amountTo").html(to + " " + data.conversion_result);


            var param = {
                amountFrom: value,
                amountTo: data.conversion_result,
                rate: data.conversion_rate,
                currencyFrom: from,
                currencyTo: to
            }
            saveTransaction(param);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("not working");
        }
    });

}

function saveTransaction(param) {

    $.ajax({
        url: '/api/transaction',
        type: "POST",
        data: JSON.stringify(param),
        async: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            alert("Transaction Saved");

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("not working");
        }
    });
}