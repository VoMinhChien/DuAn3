using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Share.Model;
using Share.Model.ViewModel;
using Share.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
   
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVien _giangVien;
        public IConfiguration _configuration;

        public GiangVienController(IGiangVien giangvien,IConfiguration _configuration)
        {
            this._giangVien = giangvien;
            this._configuration = _configuration;
        }
        /// <summary>
        /// hiển thị danh sách tất cả giảng viên
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllGiangVien")]
        [Authorize(Policy = "NguoiDungs")]
        public async Task<ActionResult<IEnumerable<GiangVien>>> GetAllGiangVien()
        {

            return await _giangVien.GetAllGiangVien();
           
        }
        /// <summary>
        /// thêm giảng viên
        /// </summary>
        /// <param name="giangvien"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ThemGiangVien")]
        [Authorize(Policy = "NguoiDungs")]
        public async Task<ActionResult<int>> PostGiangVien(GiangVien giangvien)
        {
            try
            {
                int id = await _giangVien.AddGiangVienAsync(giangvien);
                giangvien.Id = id;
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
        /// <summary>
        /// sửa giảng viên
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hocvien"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Policy = "NguoiDungs")]
        public GiangVien SuaThongTin(int id, GiangVien giangvien)
        {
            _giangVien.UpdateGiangVien(id, giangvien);
            return giangvien;
        }
        /// <summary>
        /// Xóa Giảng Viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Policy = "NguoiDungs")]
        public async Task<ActionResult> XoaGiangVien(int id)
        {
            if (id != 0)
            {
                _giangVien.XoaGiangVien(id);
                return Ok("Xoa Thành Công");
            }
            return BadRequest("Xóa K Thành Công");
        }
        /// <summary>
        /// Tìm kiếm giảng viên
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ActionName("TimKiemGiangVien")]
        
        public async Task<ActionResult<IEnumerable<GiangVien>>> TimGiangVien(string search)
        {
            if (search != "")
            {
                return await _giangVien.SearchGiangVien(search);
            }

            return BadRequest("Giảng viên không tồn tại");
        }
        /// <summary>
        /// giảng viên đổi mật khẩu
        /// </summary>
        /// <param name="viewdoipass"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ActionName("updatePassword")]
        [Authorize(Policy = "GiangViens")]
        public async Task<IActionResult> DoiPass(UpDatePassWord viewdoipass)
        {
            if (viewdoipass != null && !string.IsNullOrEmpty((viewdoipass.Id_User).ToString()) && !string.IsNullOrEmpty(viewdoipass.PasswordOld))
            {
                var khachhang = _giangVien.DoiPass(viewdoipass);
            }
            return BadRequest();
        }
        /// <summary>
        /// tạo phiếu lương cho nhân viên
        /// </summary>
        /// <param name="luong"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("luong")]
        [Authorize(Policy = "NguoiDungs")]
        public async Task<IActionResult> TraLuong(Luong luong)
        {
            if (await _giangVien.TraLuong(luong) > 0)
            {
                return Ok(new
                {
                    retCode = 1,
                    retText = "Tạo phiếu thành công",
                    data = ""
                });
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Thất bại",
                data = ""
            });
        }
        /// <summary>
        /// giảng viên đăng nhập
        /// </summary>
        /// <param name="viewLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GiangVienLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> GiangVienLogin(ViewLogin viewLogin)
        {
            if (viewLogin != null && !string.IsNullOrEmpty(viewLogin.Email) && !string.IsNullOrEmpty(viewLogin.Password) || viewLogin != null && !string.IsNullOrEmpty(viewLogin.MaDangNhap) && !string.IsNullOrEmpty(viewLogin.Password))
            {
                var giangviens = _giangVien.GiangVienLogin(viewLogin);
                if (giangviens != null)
                {
                    if (giangviens != null)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                            new Claim("Id",giangviens.Id.ToString()),
                            new Claim("TenDemVaTen",giangviens.TenDemVaTen),
                            new Claim("Email",giangviens.Email),
                           // new Claim(ClaimTypes.Role,hocviens.Roles.ToString())
                            new Claim("Role","Giangviens")

                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: singIn);
                        ViewToken<GiangVien> viewToken = new ViewToken<GiangVien>()
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            User=giangviens
                            //NguoiDung_Id = giangviens.Id,
                            //NguoiDung_Ten = giangviens.TenDemVaTen,
                            //NguoiDung_Email = giangviens.Email,
                            //NguoiDung_Role = giangviens.role.GetHashCode(),
                        };
                        return Ok(viewToken);
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                else { return BadRequest(); }
            }
            return BadRequest();
        }
    }
}
