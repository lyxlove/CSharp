using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo01.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Show()
        {
            return Content("Hello");
        }
    }
}
