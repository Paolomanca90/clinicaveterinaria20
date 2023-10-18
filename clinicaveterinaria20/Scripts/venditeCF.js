$(document).ready(function () {
    $("#btn1").click(function () {
        let input = $("#cf").val()
        $.ajax({
            method: "POST",
            url: "jsnVenditeCF",
            data: {cf: input},
            success: function (data) {
                $.each(data, function (n,e){

                    var row = `<li>Numero ricetta:${e.nricetta}, quantita: ${e.quantita}, costo totale: ${e.costotot}</li>`   
                    $("#list-cf").append(row)
                })
            } 
        })
    })
    $("#btn2").click(function () {
        let input = $("#input-data").val()
        $.ajax({
            method: "POST",
            url: "jsnVenditeData",
            data: { pippo: input },
            success: function (data) {
                $.each(data, function (n, e) {

                    var row = `<li>Numero ricetta:${e.nricetta}, quantita: ${e.quantita}, costo totale: ${e.costotot}</li>`
                    $("#list-data").append(row)
                })
            }
        })
    })
})