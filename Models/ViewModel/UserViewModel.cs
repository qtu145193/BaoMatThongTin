using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class UserViewModel
    {
        public int IDCode { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Answer1 { get; set; }
        public string Question1 { get; set; }
        public string Role { get; set; }
    }
}
