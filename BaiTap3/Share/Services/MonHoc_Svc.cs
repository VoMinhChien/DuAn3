using Microsoft.EntityFrameworkCore;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface IMonHoc
    {
        Task<List<MonHoc>> GetAllMonHoc();
        Task<int> AddMonHocAsync(MonHoc monHoc);

        Task<int> UpdateMonHoc(int id, MonHoc monHoc);
        int XoaMonHoc(int id);
        Task<List<MonHoc>> SearchMonHoc(string search);
    }
    public class MonHoc_Svc:IMonHoc
    {
        protected DataContext _context;
       
        public MonHoc_Svc(DataContext context)
        {
            _context = context;
           
        }
        public Task<int> AddMonHocAsync(MonHoc monHoc)
        {
            var chars1 = "1234567890";
            var stringChars1 = new char[6];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

            var str = new String(stringChars1);
            var maMonHoc = str;
            int ret = 0;
            try
            {
                maMonHoc = "MonHoc_" + str;
                _context.AddAsync(monHoc);
                _context.SaveChanges();
                ret = monHoc.ID;
            }
            catch
            {
                ret = 0;
            }
            return Task.FromResult(ret);
        }

        public async Task<List<MonHoc>> GetAllMonHoc()
        {
            List<MonHoc> ListGV = new List<MonHoc>();
            ListGV = await _context.MonHocs.ToListAsync();
            return ListGV;
        }

        public async Task<List<MonHoc>> SearchMonHoc(string search)
        {
            List<MonHoc> list = await _context.MonHocs.Where(o => o.IsDelete == false && o.TenMonHoc.Contains(search)).ToListAsync();
            return list;
        }

        public async Task<int> UpdateMonHoc(int id, MonHoc monHoc)
        {
            int ret = 0;
            try
            {
                MonHoc _monhoc = null;
                _monhoc = _context.MonHocs.Find(id);
                _monhoc.TenMonHoc = monHoc.TenMonHoc;
                _context.MonHocs.Update(_monhoc);
                await _context.SaveChangesAsync();
                ret = _monhoc.ID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int XoaMonHoc(int id)
        {
            int ret = 0;
            try
            {
                var xoaMH = _context.MonHocs.Where(o => o.ID == id).FirstOrDefault();
                _context.Remove(xoaMH);
                _context.SaveChanges();
                ret = xoaMH.ID;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
