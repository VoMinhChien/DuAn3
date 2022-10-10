using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class LichNghi
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten Ngay Nghi")]
        [Required(ErrorMessage = "Please enter data")]
        public string TenNgayNghi { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ly Do")]
        [Required(ErrorMessage = "Please enter data")]
        public string LyDo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayNghi { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayKetThuc { get; set; }
        public bool Isdelete { get; set; }

    }
}
