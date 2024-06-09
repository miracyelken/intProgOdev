namespace Okul.Mvc.Models
{
    public class OgrDers
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public int DersId { get; set; }

        // İlişki özellikleri
        public List<Ders> Dersler { get; set; }
        public List<Ogrenci> Ogrenciler { get; set; }
    }
}
