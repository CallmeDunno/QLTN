using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTL.Models;

public partial class QltnContext : DbContext
{
    public QltnContext()
    {
    }

    public QltnContext(DbContextOptions<QltnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChuNha> ChuNhas { get; set; }

    public virtual DbSet<DanhGiaNha> DanhGiaNhas { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<DoiTuongSuDung> DoiTuongSuDungs { get; set; }

    public virtual DbSet<HopDongNha> HopDongNhas { get; set; }

    public virtual DbSet<LoaiNha> LoaiNhas { get; set; }

    public virtual DbSet<MucDichSuDung> MucDichSuDungs { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NhaDichVu> NhaDichVus { get; set; }

    public virtual DbSet<NhaTaiSan> NhaTaiSans { get; set; }

    public virtual DbSet<QuanTriVien> QuanTriViens { get; set; }

    public virtual DbSet<TaiSan> TaiSans { get; set; }

    public virtual DbSet<ThongTinNha> ThongTinNhas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-LEDRJD7A\\SQLEXPRESS;Initial Catalog=QLTN;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChuNha>(entity =>
        {
            entity.HasKey(e => e.MaChuNha).HasName("PK__ChuNha__D13CC17F58009712");

            entity.ToTable("ChuNha");

            entity.Property(e => e.AnhChuNha).HasColumnType("text");
            entity.Property(e => e.Email).HasColumnType("text");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SdtchuNha)
                .HasColumnType("text")
                .HasColumnName("SDTChuNha");
            entity.Property(e => e.SdtchuNha2)
                .HasColumnType("text")
                .HasColumnName("SDTChuNha2");
        });

        modelBuilder.Entity<DanhGiaNha>(entity =>
        {
            entity.HasKey(e => e.MaDanhGia).HasName("PK__DanhGiaN__AA9515BF6F5A393A");

            entity.ToTable("DanhGiaNha");

            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.NgayDanhGia).HasColumnType("date");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.DanhGiaNhas)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DGN_MaNguoiDung");

            entity.HasOne(d => d.MaNhaNavigation).WithMany(p => p.DanhGiaNhas)
                .HasForeignKey(d => d.MaNha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DGN_MaNha");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu).HasName("PK__DichVu__C0E6DE8F86A12435");

            entity.ToTable("DichVu");
        });

        modelBuilder.Entity<DoiTuongSuDung>(entity =>
        {
            entity.HasKey(e => e.MaDtsd).HasName("PK__DoiTuong__3754306EF8202864");

            entity.ToTable("DoiTuongSuDung");

            entity.Property(e => e.MaDtsd).HasColumnName("MaDTSD");
            entity.Property(e => e.TenDtsd).HasColumnName("TenDTSD");
        });

        modelBuilder.Entity<HopDongNha>(entity =>
        {
            entity.HasKey(e => e.MaHopDong).HasName("PK__HopDongN__36DD4342F1315F6C");

            entity.ToTable("HopDongNha");

            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.ThoiGianBatDau).HasColumnType("date");
            entity.Property(e => e.ThoiGianKetThuc).HasColumnType("date");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.HopDongNhas)
                .HasForeignKey(d => d.MaNguoiDung)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaNguoiDung");

            entity.HasOne(d => d.MaNhaNavigation).WithMany(p => p.HopDongNhas)
                .HasForeignKey(d => d.MaNha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaNha");
        });

        modelBuilder.Entity<LoaiNha>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__LoaiNha__730A5759DD40EA80");

            entity.ToTable("LoaiNha");
        });

        modelBuilder.Entity<MucDichSuDung>(entity =>
        {
            entity.HasKey(e => e.MaMdsd).HasName("PK__MucDichS__AF4D3B05B51D8137");

            entity.ToTable("MucDichSuDung");

            entity.Property(e => e.MaMdsd).HasColumnName("MaMDSD");
            entity.Property(e => e.TenMdsd).HasColumnName("TenMDSD");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__C539D762349FF4BB");

            entity.ToTable("NguoiDung");

            entity.Property(e => e.AnhNguoiDung).HasColumnType("text");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.Sdt).HasColumnName("SDT");
        });

        modelBuilder.Entity<NhaDichVu>(entity =>
        {
            entity.HasKey(e => new { e.MaNha, e.MaDichVu });

            entity.ToTable("Nha_DichVu");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.NhaDichVus)
                .HasForeignKey(d => d.MaDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NDV_MaDichVu");

            entity.HasOne(d => d.MaNhaNavigation).WithMany(p => p.NhaDichVus)
                .HasForeignKey(d => d.MaNha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NDV_MaNha");
        });

        modelBuilder.Entity<NhaTaiSan>(entity =>
        {
            entity.HasKey(e => new { e.MaNha, e.MaTaiSan });

            entity.ToTable("Nha_TaiSan");

            entity.Property(e => e.GiaTri).HasColumnType("money");

            entity.HasOne(d => d.MaNhaNavigation).WithMany(p => p.NhaTaiSans)
                .HasForeignKey(d => d.MaNha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NTS_MaNha");

            entity.HasOne(d => d.MaTaiSanNavigation).WithMany(p => p.NhaTaiSans)
                .HasForeignKey(d => d.MaTaiSan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NTS_MaTaiSan");
        });

        modelBuilder.Entity<QuanTriVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QuanTriV__3214EC27251F1659");

            entity.ToTable("QuanTriVien");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.NameAd).HasColumnName("NameAD");
            entity.Property(e => e.PassAd).HasColumnName("PassAD");
        });

        modelBuilder.Entity<TaiSan>(entity =>
        {
            entity.HasKey(e => e.MaTaiSan).HasName("PK__TaiSan__8DB7C7BE69E33186");

            entity.ToTable("TaiSan");
        });

        modelBuilder.Entity<ThongTinNha>(entity =>
        {
            entity.HasKey(e => e.MaNha).HasName("PK__ThongTin__3A18F65F9F5E2554");

            entity.ToTable("ThongTinNha");

            entity.Property(e => e.AnhMinhHoa).HasColumnType("text");
            entity.Property(e => e.DienTich).HasColumnType("text");
            entity.Property(e => e.GiaPhong).HasColumnType("money");
            entity.Property(e => e.MaDtsd).HasColumnName("MaDTSD");
            entity.Property(e => e.MaMdsd).HasColumnName("MaMDSD");
            entity.Property(e => e.NgayDangTai).HasColumnType("date");
            entity.Property(e => e.TienDatCoc).HasColumnType("money");
            entity.Property(e => e.TienDien).HasColumnType("money");
            entity.Property(e => e.TienNuoc).HasColumnType("money");

            entity.HasOne(d => d.MaChuNhaNavigation).WithMany(p => p.ThongTinNhas)
                .HasForeignKey(d => d.MaChuNha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaChuNha");

            entity.HasOne(d => d.MaDtsdNavigation).WithMany(p => p.ThongTinNhas)
                .HasForeignKey(d => d.MaDtsd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaDTSD");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.ThongTinNhas)
                .HasForeignKey(d => d.MaLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaLoai");

            entity.HasOne(d => d.MaMdsdNavigation).WithMany(p => p.ThongTinNhas)
                .HasForeignKey(d => d.MaMdsd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MaMDSD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
