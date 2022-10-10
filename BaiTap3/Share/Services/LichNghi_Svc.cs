using Microsoft.EntityFrameworkCore;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface ILichNghi
    {
        Task<List<LichNghi>> GetAllLichNghi();
        Task<int> AddLichNghiAsync(LichNghi lichNghi);

        Task<int> UpdateLichNghi(int id, LichNghi lichNghi);
        int XoaLichNghi(int id);
        Task<List<LichNghi>> SearchLichNghi(string search);
    }
    public class LichNghi_Svc:ILichNghi
    {
        protected DataContext _context;
       
        public LichNghi_Svc(DataContext context)
        {
            _context = context;
           
        }
        public Task<int> AddLichNghiAsync(LichNghi lichNghi)
        {
          
            int ret = 0;
            try
            {
                lichNghi.Isdelete = false;
                _context.AddAsync(lichNghi);
                _context.SaveChanges();
                ret = lichNghi.Id;
            }
            catch
            {
                ret = 0;
            }
            return Task.FromResult(ret);
        }

        public async Task<List<LichNghi>> GetAllLichNghi()
        {
            List<LichNghi> ListLN = new List<LichNghi>();
            ListLN = await _context.LichNghis.ToListAsync();
            return ListLN;
        }

        public async Task<List<LichNghi>> SearchLichNghi(string search)
        {
            List<LichNghi> list = await _context.LichNghis.Where(o => o.Isdelete == false && o.TenNgayNghi.Contains(search)).ToListAsync();
            return list;
        }

        public async Task<int> UpdateLichNghi(int id, LichNghi lichNghi)
        {
            int ret = 0;
            try
            {
                LichNghi _lichnghi = null;
                _lichnghi = _context.LichNghis.Find(id);
                _lichnghi.TenNgayNghi = lichNghi.TenNgayNghi;
                _lichnghi.LyDo = lichNghi.LyDo;
                _lichnghi.NgayNghi = lichNghi.NgayNghi;
                _lichnghi.NgayKetThuc = lichNghi.NgayKetThuc;
               
                _context.LichNghis.Update(_lichnghi);
                await _context.SaveChangesAsync();
                ret = _lichnghi.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int XoaLichNghi(int id)
        {
            int ret = 0;
            try
            {
                var xoaln = _context.LichNghis.Where(o => o.Id == id).FirstOrDefault();
                _context.Remove(xoaln);
                _context.SaveChanges();
                ret = xoaln.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
