using Microsoft.AspNetCore.Identity;
using OBSEntityLayer.NewConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Kullanicilar:IdentityUser<int>
    {
        public bool Tur { get; set; }
        public Kimlik Kimlik { get; set; }
        public int KimlikID { get; set; }

        //public Ogrenci Ogrenci { get; set; }
        //public int OgrenciID { get; set; }

        //Sonradan


    }
}
