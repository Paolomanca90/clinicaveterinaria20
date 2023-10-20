$(document).ready(function () {
    $(`#btn`).click(function () {
        let impt = $(`#input`).val();
        $.ajax({
            method: 'POST',
            url: 'magazion',
            data: { nome: impt },
            success: function (data) {
                $("#trmagazzino").empty()
                $.each(data, function (n, e) {
                    console.log(e)
                    let p = ""
                    if (e.nome == "prodotto insesistente") {
                        p = `<p> prodotto insesistente </p>`
                    }
                    else {
                        $("#tabellaProdotti").show()
                        if (e.invendita) {
                          
                           


                            p = ` 
            <tr class="fst-italic fs-5">
               
     
                            <td>
      <i class="fa-solid fa-check" style="color: #305700;"></i>
                </td>
                <td>
                <img src="/Content/img/uploads/${e.foto}"  class="rounded-circle img-magazzino" /> </td>
                <td>
       ${e.quantita}
                </td>
                <td>
          ${e.nome}
                </td>
                <td>
                ${e.costo}€
                </td>
                <td>
                ${e.casetto}
           
                    modello.armadietto
                 
                </td>
                <td>
                ${e.armadietto}
                   
                </td>        
                <td><a href="./modificaprodotto/${e.idprodotto}" > modifica prodotto</a> - <a href="./eliminaprodotto/${e.idprodotto}"> elimina dalla vendita</a>  </td>
                </tr>`
                      
                        }
                        else {
                            p = ` 
            <tr class="fst-italic fs-5">
               
     
                            <td>
              <i class="fa-solid fa-xmark" style="color: #ff0000;"></i>
                </td>
                <td>
                <img src="/Content/img/uploads/${e.foto}"  class="rounded-circle img-magazzino" /> </td>
                <td>
       ${e.quantita}
                </td>
                <td>
          ${e.nome}
                </td>
                <td>
                ${e.costo}€
                </td>
                <td>
                ${e.casetto}
           
                    modello.armadietto
                 
                </td>
                <td>
                ${e.armadietto}
                   
                </td>        
                <td><a href="./modificaprodotto/${e.idprodotto}" > modifica prodotto</a> - <a href="./eliminaprodotto/${e.idprodotto}"> rimetti in vendita</a>  </td>
                </tr>` }
                    }
                    $("#tabellaProdotti").append(p)
                })
            }
        })
    })
})