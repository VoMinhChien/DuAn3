using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model.ViewModel
{
    public class UpDatePassWord
    {
        [Required]
        public int Id_User { get; set; }

        [Required]
        public string PasswordOld { get; set; }
        [Required]
        public string PasswordNew { get; set; }
    }
}
