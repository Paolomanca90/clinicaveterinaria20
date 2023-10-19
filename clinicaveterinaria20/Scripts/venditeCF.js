$(document).ready(function () {
    $("#btn1").click(function () {
        let input = $("#cf").val()
        $.ajax({
            method: "POST",
            url: "jsnVenditeCF",
            data: { cf: input },
            success: function (data) {
                $("#list-cf").empty()
                $.each(data, function (n, e) {
                    let row = ""
                    if (e.idcliente == -1) {
                        row = "nessuna vendita per questo cliente"
                    }
                    else {
                        row = `<li>Numero ricetta:${e.nricetta}, quantita: ${e.quantita}, costo totale: ${e.costotot} <a href="./EditVendita/${e.idvendita}"> modifica vendita</a> <a href="./DeleteVendita/${e.idvendita}"> storna vendita</a></li>`
                    }
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
                $("#list-data").empty()
                $.each(data, function (n, e) {
                    let row = ""
                    if (e.idcliente == -1) {
                        row = "nessuna vendita in questa data"
                    }
                    else {
                        row = `<li>Numero ricetta:${e.nricetta}, quantita: ${e.quantita}, costo totale: ${e.costotot} <a href="./EditVendita/${e.idvendita}"> modifica vendita</a> <a href="./DeleteVendita/${e.idvendita}"> storna vendita</a></li>`
                    }
                    $("#list-data").append(row)
                })
            }
        })
    })
})