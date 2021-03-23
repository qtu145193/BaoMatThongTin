using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;
using Models.ViewModel;
namespace Models.DAO
{
    public class UserDAO
    {
        //khoi tao dd context
        public atttContextDB db = null;

        public UserDAO()
        {
            db = new atttContextDB();
        }
        public IEnumerable<UserViewModel> ListAllPaging(int page, int pageSize)
        {
            var model = from a in db.Users
                        join b in db.Roles on
                        a.RoleID equals b.RoleID
                        where a.RoleID == b.RoleID
                        join c in db.Question1 on
                        a.IDQuestion1 equals c.IDQuestion1
                        where a.IDQuestion1 == c.IDQuestion1
                        select new UserViewModel()
                        {
                            IDCode = a.IDCode,
                            UserName = a.UserName,
                            UserPassword = a.UserPassword,
                            Role = b.RoleName,
                            Question1 = c.Question11,
                            Answer1 = a.Answer1
                        };

            return model.OrderBy(x=>x.IDCode).ToPagedList(page, pageSize);
        }
        //lay id cua user
        public User getByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        //kiem tra dang nhap
        public bool Login(string username, string password)
        {
            //kiem tra co username va pass trong db khong
            //neu co thi tra ve true
            var result = db.Users.SingleOrDefault(x => x.UserName == username && x.UserPassword == password);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
