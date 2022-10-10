using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class HocVien_Diem
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        
        [Display(Name = "Hoc Vien")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("HocViens")]
        public int ID_HocVien { get; set; }//kn
        [Display(Name = "MonHoc")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("MonHocs")]
        public int ID_MonHoc { get; set; }
        
        [ForeignKey("LoaiDiems")]
        public int ID_LoaiDiem { get; set; }//kn
       
        public float SoDiem { get; set; }
        public bool IsDelete { get; set; }
        public LoaiDiem LoaiDiems { get; set; }
        public HocVien HocViens { get; set; }
        public MonHoc MonHocs { get; set; }
    }
}
