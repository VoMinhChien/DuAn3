using Microsoft.AspNetCore.Mvc;
using Share.Model;
using Share.Services;
using System;
using System.Threading.Tasks;

namespace BaiTap3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ThuHocPhiController : Controller
    {
        private readonly IThuHocPhi _thuHocPhi;
        public ThuHocPhiController(IThuHocPhi thuhocphi)
        {
            this._thuHocPhi = thuhocphi;
        }
        /// <summary>
        /// Add thu học phí
        /// </summary>
        /// <param name="thuHocPhi"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AddThuHocPhi")]
        public async Task<ActionResult<int>> PostHocVien(ThuHocPhi thuHocPhi)
        {
            try
            {
                int id = await _thuHocPhi.AddThuHocPhi(thuHocPhi);
                thuHocPhi.Id = id;
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
    }
}
