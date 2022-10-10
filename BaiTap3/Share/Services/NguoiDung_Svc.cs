using Share.Helpers;
using Share.Model;
using Share.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public interface INguoiDung
    {
        NguoiDung NguoiDungLogin(ViewLogin viewLogin);
    }
    public class NguoiDung_Svc:INguoiDung
    {
        protected DataContext _context;
        protected IMaHoaHelper _maHoaHelper;
        public NguoiDung_Svc(DataContext context, IMaHoaHelper maHoaHelper)
        {
            _context = context;
            _maHoaHelper = maHoaHelper;
        }
        public NguoiDung NguoiDungLogin(ViewLogin viewLogin)
        {
            var u = _context.NguoiDungs.Where(p => p.Email.Equals(viewLogin.Email) && p.MatKhau.Equals(_maHoaHelper.Mahoa(viewLogin.Password))).FirstOrDefault();
            return u;
        }
    }
}
