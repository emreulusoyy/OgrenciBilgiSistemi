using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSEntityLayer.NewConcrete
{
    public class Kimlik
    {

        [Key] 
        public int KimlikID { get; set; }
        public string Tc { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string DogumYeri { get; set; }
        public DateTime DogumTarihi { get; set; }

        //iletisim

        public Iletisim Iletisim { get; set; }
        public int IletisimID { get; set; }

        //kullanicilar

        public Kullanicilar Kullanicilar { get; set; }

        //ogrenciler

        public Ogrenci Ogrenci { get; set; }

    }
}
