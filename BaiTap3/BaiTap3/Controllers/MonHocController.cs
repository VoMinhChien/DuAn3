using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = "NguoiDungs")]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHoc _monhoc;
        public MonHocController(IMonHoc monHoc)
        {
            this._monhoc = monHoc;
        }
        /// <summary>
        /// Hiển thị tất cả môn học
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetAllMonHoc")]
        public async Task<ActionResult<IEnumerable<MonHoc>>> GetAllMonHoc()
        {

            return await _monhoc.GetAllMonHoc();

        }
        /// <summary>
        /// thêm môn học
        /// </summary>
        /// <param name="monhoc"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ThemMonHoc")]
        public async Task<ActionResult<int>> PostMonHoc(MonHoc monhoc)
        {
            try
            {
                int id = await _monhoc.AddMonHocAsync(monhoc);
                monhoc.ID = id;
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
        /// <summary>
        /// Sửa môn học
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monhoc"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public MonHoc SuaMonHoc(int id, MonHoc monhoc)
        {
            _monhoc.UpdateMonHoc(id, monhoc);
            return monhoc;
        }
        /// <summary>
        /// xóa môn học
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> XoaMonHoc(int id)
        {
            if (id != 0)
            {
                _monhoc.XoaMonHoc(id);
                return Ok("Xoa Thành Công");
            }
            return BadRequest("Xóa K Thành Công");
        }
        /// <summary>
        /// tìm kiếm môn học
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ActionName("TimKiemMonHoc")]

        public async Task<ActionResult<IEnumerable<MonHoc>>> TimMonHoc(string search)
        {
            if (search != "")
            {
                return await _monhoc.SearchMonHoc(search);
            }

            return BadRequest("Môn Học không tồn tại");
        }
    }
}
