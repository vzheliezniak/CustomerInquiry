using Microsoft.EntityFrameworkCore;
using System;
namespace DataAccess.Models
{
    public partial class CustomersInquiryDBContext : DbContext
    {
        public CustomersInquiryDBContext()
        {
        }

        public CustomersInquiryDBContext(DbContextOptions<CustomersInquiryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<StatusLookup> StatusLookup { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB; Database=CustomersInquiryDB;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusLookup>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__StatusLo__C8EE204383C14295");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Amount).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('USD')");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Transacti__Custo__2E1BDC42");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Transacti__Statu__2D27B809");
            });
        }
    }
}
