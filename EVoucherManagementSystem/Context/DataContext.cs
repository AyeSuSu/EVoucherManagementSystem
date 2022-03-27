using Microsoft.EntityFrameworkCore;
using EVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVoucherManagementSystem.Context
{
    public class DataContext:DbContext
    {
        #region DataSets
        public DbSet<UsersModel> Users { get; set; }
        public DbSet<PaymentMethodsModel> PaymentMethods { get; set; }
        public DbSet<BuyTypesModel> BuyTypes { get; set; }
        public DbSet<EVouchersModel> EVouchers { get; set; }
        public DbSet<PurchaseEVouchersModel> PurchaseEVouchers { get; set; }

        public DbSet<ItemPurchaseModel> ItemPurchase { get; set; }
        #endregion
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Users
            modelBuilder.Entity<UsersModel>().ToTable("Users");

            modelBuilder.Entity<UsersModel>().HasKey(u => u.id).HasName("PK_Users");

            modelBuilder.Entity<UsersModel>().Property(u => u.id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<UsersModel>().Property(u => u.userName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<UsersModel>().Property(u => u.phoneNo).HasColumnType("nvarchar(25)").IsRequired();
            modelBuilder.Entity<UsersModel>().Property(u => u.password).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<UsersModel>().Property(u => u.createdDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<UsersModel>().Property(u => u.updatedDateTime).HasColumnType("datetime").IsRequired(false);
            #endregion

            #region PaymentMethods
            modelBuilder.Entity<PaymentMethodsModel>().ToTable("PaymentMethods");

            modelBuilder.Entity<PaymentMethodsModel>().HasKey(u => u.id).HasName("PK_PaymentMethods");

            modelBuilder.Entity<PaymentMethodsModel>().Property(u => u.id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<PaymentMethodsModel>().Property(u => u.name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<PaymentMethodsModel>().Property(u => u.discountPercent).HasColumnType("int").HasDefaultValue(0);
            modelBuilder.Entity<PaymentMethodsModel>().Property(u => u.createdDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<PaymentMethodsModel>().Property(u => u.updatedDateTime).HasColumnType("datetime").IsRequired(false);
            #endregion

            #region BuyTypes
            modelBuilder.Entity<BuyTypesModel>().ToTable("BuyTypes");

            modelBuilder.Entity<BuyTypesModel>().HasKey(u => u.id).HasName("PK_BuyTypes");

            modelBuilder.Entity<BuyTypesModel>().Property(u => u.id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<BuyTypesModel>().Property(u => u.isMyself).HasColumnType("int").IsRequired();
            modelBuilder.Entity<BuyTypesModel>().Property(u => u.isGiftOthers).HasColumnType("int").IsRequired();
            modelBuilder.Entity<BuyTypesModel>().Property(u => u.eVoucher_maxlimit).HasColumnType("int").HasDefaultValue(0);
            modelBuilder.Entity<BuyTypesModel>().Property(u => u.giftUser_maxlimit).HasColumnType("int").HasDefaultValue(0);
            modelBuilder.Entity<BuyTypesModel>().Property(u => u.createdDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<BuyTypesModel>().Property(u => u.updatedDateTime).HasColumnType("datetime").IsRequired(false);
            #endregion

            #region EVouchers
            modelBuilder.Entity<EVouchersModel>().ToTable("EVouchers");

            modelBuilder.Entity<EVouchersModel>().HasKey(u => u.id).HasName("PK_EVouchers");

            modelBuilder.Entity<EVouchersModel>().Property(u => u.id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.title).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.description).HasColumnType("nvarchar(1000)").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.expiryDate).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.image).HasColumnType("nvarchar(300)").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.amount).HasColumnType("int").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.quantity).HasColumnType("int").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.isActive).HasColumnType("int").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.user_id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.userName).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.phoneNo).HasColumnType("nvarchar(25)").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.qrCode).HasColumnType("nvarchar(300)").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.createdDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.updatedDateTime).HasColumnType("datetime").IsRequired(false);
            #endregion

            #region PurchaseEVouchers
            modelBuilder.Entity<PurchaseEVouchersModel>().ToTable("PurchaseEVouchers");

            modelBuilder.Entity<PurchaseEVouchersModel>().HasKey(u => u.id).HasName("PK_PurchaseEVouchers");

            modelBuilder.Entity<PurchaseEVouchersModel>().Property(u => u.id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<PurchaseEVouchersModel>().Property(u => u.eVoucher_id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<PurchaseEVouchersModel>().Property(u => u.buyType_id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<PurchaseEVouchersModel>().Property(u => u.paymentMethod_id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<PurchaseEVouchersModel>().Property(u => u.netAmount).HasColumnType("int").IsRequired();
            modelBuilder.Entity<PurchaseEVouchersModel>().Property(u => u.promoCode).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<PurchaseEVouchersModel>().Property(u => u.isUsed).HasColumnType("int").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.createdDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<EVouchersModel>().Property(u => u.updatedDateTime).HasColumnType("datetime").IsRequired(false);
            #endregion

            #region PurchaseEVouchers
            modelBuilder.Entity<ItemPurchaseModel>().ToTable("ItemPurchase");

            modelBuilder.Entity<ItemPurchaseModel>().HasKey(u => u.id).HasName("PK_ItemPurchase");

            modelBuilder.Entity<ItemPurchaseModel>().Property(u => u.id).HasColumnType("char(37)").IsRequired();
            modelBuilder.Entity<ItemPurchaseModel>().Property(u => u.item).HasColumnType("nvarchar(200)").IsRequired();
            modelBuilder.Entity<ItemPurchaseModel>().Property(u => u.promocode).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<ItemPurchaseModel>().Property(u => u.totalamount).HasColumnType("int").IsRequired();
            modelBuilder.Entity<ItemPurchaseModel>().Property(u => u.createdDateTime).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<ItemPurchaseModel>().Property(u => u.updatedDateTime).HasColumnType("datetime").IsRequired(false);
            #endregion
        }
    }
}
