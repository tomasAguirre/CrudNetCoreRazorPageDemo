using CrudNetCoreRazorPageDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudNetCoreRazorPageDemo.Pages
{
    public class EditCustomerModel : PageModel
    {
        DatabaseContext _Context;
        public EditCustomerModel(DatabaseContext databasecontext)
        {
            _Context = databasecontext;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public void OnGet(int? id) 
        {
            if (id is not null) 
            {
                var data = (from customer in this._Context.Customers
                            where customer.CustomerID == id
                            select customer).FirstOrDefault();
                Customer = data;
            }
        }

        public ActionResult OnPost() 
        {
            var customer = Customer;
            if (customer is not null) 
            {
                this._Context.Entry(customer).Property(x => x.Name).IsModified = true;
                this._Context.Entry(customer).Property(x => x.Address).IsModified = true;
                this._Context.Entry(customer).Property(x => x.Phoneno).IsModified = true;
                this._Context.Entry(customer).Property(x => x.City).IsModified = true;
                this._Context.Entry(customer).Property(x => x.Country).IsModified = true;
                this._Context.SaveChanges();
            }
            return RedirectToPage("AllCustomer");
        }
    }
}
