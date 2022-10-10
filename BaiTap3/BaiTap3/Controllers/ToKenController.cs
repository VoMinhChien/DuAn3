using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Share.Model;
using Share.Model.ViewModel;
using Share.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ToKenController : ControllerBase
    {
        public IHocVien _hocVien;
       
        public IConfiguration _configuration;
        public ToKenController(IHocVien hocVien, IConfiguration configuration)
        {
            _hocVien = hocVien;
            _configuration = configuration;
        }
        /// <summary>
        /// đăng nhập học viên
        /// </summary>
        /// <param name="viewLogin"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("hocVienLogin")]
        public async Task<IActionResult> Post(ViewLogin viewLogin)
        {
            if (viewLogin != null && !string.IsNullOrEmpty(viewLogin.Email) && !string.IsNullOrEmpty(viewLogin.Password) || viewLogin != null && !string.IsNullOrEmpty(viewLogin.MaDangNhap) && !string.IsNullOrEmpty(viewLogin.Password))
            {
                var hocviens = _hocVien.Login(viewLogin);
                if (hocviens != null)
                {
                    if (hocviens != null)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                            new Claim("Id",hocviens.Id.ToString()),
                            new Claim("TenDemVaTen",hocviens.TenDemVaTen),
                            new Claim("Email",hocviens.Email),
                            new Claim("Role","HocViens")

                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: singIn);
                        ViewToken<HocVien> viewToken = new ViewToken<HocVien>()
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            User=hocviens
                            //NguoiDung_Id = hocviens.Id,
                            //NguoiDung_Ten = hocviens.TenDemVaTen,
                            //NguoiDung_Email = hocviens.Email,
                            //NguoiDung_Role = hocviens.role.GetHashCode(),
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
