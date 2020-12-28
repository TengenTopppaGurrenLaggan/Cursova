using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=BURSE")
        {
        }

        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Cust> Custs { get; set; }
        public virtual DbSet<Resume> Resumes { get; set; }
        public virtual DbSet<Unem> Unems { get; set; }
        public virtual DbSet<Vac> Vacs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unem>()
                .Property(e => e.Name)
                .IsUnicode(false);
            //modelBuilder.Entity<Resume>()
            //    .HasMany(p => p.Une);

            //modelBuilder.Entity<Resume>()
            //   .HasMany(p => p.Cat);

            modelBuilder.Entity<Unem>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Vac>()
                .Property(e => e.Vacname)
                .IsUnicode(false);
        }
    }
}
