function KitaplariGetir() {
    $.ajax({
        type: "GET",
        url: `${BASE_API_URI}/api/Kitap/TumKitaplar`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.success) {

                var html = `<table class="table table-hover">` +
                    `<tr><th style="width:50px">Id</th><th>Kitap Adı</th> <th>Yazar Adı</th> <th>Yayin Yili</th> 
                    <th>ISBN</th>  <th>ToplamKopya</th> <th>KullanilabilirKopya</th> <th></th></tr>`;

                var arr = response.data;

                for (var i = 0; i < arr.length; i++) {
                    html += `<tr>`;
                    html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td><td>${arr[i].yazar}</td><td>${arr[i].yayinYili}</td><td>${arr[i].isbn}</td><td>${arr[i].toplamKopya}</td><td>${arr[i].kullanilabilirKopya}</td>`;
                    html += `<td><i class="bi bi-trash text-danger" onclick='RolSil(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='RolDuzenle(${arr[i]})'></i></td>`;
                    html += `</tr>`
                }
                html += `</table>`;

                $("#divKitaplar").html(html);
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
function KitapKaydet() {
    var rol = {
        Id: 0,
        Ad: $("#inputKitapAd").val(),
        Yazar: $("#inputYazarAd").val(),
        YayinYili: $("#inputYayinYili").val(),
        ISBN: $("#inputISBN").val(),
        ToplamKopya: $("#inputToplamKopya").val(),
        KullanilabilirKopya: $("#inputKullanilabilirKopya").val()
    };
    $.ajax({
        type: "POST",
        url: `${BASE_API_URI}/api/Kitap/Kaydet`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(rol),
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
    KitaplariGetir();
});