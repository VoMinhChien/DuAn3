using Microsoft.EntityFrameworkCore;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface ILichHoc
    {
        Task<List<LichHoc>> GetAllLichHoc();
        Task<int> AddLichHocAsync(LichHoc lichHoc);

        Task<int> UpdateLichHoc(int id, LichHoc lichHoc);
        int XoaLichHoc(int id);
       
    }
    public class LichHoc_Svc:ILichHoc
    {
        protected DataContext _context;

        public LichHoc_Svc(DataContext context)
        {
            _context = context;
            
        }
        public async Task<int> AddLichHocAsync(LichHoc lichHoc)
        {
          
            int ret = 0;
            try
            {
                var lich = await _context.LichHocs.Where(x=>x.PhongHoc==lichHoc.PhongHoc && x.Thu==lichHoc.Thu && x.Ca == lichHoc.Ca).FirstOrDefaultAsync();
                if(lich!=null)
                {
                    ret = 0;
                }
                else
                {
                    await _context.AddAsync(lichHoc);
                    _context.SaveChanges();
                    ret = lichHoc.Id;
                }
               
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<List<LichHoc>> GetAllLichHoc()
        {
            List<LichHoc> ListLH = new List<LichHoc>();
            ListLH = await _context.LichHocs.ToListAsync();
            return ListLH;
        }

     

        public async Task<int> UpdateLichHoc(int id, LichHoc lichhoc)
        {
            int ret = 0;
            try
            {
                LichHoc _lichhoc = null;
                _lichhoc = _context.LichHocs.Find(id);
                _lichhoc.PhongHoc = lichhoc.PhongHoc;
                _lichhoc.Thu = lichhoc.Thu;
                _lichhoc.Ca = lichhoc.Ca;
                _lichhoc.Thu = lichhoc.Thu;
                _lichhoc.MonHoc = lichhoc.MonHoc;
                _context.LichHocs.Update(_lichhoc);
                await _context.SaveChangesAsync();
                ret = _lichhoc.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int XoaLichHoc(int id)
        {
            int ret = 0;
            try
            {
                var xoalh= _context.LichHocs.Where(o => o.Id == id).FirstOrDefault();
                _context.Remove(xoalh);
                _context.SaveChanges();
                ret = xoalh.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
