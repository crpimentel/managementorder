using AutoMapper;
using managementorder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace managementorder.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public OrderController(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMapper mapper)
        {
            _httpClient = httpClientFactory.CreateClient("ProductApi");
            _configuration = configuration;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            try
            {
                List<ClientViewModel> clientList = new List<ClientViewModel>();
                HttpResponseMessage response = _httpClient.GetAsync(_configuration.GetValue<string>("ApiParam:serviceclientclientlist")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    clientList = JsonConvert.DeserializeObject<List<ClientViewModel>>(data);

                }
                List<SupplierView> supplierList = new List<SupplierView>();
                HttpResponseMessage responsesupplier = _httpClient.GetAsync(_configuration.GetValue<string>("ApiParam:servicesupplierlist")).Result;
                if (responsesupplier.IsSuccessStatusCode)
                {
                    var data = responsesupplier.Content.ReadAsStringAsync().Result;
                    supplierList = JsonConvert.DeserializeObject<List<SupplierView>>(data);

                }
                List<ProductViewModelToClient> prodList = new List<ProductViewModelToClient>();
                HttpResponseMessage responseprod = _httpClient.GetAsync(_configuration.GetValue<string>("ApiParam:serviceprodList")).Result;
                if (responseprod.IsSuccessStatusCode)
                {
                    var data = responseprod.Content.ReadAsStringAsync().Result;
                    prodList = JsonConvert.DeserializeObject<List<ProductViewModelToClient>>(data);

                }
                ViewBag.Clients = new SelectList(clientList, "Id", "Name",null)
                     .Prepend(new SelectListItem { Value = "", Text = "Seleccione" });
                ViewBag.Suppliers = new SelectList(supplierList, "Id", "Name", null)
                    .Prepend(new SelectListItem { Value = "", Text = "Seleccione" });
                ViewBag.Products = prodList;
                                   

            }
            catch (Exception ex)
            {

                //guardar en log
            }
            return PartialView();
        }

        //[HttpPost]
        //public IActionResult CalculateTotals([FromBody] OrderCalculationRequest request)
        //{
        //    decimal subTotal = 0;
        //    decimal totalDiscount = 0;
        //    decimal itbisRate = 0.18m; // 18% ITBIS

        //    foreach (var product in request.Products)
        //    {
        //        var productInfo = _context.Products.FirstOrDefault(p => p.Id == product.ProductId);
        //        if (productInfo != null)
        //        {
        //            var productTotal = product.Quantity * productInfo.Price;
        //            var productDiscount = productTotal * (product.Discount / 100);

        //            subTotal += productTotal;
        //            totalDiscount += productDiscount;
        //        }
        //    }

        //    decimal itbis = subTotal * itbisRate;
        //    decimal total = subTotal - totalDiscount + itbis;

        //    return Json(new
        //    {
        //        subTotal = subTotal,
        //        totalDiscount = totalDiscount,
        //        itbis = itbis,
        //        total = total
        //    });
        //}

        public class OrderCalculationRequest
        {
            public List<ProductCalculationData> Products { get; set; }
        }

        public class ProductCalculationData
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal Discount { get; set; }
        }

    }
}
