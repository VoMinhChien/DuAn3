using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class LopHoc
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ma Lop")]
        [Required(ErrorMessage = "Please enter data")]
        public string MaLop { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten Lop")]
        [Required(ErrorMessage = "Please enter data")]
        public string TenLop { get; set; }
        
        [Display(Name = "Khoa Dao Tao")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("KhoaDaoTaos")]
        public int KhoaDaoTao { get; set; }//kn
        [Column(TypeName = "datetime")]
        public DateTime NgayKhaiGiang { get; set; }
        public int SoLuongHocVienDangCo { get; set; }
        public int SoLuongHocVienToiDa { get; set; }
        public bool TrangThai { get; set; }
        public float HocPhi { get; set; }
        public bool Isdelete { get; set; }
        public ICollection<ThuHocPhi> ThuHocPhis { get; set; }
        public ICollection<ThuHocPhiChiTiet> ThuHocPhiChiTiets { get; set; }
        public ICollection<LichDay> LichDays { get; set; }
        public ICollection<Lop_HocVien> Lop_HocViens { get; set; }
        public KhoaDaoTao KhoaDaoTaos { get; set; }
    }
}
