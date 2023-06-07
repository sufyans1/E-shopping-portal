using E_shopping_portal.Models;
using E_shopping_portal.Repository;
using System.Web.Mvc;

namespace E_shopping_portal.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //GET Add new admin
        public ActionResult AddNewAdmin()
        {
            return View();
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
            AdminRepository adminrepository = new AdminRepository();
            ModelState.Clear();
            return View(adminrepository.ViewUserList());

        }
    }

}