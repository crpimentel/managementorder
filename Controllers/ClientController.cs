using Microsoft.AspNetCore.Mvc;

namespace managementorder.Controllers
{
    public class ClientController : Controller
    {
        public class CustomerOrder
        {
            public string DT_RowId { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string position { get; set; }
            public string office { get; set; }
            public string start_date { get; set; }
            public string salary { get; set; }
        }
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
        public IActionResult GetCustomerOrdersData(int draw, string searchValue)
        {
            var dataList = new List<CustomerOrder>
                {
                    new CustomerOrder{ DT_RowId = "row_5", first_name = "Airi", last_name = "Satou", position = "Accountant", office = "Tokyo", start_date = "28th Nov 08", salary = "$162,700" },
                    new CustomerOrder{ DT_RowId = "row_25", first_name = "Angelica", last_name = "Ramos", position = "Chief Executive Officer (CEO)", office = "London", start_date = "9th Oct 09", salary = "$1,200,000" },
                    new CustomerOrder{ DT_RowId = "row_3", first_name = "Ashton", last_name = "Cox", position = "Junior Technical Author", office = "San Francisco", start_date = "12th Jan 09", salary = "$86,000" },
                    new CustomerOrder{ DT_RowId = "row_19", first_name = "Bradley", last_name = "Greer", position = "Software Engineer", office = "London", start_date = "13th Oct 12", salary = "$132,000" },
                    new CustomerOrder{ DT_RowId = "row_28", first_name = "Brenden", last_name = "Wagner", position = "Software Engineer", office = "San Francisco", start_date = "7th Jun 11", salary = "$206,850" },
                    new CustomerOrder{ DT_RowId = "row_6", first_name = "Brielle", last_name = "Williamson", position = "Integration Specialist", office = "New York", start_date = "2nd Dec 12", salary = "$372,000" },
                    new CustomerOrder{ DT_RowId = "row_43", first_name = "Bruno", last_name = "Nash", position = "Software Engineer", office = "London", start_date = "3rd May 11", salary = "$163,500" },
                    new CustomerOrder{ DT_RowId = "row_23", first_name = "Caesar", last_name = "Vance", position = "Pre-Sales Support", office = "New York", start_date = "12th Dec 11", salary = "$106,450" },
                    new CustomerOrder{ DT_RowId = "row_51", first_name = "Cara", last_name = "Stevens", position = "Sales Assistant", office = "New York", start_date = "6th Dec 11", salary = "$145,600" },
                    new CustomerOrder{ DT_RowId = "row_4", first_name = "Cedric", last_name = "Kelly", position = "Senior Javascript Developer", office = "Edinburgh", start_date = "29th Mar 12", salary = "$433,060" }
                };
            var counttotal = dataList.Count();
            // Apply the search filter if a search term is provided
            if (!string.IsNullOrEmpty(searchValue))
            {
                dataList = dataList
                    .Where(c => c.first_name.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                c.last_name.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                c.position.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                c.office.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                    .ToList();
              
            }
            // Return the DataTables response in the expected format
            var result = new
            {
                draw = draw,
                recordsTotal = counttotal,  // Total number of records available (unfiltered)
                recordsFiltered = dataList.Count,  // Number of records after filtering by search
                data = dataList  // The filtered data
            };
            return Json(result);
        }
    }
}
