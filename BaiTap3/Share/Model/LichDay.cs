using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class LichDay
    {
        [Key]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        
        [Display(Name = "Mon Hoc")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("MonHocs")]
        public int MonHoc { get; set; }//kn
      
        [Display(Name = " Phong Hoc ")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("LopHocs")]
        public int LopHoc { get; set; }//kn

        [Display(Name = "Thu")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("ThuNgays")]
        public string Thu { get; set; }
        [Display(Name = "Ca")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("Cahocs")]
        public int Ca { get; set; }
      
        [Display(Name = "Giao Vien")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("GiangViens")]
        public int GiaoVien { get; set; }//kn
        public bool Isdelete { get; set; }
        public MonHoc MonHocs { get; set; }
        public GiangVien GiangViens { get; set; }
        public LopHoc LopHocs { get; set; }
    }
}
