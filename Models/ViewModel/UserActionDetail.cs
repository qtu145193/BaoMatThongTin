using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class UserActionDetail
    {
        public int ID { get; set; }
        public int IDCode { get; set; }

        public int IDAction { get; set; }

        public DateTime? Time { get; set; }

        public string Action { get; set; }

        public string User { get; set; }
    }
}
