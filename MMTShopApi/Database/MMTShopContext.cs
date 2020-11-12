using Microsoft.EntityFrameworkCore;
using MMTShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShopApi.Database
{
    public class MMTShopContext : DbContext
    {
        public MMTShopContext(DbContextOptions<MMTShopContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


    }
}
