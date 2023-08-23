function KullaniciGetir() {
    Get("Kullanici/TumKullanicilar", (data) => {

        var html = `<table class="table table-hover table-responsive">` +
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
            `;
            html += `<td><i class="btn btn-danger" onclick='KullaniciSil(${arr[i].id})'>Sil</i>
            <i class="btn btn-info" onclick='KullaniciDuzenle(${arr[i].id},"${arr[i].ad}",
            "${arr[i].soyad}","${arr[i].email}","${arr[i].sifre}","${arr[i].telNo}",
            "${arr[i].rol}","${arr[i].adres}","${arr[i].aktif}","${arr[i].kayitTarih}","${arr[i].foto}")'>Düzenle</i></td>`;
            html += `</tr>`
        }
        html += `</table>`;
        $("#divKullanicilar").html(html);
    });
}
function RolleriGetir() {
    Get("Rol/TumRoller", (data) => {
        $('#selectRolId').empty();
        $('#selectRolIdDuzenle').empty();
        var arr = data;
        $.each(arr, function (i, item) {
            $('#selectRolId').append($('<option>', {
                value: item.id,
                text: item.ad,
                data_tokens: item.ad

            }));
        });
        $.each(arr, function (i, item) {
            $('#selectRolIdDuzenle').append($('<option>', {
                value: item.id,
                text: item.ad,
                data_tokens: item.ad

            }));
        });
    });
}
selectedKullaniciId = 0;
function KullaniciKaydet() {
    var kullanici = {
        Id: selectedKullaniciId,
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
function KullaniciKaydet2() {
    var kullanici2 = {
        Id: 1002,
        Ad: $("#inputKullaniciAdDuzenle").val(),
        Soyad: $("#inputKullaniciSoyadDuzenle").val(),
        Email: $("#inputEmailDuzenle").val(),
        Sifre: $("#inputSifreDuzenle").val(),
        TelNo: $("#inputTelNoDuzenle").val(),
        Rol: $("#selectRolIdDuzenle").find(":selected").val(),
        Aktif: $("#inputAktifMiDuzenle").is(":checked"),
        KayitTarih: $("#inputKayitTarihDuzenle").val(),
        Adres: $("#inputAdresDuzenle").val(),
        Foto: null
    };
    Post("Kullanici/Kaydet", kullanici2, (data) => {
        KullaniciGetir();
        RolleriGetir();
        $("#kullaniciduzenleModal").modal('hide');
    });
}
function KullaniciDuzenle(id, ad, soyad, email, sifre, telNo, rol, adres, aktif, kayitTarih,foto) {
    selectedKullaniciId = id;
    $("#inputKullaniciAdDuzenle").val(ad);
    $("#inputKullaniciSoyadDuzenle").val(soyad);
    $("#inputEmailDuzenle").val(email);
    $("#inputSifreDuzenle").val(sifre);
    $("#inputTelNoDuzenle").val(telNo);
    $("#inputRolIdDuzenle").val(rol);
    $("#inputAdresDuzenle").val(adres);
    $("#inputAktifMiDuzenle").val(aktif);
    $("#inputKayitTarihDuzenle").val(kayitTarih);
    $("#inputFotoDuzenle").val(foto);
    $("#kullaniciduzenleModal").modal("show");
}
$(document).ready(function () { KullaniciGetir(); RolleriGetir(); });