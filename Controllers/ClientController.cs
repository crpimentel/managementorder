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
            // Step 2: Filter data based on the search value if provided
            if (!string.IsNullOrEmpty(searchValue))
            {
                customerOrders = customerOrders
                    .Where(c => c.name.Contains(searchValue, StringComparison.OrdinalIgnoreCase) ||
                                c.email.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
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
