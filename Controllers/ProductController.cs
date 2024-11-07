using managementorder.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace managementorder.Controllers
{
    public class ProductController : Controller
    {

        
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        // Inject HttpClient through the constructor
        public ProductController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient("ProductApi");
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                List<ProductViewModel> productList = new List<ProductViewModel>();
                //HttpResponseMessage response = _httpClient.GetAsync(_configuration.GetValue<string>("ApiParam:serviceprodurl")).Result; // relative endpoint for products
                //if (response.IsSuccessStatusCode)
                //{
                //    var data = response.Content.ReadAsStringAsync().Result;
                //    productList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
                //} comenta la llamada al api para hacer las pruebas mas rapidas ya que lo he probado
                productList.Add(new ProductViewModel()
                {
                    Id = 1,
                    Name = "Louis Vuitton",
                    Description = "Louis Vuitton ha acumulado 130.727 menciones y mantiene su lugar entre las marcas más codiciadas. Su herencia atemporal, combinada con diseños modernos en bolsos y demás accesorios, la mantiene en lo más alto de la industria de la moda de lujo",
                    Price = 200.00m,
                    Stock = 100

                });
                productList.Add(new ProductViewModel()
                {
                    Id = 2,
                    Name = "Prada",
                    Description = "Prada está ganando popularidad entre los influencers gracias a su estilo vanguardista y diseños innovadores. La marca italiana destaca por su mezcla única de minimalismo y elegancia. Generó 129.596 menciones en las redes.",
                    Price = 400.00m,
                    Stock = 150

                });
                productList.Add(new ProductViewModel()
                {
                    Id = 3,
                    Name = " Saint Laurent",
                    Description = "Saint Laurent, sinónimo de elegancia y sofisticación, mantiene un sólido lugar en el top 10. Los influencers se sienten atraídos por sus diseños atrevidos, su sastrería impecable y su estética rock-chic. La mencionaron 100.088 veces en las redes sociales,",
                    Price = 400.00m,
                    Stock = 150

                });
                ViewBag.ProductList = productList;
            }
            catch (Exception ex)
            {
                //Insert log
                Console.WriteLine("ERROR");
            }
           

            return View();
        }
    }
}
