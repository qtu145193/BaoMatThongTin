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
        public atttDBContext db = null;

        public UserDAO()
        {
            db = new atttDBContext();
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
                        where a.RoleID==2
                        select new UserViewModel()
                        {
                            IDCode = a.IDCode,
                            Username = a.UserName,
                            Password = a.UserPassword,
                            Role = b.RoleName,
                        };

            return model.OrderBy(x=>x.IDCode).ToPagedList(page, pageSize);
        }
        public IEnumerable<UserActionDetail> ListAction(int page, int pageSize)
        {
            var model = from a in db.ActionDetails
                        join b in db.Actions on
                        a.IDAction equals b.IDAction
                        where a.IDAction == b.IDAction
                        join c in db.Users on
                        a.IDCode equals c.IDCode
                        where a.IDCode == c.IDCode
                        select new UserActionDetail()
                        {
                            ID = a.IDAc,
                            IDCode = a.IDCode,
                            IDAction = b.IDAction,
                            User = c.UserName,
                            Action = b.ActionName,
                            Time = a.Time,
                        };
            return model.OrderByDescending(x => x.Time).ToPagedList(page, pageSize);
        }
        //lay id cua user
        public User getByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int? IDCode)
        {
            return db.Users.Find(IDCode);
        }
        public UserViewModel ViewUser(int? ID)
        {
            UserViewModel user = new UserViewModel();
            User user1 = db.Users.Find(ID);
            user.IDCode = user1.IDCode;
            user.Password = user1.UserPassword;
            user.Username = user1.UserName;
            return user;
        }
        //lay cau hoi bao mat
        public string getQuestion()
        {
            string q = db.Database.SqlQuery<string>("select Question1 as q from Question1").FirstOrDefault();
            return q;
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
        public int InsertUser(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.IDCode;
        }
        public bool UpdateUser(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.IDCode);
                user.UserName = entity.UserName.Trim();
                user.Answer1 = entity.Answer1.Trim();
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteUser(int? id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateUserPass(UserViewModel entity)
        {
            try
            {
                var user = db.Users.Find(entity.IDCode);
                user.UserName = entity.Username.TrimEnd();
                user.UserPassword = entity.Password.Trim();
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //kiem tra username khi dang ky co trung khong
        public bool CheckUserName(String name)
        {
            return db.Users.Count(x => x.UserName == name) > 0;
        }
        //cac hàm lưu lịch sử
        public void LoginHistory(int id)
        {
            ActionDetail userAction = new ActionDetail();
            userAction.IDCode = id;
            userAction.IDAction = 3;
            userAction.Time = DateTime.Now;
            db.ActionDetails.Add(userAction);
            db.SaveChanges();
        }
        public void ChangeHistory(int id)
        {
            ActionDetail userAction = new ActionDetail();
            userAction.IDCode = id;
            userAction.IDAction = 4;
            userAction.Time = DateTime.Now;
            db.ActionDetails.Add(userAction);
            db.SaveChanges();
        }
    }
}
