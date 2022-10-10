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
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class NguoiDungController : Controller
    {
        private readonly INguoiDung _nguoiDung;
        public IConfiguration _configuration;

        public NguoiDungController(INguoiDung nguoidung, IConfiguration _configuration)
        {
            this._nguoiDung = nguoidung;
            this._configuration = _configuration;
        }
        [HttpPost]
        [ActionName("NguoiDungLogin")]
        [AllowAnonymous]
        public async Task<IActionResult> NguoiDungLogin(ViewLogin viewLogin)
        {
            if (viewLogin != null && !string.IsNullOrEmpty(viewLogin.Email) && !string.IsNullOrEmpty(viewLogin.Password) || viewLogin != null && !string.IsNullOrEmpty(viewLogin.MaDangNhap) && !string.IsNullOrEmpty(viewLogin.Password))
            {
                var nguoidungs = _nguoiDung.NguoiDungLogin(viewLogin);
                if (nguoidungs != null)
                {
                    if (nguoidungs != null)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                            new Claim("Id",nguoidungs.Id.ToString()),
                            new Claim("TenNguoiDung",nguoidungs.TenNguoiDung),
                            new Claim("Email",nguoidungs.Email),
                           // new Claim(ClaimTypes.Role,hocviens.Roles.ToString())
                            new Claim("Role","NguoiDungs")

                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: singIn);
                        ViewToken<NguoiDung> viewToken = new ViewToken<NguoiDung>()
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            User=nguoidungs
                            //NguoiDung_Id = nguoidungs.Id,
                            //NguoiDung_Ten = nguoidungs.TenNguoiDung,
                            //NguoiDung_Email = nguoidungs.Email,
                            //NguoiDung_Role = nguoidungs.role.GetHashCode(),
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
