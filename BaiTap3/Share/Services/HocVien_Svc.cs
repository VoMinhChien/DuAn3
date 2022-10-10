using Microsoft.EntityFrameworkCore;
using Share.Helpers;
using Share.Model;
using Share.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface IHocVien
    {
        HocVien Login(ViewLogin viewLogin);

        int SendEmail(string email);
        int CheckOTP(CheckMaOTP checkMaOTP);
        int ResetPass(ResetPastWord resetPassWord);
        Task<List<HocVien>> GetAllHocVien();
        Task<int> AddHocVienAsync(HocVien hocvien);
        Task<int>DangKyLopHocChoSinhVien(Lop_HocVien lop_HocVien);
        Task<int> UpdateHocVien(int id, HocVien hocVien);
        int XoaHocVien(int id);
        Task<List<HocVien>> SearchHocVien(string search);   
        int DoiPass(UpDatePassWord viewDoiPass);
    }

    public class HocVien_Svc : IHocVien
    {
        protected DataContext _context;
        protected IMaHoaHelper _maHoaHelper;
        public HocVien_Svc(DataContext context, IMaHoaHelper maHoaHelper)
        {
            _context = context;
            _maHoaHelper = maHoaHelper;
        }
        public HocVien Login(ViewLogin viewLogin)
        {
            var u = _context.HocViens.Where(p => p.Email.Equals(viewLogin.Email) && p.MatKhau.Equals(_maHoaHelper.Mahoa(viewLogin.Password))
           || p.MaDangNhap.Equals(viewLogin.MaDangNhap) && p.MatKhau.Equals(_maHoaHelper.Mahoa(viewLogin.Password))).FirstOrDefault();
            return u;
        }
    
       
        public int CheckOTP(CheckMaOTP checkMaOTP)
        {
            var CheckOTP = _context.HocViens.Where(o => o.Email == checkMaOTP.RS_Email && o.OTP == checkMaOTP.RS_OTP ).FirstOrDefault();
            if (CheckOTP != null)
            {
                int ret = 0;
                try
                {
                    return ret = 1;
                }
                catch
                {
                    ret = 0;
                }
                return ret;
            }
            return 0;
        }

        public int ResetPass(ResetPastWord resetPassWord)
        {

            HocVien _HocViens = null;
            _HocViens = _context.HocViens.Where(o => o.Email == resetPassWord.Email).FirstOrDefault();
            _HocViens.MatKhau = resetPassWord.Password;
            _context.Update(_HocViens);
            _context.SaveChanges();
            return 0;
        }

        public int SendEmail(string email)
        {
            var chars1 = "1234567890";
            var stringChars1 = new char[6];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

            var str = new String(stringChars1);
            string maOTP = str;

            int ret = 0;
            var checkemail = _context.HocViens.Where(O => O.Email == email).FirstOrDefault();
            if (checkemail != null)
            {
                HocVien _HocViens = null;
                _HocViens = _context.HocViens.Where(o => o.Email == email).FirstOrDefault();
                _context.Update(_HocViens);
                _context.SaveChanges();

                try
                {
                    HocVien _HocVienss = null;
                    _HocVienss = _context.HocViens.Where(o => o.Email == email).FirstOrDefault();
                   
                    _HocVienss.OTP = maOTP;
                    _context.Update(_HocVienss);
                    _context.SaveChanges();
                    ret = _HocVienss.Id;

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("chienvmps18790@fpt.edu.vn");
                        mail.To.Add(email);
                        mail.Subject = "Khôi Phục Mật Khẩu Tài Khoản";
                        mail.Body = "<h5>Xin chào " + _HocViens.TenDemVaTen + "</h5>" + "<p>Đây là hệ thống tự động vui lòng không trả lời , Mã Có hiệu lực trong vòng 1 phút !</p>" +
                            "<p>Mã OTP của bạn là: " + str + "</p>" +
                            "<p>Chúc bạn một ngày tốt lành</p>" +
                            "<p><i style='color:red'>Lưu ý: đây là mã OTP vui lòng không chia sẽ cho bất kì ai<i></p>";
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("chienvmps18790@fpt.edu.vn", "19008198");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);

                        }
                    }

                }

                catch
                {
                    ret = 0;
                }
                return ret;

            }

            return 0;

        }
        public async Task<List<HocVien>> GetAllHocVien()
        {
            List<HocVien> ListHV = new List<HocVien>();
            ListHV = await _context.HocViens.ToListAsync();
            return ListHV;
        }

        public Task<int> AddHocVienAsync(HocVien hocvien)
        {
            var chars1 = "1234567890";
            var stringChars1 = new char[6];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

            var str = new String(stringChars1);
            var madangnhap = str;
            int ret = 0;
            try
            {
                hocvien.role = 3;
                hocvien.MaDangNhap = "HV_"+ madangnhap;
                hocvien.MatKhau = _maHoaHelper.Mahoa(hocvien.MatKhau);
                _context.AddAsync(hocvien);
                _context.SaveChanges();
                ret = hocvien.Id;
            }
            catch
            {
                ret = 0;
            }
            return Task.FromResult(ret);
        }
        public Task<int> DangKyLopHocChoSinhVien(Lop_HocVien lop_HocVien) 
        {
            int ret = 0;
            try
            {
                
                _context.AddAsync(lop_HocVien);
                _context.SaveChanges();
                ret = lop_HocVien.Id;
            }
            catch
            {
                ret = 0;
            }
            return Task.FromResult(ret);
        }

        public async Task<int> UpdateHocVien(int id, HocVien hocVien)
        {
            int ret = 0;
            try
            {
                HocVien _hocvien = null;
                _hocvien = _context.HocViens.Find(id);
                _hocvien.Ho = hocVien.Ho;
                _hocvien.TenDemVaTen = hocVien.TenDemVaTen;
                _hocvien.NgaySinh = hocVien.NgaySinh;
                _hocvien.GioiTinh = hocVien.GioiTinh;
                _hocvien.Email = hocVien.Email;
                _hocvien.Sdt = hocVien.Sdt;
                _hocvien.DiaChi = hocVien.DiaChi;
                _hocvien.PhuHuynh=hocVien.PhuHuynh;            
                _hocvien.HinhDaiDien= hocVien.HinhDaiDien;
                _context.HocViens.Update(_hocvien);
                await _context.SaveChangesAsync();
                ret = _hocvien.Id;
            }
            catch
            {                                                                                                                                       
                ret = 0;
            }
            return ret;
        }

        public int XoaHocVien(int id)
        {
            int ret = 0;
            try
            {
                var xoahv = _context.HocViens.Where(o => o.Id == id).FirstOrDefault();
                _context.Remove(xoahv);
                _context.SaveChanges();
                ret=xoahv.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<List<HocVien>> SearchHocVien(string search)
        {
            List<HocVien> list = await _context.HocViens.Where(o => o.IsDelete == false && o.TenDemVaTen.Contains(search)).ToListAsync();
            return list;
        }

        public int DoiPass(UpDatePassWord viewDoiPass)
        {

            var u = _context.HocViens.Where(p => p.Id.Equals(viewDoiPass.Id_User) && p.MatKhau.Equals(_maHoaHelper.Mahoa(viewDoiPass.PasswordOld))).FirstOrDefault();
            if (u != null)
            {
                int ret = 0;
                try
                {
                    HocVien _hv = null;
                    _hv = _context.HocViens.Find(u.Id);
                    _hv.MatKhau = _maHoaHelper.Mahoa(viewDoiPass.PasswordNew);      
                    _context.Update(_hv);
                    _context.SaveChanges();
                    ret = _hv.Id;
                }
                catch
                {
                    ret = 0;
                }
                return ret;
            }
            return 0;

        }
    }
}
