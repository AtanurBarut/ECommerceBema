using DataAcccess.Concrete.EntityFremawork.Mapping;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcccess.Concrete.Contexts
{
    public class ECommerceBemaContext : DbContext
    {
        public ECommerceBemaContext(DbContextOptions<ECommerceBemaContext> options) : base(options)
        {

        }
        public ECommerceBemaContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connString = "Data Source=.\\SQLEXPRESS; Initial Catalog = ECommerceBemaDB; Intagrated Security = true";
            string connString = "Data Source=.; Initial Catalog = ECommerceBemaDB; User Id=sa; Password=sapass";
            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
