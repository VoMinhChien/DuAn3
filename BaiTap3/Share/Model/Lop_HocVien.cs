using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class Lop_HocVien
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
       
        [Display(Name = "Hoc Vien")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("HocViens")]
        public int Id_HocVien { get; set; }
   
        [Display(Name = "Ma Lop")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("LopHocs")]
        public int MaLop { get; set; }
        public bool status {get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayDangKy { get; set; }
        public bool TrangThaiHocPhi { get; set; }
        public bool Isdelete { get; set; }
        public LopHoc LopHocs { get; set; }
        public HocVien HocViens { get; set; }

    }
}
