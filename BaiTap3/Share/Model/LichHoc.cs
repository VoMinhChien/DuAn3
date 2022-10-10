using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class LichHoc
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Display(Name = " Lop Hoc ")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("LopHocs")]
        public int PhongHoc { get; set; }//kn
        [Display(Name = "Thu")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("ThuNgays")]
        public int Thu { get; set; }
        [Display(Name = "Ca")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("Cahocs")]
        public int Ca { get; set; }
        [Display(Name = "Mon Hoc")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("MonHocs")]
        public int MonHoc { get; set; }//kn
        public LopHoc LopHocs { get; set; }
        public MonHoc MonHocs { get; set; }
        public CaHoc Cahocs { get; set; }
        public ThuNgay ThuNgays { get; set; } 
       
    }
}
