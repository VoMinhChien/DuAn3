using Microsoft.EntityFrameworkCore;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface IPhanQuyen
    {
        Task<bool> ThemQuyen(List<Role_QUyen> role_Quyens);
        Task<bool> XoaQuyen(List<Role_QUyen> role_Quyens);
        Task<List<Role_QUyen>> GetRole_QuyensAsync(int id_role);
        Task<List<Quyen>> GetRoleQuyenNotHaveAsync(int id_role);
    }
    public class PhanQuyen_Svc
    {
        private readonly DataContext _context;
        public PhanQuyen_Svc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddOrUpdateRole_QuyenAsync(List<Role_QUyen> role_Quyens)
        {
            bool ret = false;
            try
            {
                foreach (var item in role_Quyens)
                {
                    Role_QUyen role_Quyen = new Role_QUyen();
                    role_Quyen = await _context.Roles_Quyens.Where(x => x.ID_Role == item.ID_Role && x.ID_Quyen == item.ID_Quyen)
                            .FirstOrDefaultAsync();
                    if (role_Quyen != null)//kiểm tra quyền đó đã có chưa
                    {
                        continue;
                    }
                    else//chưa có thì thêm vào cho role
                    {
                        await _context.Roles_Quyens.AddAsync(item);
                    }
                }
                await _context.SaveChangesAsync();
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        public async Task<bool> DeleteAlNothavelRole_QuyenAsync(List<Role_QUyen> role_Quyens)
        {
            bool ret = false;
            try
            {
                List<Role_QUyen> role_Quyennothave = new List<Role_QUyen>();
                List<int> id_role_quyens = (from p in role_Quyens
                                            select p.ID_Quyen).ToList();
                //lấy các quyền mà role bỏ đi và xóa nó
                role_Quyennothave = await _context.Roles_Quyens.Where(x => !id_role_quyens.Contains(x.ID_Quyen)
                                          && x.ID_Role == role_Quyens[0].ID_Role).ToListAsync();
                foreach (var item in role_Quyennothave)
                {
                    _context.Roles_Quyens.Remove(item);
                }
                await _context.SaveChangesAsync();
                ret = true;
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public async Task<List<Role_QUyen>> GetRole_QuyensAsync(int id_Role)
        {
            List<Role_QUyen> Role_Quyens = new List<Role_QUyen>();
            Role_Quyens = await _context.Roles_Quyens.Where(x => x.ID_Role == id_Role)
                            .Include(x => x.Quyens).ToListAsync();
            return Role_Quyens;
        }

        public async Task<List<Quyen>> GetRoleQuyenNotHaveAsync(int id_Role)
        {
            List<Role_QUyen> Role_Quyens = new List<Role_QUyen>();
            Role_Quyens = await _context.Roles_Quyens.Where(x => x.ID_Role == id_Role)
                                .ToListAsync();
            List<int> id_Quyen = new List<int>();
            id_Quyen = (from p in Role_Quyens
                        select p.ID_Quyen).ToList();
            List<Quyen> quyens = new List<Quyen>();
            quyens = await _context.Quyens.Where(x => !id_Quyen.Contains(x.Id)).ToListAsync();
            return quyens;
        }
    }
}
