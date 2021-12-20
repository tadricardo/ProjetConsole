using System;
using System.Data.Entity;
using System.Linq;

namespace FiltersMVCDemo.Models
{
    public class MyContext : DbContext
    {
       
        public MyContext()
            : base("name=MyContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }

   
}