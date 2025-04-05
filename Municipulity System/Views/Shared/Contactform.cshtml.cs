using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Municipulity2.Pages
{
    public class ContactModel : PageModel
    {public bool hasData = false;
        public string FirstName = "";
        public string LastName = "";
        public string Message = "";
  
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            hasData = true;
        FirstName = Request.Form ["FirtName"];
        LastName = Request.Form["LastName"];
            Message = Request.Form["Message"];

        }
    }
}
