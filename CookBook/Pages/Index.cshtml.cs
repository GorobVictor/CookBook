using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookBook.Pages {
    public class IndexModel : PageModel {
        public Connection Connection { get; set; } = new Connection(Startup.Configuration["ConnectionStrings:Default"]);
        public void OnGet() {
        }
    }
}
