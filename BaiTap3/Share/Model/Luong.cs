using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class Luong

    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        
        [Display(Name = "Nguoi Nhan Luong")]
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("giangViens")]
        public int ID_GiangVien { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayNhanLuong { get; set; }
        [Column(TypeName = "float")]
        public int TeacherSalary { get; set; }
        public float TienLuong { get; set; }
        public float TroCap { get; set; }
        public float TongTienNhan { get; set; }
        public string GhiChu { get; set; }
        public bool Status { get; set; }
        public GiangVien giangViens { get; set; }
    }
}
