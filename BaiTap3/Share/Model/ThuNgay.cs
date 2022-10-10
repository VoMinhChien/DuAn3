using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class ThuNgay
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Thứ")]
        [Required(ErrorMessage = "Please enter data")]
        public string ThuNgayCuThe { get; set; }
        public string IsDelete { get; set; }
        public ICollection<LichHoc> LichHocs { get; set; }
    }
}
