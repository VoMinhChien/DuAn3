using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class KhoaDaoTao
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ma Khoa Dao Tao")]
        [Required(ErrorMessage = "Please enter data")]
        public string MaKhoa { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten Khoa Dao Tao")]
        [Required(ErrorMessage = "Please enter data")]
        public string TenKhoa { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndTime { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<MonHoc> MonHocs { get; set; }
        public ICollection<LopHoc> LopHocs { get; set; }

    }
}
