using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectMIPFinal.Models
{
    public class Accesorii
    {

        public int ID { get; set; }
        public int CheieRezerva { get; set; }
        public string Logo { get; set; }
        public string ParfumMasina { get; set; }
    }

    public class AccesoriiDbContext : DbContext
    {
        public DbSet<Accesorii> AccesoriiSet { get; set; }
    }
}