using Fresenius.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Fresenius.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base(nameOrConnectionString: "MyDbContext")
        {}

        public DbSet<User> Users { get; set; }
    }
}