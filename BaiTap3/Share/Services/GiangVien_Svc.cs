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
    public interface IGiangVien
    {
        GiangVien GiangVienLogin(ViewLogin viewLogin);
        Task<List<GiangVien>> GetAllGiangVien();
        Task<int> AddGiangVienAsync(GiangVien giangVien);

        Task<int> UpdateGiangVien(int id, GiangVien giangVien);
        int XoaGiangVien(int id);
        Task<List<GiangVien>> SearchGiangVien(string search);
        int DoiPass(UpDatePassWord viewDoiPass);
        Task<int> TraLuong(Luong luong);
    }
    public class GiangVien_Svc : IGiangVien
    {
        protected DataContext _context;
        protected IMaHoaHelper _maHoaHelper;
        public GiangVien_Svc(DataContext context, IMaHoaHelper maHoaHelper)
        {
            _context = context;
            _maHoaHelper = maHoaHelper;
        }
        public GiangVien GiangVienLogin(ViewLogin viewLogin)
        {
            var u = _context.GiangViens.Where(p => p.Email.Equals(viewLogin.Email) && p.MatKhau.Equals(_maHoaHelper.Mahoa(viewLogin.Password))).FirstOrDefault();
            return u;
        }
        public async Task<int> TraLuong(Luong luong)
        {
            int ret = 0;
            try
            {
                List<ThuHocPhiChiTiet> hocphilist = await _context.ThuHocPhiChiTiets.Where(x => x.ID_MaGiangVien == luong.ID_GiangVien).ToListAsync();
                float doanhthu = 0;
                foreach (var item in hocphilist)
                {
                    doanhthu += item.SoTien;
                }
                luong.TienLuong = doanhthu * luong.TeacherSalary / 100;
                luong.TongTienNhan = (doanhthu * luong.TeacherSalary / 100) + luong.TroCap;
                luong.NgayNhanLuong = DateTime.Now;
                luong.GhiChu = luong.GhiChu;
                luong.Status = true;
                await _context.Luongs.AddAsync(luong);
                await _context.SaveChangesAsync();
                ret = luong.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public Task<int> AddGiangVienAsync(GiangVien giangVien)
        {
            var chars1 = "1234567890";
            var stringChars1 = new char[6];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

            var str = new String(stringChars1);
            var maSoThue = str;
            int ret = 0;
            try
            {
                giangVien.role = 2;
                giangVien.MasoThue = "Thue_" + maSoThue;
                giangVien.MatKhau = _maHoaHelper.Mahoa(giangVien.MatKhau);
                _context.AddAsync(giangVien);
                _context.SaveChanges();
                ret = giangVien.Id;
            }
            catch
            {
                ret = 0;
            }
            return Task.FromResult(ret);
        }

        public async Task<List<GiangVien>> GetAllGiangVien()
        {
            List<GiangVien> ListGV = new List<GiangVien>();
            ListGV = await _context.GiangViens.ToListAsync();
            return ListGV;
        }

        public async Task<List<GiangVien>> SearchGiangVien(string search)
        {
            List<GiangVien> list = await _context.GiangViens.Where(o => o.Isdelete == false && o.TenDemVaTen.Contains(search)).ToListAsync();
            return list;
        }

        public async Task<int> UpdateGiangVien(int id, GiangVien giangVien)
        {
            int ret = 0;
            try
            {
                GiangVien _giangvien = null;
                _giangvien = _context.GiangViens.Find(id);
                _giangvien.Ho = giangVien.Ho;
                _giangvien.TenDemVaTen = giangVien.TenDemVaTen;
                _giangvien.NgaySinh = giangVien.NgaySinh;
                _giangvien.GioiTinh = giangVien.GioiTinh;
                _giangvien.Email = giangVien.Email;
                _giangvien.SDT = giangVien.SDT;
                _giangvien.DiaChi = giangVien.DiaChi;
                _giangvien.DayMonChinh = giangVien.DayMonChinh;
                _giangvien.HinhAnh = giangVien.HinhAnh;
                _context.GiangViens.Update(_giangvien);
                await _context.SaveChangesAsync();
                ret = _giangvien.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public int DoiPass(UpDatePassWord viewDoiPass)
        {

            var u = _context.GiangViens.Where(p => p.Id.Equals(viewDoiPass.Id_User) && p.MatKhau.Equals(_maHoaHelper.Mahoa(viewDoiPass.PasswordOld))).FirstOrDefault();
            if (u != null)
            {
                int ret = 0;
                try
                {
                    GiangVien _gv = null;
                    _gv = _context.GiangViens.Find(u.Id);
                    _gv.MatKhau = _maHoaHelper.Mahoa(viewDoiPass.PasswordNew);
                    _context.Update(_gv);
                    _context.SaveChanges();
                    ret = _gv.Id;
                }
                catch
                {
                    ret = 0;
                }
                return ret;
            }
            return 0;

        }
        public int XoaGiangVien(int id)
        {
            int ret = 0;
            try
            {
                var xoagv = _context.GiangViens.Where(o => o.Id == id).FirstOrDefault();
                _context.Remove(xoagv);
                _context.SaveChanges();
                ret = xoagv.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
