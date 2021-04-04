using ATTT.Common;
using Models.DAO;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATTT.Controllers
{
    public class WeaponController : BaseController
    {
        // GET: Weapon
        public ActionResult ListWeapon()
        {
            var productDao = new ProductDAO();
            ViewBag.ListProduct = productDao.listProduct();
            return View();
        }
        public ActionResult Detail(int id)
        {
            var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
            var product = new ProductDAO().ViewDetail(id);
            var userDao = new UserDAO();
            userDao.SelectHistory(sess.userID);
            return View(product);
        }
        public ActionResult ChangeDetail(int id)
        {
            var product = new ProductDAO().ViewDetail(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult ChangeDetail(WeaponViewModel model)
        {
            if (ModelState.IsValid)
            {                
                var dao = new ProductDAO();
                var result = dao.UpdateProduct(model);
                if (result)
                {
                    var userDao = new UserDAO();
                    var sess = (UserLogin)Session[CommonConstant.USER_SESSION];
                    userDao.UpdateHistory(sess.userID);
                    return RedirectToAction("ListWeapon");
                }
                else
                {
                    ModelState.AddModelError("", "Thay đổi không thành công");
                }
            }            
            return View(model);
        }
    }
}