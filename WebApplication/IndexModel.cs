namespace WebApplication
{
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class IndexModel : PageModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
