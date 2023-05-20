using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSEntityLayer.NewConcrete
{
    public class MufredatDersler
    {
        [Key]
        public int MufredatDerslerID { get; set; }

        public Mufredat Mufredat { get; set; }
        public int MufredatID { get; set; }

        public Dersler Dersler { get; set; }
        public int DerslerID { get; set; }

    }
}
