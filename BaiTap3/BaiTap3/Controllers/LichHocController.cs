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
    public class LichHocController : ControllerBase
    {
        private readonly ILichHoc _lichhoc;
        public LichHocController(ILichHoc lichhoc)
        {
            this._lichhoc = lichhoc;
        }
        /// <summary>
        /// hiển thị lịch học
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllLichHoc")]
        public async Task<ActionResult<IEnumerable<LichHoc>>> GetAllLichHoc()
        {

            return await _lichhoc.GetAllLichHoc();

        }
        /// <summary>
        /// thêm lịch học
        /// </summary>
        /// <param name="lichhoc"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ThemLichHoc")]
        public async Task<ActionResult<int>> PostLichHoc(LichHoc lichhoc)
        {
            if (ModelState.IsValid)
            {
                if (await _lichhoc.AddLichHocAsync(lichhoc) > 0)
                {
                    return Ok("Thêm Lịch Học Thành Công");
                }
                else
                {
                    return BadRequest("Đã tồn tại, vui lòng vào phần sửa");
                }
            }
            return BadRequest();











            try
            {
                int id = await _lichhoc.AddLichHocAsync(lichhoc);
                lichhoc.Id = id;
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
        /// <summary>
        /// sửa lịch học
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lichhoc"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public LichHoc SuaThongTin(int id, LichHoc lichhoc)
        {
            _lichhoc.UpdateLichHoc(id, lichhoc);
            return lichhoc;
        }
        /// <summary>
        /// Xóa lịch học
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> XoaLichHoc(int id)
        {
            if (id != 0)
            {
                _lichhoc.XoaLichHoc(id);
                return Ok("Xoa Thành Công");
            }
            return BadRequest("Xóa K Thành Công");
        }
        
    }
}
