using ATTT.Common;
using ATTT.Models;
using Models.DAO;
using Models.Framework;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATTT.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //tao bien truy cap db context
                //kiem tra username va password
                var dao = new UserDAO();
                var result = dao.Login(model.Username,MaHoaMD5.MD5Hash(model.Password));
                //neu ket qua dung thi chuyen qua trang home
                //neu ket qua sai thi cho dang nhap lai
                if (result == true)
                {
                    var user = dao.getByID(model.Username);
                    var usersession = new UserLogin();
                    usersession.Username = user.UserName;
                    usersession.userID = user.IDCode;
                    usersession.roleID = user.RoleID;
                    Session.Add(CommonConstant.USER_SESSION, usersession);
                    dao.LoginHistory(usersession.userID);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            return View(model);
        }
        //controller dang ky user
        public ActionResult Register()
        {
            var dao = new UserDAO();
            RegisterViewModel model = new RegisterViewModel();
            model.Question1 = dao.getQuestion().Trim();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        { 
                var dao = new UserDAO();
                model.Question1 = dao.getQuestion().Trim();
            //neu name bi trung thi tra ve true 
            //bao cho nguoi dung la ten bi trung
            if (dao.CheckUserName(model.Username))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.Username;
                    user.UserPassword = MaHoaMD5.MD5Hash(model.Password);
                    user.Answer1 = model.Answer1;
                    user.RoleID = 2;
                    user.IDQuestion1 = 1;
                    var result = dao.InsertUser(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                } 
            return View(model);
        }
        public ActionResult UserDetail(int? id)
        {

            if (!id.Equals(null))
            {
                if (Session[CommonConstant.USER_SESSION] == null)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    var dao = new UserDAO();
                    return View(dao.ViewUser(id));
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserDetail(UserViewModel user) 
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                user.Password = MaHoaMD5.MD5Hash(user.Password);
                var result = dao.UpdateUserPass(user);
                if (result == true)
                {
                    dao.ChangeHistory(user.IDCode);
                    ViewBag.Success = "Thay đổi thành công";
                }
                else
                {
                   ModelState.AddModelError("", "Thay đổi không thành công");
                }
            }
            return View(user);

        }
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return RedirectToAction("Index","Home");
        }
    }
}