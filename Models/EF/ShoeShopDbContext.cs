namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShoeShopDbContext : DbContext
    {
        public ShoeShopDbContext()
            : base("name=ShoeShopDbContext2")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<ChiTietDatHang> ChiTietDatHangs { get; set; }
        public virtual DbSet<CongTy> CongTies { get; set; }
        public virtual DbSet<DatHang> DatHangs { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<HoTro> HoTroes { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhomSanPham> NhomSanPhams { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<ThanhPho> ThanhPhoes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatHang>()
                .HasMany(e => e.ChiTietDatHangs)
                .WithOptional(e => e.DatHang)
                .HasForeignKey(e => e.Dathang_ID);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DatHangs)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.Khachhang_ID);

            modelBuilder.Entity<NhomSanPham>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.NhomSanPham)
                .HasForeignKey(e => e.NhomSP_ID);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDatHangs)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.Sanpham_ID);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.SanPhams)
                .Map(m => m.ToTable("SanPhamTag").MapLeftKey("SanPhamID").MapRightKey("TagID"));
        }
    }
}
