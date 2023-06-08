using E_shopping_portal.Models;
using E_shopping_portal.Repository;
using System.Web.Mvc;

namespace E_shopping_portal.Controllers
{
    public class AdminController : Controller
    {
        public bool IsAdminLoggedIn()
        {
            if (Session["username"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }




        // GET: Admin
        public ActionResult Index()
        {
            if (IsAdminLoggedIn())
            {
                return View();
            }
            else { return RedirectToAction("SigninUser", "EshoppingPortal"); }
        }

        //GET Add new admin
        public ActionResult AddNewAdmin()
        {
            if (IsAdminLoggedIn())
            {
                return View();
            }
            else { return RedirectToAction("SigninUser", "EshoppingPortal"); }
        }
        public ActionResult AdminLogout()
        {

            Session["username"] = Session["username"] = null;
            return RedirectToAction("SigninUser", "EshoppingPortal");
        }

        [HttpPost]
        public ActionResult AddNewAdmin(AdminAddNewAdminModel model)
        {
            AdminRepository adminRepository = new AdminRepository();
            if (ModelState.IsValid)
            {
                if (adminRepository.AddNewAdmin(model))
                {
                    ViewBag.Message = "Added new admin";
                    return View();

                }
                else
                {
                    ViewBag.Message = "error";
                    return View();
                }
            }
            else
            {
                ViewBag.message = "please fill all valid fields";
                return View();
            }
        }
        //GET view use list
        public ActionResult ViewUserList()
        {
            if (IsAdminLoggedIn())
            {
                AdminRepository adminrepository = new AdminRepository();
                ModelState.Clear();

                return View(adminrepository.ViewUserList());
            }
            else
            { return RedirectToAction("SigninUser", "EshoppingPortal"); }

        }
        public ActionResult DeleteUser(int id)
        {
            if (IsAdminLoggedIn())
            {

                AdminRepository adminrepository = new AdminRepository();
                if (adminrepository.DeleteUser(id))
                {
                    ViewBag.message = "Deleted succesfully";
                    return RedirectToAction("ViewUserList", "Admin");
                }
                else
                {
                    ViewBag.message = "Couldnt delete row";
                    return RedirectToAction("ViewUserList", "Admin");
                }
            }
            else { return RedirectToAction("SigninUser", "Eshoppingportal"); }

        }
        public ActionResult ContactUsMessages()
        {

            if (IsAdminLoggedIn())
            {
                AdminRepository adminrepository = new AdminRepository();
                ModelState.Clear();
                return View(adminrepository.ContactUsMessages());
            }
            else { return RedirectToAction("SigninUser", "EshoppingPortal"); }
        }
    }

}