using E_shopping_portal.Models;
using E_shopping_portal.Repository;
using System;
using System.Web.Mvc;

namespace E_shopping_portal.Controllers
{
    public class EshoppingPortalController : Controller
    {
        // GET: EshoppingPortal
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();

        }

        // GET: About us 
        public ActionResult About()
        {
            ViewBag.Title = "About us";
            return View();
        }
        // GET: Contact us 
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact us";
            return View();
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

            return View();
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
                        return View();
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

            return View();
        }

        // POST: EshoppingPortal/Create
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
                        return View();
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

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
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
