using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ATTT
{
    [Serializable]
    public class UserLogin
    {
        public int userID { set; get; }
        public string Username { get; set; }
        public int roleID { set; get; }
        public bool? Follow { get; set; }
    }
}