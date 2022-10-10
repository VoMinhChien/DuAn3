using Microsoft.EntityFrameworkCore;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface IDiem
    {
        Task<int> AddDiem(Diem diem);
        Task<List<Diem>> GetAllDiem();
        Task<int> UpdateDiem(int id, Diem diem);
        int Xoa(int id);
    }
    public class Diem_Svc:IDiem
    {
        protected DataContext _context;
        
        public Diem_Svc(DataContext context)
        {
            _context = context;
          
        }
        public Task<int> AddDiem(Diem diem)
        {
          
            int ret = 0;
            try
            {
           
                _context.AddAsync(diem);
                _context.SaveChanges();
                ret = diem.Id;
            }
            catch
            {
                ret = 0;
            }
            return Task.FromResult(ret);
        }
        public async Task<List<Diem>> GetAllDiem()
        {
            List<Diem> List = new List<Diem>();
            List = await _context.Diems.ToListAsync();
            return List;
        }
        public async Task<int> UpdateDiem(int id, Diem diem)
        {
            int ret = 0;
            try
            {
                Diem _diem = null;
                _diem = _context.Diems.Find(id);
                _diem.TenMonHoc = diem.TenMonHoc;
                _diem.LoaiDiem = diem.LoaiDiem;
                _diem.SoCotDiem = diem.SoCotDiem;
                _diem.SoCotDiemBatBuoc = diem.SoCotDiemBatBuoc;

                _context.Diems.Update(_diem);
                await _context.SaveChangesAsync();
                ret = _diem.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public int Xoa(int id)
        {
            int ret = 0;
            try
            {
                var xoa = _context.Diems.Where(o => o.Id == id).FirstOrDefault();
                _context.Remove(xoa);
                _context.SaveChanges();
                ret = xoa.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
