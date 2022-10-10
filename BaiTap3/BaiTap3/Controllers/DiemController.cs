using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Share.Model;
using Share.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaiTap3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class DiemController : Controller
    {
        private readonly IDiem _diem;
        public IConfiguration _configuration;
        public DiemController(IDiem diem, IConfiguration _configuration)
        {
            this._diem = diem;
            this._configuration = _configuration;
        }
        /// <summary>
        /// Thêm loại điểm
        /// </summary>
        /// <param name="diem"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ThemLoaiDiem")]
        public async Task<ActionResult<int>> ThemLoaiDiem(Diem diem)
        {
            try
            {
                int id = await _diem.AddDiem(diem);
                diem.Id = id;
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
        /// <summary>
        /// hiển thị các loại điểm
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Diem>>> GetAllLoaiDiem()
        {

            return await _diem.GetAllDiem();

        }
        /// <summary>
        /// sửa loại điểm môn học
        /// </summary>
        /// <param name="id"></param>
        /// <param name="diem"></param>
        /// <returns></returns>
        [HttpPut("{id}")]

        public Diem SuaThongTin(int id, Diem diem)
        {
            _diem.UpdateDiem(id, diem);
            return diem;
        }
        /// <summary>
        /// xóa loại điểm môn học
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Xoa(int id)
        {
            if (id != 0)
            {
                _diem.Xoa(id);
                return Ok("Xoa Thành Công");
            }
            return BadRequest("Xóa K Thành Công");
        }
    }
}
