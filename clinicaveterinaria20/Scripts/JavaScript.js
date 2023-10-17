$(document).ready(function () {
    $(`#btn`).click(function () {
        let impt = $(`#input`).val();
        $.ajax({
            method: 'POST',
            url: 'magazion',
            data: { nome: impt },
            success: function (data) {
                $.each(data, function (n, e) {
                    console.log(e)
                    if (e.quantita == 0) {
                        let p = `prodotto mometaneamente non presente`
                    }
                    else {
                        let p = `ci sono ${e.quantita} ${e.nome} con un costo ${e.costo}€ sitati nel armadietto n${e.armadietto}`
                    }
                })
            }
        })
    })
})