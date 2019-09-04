using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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