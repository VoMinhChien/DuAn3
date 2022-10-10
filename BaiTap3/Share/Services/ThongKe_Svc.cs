using Microsoft.EntityFrameworkCore;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface IThongKe
    {
        Task<List<ThuHocPhiChiTiet>> HienDsHocVienDaDongHocPhi();
        Task<List<ThuHocPhiChiTiet>> HienDoanhThuTrong1Ngay(DateTime date);
        Task<List<Luong>> HienLuongTheoMaGV(int id_Teacher);
        Task<Luong> GetDetailsSalary(int id_Slary);
    }
         
    public class ThongKe_Svc:IThongKe
    {
        private readonly DataContext _context;
        public ThongKe_Svc(DataContext context)
        {
            _context = context;
        }
        public async Task<List<ThuHocPhiChiTiet>> HienDoanhThuTrong1Ngay(DateTime date)
        {

            return await _context.ThuHocPhiChiTiets.Where(x => x.PaymentDate.Year == date.Year && x.PaymentDate.Month == date.Month
                     && x.PaymentDate.Day == date.Day).ToListAsync();
        }

        public async Task<List<ThuHocPhiChiTiet>> HienDsHocVienDaDongHocPhi()
        {
            return await _context.ThuHocPhiChiTiets.ToListAsync();
        }
        public async Task<List<Luong>> HienLuongTheoMaGV(int id_Teacher)
        {
            return await _context.Luongs.Where(x => x.ID_GiangVien == id_Teacher).ToListAsync();
        }
        public async Task<Luong> GetDetailsSalary(int id_Slary)
        {
            return await _context.Luongs.Where(x => x.Id == id_Slary).FirstOrDefaultAsync();
        }
      
    }
}
