using Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase {
        Connection Connection { get; set; } = new Connection(Startup.Configuration["ConnectionStrings:Default"]);
        [HttpGet]
        [Route("GetRecipts")]
        public IActionResult GetRecipts(int id = -1) {
            if (id == -1)
                return Ok(Connection.Recipts.ToList());
            else {
                var result = Connection.Recipts.FirstOrDefault(x => x.Id == id);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound();
            }
        }
    }
}
