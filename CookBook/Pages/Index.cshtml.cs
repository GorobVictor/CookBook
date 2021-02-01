using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Context;
using Context.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookBook.Pages {
    public class IndexModel : PageModel {
        public Connection Connection { get; set; } = new Connection(Startup.Configuration["ConnectionStrings:Default"]);
        public void OnGet() {
        }
        public void OnPostSendComment(int reciptsId = -1, string comments = null, short rating = -1) {
            var user = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            if (comments == null && rating == -1 || user == null)
                return;
            Connection.Reviews.Add(new Reviews() {
                RevMessage = comments,
                RevRating = rating,
                ReciptsId = reciptsId,
                UserId = Connection.User.FirstOrDefault(x => x.UsLogin == user).Id,
                RevDate = DateTime.Now,
            });
            Connection.SaveChanges();
        }
    }
}
