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
    public class KhoaDaoTaoController : Controller
    {
        private readonly IKhoaDaoTao _khoaDaoTao;
        public KhoaDaoTaoController(IKhoaDaoTao khoaDaoTao)
        {
            this._khoaDaoTao = khoaDaoTao;
        }
        /// <summary>
        /// Thêm Khóa đào tạo
        /// </summary>
        /// <param name="khoadaotao"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ThemKhoaDaoTao")]
        public async Task<ActionResult<int>> PostKhoaDaoTao(KhoaDaoTao khoadaotao)
        {
            try
            {
                int id = await _khoaDaoTao.AddKhoaDaoTao(khoadaotao);
                khoadaotao.Id = id;
            }
            catch (Exception ex)
            {
                // return BadRequest(-1);
            }
            return Ok(1);
        }
        /// <summary>
        /// hiển thị khóa đào tạo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<KhoaDaoTao>>> GetAllKhoaDaotao()
        {

            return await _khoaDaoTao.GetAllKhoaDaoTao();

        }
        /// <summary>
        /// sửa khóa đào tạo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="khoaDaoTao"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
      
        public KhoaDaoTao SuaThongTin(int id, KhoaDaoTao khoaDaoTao)
        {
            _khoaDaoTao.UpdateKhoaDaoTao(id, khoaDaoTao);
            return khoaDaoTao;
        }
        /// <summary>
        /// xóa khóa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Xoa(int id)
        {
            if (id != 0)
            {
                _khoaDaoTao.Xoa(id);
                return Ok("Xoa Thành Công");
            }
            return BadRequest("Xóa K Thành Công");
        }
    }
}
