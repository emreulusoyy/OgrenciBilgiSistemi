﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DerslerMufredat", b =>
                {
                    b.Property<int>("DerslersDerslerID")
                        .HasColumnType("int");

                    b.Property<int>("MufredatID")
                        .HasColumnType("int");

                    b.HasKey("DerslersDerslerID", "MufredatID");

                    b.HasIndex("MufredatID");

                    b.ToTable("DerslerMufredat");
                });

            modelBuilder.Entity("EntityLayer.Concrete.DersKayit", b =>
                {
                    b.Property<int>("DersKayitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DerslerID")
                        .HasColumnType("int");

                    b.Property<int>("OgrenciID")
                        .HasColumnType("int");

                    b.HasKey("DersKayitID");

                    b.HasIndex("DerslerID");

                    b.HasIndex("OgrenciID");

                    b.ToTable("DersKayit");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kullanicilar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("KimlikID")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Tur")
                        .HasColumnType("bit");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("KimlikID")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.Dersler", b =>
                {
                    b.Property<int>("DerslerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Kodu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kredi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DerslerID");

                    b.ToTable("Derslers");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.Iletisim", b =>
                {
                    b.Property<int>("IletisimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gsm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Il")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ilce")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IletisimID");

                    b.ToTable("Iletisims");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.Kimlik", b =>
                {
                    b.Property<int>("KimlikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("DogumYeri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IletisimID")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KimlikID");

                    b.HasIndex("IletisimID");

                    b.ToTable("Kimliks");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.Mufredat", b =>
                {
                    b.Property<int>("MufredatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MufredatAdi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MufredatID");

                    b.ToTable("Mufredats");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.MufredatDersler", b =>
                {
                    b.Property<int>("MufredatDerslerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DerslerID")
                        .HasColumnType("int");

                    b.Property<int>("MufredatID")
                        .HasColumnType("int");

                    b.HasKey("MufredatDerslerID");

                    b.HasIndex("DerslerID");

                    b.HasIndex("MufredatID");

                    b.ToTable("MufredatDerslers");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KimlikID")
                        .HasColumnType("int");

                    b.Property<int>("MufredatID")
                        .HasColumnType("int");

                    b.Property<string>("OgrenciNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OgrenciID");

                    b.HasIndex("KimlikID")
                        .IsUnique();

                    b.HasIndex("MufredatID");

                    b.ToTable("Ogrencis");
                });

            modelBuilder.Entity("DerslerMufredat", b =>
                {
                    b.HasOne("OBSEntityLayer.NewConcrete.Dersler", null)
                        .WithMany()
                        .HasForeignKey("DerslersDerslerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBSEntityLayer.NewConcrete.Mufredat", null)
                        .WithMany()
                        .HasForeignKey("MufredatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Concrete.DersKayit", b =>
                {
                    b.HasOne("OBSEntityLayer.NewConcrete.Dersler", "Dersler")
                        .WithMany("DersKayit")
                        .HasForeignKey("DerslerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBSEntityLayer.NewConcrete.Ogrenci", "Ogrenci")
                        .WithMany("DersKayit")
                        .HasForeignKey("OgrenciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dersler");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Kullanicilar", b =>
                {
                    b.HasOne("OBSEntityLayer.NewConcrete.Kimlik", "Kimlik")
                        .WithOne("Kullanicilar")
                        .HasForeignKey("EntityLayer.Concrete.Kullanicilar", "KimlikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kimlik");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Kullanicilar", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Kullanicilar", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Kullanicilar", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Kullanicilar", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.Kimlik", b =>
                {
                    b.HasOne("OBSEntityLayer.NewConcrete.Iletisim", "Iletisim")
                        .WithMany()
                        .HasForeignKey("IletisimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Iletisim");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.MufredatDersler", b =>
                {
                    b.HasOne("OBSEntityLayer.NewConcrete.Dersler", "Dersler")
                        .WithMany()
                        .HasForeignKey("DerslerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBSEntityLayer.NewConcrete.Mufredat", "Mufredat")
                        .WithMany()
                        .HasForeignKey("MufredatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dersler");

                    b.Navigation("Mufredat");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.Ogrenci", b =>
                {
                    b.HasOne("OBSEntityLayer.NewConcrete.Kimlik", "Kimlik")
                        .WithOne("Ogrenci")
                        .HasForeignKey("OBSEntityLayer.NewConcrete.Ogrenci", "KimlikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OBSEntityLayer.NewConcrete.Mufredat", "Mufredat")
                        .WithMany()
                        .HasForeignKey("MufredatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kimlik");

                    b.Navigation("Mufredat");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.Dersler", b =>
                {
                    b.Navigation("DersKayit");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.Kimlik", b =>
                {
                    b.Navigation("Kullanicilar");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("OBSEntityLayer.NewConcrete.Ogrenci", b =>
                {
                    b.Navigation("DersKayit");
                });
#pragma warning restore 612, 618
        }
    }
}
