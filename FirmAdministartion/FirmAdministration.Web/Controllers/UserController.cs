using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirmAdministartion.Data.DataAccess;
using FirmAdministartion.Data.Identity;
using FirmAdministartion.Data.Services.Abstraction;
using FirmAdministration.Web.Models.ViewModels;

namespace FirmAdministration.Web.Controllers
{
    public class UserController : Controller
    {

        private IUserRepository<ApplicationUser> _repo;

        public UserController(IUserRepository<ApplicationUser> repo)
        {
            _repo = repo;

        }
        public ActionResult Index()
        {
            var users = _repo.GetAll();
            var viewModel = AutoMapper.Mapper.Map<List<UserViewModel>>(users);
            return View("Index","_AdminLayout",viewModel);
        }
    }
}