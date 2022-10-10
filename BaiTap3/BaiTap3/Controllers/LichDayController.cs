using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share.Model;
using Share.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaiTap3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LichDayController : ControllerBase
    {
        private readonly ILichDay _lichday;
        public LichDayController(ILichDay lichday)
        {
            this._lichday = lichday;
        }
        [HttpGet]
        [ActionName("GetAllLichDay")]
        [Authorize(Policy = "NguoiDungs")]
        [Authorize(Policy = "GiangViens")]
        public async Task<ActionResult<IEnumerable<LichDay>>> GetAllLichday()
        {

            return await _lichday.GetAllLichDay();

        }
        [HttpPost]
        [ActionName("ThemLichDay")]
        [Authorize(Policy = "NguoiDungs")]
        public async Task<ActionResult<int>> PostLichDay(LichDay lichday)
        {
            if (ModelState.IsValid)
            {
                if (await _lichday.AddLichDayAsync(lichday) > 0)
                {
                    return Ok("Thêm Lịch day Thành Công");
                }
                else
                {
                    return BadRequest("Đã tồn tại, vui lòng vào phần sửa");
                }
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        [Authorize(Policy = "NguoiDungs")]
        public LichDay SuaThongTin(int id, LichDay lichday)
        {
            _lichday.UpdateLichDay(id, lichday);
            return lichday;
        }
        [HttpDelete("{id}")]
        [Authorize(Policy = "NguoiDungs")]
        public LichDay xoa(int id, LichDay lichday)
        {
            _lichday.XoaLichHoc(id);
            return lichday;
        }
    }
}
