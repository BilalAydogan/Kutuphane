function KategorileriGetir() {
    Get("Kategori/TumKategoriler", (data) => {

        var html = `<table class="table table-hover table-responsive">` +
            `<tr><th style="width:50px">Id</th><th>Rol Adı</th><th></th></tr>`;
        var arr = data;
        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td>`;
            html += `<td><i class="btn btn-danger" onclick='RolSil(${arr[i].id})'> Sil </i>
                    <button type="button" style="width:100px " class="btn btn-info" data-bs-toggle="collapse" onclick = 'KategoriDuzenle(${arr[i].id},"${arr[i].ad}")'> Düzenle </button></td>`;
            html += `</tr>`
        }
        html += `</table>`;

        $("#divKitapKategori").html(html);

    });
}
let selectedKategoriId = 0;

function YeniKategori() {
    selectedKategoriId = 0;
    $("#inputKitapKategoriAd").val("");
    $("#kategoriModal").modal("show");
}
function KategoriKaydet() {
    var kategori = {
        Id: selectedKategoriId,
        Ad: $("#inputKitapKategoriAd").val()
    };
    Post("Kategori/Kaydet", kategori, (data) => {
        KategorileriGetir();
        $("#kategoriModal").modal('hide');
        alert("Başarılı!!");
    });
}


function KategoriSil(id) {
    Delete(`Kategori/Sil?id=${id}`, (data) => {
        RolleriGetir();
        alert("Başarılı Bir Şekilde Silindi!!!");
    });
}

function KategoriDuzenle(id, ad) {
    selectedKategoriId = id;
    $("#inputKitapKategoriAd").val(ad);
    $("#kategoriModal").modal("show");
}

$(document).ready(function () {
    KategorileriGetir();
});