using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public  class ThuHocPhiChiTiet
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Display(Name = "Lop Hoc")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("LopHocs")]
        public int ID_MaLop { get; set; }
        [Display(Name = "Hoc Vien")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("HocViens")]
        public int ID_MaHocVien { get; set; }
       
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("GiangViens")]
        public int ID_MaGiangVien { get; set; }
        public float SoTien { get; set; }
        public bool Status { get; set; }
        public DateTime PaymentDate { get; set; }
        public LopHoc LopHocs { get; set; }
        public HocVien HocViens { get; set; }
        public GiangVien GiangViens { get; set; }
    }
}
