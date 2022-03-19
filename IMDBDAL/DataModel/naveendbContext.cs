using System;
using MasterProjectDAL.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IMDBDAL.DataModel
{
    public partial class naveendbContext : DbContext, InaveendbContext
    {
        //public naveendbContext()
        //{
        //}

        public naveendbContext(DbContextOptions<naveendbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Producer> Producer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=N@veen9100;database=naveendb");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.IdActor)
                    .HasName("PRIMARY");

                entity.ToTable("actor");

                entity.Property(e => e.IdActor).HasColumnName("idActor");

                entity.Property(e => e.ActorName)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.IdMovie)
                    .HasName("PRIMARY");

                entity.ToTable("movie");

                entity.HasIndex(e => e.ActorId)
                    .HasName("Id_Actor_idx");

                entity.HasIndex(e => e.ProducerId)
                    .HasName("Id_Producer_idx");

                entity.Property(e => e.IdMovie).HasColumnName("idMovie");

                entity.Property(e => e.DateOfRelease).HasColumnType("date");

                entity.Property(e => e.MovieName)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.ActorId)
                    .HasConstraintName("Id_Actor");

                entity.HasOne(d => d.Producer)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.ProducerId)
                    .HasConstraintName("Id_Producer");
            });

            modelBuilder.Entity<Producer>(entity =>
            {
                entity.HasKey(e => e.IdProducer)
                    .HasName("PRIMARY");

                entity.ToTable("producer");

                entity.Property(e => e.IdProducer).HasColumnName("idProducer");

                entity.Property(e => e.ProducerName)
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
