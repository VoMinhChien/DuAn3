using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model.ViewModel
{
    public class ViewHienThiDiemHs
    {
        public int ID_MonHoc { get; set; }
        public int Id_HocVien { get; set; }
        public List<ViewThemDiemMieng> DiemKiemTraMiengs { get; set; }
        public List<ViewThemDiem1Tiet> diemKiemTraMotTiets { get; set; }
        public List<ViewThemDiem15p> kiemTra15Phuts { get; set; }
        public List<ViewThemDiemCuoiKy> diemThiCuoiKis { get; set; }
    }
}
