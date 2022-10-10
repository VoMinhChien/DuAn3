using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class Roles
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten Role")]
        [Required(ErrorMessage = "Please enter data")]
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<HocVien> HocViens { get; set; }
        public ICollection<GiangVien> GiangViens { get; set; }
        public ICollection<NguoiDung> NguoiDungs { get; set; }
        public ICollection<Role_QUyen> Role_QUyens { get; set; }
    }
}
