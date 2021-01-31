using Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase {
        Connection Connection { get; set; } = new Connection(Startup.Configuration["ConnectionStrings:Default"]);
        [HttpPost]
        [Route("GetRecipts")]
        public IActionResult GetRecipts(int id = -1) {
            if (id == -1)
                return Ok(Connection.Recipts
                    .Include(x => x.Ingredients)
                        .ThenInclude(ingredient => ingredient.Products)
                        .ThenInclude(unit => unit.Units)
                    .Include(x => x.Ingredients)
                    .ToList());
            else {
                var results = Connection.Recipts.Where(x => x.RecCategoryId == id)
                    .Include(x => x.Ingredients)
                        .ThenInclude(ingredient => ingredient.Products)
                        .ThenInclude(unit => unit.Units)
                    .Include(x => x.Ingredients)
                    .ToList();
                if (results.Count == 0)
                    return NotFound(results);
                return Ok(results);
            }
        }
    }
}
