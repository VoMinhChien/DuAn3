using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share.Model;
using Share.Model.ViewModel;
using Share.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BaiTap3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
   
    public class HocVienController : ControllerBase
    {
        private readonly IHocVien _hocVien;
        public HocVienController(IHocVien hocVien)
        {
            this._hocVien = hocVien;
        }
        /// <summary>
        /// Gửi Mã OTP về email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        [HttpPost]
        [ActionName("SendEmail")]

        public async Task<ActionResult> SendEmail(string email)
        {
            if (ModelState.IsValid)
            {
                if (_hocVien.SendEmail(email) > 0)
                {
                    return Ok("Kiểm tra Email để nhận mã OTP nhé !");

                }


            }
            return BadRequest("Email không tồn tại hoặc  chưa được đăng ký");

        }
        /// <summary>
        /// kiểm tra mã OTP đúng ko
        /// </summary>
        /// <param name="checkMaOTP"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("KiemTraOTP")]
        public async Task<ActionResult> CheckOtp(CheckMaOTP checkMaOTP)
        {
            if (ModelState.IsValid)
            {
                if (_hocVien.CheckOTP(checkMaOTP) > 0)
                {
                    return Ok("Chuyển Trang Đặt mk mới");
                }
            }
            return BadRequest("Mã OTP không đúng ,Hoặc đã hết hạn !  Vui Lòng Thử lại");
        }
        /// <summary>
        /// đổi lại mật khẩu
        /// </summary>
        /// <param name="resetPassWord"></param>
        /// <returns></returns>

        [HttpPut]
        [ActionName("ResetPassWord")]
        public async Task<ActionResult> ResetPass([FromBody] ResetPastWord resetPassWord)
        {
            if (ModelState.IsValid)
            {
                _hocVien.ResetPass(resetPassWord);
                return Ok("Cập nhật mật khẩu thành công");
            }
            return BadRequest();
        }
        /// <summary>
        /// hiển thị tất cả danh sách học viên
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllHocVien")]
        [Authorize(Policy = "NguoiDungs")]
        [Authorize(Policy = "GiangViens")]
        [Authorize(Policy = "HocViens")]
       
        public async Task<ActionResult<IEnumerable<HocVien>>> GetAllHocVien()
        {

            return await _hocVien.GetAllHocVien();
           
        }
        /// <summary>
        /// thêm học viên
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ThemHocVien")]
        [Authorize(Policy = "NguoiDungs")]
       
        public async Task<ActionResult<int>> PostHocVien(HocVien hocvien)
        {
            try
            {
                int id = await _hocVien.AddHocVienAsync(hocvien);
                hocvien.Id = id;
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
        /// <summary>
        /// sửa thông tin học viên
        /// </summary>
        /// <param name="id"></param>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Policy = "NguoiDungs")]
       
        public HocVien SuaThongTin(int id, HocVien hocvien)
        {
            _hocVien.UpdateHocVien(id, hocvien);
            return hocvien;
        }
        /// <summary>
        /// xóa học viên
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hoc"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = "NguoiDungs")]
        
        public async Task<ActionResult> XoaHocVien(int id)
        {
            if(id != 0)
            {
                _hocVien.XoaHocVien(id);
                return Ok("Xoa Thành Công");
            }
            return BadRequest("Xóa K Thành Công");
        }
        /// <summary>
        /// Tìm Kiếm Học Viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ActionName("TimKiemHocVien")]

        public async Task<ActionResult<IEnumerable<HocVien>>> TimHocVien(string search)
        {
            if(search != "")
            {
                return await _hocVien.SearchHocVien(search);
            }

            return BadRequest("Học viên không tồn tại");
        }
        /// <summary>
        ///học viên thay đổi mật khẩu
        /// </summary>
        /// <param name="viewdoipass"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ActionName("UpdatePassWord")]
        public async Task<IActionResult> DoiPass(UpDatePassWord viewdoipass)
        {
            if (viewdoipass != null && !string.IsNullOrEmpty((viewdoipass.Id_User).ToString()) && !string.IsNullOrEmpty(viewdoipass.PasswordOld))
            {
                var khachhang = _hocVien.DoiPass(viewdoipass);


            }
            return BadRequest();
        }
    }
}
