using OBSEntityLayer.NewConcrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DersKayit

    {
        [Key]
        public int DersKayitID { get; set; }
        public DateTime CreatedDate { get; set; }


        public Ogrenci Ogrenci { get; set; }

        public int OgrenciID { get; set; }

        public Dersler Dersler { get; set; }
        public int DerslerID { get; set; }


    }
}
