using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class CaHoc
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = " Ten Ca Hoc ")]
        [Required(ErrorMessage = "Please enter data")]
        public string TenCaHoc { get; set; }
        public TimeSpan TgianBatDau { get; set; }
        public TimeSpan TgianKetThuc { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<LichHoc> LichHocs { get; set; }
    }
}
