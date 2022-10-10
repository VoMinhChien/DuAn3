using Microsoft.EntityFrameworkCore;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface IThuPhiChiTiet
    {
        Task<int> Add(ThuHocPhiChiTiet chiTiet);
        //Task<float> TongDoanhThu();
    }
    public class ThuHocPhiChiTiet_Svc:IThuPhiChiTiet
    {
        protected DataContext _context;
    
        public ThuHocPhiChiTiet_Svc(DataContext context)
        {
            _context = context;
            
        }

        public async Task<int> Add(ThuHocPhiChiTiet chiTiet)
        {
            
            int ret = 0;
            try
            {
                ThuHocPhi hp = new ThuHocPhi();
                hp = await _context.ThuHocPhis.Where(o => o.MaLopHoc == chiTiet.ID_MaLop).FirstOrDefaultAsync();
                chiTiet.SoTien = hp.MucThuPhi;
                await _context.AddAsync(chiTiet);
                await _context.SaveChangesAsync();
                ret = chiTiet.Id;
            }
            catch
            {
                ret = 0;
            }
            
            return 0;
        }
        //public async Task<float> TongDoanhThu()
        //{
        //    ThuHocPhi thp = null;
        //    // var lhs = _context.Lop_HocViens.FirstOrDefault();
        //    var s = _context.Lop_HocViens.Where(o => o.TrangThaiHocPhi == false && o.MaLop == thp.MaLopHoc).ToList();
        //    var sl = s.Count();
        //    float i;
        //    for (i = 0; i < sl; i++)
        //    {
        //        i += thp.MucThuPhi;
        //    };
        //    return i;
        //}
    }
}
