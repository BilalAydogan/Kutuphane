function KitaplariGetir() {
    Get("Kitap/TumKitaplar", (data) => {
        $('#selectKitapId').empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectKitapId').append($('<option>', {
                value: item.id,
                text: item.ad

            }));
        });
    });
}
function KullanicilariGetir() {
    Get("Kullanici/TumKullanicilar", (data) => {
        $('#selectKullaniciId').empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectKullaniciId').append($('<option>', {
                value: item.id,
                text: item.ad

            }));
        });
    });
}

function KiralamalariGetir() {
    Get("Kiralama/TumKiralamalar", (data) => {

                var html = `<table class="table table-hover">` +
                    `<tr><th style="width:50px">Id</th><th>KitapId</th> <th>KullaniciId</th> <th>KiralamaTarih</th> 
                    <th>BitisTarih</th>  <th>GeriVerisTarih</th> <th>İşlemler</th></tr>`;

                var arr = data;

                for (var i = 0; i < arr.length; i++) {
                    html += `<tr>`;
                    html += `<td>${arr[i].id}</td><td>${arr[i].kitapId}</td><td>${arr[i].kullaniciId}</td><td>${arr[i].kiralamaTarih}</td><td>${arr[i].bitisTarih}</td><td>${arr[i].geriVerisTarih}</td>`;
                    html += `<td><i class="btn btn-danger" onclick='alert("Kiralama Silme Eklenecek!");'>Sil</i> <i class="btn btn-info" onclick='alert("Kiralama Düzenleme Eklenecek!");'>Düzenle</i></td>`;
                    html += `</tr>`
                }
                html += `</table>`;
                $("#divKiralamalar").html(html);
    });
}
function KiralamaOzetGetir() {
    Get("Kiralama/KiralamaOzet", (data) => {

        var html = `<table class="table table-hover">` +
            `<tr><th style="width:50px">Id</th><th>KitapAd</th> <th>KullaniciAd</th> <th>KiralamaTarih</th> 
                    <th>BitisTarih</th>  <th>GeriVerisTarih</th> <th>İşlemler</th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`; 
            html += `<td>${arr[i].id}</td><td>${arr[i].kitapAd}</td><td>${arr[i].kullaniciAd}</td><td>${arr[i].kiralamaTarih}</td><td>${arr[i].bitisTarih}</td><td>${arr[i].geriVerisTarih}</td>`;
            html += `<td><i class="btn btn-danger" onclick='KiralamaSil(${arr[i].id})'>Sil</i> <i class="btn btn-info" onclick='alert("Kiralama Düzenleme Eklenecek!");'>Düzenle</i></td>`;
            html += `</tr>`
        }
        html += `</table>`;
        $("#divKiralamaOzet").html(html);
    });
}
function KiralamaKaydet() {
    var kiralama = {
        Id: 0,
        KitapId: $("#selectKitapId").val(),
        KullaniciId: $("#selectKullaniciId").val(),
        KiralamaTarih: moment().format(),
        BitisTarih: moment().add(14, 'days').calendar(),
        GeriVerisTarih: null
    };
    Post("Kiralama/Kaydet", kiralama, (data) => {
        KiralamalariGetir();
        KiralamaOzetGetir();
        KitaplariGetir();
        KullanicilariGetir();
        $("#kiralamaModal").modal('hide');
    });
}
function KiralamaSil(id) {
    Delete(`Kiralama/Sil?id=${id}`, (data) => {
        KiralamalariGetir();
        KiralamaOzetGetir();
        KitaplariGetir();
        KullanicilariGetir();
    });
}
$(document).ready(function () {
    KiralamalariGetir();
    KiralamaOzetGetir();
    KitaplariGetir();
    KullanicilariGetir();
});