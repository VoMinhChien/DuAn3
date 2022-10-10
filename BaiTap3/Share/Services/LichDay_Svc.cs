using Microsoft.EntityFrameworkCore;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface ILichDay
    {
        Task<List<LichDay>> GetAllLichDay();
        Task<int> AddLichDayAsync(LichDay lichday);

        Task<int> UpdateLichDay(int id, LichDay lichHoc);
        int XoaLichHoc(int id);
    }
    public class LichDay_Svc : ILichDay
    {
        protected DataContext _context;

        public LichDay_Svc(DataContext context)
        {
            _context = context;

        }
        public async Task<int> AddLichDayAsync(LichDay lichday)
        {
            int ret = 0;
            try
            {
                var lich = await _context.LichDays.Where(x => x.LopHoc == lichday.LopHoc && x.GiaoVien == lichday.GiaoVien && x.Thu == lichday.Thu && x.Ca == lichday.Ca).FirstOrDefaultAsync();
                if (lich != null)
                {
                    ret = 0;
                }
                else
                {
                    await _context.AddAsync(lichday);
                    _context.SaveChanges();
                    ret = lichday.ID;
                }

            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<List<LichDay>> GetAllLichDay()
        {
            List<LichDay> ListLD = new List<LichDay>();
            ListLD = await _context.LichDays.ToListAsync();
            return ListLD;
        }

        public async Task<int> UpdateLichDay(int id, LichDay lichHoc)
        {
            int ret = 0;
            try
            {
                LichDay _lichday = null;
                _lichday = _context.LichDays.Find(id);
                _lichday.Thu = lichHoc.Thu;
                _lichday.MonHoc = lichHoc.MonHoc;
                _lichday.LopHoc = lichHoc.LopHoc;
                _lichday.Ca = lichHoc.Ca;
                _lichday.GiaoVien = lichHoc.GiaoVien;

                _context.LichDays.Update(_lichday);
                await _context.SaveChangesAsync();
                ret = _lichday.ID;
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
                var xoald = _context.LichDays.Where(o => o.ID == id).FirstOrDefault();
                _context.Remove(xoald);
                _context.SaveChanges();
                ret = xoald.ID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
