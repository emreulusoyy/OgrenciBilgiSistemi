using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSEntityLayer.NewConcrete
{
    public class Dersler
    {
        [Key]
        public int DerslerID { get; set; }
        public string Kodu { get; set; }
        public string Adi { get; set; }
        public bool Durum { get; set; }
        public string Kredi { get; set; }

        //sonradan
        public ICollection<Mufredat> Mufredat { get; set; }

        public ICollection<DersKayit> DersKayit { get; set; }




    }
}
