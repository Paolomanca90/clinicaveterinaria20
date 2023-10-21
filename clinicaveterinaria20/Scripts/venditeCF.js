$(document).ready(function () {
    $("#btn1").click(function () {
        let input = $("#cf").val()
        $.ajax({
            method: "POST",
            url: "jsnVenditeCF",
            data: { cf: input },
            success: function (data) {
                $("#trCf").empty()
                $.each(data, function (n, e) {
                    let row = ""
                    if (e.idcliente == -1) {
                        $("#list-cf").show()
                        $("#tabellaHead1").hide()
                        row = `<p class="text-center text-danger">
                        Nessuna vendita per questo cliente</p>`
                    }
                    else {
                        $("#list-cf").show()
                        $("#tabellaHead1").show()
                        row = `
                        <tr>
                            <td>
                                ${e.nricetta}
                            </td>
                            <td>
                                ${e.quantita}
                            </td>
                            <td>
                                ${e.costotot}€
                            </td>
                            <td><a href="./modificaprodotto/${e.idprodotto}" > <i class="fa fa-edit"></i></a></td>
                            <td><a href="./eliminaprodotto/${e.idprodotto}"> <i class="fa fa-trash"></i></a>  </td>
                        </tr>`
                    }
                    $("#trCf").append(row)
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
                $("#trData").empty()
                $.each(data, function (n, e) {
                    let row = ""
                    if (e.idcliente == -1) {
                        $("#list-data").show()
                        $("#tabellaHead").hide()
                        row = `<p class="text-center text-danger">
                        Nessuna vendita in questa data</p>`
                    }
                    else {
                        $("#list-data").show()
                        $("#tabellaHead").show()
                        row = `
                        <tr>
                            <td>
                                ${e.nricetta}
                            </td>
                            <td>
                                ${e.quantita}
                            </td>
                            <td>
                                ${e.costotot}€
                            </td>
                            <td><a href="./modificaprodotto/${e.idprodotto}" > <i class="fa fa-edit"></i></a></td>
                            <td><a href="./eliminaprodotto/${e.idprodotto}"> <i class="fa fa-trash"></i></a>  </td>
                        </tr>`                    }
                    $("#trData").append(row)
                })
            }
        })
    })
})