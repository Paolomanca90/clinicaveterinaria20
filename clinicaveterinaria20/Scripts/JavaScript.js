$(document).ready(function () {
    $(`#btn`).click(function () {
        let impt = $(`#input`).val();
        $.ajax({
            method: 'POST',
            url: 'magazion',
            data: { nome: impt },
            success: function (data) {
                $("#div").empty()
                $.each(data, function (n, e) {
                    console.log(e)
                    let p = ""
                    if (e.nome == "prodotto insesistente") {
                        p = `<p> prodotto insesistente </p>`
                    }
                    else {
                        if (e.invendita) {
                            if (e.quantita == 0) {
                                p = `<p> ${e.nome} prodotto mometaneamente non presente </p>`
                            }
                            else {
                                p = `<p class="m-2"> ci sono ${e.quantita} ${e.nome} con un costo ${e.costo}€ sitati nel armadietto n${e.armadietto} nel cassetto${e.casetto} <a href="./modificaprodotto/${e.idprodotto}" class="btn btn-light rounded-pill border-0 w-25 fw-semibold p-2"> modifica prodotto</a> <a href="./eliminaprodotto/${e.idprodotto}" class="btn btn-light rounded-pill border-0 w-25 fw-semibold p-2"> elimina dalla vendita </a> </p>
                                        <img src="/Content/img/uploads/${e.foto}"  class="rounded-circle img-magazzino"/>`
                            }
                        }
                        else { p = `<p class="m-2"> ${e.nome} prodotto non più in vendita <a href="./modificaprodotto/${e.idprodotto}" class="btn btn-light rounded-pill border-0 w-25 fw-semibold p-2"> modifica prodotto</a> <a href="./eliminaprodotto/${e.idprodotto}"> rimetti in vendita</a>  </p>  <img src="/Content/img/uploads/${e.foto}"  class="rounded-circle img-magazzino" />` }
                    }
                    $("#div").append(p)
                })
            }
        })
    })
})