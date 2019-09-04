using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace jwt_authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanResourcesController : ControllerBase
    {
        // GET api/humanresources
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1 from HR", "value2 from HR" };
        }
    }
}