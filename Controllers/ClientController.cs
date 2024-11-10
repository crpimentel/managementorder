using AutoMapper;
using managementorder.Helper;
using managementorder.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

namespace managementorder.Controllers
{
    public class ClientController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        // Inject HttpClient through the constructor
        public ClientController(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMapper mapper)
        {
            _httpClient = httpClientFactory.CreateClient("ProductApi");
            _configuration = configuration;
            _mapper = mapper;
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
        public IActionResult GetCustomerOrdersData(int draw, string searchValue, [FromQuery] int start, [FromQuery] int length)
        {
            List<ClientViewModel> clientList = new List<ClientViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_configuration.GetValue<string>("ApiParam:serviceclientorder")).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                clientList = JsonConvert.DeserializeObject<List<ClientViewModel>>(data);
            }
            //Step 1: Retrieve all data from the database(for simplicity, using an in-memory list here)
            // Using AutoMapper to map from client list  to customer order list  
            var customerOrders = _mapper.Map<List<CustomerOrder>>(clientList); 
            //var customerOrders = new List<CustomerOrder>
            //    {
            //        new CustomerOrder{ DT_RowId = "row_5",  name= "Airi", email= "Satou", orderDate = "2024-09-11T00:00:00", productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf"},
            //        new CustomerOrder{ DT_RowId = "row_4", name= "Cedric", email= "Kelly",orderDate = "2024-09-11T00:00:00", productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_6", name= "Cedric", email= "Kelly",orderDate = "2024-09-11T00:00:00", productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_7", name= "Cedric", email= "Kelly",orderDate = "2024-09-11T00:00:00", productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_8", name= "Cedric", email= "Kelly",orderDate = "2024-09-11T00:00:00", productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_9", name= "Cedric", email= "Kelly",orderDate = "2024-09-11T00:00:00", productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_10", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_11", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_12", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_13", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_14", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_15", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_16", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_17", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_18", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_19", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_20", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_21", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_22", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_23", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_24", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_25", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_26", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },
            //        new CustomerOrder{ DT_RowId = "row_27", name= "Cedric", email= "Kelly", orderDate = "2024-09-11T00:00:00",productName="prada",productPrice="60",productStock = "50",productDesc ="asdfasfdasf" },

            //    };

            // Step 2: Filter data based on the search value if provided
            if (!string.IsNullOrEmpty(searchValue))
            {
                customerOrders = customerOrders
                    .Where(c => c.name.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                c.email.Contains(searchValue, StringComparison.OrdinalIgnoreCase)||
                                c.productName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            }
            // Step 3: Store the count of filtered records (for DataTables' `recordsFiltered`)
            var counttotal = customerOrders.Count();
            // Step 4: Apply pagination to the filtered data
            var pagedData = customerOrders.Skip(start).Take(length).ToList();
            // Return the DataTables response in the expected format
            var result = new
            {
                draw = draw,
                recordsTotal = counttotal,  // Total number of records available (unfiltered)
                recordsFiltered = customerOrders.Count,  // Number of records after filtering by search
                data = pagedData  // The filtered data
            };
            var lookJson=Json(result);
            return Json(result);
        }
    }
}
