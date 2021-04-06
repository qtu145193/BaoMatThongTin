using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Models.Framework;
using System.Net;
using Models.ViewModel;
using ATTT.Common;

namespace ATTT.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult ListUser(int page=1,int pageSize = 10)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        // GET: Admin/User
        public ActionResult ListAction()
        {
            var dao = new UserDAO();
            var model = dao.ListAction();
            return View(model);
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                //luu nguoi dung moi vao database
                var dao = new UserDAO();
                user.UserPassword = MaHoaMD5.MD5Hash(user.UserPassword);
                int id = dao.InsertUser(user);
                if (id > 0)
                {
                    return RedirectToAction("ListUser");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm người dùng không thành công");
            }
            return View("CreateUser");
        }
        public ActionResult EditUser(int? id)
        {
            User userEdit = new UserDAO().ViewDetail(id);
            return View(userEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(User user)
        {   
            var dao = new UserDAO();
            bool result = dao.UpdateUser(user);
            //luu nguoi dung moi vao database
            //neu update thanh cong thi result la true
            if (result)
                {
                    return RedirectToAction("ListUser");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật người dùng không thành công");
                }
            return View("EditUser");
        }
        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User userDele = new UserDAO().ViewDetail(id);
            if (userDele == null)
            {
                return HttpNotFound();
            }
            return View(userDele);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(int id)
        {
            var dao = new UserDAO();
            bool result = dao.DeleteUser(id);
            //neu delete thanh cong thi result la true
            if (result)
            {
                return RedirectToAction("ListUser");
            }
            else
            {
                ViewBag.ErrorMessage = "Xóa người dùng không thành công";
            }
            return View("DeleteUser");
        }
        public ActionResult Notify(int id)
        {
            var dao = new UserDAO();
            dao.ChangeFollow(id);
            return RedirectToAction("ListUser");
        }
    }
}