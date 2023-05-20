using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSEntityLayer.NewConcrete
{
    public class Mufredat
    {
        [Key]
        public int MufredatID { get; set; }
        public string MufredatAdi { get; set; }

        //mufredat
        //sonradan
        public ICollection<Dersler> Derslers { get; set; }
        //public ICollection<Ogrenci> Ogrencis { get; set; } //sonradan




    }
}
