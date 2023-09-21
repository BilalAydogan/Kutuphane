namespace Kutuphane.Web.Models
{
    public class KitapModel
    {
        public int id;
        public string ad;
        public string yazar;
        public int yayinYili;
        public string isbn;
        public int kategoriId;
        public string? kitapKategori;
    }
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
