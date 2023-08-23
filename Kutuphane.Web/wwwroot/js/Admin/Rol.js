function RolleriGetir() {
    Get("Rol/TumRoller", (data) => {

        var html = `<table class="table table-hover table-responsive">` +
                    `<tr><th style="width:50px">Id</th><th>Rol Adı</th><th></th></tr>`;
                var arr = data;
                for (var i = 0; i < arr.length; i++) {
                    html += `<tr>`;
                    html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td>`;
                    html += `<td><i class="btn btn-danger" onclick='RolSil(${arr[i].id})'> Sil </i>
                    <button type="button" style="width:100px " class="btn btn-info" data-bs-toggle="collapse" onclick = 'RolDuzenle(${arr[i].id},"${arr[i].ad}")'> Düzenle </button></td>`;
                    html += `</tr>`
                }
                html += `</table>`;

                $("#divRoller").html(html);
            
    });
}
let selectedRolId = 0;

function YeniRol() {
    selectedRolId = 0;
    $("#inputRolAd").val("");
    $("#rolModal").modal("show");
}
function RolKaydet() {
    var rol = {
        Id: selectedRolId,
        Ad: $("#inputRolAd").val()
    };
    Post("Rol/Kaydet", rol, (data) => {
        RolleriGetir();
        $("#rolModal").modal('hide');
        alert("Başarılı!!");
    });
}


function RolSil(id) {
    Delete(`Rol/Sil?id=${id}`, (data) => {
        RolleriGetir();
        alert("Başarılı Bir Şekilde Silindi!!!");
    });
}

function RolDuzenle(id, ad) {
    selectedRolId = id;
    $("#inputRolAd").val(ad);
    $("#rolModal").modal("show");
}

$(document).ready(function () {
    RolleriGetir();
});