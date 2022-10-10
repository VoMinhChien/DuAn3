using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model
{
    public class Role_QUyen
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("Roles")]
        public int ID_Role { get; set; }
        [Required(ErrorMessage = "Please enter data")]
        [ForeignKey("Quyens")]
        public int ID_Quyen { get; set; }
        public Roles Roles { get; set; }
        public Quyen Quyens { get; set; }
    }
}
