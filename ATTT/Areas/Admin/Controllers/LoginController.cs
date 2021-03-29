using ATTT.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using ATTT.Common;

namespace ATTT.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //tao bien truy cap db context
                //kiem tra username va password
                var dao = new UserDAO();
                var result = dao.Login(model.userName, MaHoaMD5.MD5Hash(model.passWord));
                //neu ket qua dung thi chuyen qua trang home
                //neu ket qua sai thi cho dang nhap lai
                if(result == true)
                {
                    var user = dao.getByID(model.userName);
                    //neu tai khoan la cua admin thi cho vao
                    if (user.RoleID == 1)
                    {
                        var usersession = new UserLogin();
                        usersession.Username = user.UserName;
                        usersession.userID = user.IDCode;
                        usersession.roleID = user.RoleID;
                        Session.Add(CommonConstant.USER_SESSION, usersession);
                        return RedirectToAction("Home", "Home", user);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Không có quyền truy cập trang này");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            return View("Index");
        }
    }
}