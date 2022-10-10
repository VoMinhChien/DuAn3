using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share.Model;
using Share.Model.ViewModel;
using Share.Services;
using System;
using System.Threading.Tasks;

namespace BaiTap3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Policy = "NguoiDungs")]
    [Authorize(Policy = "GiangViens")]
    public class LopHocController : ControllerBase
    {
        private readonly ILopHoc _Lophoc;
        public LopHocController(ILopHoc khoaDaoTao)
        {
            this._Lophoc = khoaDaoTao;
        }
        /// <summary>
        /// Thêm Lớp Học
        /// </summary>
        /// <param name="lopHoc"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ThemLopHoc")]
        public async Task<ActionResult<int>> PostLopHoc(LopHoc lopHoc)
        {
            try
            {
                int id = await _Lophoc.AddLopHoc(lopHoc);
                lopHoc.Id = id;
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
        /// <summary>
        /// Học viên đăng ký vào lớp học
        /// </summary>
        /// <param name="lop_HocVien"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("DangKyVaoLopHoc")]
        public async Task<IActionResult> PostHocVienVaoLopHoc(Lop_HocVien lop_HocVien)
        {
            if(ModelState.IsValid)
            {
                if(await _Lophoc.DangKyHocVienVaoLopHoc(lop_HocVien) > 0)
                {
                    return Ok("Đăng ký vào lớp học thành công");
                }
               else
                {
                    return BadRequest("Bạn đã dky lớp học này hoặc Số lượng học viên đã đủ !");
                }
            }
            return BadRequest();
        }
        /// <summary>
        /// Thêm điểm cho 1 học viên
        /// </summary>
        /// <param name="hv_diem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("themdiem")]
        public async Task<IActionResult> AddPointAsync(HocVien_Diem hv_diem)
        {
            if (ModelState.IsValid)
            {
                if (await _Lophoc.ThemDiemCho1Hv(hv_diem))
                {
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Thêm Thành Công"
                    });
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Thêm Thất bại, vui lòng kiểm tra lại"
            });
        }
        /// <summary>
        /// thêm điểm cho cả lớp học
        /// </summary>
        /// <param name="themdiem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("themdiemcholop")]
        public async Task<IActionResult> AddListPointAsync(ViewThemDiems themdiem)
        {
            if (ModelState.IsValid)
            {
                if (await _Lophoc.ThemDiemChoNhieuHv(themdiem))
                {
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "Thêm Thành Công"
                    });
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Thêm Thất bại, vui lòng kiểm tra lại"
            });
        }
        /// <summary>
        /// xem điểm theo môn học
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ActionName("xemdiem")]
        public async Task<IActionResult> GetPointsAsync(int monhoc)
        {
            return Ok(new
            {
                retCode = 1,
                retText = "Thành Công",
                data = await _Lophoc.HienThiDiemHocVien(monhoc)
            });
        }
        /// <summary>
        /// hiển thị ds học viên trong lớp học
        /// </summary>
        /// <param name="malop"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ActionName("danhsachhocvien")]
        public async Task<IActionResult> GetStudentByClassAsync(int malop)
        {
            return Ok(new
            {
                retCode = 1,
                retText = "thành công",
                data = await _Lophoc.HienDanhSachHvTrongLopHoc(malop)
            });
        }
        [HttpGet("{id}")]
        [ActionName("diemhocvien")]
        public async Task<IActionResult> GetListDiemByStudentAsync(int mahv)
        {
            return Ok(new
            {
                retCode = 1,
                retText = "Thành công",
                data = await _Lophoc.HienThiDiem1HocVien(mahv)
            });
        }

    }
}
