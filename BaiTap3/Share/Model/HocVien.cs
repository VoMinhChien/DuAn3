using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class HocVien
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ho")]
        [Required(ErrorMessage = "Please enter data")]
        public String Ho { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten Dem Va Ten")]
        [Required(ErrorMessage = "Please enter data")]
        public string TenDemVaTen { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgaySinh { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Gioi Tinh")]
        [Required(ErrorMessage = "Please enter data")]
        public string GioiTinh { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter data")]
        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Invalid phone number.")]
        [Display(Name = "PhoneNumber")]
        public string Sdt { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Dia Chi")]
        [Required(ErrorMessage = "Please enter data")]
        public string DiaChi { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Phu Huynh")]
        [Required(ErrorMessage = "Please enter data")]
        public string PhuHuynh { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Mat Khau")]
        
        public string MatKhau { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Hinh Dai Dien")]
        [Required(ErrorMessage = "Please enter data")]
        public string HinhDaiDien { get; set; }
        public string MaDangNhap { get; set; }
        public string OTP { get; set; }
        public bool IsDelete { get; set; }
        [ForeignKey("Roles")]
        public int role { get; set; }
        public Roles Roles { get; set; }
       public ICollection<Lop_HocVien> Lop_HocViens { get; set; }
        public ICollection<HocVien_Diem> HocVien_Diems { get; set; }
        public ICollection<ThuHocPhiChiTiet> ThuHocPhiChiTiets { get; set; }
    }
}
