function Kitap() {
    var kitap = {
        Id: 0,
        Ad: $("#inputKitapAdi").val()
    };
    Post("Kitap/Kaydet", kitap, (data) => {
        alert("Başarılı!!");
    });
}
//function Kitap() {

//    var kitap = {
        
//    };

//    POST('Kitap/Kaydet', kitap, (data) => {

//        alert("Başarılı Bir Şekilde Kaydedildi");
//    });

//}