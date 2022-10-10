using Microsoft.AspNetCore.Mvc;
using Share.Model;
using Share.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaiTap3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class Role_QuyenController : Controller
    {
        private readonly IPhanQuyen _role_Quyen;
        public Role_QuyenController(IPhanQuyen role_Quyen)
        {
            _role_Quyen = role_Quyen;
        }
        /// <summary>
        /// thêm và xóa quyền
        /// </summary>
        /// <param name="Role_Quyens"></param>
        /// <returns></returns>
        [HttpPost()]
        [ ActionName("rolequyen")]
        public async Task<IActionResult> UpdateOrAddRole_QuyenAsync(List<Role_QUyen> Role_Quyens)
        {
            if (ModelState.IsValid)
            {
                if (await _role_Quyen.ThemQuyen(Role_Quyens))
                {
                    if (await _role_Quyen.XoaQuyen(Role_Quyens))
                    {
                        return Ok(new
                        {
                            retCode = 1,
                            retText = "Cập nhật quyền cho role thành công",
                            data = await _role_Quyen.GetRole_QuyensAsync(Role_Quyens[0].ID_Role)
                        });
                    }
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText = "Cập nhật quyền cho role thất bại",
                data = ""
            });
        }
        /// <summary>
        /// hiển thị role đang có
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ActionName("quyenin")]
        public async Task<List<Role_QUyen>> GetRole_QuyensAsync(int id)
        {
            return await _role_Quyen.GetRole_QuyensAsync(id);
        }
        /// <summary>
        /// hiển thị role chưa có
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ ActionName("quyennotin")]
        public async Task<List<Quyen>> GetQuyenRoleNotHaveAsync(int id)
        {
            return await _role_Quyen.GetRoleQuyenNotHaveAsync(id);
        }
    }
}
