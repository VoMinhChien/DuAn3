using Microsoft.EntityFrameworkCore;
using Share.Helpers;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface IKhoaDaoTao
    {
        Task<int> AddKhoaDaoTao(KhoaDaoTao KhoaDaoTaos);
        Task<List<KhoaDaoTao>> GetAllKhoaDaoTao();     
        Task<int> UpdateKhoaDaoTao(int id, KhoaDaoTao khoaDaoTao);
        int Xoa(int id);
    }
        public class KhoaDaoTao_Svc:IKhoaDaoTao
    {
        protected DataContext _context;
        protected IMaHoaHelper _maHoaHelper;
        public KhoaDaoTao_Svc(DataContext context, IMaHoaHelper maHoaHelper)
        {
            _context = context;
            _maHoaHelper = maHoaHelper;
        }
        public Task<int> AddKhoaDaoTao(KhoaDaoTao khoaDaoTaos)
        {
            var chars1 = "1234567890";
            var stringChars1 = new char[6];
            var random1 = new Random();

            for (int i = 0; i < stringChars1.Length; i++)
            {
                stringChars1[i] = chars1[random1.Next(chars1.Length)];
            }

            var str = new String(stringChars1);
            var MaKhoa = str;
            int ret = 0;
            try
            {
                khoaDaoTaos.MaKhoa ="KHOA_"+ MaKhoa;
                _context.AddAsync(khoaDaoTaos);
                _context.SaveChanges();
                ret = khoaDaoTaos.Id;
            }
            catch
            {
                ret = 0;
            }
            return Task.FromResult(ret);
        }
        public async Task<List<KhoaDaoTao>> GetAllKhoaDaoTao()
        {
            List<KhoaDaoTao> List = new List<KhoaDaoTao>();
            List = await _context.KhoaDaoTaos.ToListAsync();
            return List;
        }
        public async Task<int> UpdateKhoaDaoTao(int id, KhoaDaoTao khoaDaoTao)
        {
            int ret = 0;
            try
            {
                KhoaDaoTao _kdt = null;
                _kdt = _context.KhoaDaoTaos.Find(id);
                _kdt.TenKhoa = khoaDaoTao.TenKhoa;
                _kdt.MaKhoa = khoaDaoTao.MaKhoa;
                _kdt.StartTime = khoaDaoTao.StartTime;
                _kdt.EndTime = khoaDaoTao.EndTime;


                _context.KhoaDaoTaos.Update(_kdt);
                await _context.SaveChangesAsync();
                ret = _kdt.Id;
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
                var xoa = _context.KhoaDaoTaos.Where(o => o.Id == id).FirstOrDefault();
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
