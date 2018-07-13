using Microsoft.AspNetCore.Mvc;
using Keepr.Repositories;
using Keepr.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{
public class HomeController: Controller
{
    [Route("home/index")]
    public ActionResult Index()
    {
        ViewBag.Message = "message for home controller";
        return View();
    }
}
}