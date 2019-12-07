using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WOAPI.WOContext;

namespace WOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : WOController
    {

        public StudentController(WOModel _wo) : base(_wo)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}