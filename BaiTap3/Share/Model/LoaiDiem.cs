using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class LoaiDiem
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten Loai Diem")]
        [Required(ErrorMessage = "Please enter data")]
        public string TenLoaiDiem { get; set; }
        public int HeSo { get; set; }
        public ICollection<Diem> Diems { get; set; }

    }
}
