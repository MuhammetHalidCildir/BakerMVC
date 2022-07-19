using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EfContexts
{
    public class Ef_Perakende : DbContext
    {
        //https://www.connectionstrings.com/sql-server/
        private static readonly string connectionString = @"server=.\sqlexpress;database=perakende;user id=sa;password=1";
        public Ef_Perakende() : base(connectionString)
        {
        }
    }
}