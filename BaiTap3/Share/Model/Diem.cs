using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class Diem
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten Mon Hoc")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("MonHocs")]
        public string TenMonHoc { get; set; }
       
        [Display(Name = "Loai Diem")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("LoaiDiems")]
        public int LoaiDiem { get; set; }//kn
        public int SoCotDiem { get; set; }
        public int SoCotDiemBatBuoc { get; set; }
        public bool IsDelete { get; set; }
        public LoaiDiem LoaiDiems { get; set; }
        public ICollection<HocVien_Diem> HocVien_Diems { get; set; }
    }
}
