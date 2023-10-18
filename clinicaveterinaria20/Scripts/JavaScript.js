$(document).ready(function () {
    $(`#btn`).click(function () {
        let impt = $(`#input`).val();
        $.ajax({
            method: 'POST',
            url: 'magazion',
            data: { nome: impt },
            success: function (data) {
                $.each(data, function (n, e) {
                    $("#div").empty()
                    console.log(e)
                    let p = ""
                    if (e.nome == "prodotto insesistente") {
                        p = `<p> prodotto insesistente </p>`
                    }
                    else {
                        if (e.quantita == 0) {
                            p = `<p> ${e.nome} prodotto mometaneamente non presente </p>`
                        }
                        else {
                            p = `<p> ci sono ${e.quantita} ${e.nome} con un costo ${e.costo}€ sitati nel armadietto n${e.armadietto} nel cassetto${e.cassetto} <a href="./modificaprodotto/${e.idprodotto}"> modifca prodotto</a> <a href="./eliminaprodotto/${e.idprodotto}"> modifca prodotto</a> </p> `
                        }
                    }
                    $("#div").append(p)
                })
            }
        })
    })
})