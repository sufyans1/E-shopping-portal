using E_shopping_portal.Models;
using E_shopping_portal.Repository;
using System;
using System.Web.Mvc;

namespace E_shopping_portal.Controllers
{
    public class EshoppingPortalController : Controller
    {
        // GET: EshoppingPortal
        public bool IsAdminLoggedIn()
        {
            if (Session["username"] != null)
            {
                return true;
            }
            else { return false; }
        }
        public ActionResult Index()
        {
            if (!IsAdminLoggedIn())
            {
                ViewBag.Title = "Home";
                return View();
            }
            else { return RedirectToAction("Index", "Admin"); }

        }

        // GET: About us 
        public ActionResult About()
        {
            if (!IsAdminLoggedIn())
            {
                ViewBag.Title = "About us";
                return View();
            }
            else { return RedirectToAction("Index", "Admin"); }
        }
        // GET: Contact us 
        public ActionResult Contact()
        {
            if (!IsAdminLoggedIn())
            {
                ViewBag.Title = "Contact us";
                return View();
            }
            else { return RedirectToAction("Index", "Admin"); }
        }

        [HttpPost]
        public ActionResult Contact(HomeContactUSModel model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("ThankYou");
            }


            ViewBag.Title = "Contact Us";
            return View(model);
        }

        // GET: /Contact/ThankYou
        public ActionResult ThankYou()
        {
            ViewBag.Title = "Thank You";
            return View();
        }


        // GET: EshoppingPortal/Details/5
        public ActionResult SigninUser()
        {

            if (!IsAdminLoggedIn())
            {
                ViewBag.Title = "Sign in";
                return View();
            }
            else { return RedirectToAction("Index", "Admin"); }
        }


        [HttpPost]
        public ActionResult SigninUser(HomeSiginModel signin)
        {
            E_shoppingPortalHomeRepository repository = new E_shoppingPortalHomeRepository();


            try
            {
                if (ModelState.IsValid)
                {
                    if (repository.SigninUser(signin) == 0)
                    {
                        ViewBag.Message = "user is customer";
                        return View();
                    }
                    else if (repository.SigninUser(signin) == 1)
                    {
                        ViewBag.Message = "user is admin";
                        Session["username"] = signin.Username;
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.Message = "user doesnt exist";
                        return View();
                    }
                }

                else
                {
                    ViewBag.Message = "Validation failed";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
            return View();
        }

        // GET: EshoppingPortal/Create
        public ActionResult SignupUser()
        {

            if (!IsAdminLoggedIn())
            {
                ViewBag.Title = "Sign up";
                return View();
            }
            else { return RedirectToAction("Index", "Admin"); }
        }

        /// POST: EshoppingPortal/Create
        [HttpPost]
        public ActionResult SignupUser(HomeSignupModel signup)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    E_shoppingPortalHomeRepository repository = new E_shoppingPortalHomeRepository();
                    if (repository.SignupUser(signup))
                    {
                        ViewBag.Message = "Sign up successful";
                    }
                    else
                    {
                        ViewBag.Message = "Sign up failed";
                    }

                }
                else
                {
                    ViewBag.Message = "Validation failed";
                }


            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

            }
            return View();
        }

        // GET: EshoppingPortal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EshoppingPortal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EshoppingPortal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EshoppingPortal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
