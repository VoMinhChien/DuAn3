using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Model.ViewModel
{
    public class ViewToken<T>
    {
        public string Token { get; set; }
        public T User { get; set; }
    }
}
