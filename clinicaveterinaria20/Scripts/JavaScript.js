$(document).ready(function () {
    $(`#btn`).click(function () {
        let impt = $(`#input`).val();
        $.ajax({
            method: 'POST',
            url: 'magazion',
            data: { nome: impt },
            success: function (data) {
                $("#tabellaBody").empty()
                $.each(data, function (n, e) {
                    console.log(e)
                    let p = ""
                    if (e.nome == "prodotto insesistente") {
                        $("#tabellaProdotti").show()
                        $("#tabellaHead").hide()
                        p = `<p class="text-center text-danger fst-italic light"> Prodotto inesistente </p>`
                    }
                    else {
                        $("#tabellaProdotti").show()
                        $("#tabellaHead").show()
                        if (e.invendita) {
                          
                           


                            p = ` 
            <tr class="fst-italic fs-5 light">
               
     
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
           
 
                 
                </td>
                <td>
                ${e.armadietto}
                   
                </td>        
                <td><a href="./modificaprodotto/${e.idprodotto}" > modifica prodotto</a> - <a href="./eliminaprodotto/${e.idprodotto}"> elimina dalla vendita</a>  </td>
                </tr>`
                      
                        }
                        else {
                            p = ` 
            <tr class="fst-italic fs-5 light">
               
     
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
           
                    
                 
                </td>
                <td>
                ${e.armadietto}
                   
                </td>        
                <td><a href="./modificaprodotto/${e.idprodotto}" > modifica prodotto</a> - <a href="./eliminaprodotto/${e.idprodotto}"> rimetti in vendita</a>  </td>
                </tr>` }
                    }
                    $("#tabellaBody").append(p)
                })
            }
        })
    })
})