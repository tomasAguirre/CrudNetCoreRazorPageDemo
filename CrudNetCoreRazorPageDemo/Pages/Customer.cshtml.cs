using CrudNetCoreRazorPageDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudNetCoreRazorPageDemo.Pages
{
    public class CustomerModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }
        DatabaseContext _DBConext;

        public CustomerModel(DatabaseContext dBConext)
        {
            _DBConext = dBConext;
        }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            var customer = this.Customer;
            if (!ModelState.IsValid) 
            {
                return Page();
            }
            customer.CustomerID = 0;
            this._DBConext.Add(customer);
            this._DBConext.SaveChanges();
            return RedirectToPage("AllCustomer");
        }

    }
}
