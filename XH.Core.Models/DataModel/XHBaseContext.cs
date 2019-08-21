using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace XH.Core.Api
{
    public partial class XHBaseContext : DbContext
    {
        public XHBaseContext()
        {
        }

        public XHBaseContext(DbContextOptions<XHBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<XhAcceptance> XhAcceptance { get; set; }
        public virtual DbSet<XhAccount> XhAccount { get; set; }
        public virtual DbSet<XhAssess> XhAssess { get; set; }
        public virtual DbSet<XhCheckRecord> XhCheckRecord { get; set; }
        public virtual DbSet<XhCheckRecordDetail> XhCheckRecordDetail { get; set; }
        public virtual DbSet<XhCity> XhCity { get; set; }
        public virtual DbSet<XhCredit> XhCredit { get; set; }
        public virtual DbSet<XhDictInfo> XhDictInfo { get; set; }
        public virtual DbSet<XhMenu> XhMenu { get; set; }
        public virtual DbSet<XhPayBusiness> XhPayBusiness { get; set; }
        public virtual DbSet<XhPayWork> XhPayWork { get; set; }
        public virtual DbSet<XhSourceGoods> XhSourceGoods { get; set; }
        public virtual DbSet<XhTransactionDetail> XhTransactionDetail { get; set; }
        public virtual DbSet<XhUser> XhUser { get; set; }
        public string AppSetingHelper { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration["ConnectionStrings:Sqlconn"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<XhAcceptance>(entity =>
            {
                entity.HasKey(e => e.AcceptanceId);

                entity.ToTable("xh_Acceptance");

                entity.Property(e => e.AcceptanceId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AcceptanceByUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.GoodsId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.ToTable("xh_account");

                entity.Property(e => e.AccountId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountMoney).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CanUserMoney).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhAssess>(entity =>
            {
                entity.HasKey(e => e.AssessId);

                entity.ToTable("xh_assess");

                entity.Property(e => e.AssessId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AssessContent)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.GoodsId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhCheckRecord>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.ToTable("xh_check_record");

                entity.Property(e => e.RecordId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AppMoney).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TotalMoney).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<XhCheckRecordDetail>(entity =>
            {
                entity.HasKey(e => e.RecordDetailId);

                entity.ToTable("xh_check_record_detail");

                entity.Property(e => e.RecordDetailId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CanUseMoney).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LeftOverMoney).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SummitMoney).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("xh_city");

                entity.Property(e => e.CityId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Column10)
                    .HasColumnName("Column_10")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhCredit>(entity =>
            {
                entity.HasKey(e => e.CreditId);

                entity.ToTable("xh_credit");

                entity.Property(e => e.CreditId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.IntegralNum).HasColumnName("integralNum");

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhDictInfo>(entity =>
            {
                entity.HasKey(e => e.StaticId);

                entity.ToTable("xh_dict_info");

                entity.Property(e => e.StaticId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.LevelXh).HasColumnName("LevelXH");

                entity.Property(e => e.Name)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("xh_menu");

                entity.Property(e => e.MenuId)
                    .HasMaxLength(36)
                    .ValueGeneratedNever();

                entity.Property(e => e.Column10)
                    .HasColumnName("Column_10")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MenuClassify)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuParentId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhPayBusiness>(entity =>
            {
                entity.HasKey(e => e.PayId);

                entity.ToTable("xh_pay_business");

                entity.Property(e => e.PayId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.PayByDataSource)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.PayMany).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaythirdId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhPayWork>(entity =>
            {
                entity.HasKey(e => e.PayId);

                entity.ToTable("xh_pay_work");

                entity.Property(e => e.PayId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.PayByDataSource)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.PayMany).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaythirdId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhSourceGoods>(entity =>
            {
                entity.HasKey(e => e.GoodsId);

                entity.ToTable("xh_source_goods");

                entity.Property(e => e.GoodsId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.GoodByAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GoodsByUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.GoodsName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GoodsNeedTime).HasColumnType("datetime");

                entity.Property(e => e.GoodsPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.GoodsWeight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhTransactionDetail>(entity =>
            {
                entity.HasKey(e => e.DetailId);

                entity.ToTable("xh_transaction_detail");

                entity.Property(e => e.DetailId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.GoodsId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<XhUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("xh_user");

                entity.Property(e => e.UserId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.OperateTime).HasColumnType("datetime");

                entity.Property(e => e.OperateUser)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Remakes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserAddresss)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.UserPAddress)
                   .HasMaxLength(200)
                   .IsUnicode(false);

                entity.Property(e => e.UserIdCard)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPicture)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
