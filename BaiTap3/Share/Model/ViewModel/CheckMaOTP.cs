using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model.ViewModel
{
    public class CheckMaOTP
    {
        [Required]
        public string RS_Email { get; set; }
        [Required]
        public string RS_OTP { get; set; }
    }
}
