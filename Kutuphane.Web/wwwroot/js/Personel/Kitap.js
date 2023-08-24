function KitaplariGetir() {
    Get("Kitap/TumKitaplar", (data) => {
        var html = `<table class="table table-hover table-responsive">` +
                    `<tr><th style="width:50px">Id</th><th>Kitap Adı</th> <th>Yazar Adı</th> <th>Yayin Yili</th> 
                    <th>ISBN</th> <th>İşlemler</th></tr>`;

                var arr = data;

                for (var i = 0; i < arr.length; i++) {
                    html += `<tr>`;
                    html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td><td>${arr[i].yazar}</td><td>${arr[i].yayinYili}</td><td>${arr[i].isbn}</td>`;
                    html += `<td><i class="btn btn-danger" onclick='alert("Kitap Silme Eklenecek!");'> Sil </i>
                    <i class="btn btn-info" onclick='KitapDuzenle(${arr[i].id},"${arr[i].ad}","${arr[i].yazar}","${arr[i].yayinYili}","${arr[i].isbn}")'> Düzenle </i></td>`;
                    html += `</tr>`
                }
                html += `</table>`;          
    });
}
function KitapKategoriGetir() {
    Get("Kategori/TumKategoriler", (data) => {
        $('#selectKitapKategoriId').empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectKitapKategoriId').append($('<option>', {
                value: item.id,
                text: item.ad,
                data_tokens: item.ad

            }));
        });
    });
}
function KitapOzetGetir() {
    Get("Kitap/KitapOzet", (data) => {
        var html = `<table class="table table-hover table-responsive">` +
            `<tr><th style="width:50px">Id</th><th>Kitap Adı</th> <th>Yazar Adı</th> <th>Yayin Yili</th> 
                    <th>ISBN</th> <th>Kitap Türü</th> <th>İşlemler</th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td><td>${arr[i].yazar}</td><td>${arr[i].yayinYili}</td><td>${arr[i].isbn}</td><td>${arr[i].kategori_Ad}</td>`;
            html += `<td><i class="btn btn-danger" onclick='alert("Kitap Silme Eklenecek!");'> Sil </i>
                    <i class="btn btn-info" onclick='KitapDuzenle(${arr[i].id},"${arr[i].ad}","${arr[i].yazar}","${arr[i].yayinYili}","${arr[i].isbn}")'> Düzenle </i></td>`;
            html += `</tr>`
        }
        html += `</table>`;
        $("#divKitaplar").html(html);
    });
}

selectedKitapId = 0;
function KitapKaydet() {
    var kitap = {
        Id: selectedKitapId,
        Ad: $("#inputKitapAd").val(),
        Yazar: $("#inputYazarAd").val(),
        YayinYili: $("#inputYayinYili").val(),
        ISBN: $("#inputISBN").val(),
        KategoriId: $('#selectKitapKategoriId').val()
    };
    Post("Kitap/Kaydet", kitap, (data) => {
        KitaplariGetir();
        KitapOzetGetir()
        $("#kitapModal").modal('hide');
        alert("Başarılı!!");
    });
}
function KitapSil(id) {
    Delete(`Kitap/Sil?id=${id}`, (data) => {
        KitaplariGetir();
        KitapOzetGetir()
    });
}

function KitapDuzenle(id, ad, yazar, yayinYili, isbn) {
    selectedKitapId = id;
    $("#inputKitapAd").val(ad);
    $("#inputYazarAd").val(yazar);
    $("#inputYayinYili").val(yayinYili);
    $("#inputISBN").val(isbn);
    $("#kitapModal").modal("show");
}
$(document).ready(function () {
    KitaplariGetir();
    KitapOzetGetir();
    KitapKategoriGetir();
});