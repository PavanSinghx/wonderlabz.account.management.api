using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace wonderlabz.account.management.api.Models.Mappings
{
    public partial class BankingContext : DbContext
    {
        public BankingContext()
        {
        }

        public BankingContext(DbContextOptions<BankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAccountType> TbAccountType { get; set; }
        public virtual DbSet<TbUser> TbUser { get; set; }
        public virtual DbSet<TbUserTransactionHistory> TbUserTransactionHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAccountType>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId)
                    .HasName("PK__tb_Accou__8F9585AFCA897F76");

                entity.ToTable("tb_AccountType");

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tb_User__1788CC4CD3CA48D7");

                entity.ToTable("tb_User");

                entity.Property(e => e.Firstnames)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbUserTransactionHistory>(entity =>
            {
                entity.HasKey(e => e.UserTransactionHistoryId)
                    .HasName("PK__tb_UserT__526CBC85B64612B1");

                entity.ToTable("tb_UserTransactionHistory");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.TbUserTransactionHistory)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tb_UserTr__Accou__02084FDA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TbUserTransactionHistory)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tb_UserTr__UserI__01142BA1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
