namespace OgrenciBilgiSistemi.Models
{
    public class DersDurumModel
    {
        public int DerslerID { get; set; }
        public int OgrenciID { get; set; }
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public bool Durum { get; set; }
        
    }
}
