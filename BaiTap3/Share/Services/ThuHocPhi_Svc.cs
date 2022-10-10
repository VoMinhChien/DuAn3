using Share.Helpers;
using Share.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface IThuHocPhi
    {
        Task<int> AddThuHocPhi(ThuHocPhi thuHocPhi);
    }
    public class ThuHocPhi_Svc:IThuHocPhi
    {
        protected DataContext _context;
        protected IMaHoaHelper _maHoaHelper;
        public ThuHocPhi_Svc(DataContext context, IMaHoaHelper maHoaHelper)
        {
            _context = context;
            _maHoaHelper = maHoaHelper;
        }
        public Task<int> AddThuHocPhi(ThuHocPhi thuHocPhi)
        {
            int ret = 0;
            try
            {

                _context.AddAsync(thuHocPhi);
                _context.SaveChanges();
                ret = thuHocPhi.Id;
            }
            catch
            {
                ret = 0;
            }
            return Task.FromResult(ret);
        }
    }
}
