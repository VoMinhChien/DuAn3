using Microsoft.AspNetCore.Mvc;
using Share.Model;
using Share.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaiTap3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ThuHocPhiChiTietController : ControllerBase
    {
        private readonly IThuPhiChiTiet _thuHocPhichitiet;
        public ThuHocPhiChiTietController(IThuPhiChiTiet thuHocPhichitiet)
        {
            this._thuHocPhichitiet = thuHocPhichitiet;
        }
        [HttpPost]
        [ActionName("DongHocPhi")]
        public async Task<ActionResult<int>> PostHocVien(ThuHocPhiChiTiet thuHocPhichitiet)
        {
            try
            {
                int id = await _thuHocPhichitiet.Add(thuHocPhichitiet);
                
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
        //[HttpGet]
        //[ActionName("Tong Doanh Thu")]
        //public async Task<float> TongDoanhThu()
        //{
        //    return await TongDoanhThu();
        //}
    }
}
