using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KV.Entities.Models
{
    public partial class BookLibraryContext : DbContext
    {
        public BookLibraryContext()
        {
        }

        public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BarCode> BarCode { get; set; }
        public virtual DbSet<Bookinfo> Bookinfo { get; set; }
        public virtual DbSet<Timage> Timage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=112.74.53.114;Initial Catalog=BookLibrary;User ID=sa;Password=`1qaz!QAZ;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BarCode>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EntryTime).HasColumnType("datetime");

                entity.Property(e => e.Epc)
                    .IsRequired()
                    .HasColumnName("EPC")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bookinfo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasMaxLength(200);

                entity.Property(e => e.BNo).HasColumnName("b_no");

                entity.Property(e => e.Booksize)
                    .HasColumnName("booksize")
                    .HasMaxLength(20);

                entity.Property(e => e.CategoryNum)
                    .HasColumnName("categoryNum")
                    .HasMaxLength(50);

                entity.Property(e => e.Createtime)
                    .HasColumnName("createtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Isbn)
                    .HasColumnName("isbn")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Limg)
                    .HasColumnName("limg")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Mimg)
                    .HasColumnName("mimg")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pagecount)
                    .HasColumnName("pagecount")
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Publishdate)
                    .HasColumnName("publishdate")
                    .HasColumnType("date");

                entity.Property(e => e.Publisher)
                    .HasColumnName("publisher")
                    .HasMaxLength(100);

                entity.Property(e => e.Remark)
                    .HasColumnName("remark")
                    .HasMaxLength(2000);

                entity.Property(e => e.Simg)
                    .HasColumnName("simg")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(500);

                entity.Property(e => e.Translation)
                    .HasColumnName("translation")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Timage>(entity =>
            {
                entity.ToTable("TImage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
        public void Insert<T>(T t)where T:class {
            Set<T>().Add(t);
        }
    }
}
