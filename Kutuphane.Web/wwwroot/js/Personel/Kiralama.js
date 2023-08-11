function KiralamalariGetir() {
    $.ajax({
        type: "GET",
        url: `${BASE_API_URI}/api/Kiralama/TumKiralamalar`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.success) {

                var html = `<table class="table table-hover">` +
                    `<tr><th style="width:50px">Id</th><th>KitapId</th> <th>KullaniciId</th> <th>KiralamaTarih</th> 
                    <th>BitisTarih</th>  <th>GeriVerisTarih</th> <th>İşlemler</th></tr>`;

                var arr = response.data;

                for (var i = 0; i < arr.length; i++) {
                    html += `<tr>`;
                    html += `<td>${arr[i].id}</td><td>${arr[i].kitapId}</td><td>${arr[i].kullaniciId}</td><td>${arr[i].kiralamaTarih}</td><td>${arr[i].bitisTarih}</td><td>${arr[i].geriVerisTarih}</td>`;
                    html += `<td><i class="bi bi-trash text-danger" onclick='alert("Kiralama Silme Eklenecek!");'></i><i class="bi bi-pencil-square" onclick='alert("Kiralama Düzenleme Eklenecek!");'></i></td>`;
                    html += `</tr>`
                }
                html += `</table>`;

                $("#divKiralamalar").html(html);
            }
            else {
                alert(response.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });
}
function KiralamaKaydet() {
    var kiralama = {
        Id: 0,
        KitapId: $("#inputKitapId").val(),
        KullaniciId: $("#inputKullaniciId").val(),
        YKiralamaTarih: $("#inputKiralamaTarih").val(),
        BitisTarih: $("#inputBitisTarih").val(),
        GeriVerisTarih: $("#inputGeriVerisTarih").val()
    };
    $.ajax({
        type: "POST",
        url: `${BASE_API_URI}/api/Kitap/Kaydet`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(kiralama),
        success: function (response) {
            if (response.success) {
                KitaplariGetir();
            }
            else {
                alert(response.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });
}



$(document).ready(function () {
    KiralamalariGetir();
});