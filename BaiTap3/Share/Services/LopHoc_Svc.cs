using Microsoft.EntityFrameworkCore;
using Share.Helpers;
using Share.Model;
using Share.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface ILopHoc
    {
        Task<int> AddLopHoc(LopHoc lophoc);
        Task<List<Lop_HocVien>> HienDanhSachHvTrongLopHoc(int maLop);
        Task<int> DangKyHocVienVaoLopHoc(Lop_HocVien lop_HocViens);
        Task<int> HuyDangKyLopHoc(int id, Lop_HocVien lop_HocViens);
        Task<List<Lop_HocVien>> HienThiLopHocDaDangKy(int id);
        Task<List<Lop_HocVien>> HienThiLopHocDaHuy(int id);
        Task<bool> ThemDiemCho1Hv(HocVien_Diem hocVien_Diem);
        Task<bool> ThemDiemChoNhieuHv(ViewThemDiems viewThemDiems);
        Task<List<ViewHienThiDiemHs>> HienThiDiemHocVien(int monhoc);
        Task<List<ViewHienThiDiemHs>> HienThiDiem1HocVien(int maHocVien);
        //Task<List<TeacherSchedule>> GetTeacherSchedulesAsync(int id_Class);

    }
    public class LopHoc_Svc : ILopHoc
    {
        protected DataContext _context;
        protected IMaHoaHelper _maHoaHelper;
        public LopHoc_Svc(DataContext context, IMaHoaHelper maHoaHelper)
        {
            _context = context;
            _maHoaHelper = maHoaHelper;
        }
        public Task<int> AddLopHoc(LopHoc lophoc)
        {
            var chars1 = "1234567890";
            var stringChars1 = new char[6];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

            var str = new String(stringChars1);
            var maLop = str;
            int ret = 0;
            try
            {
                
                lophoc.MaLop = "LOP_" + maLop;
                lophoc.SoLuongHocVienDangCo = 0;
                lophoc.TrangThai = false;
                _context.AddAsync(lophoc);
                _context.SaveChanges();
                ret = lophoc.Id;
            }
            catch
            {
                ret = 0;
            }
            return Task.FromResult(ret);
        }
        public async Task<List<Lop_HocVien>> HienDanhSachHvTrongLopHoc(int maLop)
        {
            return await _context.Lop_HocViens.Where(x => x.MaLop == maLop)
                .Include(x => x.HocViens)
                .ToListAsync();
        }
        public async Task<int> DangKyHocVienVaoLopHoc(Lop_HocVien lop_HocViens)
        {
            int ret = 0;
            try
            {
                Lop_HocVien lhv = new Lop_HocVien();
                lhv = await _context.Lop_HocViens.Where(o => o.Id_HocVien == lop_HocViens.Id_HocVien &&  o.MaLop == lop_HocViens.MaLop ).FirstOrDefaultAsync();
                if (lhv != null)
                {
                    ret =0;
                }
                else
                {
                        LopHoc lops = new LopHoc();
                        lops = await _context.LopHocs.Where(o => o.Id == lop_HocViens.MaLop).FirstOrDefaultAsync();
                        if (lops.SoLuongHocVienDangCo < lops.SoLuongHocVienToiDa)
                        {
                            lops.SoLuongHocVienDangCo += 1;
                            _context.LopHocs.Update(lops);
                            await _context.SaveChangesAsync();
                            lop_HocViens.Isdelete = false;
                            lop_HocViens.status = false;
                            lop_HocViens.NgayDangKy = DateTime.Now;
                            await _context.AddAsync(lop_HocViens);
                            _context.SaveChanges();
                            ret = lop_HocViens.Id;
                        }
                        else
                        {

                            ret = 0;

                        }
                }   
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public async Task<List<ViewHienThiDiemHs>> HienThiDiem1HocVien(int maHocVien)
        {
            List<HocVien_Diem> hv_diem = new List<HocVien_Diem>();
            hv_diem = await _context.HocVien_Diems
                         .Where(x => x.ID_HocVien == maHocVien)
                         .Include(x => x.HocViens)
                         .ToListAsync();
            var Diem15phut = hv_diem.Where(x => x.ID_LoaiDiem == 1).ToList();
            var Diemmottiet = hv_diem.Where(x => x.ID_LoaiDiem == 2).ToList();
            var Diemcuoiky = hv_diem.Where(x => x.ID_LoaiDiem == 3).ToList();
            var Diemkiemtramieng = hv_diem.Where(x => x.ID_LoaiDiem == 4).ToList();
            List<ViewThemDiemMieng> diemmieng = new List<ViewThemDiemMieng>();
            List<ViewThemDiem1Tiet> diemmottiet = new List<ViewThemDiem1Tiet>();
            List<ViewThemDiem15p> diem15phut = new List<ViewThemDiem15p>();
            List<ViewThemDiemCuoiKy> diemthicuoiki = new List<ViewThemDiemCuoiKy>();
            List<ViewHienThiDiemHs> viewListDiems = new List<ViewHienThiDiemHs>();
            var diemmiengStudent = Diemkiemtramieng.Where(x => x.ID_HocVien == maHocVien).ToList();
            foreach (var student in diemmiengStudent)
            {
                diemmieng.Add(new ViewThemDiemMieng
                {
                    Id_Diem = student.Id,
                    diem = student.SoDiem
                });
            }
            var diem15Phut = Diem15phut.Where(x => x.ID_HocVien == maHocVien).ToList();
            foreach (var student in diem15Phut)
            {
                diem15phut.Add(new ViewThemDiem15p
                {
                    Id_Diem = student.Id,
                    diem = student.SoDiem
                });
            }
            var diemMotTiet = Diemmottiet.Where(x => x.ID_HocVien == maHocVien).ToList();
            foreach (var student in diemMotTiet)
            {
                diemmottiet.Add(new ViewThemDiem1Tiet
                {
                    Id_Diem = student.Id,
                    diem = student.SoDiem
                });
            }
            var diemCuoiKi = Diemcuoiky.Where(x => x.ID_HocVien == maHocVien).ToList();
            foreach (var student in diemCuoiKi)
            {
                diemthicuoiki.Add(new ViewThemDiemCuoiKy
                {
                    Id_Diem = student.Id,
                    diem = student.SoDiem
                });
            }
            foreach (var student in hv_diem)
            {
                viewListDiems.Add(new ViewHienThiDiemHs
                {
                    Id_HocVien = maHocVien,
                    ID_MonHoc = student.ID_MonHoc,
                    kiemTra15Phuts = diem15phut,
                    DiemKiemTraMiengs = diemmieng,
                    diemKiemTraMotTiets = diemmottiet,
                    diemThiCuoiKis = diemthicuoiki
                });
            }
            return viewListDiems;
        }
        public async Task<List<Lop_HocVien>> HienThiLopHocDaDangKy(int id)
        {
            List<Lop_HocVien> ListLop_HocVien = new List<Lop_HocVien>();
            ListLop_HocVien = await _context.Lop_HocViens.Where(o=>o.Isdelete==false && o.Id_HocVien==id).ToListAsync();
            return ListLop_HocVien;
        }
        public async Task<List<Lop_HocVien>> HienThiLopHocDaHuy(int id)
        {
            List<Lop_HocVien> ListLop_HocVien = new List<Lop_HocVien>();
            ListLop_HocVien = await _context.Lop_HocViens.Where(o => o.Isdelete == true && o.Id_HocVien == id).ToListAsync();
            return ListLop_HocVien;
        }
        public async Task<int> HuyDangKyLopHoc(int id, Lop_HocVien lop_HocViens)
        {
            int ret = 0;
            try
            {
                Lop_HocVien _lophocvien = null;
                _lophocvien = _context.Lop_HocViens.Find(id);
                _lophocvien.Isdelete = true;
                _context.Lop_HocViens.Update(_lophocvien);
                await _context.SaveChangesAsync();
                LopHoc lop = new LopHoc();
                lop = await _context.LopHocs.Where(o => o.Id == lop_HocViens.MaLop).FirstOrDefaultAsync();
                lop.SoLuongHocVienDangCo -= 1;
                _context.LopHocs.Update(lop);
                await _context.SaveChangesAsync();
                ret = _lophocvien.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public async Task<bool> ThemDiemCho1Hv(HocVien_Diem hocVien_Diem)
        {
            bool ret = false;
            try
            {
                await _context.HocVien_Diems.AddAsync(hocVien_Diem);
                await _context.SaveChangesAsync();
                ret = true;
            }
            catch
            {
            }
            return ret;
        }
        public async Task<bool> ThemDiemChoNhieuHv(ViewThemDiems viewThemDiems)
        {
            bool ret = false;
            try
            {
                HocVien_Diem hv_diem = new HocVien_Diem();
                foreach (var item in viewThemDiems.diemHs)
                {
                    hv_diem.ID_LoaiDiem = viewThemDiems.LoaiDiems;
                    hv_diem.ID_MonHoc = viewThemDiems.Id_MonHocs;
                    hv_diem.ID_HocVien = item.ID_HocVien;
                    hv_diem.SoDiem = item.Diem;
                    await _context.HocVien_Diems.AddAsync(hv_diem);
                }
                await _context.SaveChangesAsync();
                ret = true;
            }
            catch
            {
            }
            return ret;
        }
        public async Task<List<ViewHienThiDiemHs>> HienThiDiemHocVien(int monhoc)
        {
            List<HocVien_Diem> hv_diem = new List<HocVien_Diem>();
            hv_diem = await _context.HocVien_Diems
                         .Where(x => x.ID_MonHoc == monhoc)
                         .Include(x => x.HocViens)
                         .ToListAsync();
            var GroupBy = hv_diem.GroupBy(x => x.ID_HocVien).Select(g => new
            {
                id_Student = g.Key
            });
            var Diem15phut = hv_diem.Where(x => x.ID_LoaiDiem == 1).ToList();
            var Diemmottiet = hv_diem.Where(x => x.ID_LoaiDiem == 2).ToList();
            var Diemcuoiky = hv_diem.Where(x => x.ID_LoaiDiem == 3).ToList();
            var Diemkiemtramieng = hv_diem.Where(x => x.ID_LoaiDiem == 4).ToList();
            List<ViewThemDiemMieng> diemmieng = new List<ViewThemDiemMieng>();
            List<ViewThemDiem1Tiet> diemmottiet = new List<ViewThemDiem1Tiet>();
            List<ViewThemDiem15p> diem15phut = new List<ViewThemDiem15p>();
            List<ViewThemDiemCuoiKy> diemthicuoiki = new List<ViewThemDiemCuoiKy>();
            List<ViewHienThiDiemHs> viewListDiems = new List<ViewHienThiDiemHs>();
            foreach (var item in GroupBy)
            {
                var diemmiengStudent = Diemkiemtramieng.Where(x => x.ID_HocVien == item.id_Student).ToList();
                foreach (var student in diemmiengStudent)
                {
                    diemmieng.Add(new ViewThemDiemMieng
                    {
                        Id_Diem = student.Id,
                        diem = student.SoDiem
                    });
                }
                var diem15Phut = Diem15phut.Where(x => x.ID_HocVien == item.id_Student).ToList();
                foreach (var student in diem15Phut)
                {
                    diem15phut.Add(new ViewThemDiem15p
                    {
                        Id_Diem = student.Id,
                        diem = student.SoDiem
                    });
                }
                var diemMotTiet = Diemmottiet.Where(x => x.ID_HocVien == item.id_Student).ToList();
                foreach (var student in diemMotTiet)
                {
                    diemmottiet.Add(new ViewThemDiem1Tiet
                    {
                        Id_Diem = student.Id,
                        diem = student.SoDiem
                    });
                }
                var diemCuoiKi = Diemcuoiky.Where(x => x.ID_HocVien == item.id_Student).ToList();
                foreach (var student in diemCuoiKi)
                {
                    diemthicuoiki.Add(new ViewThemDiemCuoiKy
                    {
                        Id_Diem = student.Id,
                        diem = student.SoDiem
                    });
                }
                viewListDiems.Add(new ViewHienThiDiemHs
                {
                    Id_HocVien = item.id_Student,
                    ID_MonHoc = monhoc,
                    kiemTra15Phuts = diem15phut,
                    DiemKiemTraMiengs = diemmieng,
                    diemKiemTraMotTiets = diemmottiet,
                    diemThiCuoiKis = diemthicuoiki
                });
            }
            return viewListDiems;
        }
    }
}
