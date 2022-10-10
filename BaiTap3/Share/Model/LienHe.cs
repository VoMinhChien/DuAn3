using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class LienHe
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ho Ten")]
        [Required(ErrorMessage = "Please enter data")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Please enter data")]
        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Invalid phone number.")]
        [Display(Name = "PhoneNumber")]
        public int SDT { get; set; }
      
        [Display(Name = "Tin Nhan")]
        [Required(ErrorMessage = "Please enter data")]
        public string TinNhan { get; set; }
        public bool IsDelete { get; set; }

    }
}
