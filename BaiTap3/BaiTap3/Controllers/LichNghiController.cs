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
    public class LichNghiController : ControllerBase
    {
        private readonly ILichNghi _lichnghi;
        public LichNghiController(ILichNghi lichnghi)
        {
            this._lichnghi = lichnghi;
        }
        /// <summary>
        /// hiển thị danh sách các lịch nghỉ
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllLichNghi")]
        public async Task<ActionResult<IEnumerable<LichNghi>>> GetAllLichnghi()
        {

            return await _lichnghi.GetAllLichNghi();

        }
        /// <summary>
        /// Thêm lịch nghỉ
        /// </summary>
        /// <param name="lichNghi"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ThemLichNghi")]
        public async Task<ActionResult<int>> PostLichNghi(LichNghi lichNghi)
        {
            try
            {
                int id = await _lichnghi.AddLichNghiAsync(lichNghi);
                lichNghi.Id = id;
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
        /// <summary>
        /// sửa lịch nghỉ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lichNghi"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public LichNghi SuaThongTin(int id, LichNghi lichNghi)
        {
            _lichnghi.UpdateLichNghi(id, lichNghi);
            return lichNghi;
        }
        /// <summary>
        /// Xóa Lịch Nghỉ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> XoaLichNghi(int id)
        {
            if (id != 0)
            {
                _lichnghi.XoaLichNghi(id);
                return Ok("Xoa Thành Công");
            }
            return BadRequest("Xóa K Thành Công");
        }
        /// <summary>
        /// Tìm kiếm lịch nghỉ
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ActionName("TimKiemLichNghi")]

        public async Task<ActionResult<IEnumerable<LichNghi>>> Tim(string search)
        {
            if (search != "")
            {
                return await _lichnghi.SearchLichNghi(search);
            }

            return BadRequest("Lich Nghi không tồn tại");
        }
    }
}
