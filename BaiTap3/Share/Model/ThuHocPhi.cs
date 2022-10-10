using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class ThuHocPhi
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
       
        [Display(Name = "Lop Hoc")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("LopHocs")]
        public int MaLopHoc { get; set; } //kn
        public float MucThuPhi { get; set; }
        public float GiamGia { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = " Ghi Chu ")]
        [Required(ErrorMessage = "Please enter data")]
        public string GhiChu { get; set; }
        public bool Isdelete { get; set; }
        public LopHoc LopHocs { get; set; }
        
    }
}
