using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WOAPI.WOContext;

namespace WOAPI.Controllers
{
    public class WOController : Controller
    {
        protected WOModel wo = null;

        public WOController(WOModel _wo)
        {
            wo = _wo;

        }
    }
}