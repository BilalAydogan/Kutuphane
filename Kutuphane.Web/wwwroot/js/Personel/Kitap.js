function KitaplariGetir() {
    Get("Kitap/TumKitaplar", (data) => {
                var html = `<table class="table table-hover">` +
                    `<tr><th style="width:50px">Id</th><th>Kitap Adı</th> <th>Yazar Adı</th> <th>Yayin Yili</th> 
                    <th>ISBN</th>  <th>ToplamKopya</th> <th>KullanilabilirKopya</th> <th>İşlemler</th></tr>`;

                var arr = data;

                for (var i = 0; i < arr.length; i++) {
                    html += `<tr>`;
                    html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td><td>${arr[i].yazar}</td><td>${arr[i].yayinYili}</td><td>${arr[i].isbn}</td><td>${arr[i].toplamKopya}</td><td>${arr[i].kullanilabilirKopya}</td>`;
                    html += `<td><i class="btn btn-danger" onclick='alert("Kitap Silme Eklenecek!");'> Sil </i> <i class="btn btn-info" onclick='alert("Kitap Düzenleme Eklenecek!");'> Düzenle </i></td>`;
                    html += `</tr>`
                }
                html += `</table>`;
        $("#divKitaplar").html(html);            
    });
}
function KitapKaydet() {
    var kitap = {
        Id: 0,
        Ad: $("#inputKitapAd").val(),
        Yazar: $("#inputYazarAd").val(),
        YayinYili: $("#inputYayinYili").val(),
        ISBN: $("#inputISBN").val(),
        ToplamKopya: $("#inputToplamKopya").val(),
        KullanilabilirKopya: $("#inputKullanilabilirKopya").val()
    };
    Post("Kitap/Kaydet", kitap, (data) => {
        KitaplariGetir();
        $("#kitapModal").modal('hide');
    });
}
function KitapSil(id) {
    Delete(`Kitap/Sil?id=${id}`, (data) => {
        KitaplariGetir();
    });
}

function KitapDuzenle(id, ad) {
    selectedRolId = id;
    $("#inputRolAd").val(ad);
    $("#rolModal").modal("show");
}
$(document).ready(function () {
    KitaplariGetir();
});