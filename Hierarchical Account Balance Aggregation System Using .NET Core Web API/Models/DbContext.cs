//this file has the interaction with DB
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace microtech_task_final.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        //mapping
        //virtual for dynamic bynding
        public virtual DbSet<Account> Accounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-00JH14J\\MSSQLSERVER08;Database=TestDev;Trusted_Connection=True;");
            }
        }

        //define specs of db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccNumber);

                entity.Property(e => e.AccNumber)
                    .HasMaxLength(10)
                    .HasColumnName("Acc_Number")
                    .IsFixedLength();

                entity.Property(e => e.AccParent)
                    .HasMaxLength(10)
                    .HasColumnName("ACC_Parent")
                    .IsFixedLength();

                entity.Property(e => e.Balance).HasColumnType("decimal(20, 9)");

                entity.HasOne(d => d.AccParentNavigation)
                    .WithMany(p => p.InverseAccParentNavigation)
                    .HasForeignKey(d => d.AccParent)
                    .HasConstraintName("FK_Accounts_Accounts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
