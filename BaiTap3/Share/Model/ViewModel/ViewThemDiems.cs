using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model.ViewModel
{
    public class ViewThemDiems
    {
        public int Id_MonHocs { get; set; }
        public int LoaiDiems { get; set; }
        public List<ViewThemDiemHS> diemHs { get; set; }
    }
}
