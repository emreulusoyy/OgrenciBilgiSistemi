using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OBSEntityLayer.NewConcrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<Kullanicilar,Rol,int>

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VO9M4VR\\SQLEXPRESS;initial catalog=AtilimYeni; integrated security=true");
        }
          public DbSet<DersKayit> DersKayit { get; set; }

        public DbSet<Dersler> Derslers { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Kimlik> Kimliks { get; set; }
        public DbSet<Mufredat> Mufredats { get; set; }
        public DbSet<MufredatDersler> MufredatDerslers { get; set; }
        public DbSet<Ogrenci> Ogrencis { get; set; }
    }
}
