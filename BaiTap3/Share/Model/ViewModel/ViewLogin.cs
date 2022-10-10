using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model.ViewModel
{
    public class ViewLogin
    {
       
        public string MaDangNhap { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
