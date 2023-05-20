using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSEntityLayer.NewConcrete
{
    public class Ogrenci
    {
        [Key]
        public int OgrenciID { get; set; }
        public string OgrenciNo { get; set; }

        //Kimlik

        public Kimlik Kimlik { get; set; }
        public int KimlikID { get; set; }

        //Mufredat
        public Mufredat Mufredat { get; set; }
        public int MufredatID { get; set; }
        //Derskayit

        public ICollection<DersKayit> DersKayit { get; set; }

        //public Kullanicilar Kullanicilar { get; set; }

        //public Kullanicilar Kullanicilar { get; set; }
        //public int Id { get; set; } 

        //public ICollection<Dersler> Derslers { get; set; } //Sonradan ekledim




    }
}
