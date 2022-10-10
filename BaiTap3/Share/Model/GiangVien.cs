using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class GiangVien
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ma So Thue")]
        [Required(ErrorMessage = "Please enter data")]
        
        public string MasoThue { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ho")]
        [Required(ErrorMessage = "Please enter data")]
        public string Ho { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten Dem va Tena")]
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
        public string SDT { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Dia Chi")]
        [Required(ErrorMessage = "Please enter data")]
       
        public string DiaChi { get; set; }
       
        [Display(Name = "Mon Day Chinh")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("MonHocs")]
        public int DayMonChinh { get; set; }//KN
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Hinh Anh")]
        [Required(ErrorMessage = "Please enter data")]

        public string HinhAnh { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Mat Khau")]
        [Required(ErrorMessage = "Please enter data")]
        public string MatKhau { get; set; }
        public string OTP { get; set; }
        public bool Isdelete { get; set; }
        [ForeignKey("Roles")]
        public int role { get; set; }
        public Roles Roles { get; set; }
        public MonHoc MonHocs { get; set; }
        public ICollection<LichDay> LichDays { get; set; }
        public ICollection<Luong> Luongs { get; set; }
        public ICollection<ThuHocPhiChiTiet> ThuHocPhiChiTiets { get; set; }
    }
}
