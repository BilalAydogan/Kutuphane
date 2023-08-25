function KitapOzetGetir() {
    Get("Kitap/KitapOzet", (data) => {
        var html = `<table class="table table-hover table-responsive">` +
            `<tr><th style="width:50px">Id</th><th>Kitap Adı</th> <th>Yazar Adı</th> <th>Yayin Yili</th> 
                    <th>ISBN</th> <th>Kitap Türü</th> <th>İşlemler</th></tr>`;

        var arr = data;

        for (var i = 0; i < arr.length; i++) {
            html += `<tr>`;
            html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td><td>${arr[i].yazar}</td><td>${arr[i].yayinYili}</td><td>${arr[i].isbn}</td><td>${arr[i].kategori_Ad}</td>`;
            html += `</tr>`
        }
        html += `</table>`;
        $("#divAnaSayfaKitaplar").html(html);
    });
}
$(document).ready(function () {
    KitapOzetGetir();
});