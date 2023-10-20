$(document).ready(function () {
    $("#btn1").click(function () {
        $("#list-cf").show()
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
                        row = "nessuna vendita per questo cliente"
                    }
                    else {
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
        $("#list-data").show()
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
                        row = "nessuna vendita in questa data"
                    }
                    else {
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