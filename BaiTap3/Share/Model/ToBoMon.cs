using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class ToBoMon
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Display(Name = "Ten To Bo Mon")]
        [Required(ErrorMessage = "Please enter data")]
        public string TenToBoMon { get; set; }
        public bool IsDelete { get; set; }
    }
}
