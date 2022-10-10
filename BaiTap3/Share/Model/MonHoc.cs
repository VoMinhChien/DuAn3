using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class MonHoc
    {
        [Key]
        [Column(TypeName = "int")]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ma Mon Hoc")]
        [Required(ErrorMessage = "Please enter data")]   
        public string MaMonHoc { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten Mon Hoc")]
        [Required(ErrorMessage = "Please enter data")]
        public string TenMonHoc { get; set; }
       
        [Display(Name = "Khoa Dao Tao")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("KhoaDaoTaos")]
        public int KhoaDaoTao { get; set; }//kn
        public bool IsDelete { get; set; }
        public KhoaDaoTao KhoaDaoTaos { get; set; }
        public ICollection<LichHoc> LichHocs { get; set; }
        public ICollection<LichDay> LichDays { get; set; }
        public ICollection<GiangVien> GiangViens { get; set; }

    }
}
