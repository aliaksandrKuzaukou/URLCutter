using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using UrlCutterApp.Models;
using MySql.Data.MySqlClient;

namespace UrlCutterApp.Contexts
{
    public class URLContext:DbContext
    {
        public DbSet<URLAdress> URLAdresses { get; set; }
        public URLContext(DbContextOptions<URLContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
