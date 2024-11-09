using Microsoft.AspNetCore.Mvc;

namespace managementorder.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CustomerOrders()
        {
            return PartialView("_CustomerOrders");
        }
        // Action that provides static data for DataTables
        [HttpGet]
        public IActionResult GetCustomerOrdersData()
        {
            // Create a static list of data
            var customerOrders = new List<object>
            {
                new { first_name = "John", last_name = "Doe", position = "Manager", office = "New York", salary = "$120,000" },
                new { first_name = "Jane", last_name = "Smith", position = "Developer", office = "San Francisco", salary = "$105,000" },
                new { first_name = "Bill", last_name = "Johnson", position = "Designer", office = "Los Angeles", salary = "$95,000" },
                new { first_name = "Sara", last_name = "Williams", position = "Analyst", office = "Chicago", salary = "$88,000" },
                new { first_name = "James", last_name = "Brown", position = "Support", office = "Houston", salary = "$75,000" }
            };

            // Return the data in the format that DataTables expects
            return Json(new { data = customerOrders });
        }
    }
}
