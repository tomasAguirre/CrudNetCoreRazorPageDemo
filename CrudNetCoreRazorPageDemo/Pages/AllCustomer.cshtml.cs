using CrudNetCoreRazorPageDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudNetCoreRazorPageDemo.Pages
{
    public class AllCustomerModel : PageModel
    {
        public List<Customer> CustomerList { get; set; }
        DatabaseContext _DBContext;

        public AllCustomerModel(DatabaseContext DBContext) 
        {
            this._DBContext = DBContext;
        }
        public void OnGet()
        {
            var data = (from Customer in _DBContext.Customers
                        select Customer).ToList();

            this.CustomerList = data;
        }

        public ActionResult OnGetDelete(int? id) 
        {
            if (id is not null) 
            {
                var data = (from customer in _DBContext.Customers
                            where customer.CustomerID == id
                            select customer).SingleOrDefault();

                this._DBContext.Customers.Remove(data);
                this._DBContext.SaveChanges();
            }
            return RedirectToPage("AllCustomer");
        }
    }
}
