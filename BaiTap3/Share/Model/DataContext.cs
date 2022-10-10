using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<Diem> Diems { get; set; }
        public DbSet<GiangVien> GiangViens { get; set; }
        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<HocVien_Diem> HocVien_Diems { get; set; }
        public DbSet<KhoaDaoTao> KhoaDaoTaos { get; set; }

        public DbSet<LichDay> LichDays { get; set; }
        public DbSet<LichHoc> LichHocs { get; set; }
        public DbSet<LichNghi> LichNghis { get; set; }

        public DbSet<LienHe> LienHes { get; set; }
        public DbSet<LoaiDiem> LoaiDiems { get; set; }
        public DbSet<Lop_HocVien> Lop_HocViens { get; set; }
        public DbSet<LopHoc> LopHocs { get; set; }
        public DbSet<Luong> Luongs { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<Role_QUyen> Roles_Quyens { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<ToBoMon> ToBoMons { get; set; }
      
        public DbSet<ThuHocPhi> ThuHocPhis { get; set; }
        public DbSet<CaHoc> CaHocs { get; set; }
        public DbSet<ThuNgay> ThuNgays { get; set; }
        public DbSet<ThuHocPhiChiTiet> ThuHocPhiChiTiets { get; set; }

    }
}
