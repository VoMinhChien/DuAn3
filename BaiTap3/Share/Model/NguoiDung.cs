using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class NguoiDung
    {
        [Key]
        [Column(TypeName = "int")]
        public int  Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten Nguoi Dung")]
        [Required(ErrorMessage = "Please enter data")]
        public string TenNguoiDung { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter data")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Hinh Anh")]
        [Required(ErrorMessage = "Please enter data")]
        public string HinhAnh { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Mat Khau")]
        [Required(ErrorMessage = "Please enter data")]
        public string MatKhau { get; set; }
        public string OTP { get; set; }
        [ForeignKey("Roles")]
        public int role { get; set; }
        public Roles Roles { get; set; }
        public ICollection<Role_QUyen> NguoiDung_QUyens { get; set; }

       

    }
}
