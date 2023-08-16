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
function KiralamaKaydet() {
    var kiralama = {
        Id: 0,
        KitapId: $("#inputKitapId").val(),
        KullaniciId: $("#inputKullaniciId").val(),
        KiralamaTarih: moment().format(),
        BitisTarih: moment().add(14, 'days').calendar(),
        GeriVerisTarih: null
    };
    Post("Kiralama/Kaydet", kiralama, (data) => {
        KiralamalariGetir();
        $("#kiralamaModal").modal('hide');
    });
}
function KiralamaSil(id) {
    Delete(`Kiralama/Sil?id=${id}`, (data) => {
        KiralamalariGetir();
    });
}



$(document).ready(function () {
    KiralamalariGetir();
});