using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EfContexts
{
    public class Ef_Toptan : DbContext
    {
        //https://www.connectionstrings.com/sql-server/
        private static readonly string connectionString = @"server=.\sqlexpress;database=toptan;user id=sa;password=1sa";
        public Ef_Toptan() : base(connectionString)
        {
        }
    }
}