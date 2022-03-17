using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MasterProjectDAL.DataModel
{
    public partial class MasterProjectContext : DbContext,IMasterProjectContext
    {
        //public MasterProjectContext()
        //{
        //}

        public MasterProjectContext(DbContextOptions<MasterProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("server=35.209.224.45;port=3306;user=akshay;password=WVb3H1981nJK;database=MasterProject");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasComment("																							");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
