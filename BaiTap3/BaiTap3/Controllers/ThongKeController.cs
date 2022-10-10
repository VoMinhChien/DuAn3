using Microsoft.AspNetCore.Mvc;
using Share.Services;
using System;
using System.Threading.Tasks;

namespace BaiTap3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ThongKeController : ControllerBase
    {
        private readonly IThongKe _thongKe;
        public ThongKeController(IThongKe thongke)
        {
            _thongKe = thongke;
        }
        [HttpGet("{date}")]
        [ActionName("doanhthutheongay")]
        public async Task<IActionResult> GetFeeByDate(DateTime date)
        {
            return Ok(new
            {
                retCode = 1,
                retText = "successfuly",
                data = await _thongKe.HienDoanhThuTrong1Ngay(date)
            });
        }
        [HttpGet, ActionName("getall")]
        public async Task<IActionResult> GetAllFees()
        {
            return Ok(new
            {
                retCode = 1,
                retText = "successfuly",
                data = await _thongKe.HienDsHocVienDaDongHocPhi()
            });
        }
        [HttpGet("{id}"), ActionName("luonggiangvien")]
        public async Task<IActionResult> GetSalatyByTeacher(int teacherId)
        {
            return Ok(new
            {
                retCode = 1,
                retText = "successfuly",
                data = await _thongKe.HienLuongTheoMaGV(teacherId)
            });
        }
        [HttpGet("{id}"), ActionName("luongchitiet")]
        public async Task<IActionResult> GetDetailsSalary(int salaryId)
        {
            return Ok(new
            {
                retCode = 1,
                retText = "successfuly",
                data = await _thongKe.GetDetailsSalary(salaryId)
            });
        }
    }
}
