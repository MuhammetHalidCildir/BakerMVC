using Entities.Urunler;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EfContexts
{
    public class Ef_Urunler : DbContext
    {
        //https://www.connectionstrings.com/sql-server/
        private static readonly string connectionString = @"server=.\sqlexpress;database=urunler;user id=sa;password=1";
        public Ef_Urunler() : base(connectionString)
        {
        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<AltKategori> AltKategoriler { get; set; }
    }
}