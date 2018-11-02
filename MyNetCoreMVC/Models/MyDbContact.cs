using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyNetCoreMVC.Models
{
    public class MyDbContact : DbContext
    {
        public MyDbContact(DbContextOptions options) :
            base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public class Category {
            public long Id { get; set; }
            public string Name { get; set; }
        }

        public class Product {
            public long Id { get; set; }
            public string Name { get; set; }
            public string Price { get; set; } }


    }
}
