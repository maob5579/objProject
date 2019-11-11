using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MockWcfClient.Models;
using MockWcfClient.ViewModels;

namespace MockWcfClient.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            UserServiceClient usc = new UserServiceClient();
            ViewBag.listUsers = usc.GetAllUsers();
            return View();
        }

        [HttpGet]
        public ActionResult Create()

        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(UserViewModel uvm)

        {
            UserServiceClient usc = new UserServiceClient();
            usc.Create(uvm.User);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string userId)

        {
            UserServiceClient usc = new UserServiceClient();
            usc.Delete(usc.GetUserById(userId));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string userId)

        {
            UserServiceClient usc = new UserServiceClient();
            UserViewModel uvm = new UserViewModel();
            uvm.User = usc.GetUserById(userId);
            return View("Edit", uvm);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel uvm)

        {
            UserServiceClient usc = new UserServiceClient();
            usc.Edit(uvm.User);
            return RedirectToAction("Index");
        }

    }
}