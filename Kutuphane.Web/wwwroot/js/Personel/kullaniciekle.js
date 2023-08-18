function KullaniciGetir() {
    Get("Kullanici/TumKullanicilar", (data) => {

        var html = `<table class="table table-hover">` +
            `<tr>
            <th style="width:50px">Id</th>
            <th>Ad</th>
            <th>Soyad</th>
            <th>Email</th> 
            <th>Sifre</th>
            <th>TelNo</th>
            <th>RolId</th>
            <th>Aktif</th>
            <th>Kayit Tarihi</th>
            <th>Adres</th>
            <th>Foto</th>
            <th>İşlemler</th>
            </tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `
            <td>${arr[i].id}</td>
            <td>${arr[i].ad}</td>
            <td>${arr[i].soyad}</td>
            <td>${arr[i].email}</td>
            <td>${arr[i].sifre}</td>
            <td>${arr[i].telNo}</td>
            <td>${arr[i].rolId}</td>
            <td>${arr[i].aktif}</td>
            <td>${arr[i].kayitTarih}</td>
            <td>${arr[i].adres}</td>
            <td>${arr[i].foto}</td>
            `;
            html += `<td><i class="btn btn-danger" onclick='alert("silme eklenecek")'>Sil</i> <i class="btn btn-info" onclick='alert("Kiralama Düzenleme Eklenecek!");'>Düzenle</i></td>`;
            html += `</tr>`
        }
        html += `</table>`;
        $("#divKullanicilar").html(html);
    });
}
function RolleriGetir() {
    Get("Rol/TumRoller", (data) => {
        $('#selectRolId').empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectRolId').append($('<option>', {
                value: item.id,
                text: item.ad,
                data_tokens: item.ad

            }));
        });
    });
}
function KullaniciKaydet() {
    var kullanici = {
        Id: 0,
        Ad: $("#inputKullaniciAd").val(),
        Soyad: $("#inputKullaniciSoyad").val(),
        Email: $("#inputEmail").val(),
        Sifre: $("#inputSifre").val(),
        TelNo: $("#inputTelNo").val(),
        RolId: $("#selectRolId").find(":selected").val(),
        Aktif: $("#inputAktifMi").is(":checked"),
        KayitTarih: moment().format(),
        Adres: $("#inputAdres").val(),
        Foto:null,
    };
    Post("Kullanici/Kaydet", kullanici, (data) => {
        KullaniciGetir();
        RolleriGetir();
        $("#kullaniciModal").modal('hide');
    });
}
function KullaniciSil(id) {
    Delete(`Kullanici/Sil?id=${id}`, (data) => {
        KullaniciGetir();
        RolleriGetir();
    });
}
$(document).ready(function () { KullaniciGetir(); RolleriGetir(); });