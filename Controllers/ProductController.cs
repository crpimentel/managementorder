using managementorder.Helper;
using managementorder.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;


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
                HttpResponseMessage response = _httpClient.GetAsync(_configuration.GetValue<string>("ApiParam:serviceprodurl")).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    productList = JsonConvert.DeserializeObject<List<ProductViewModel>>(data);
                }
                //comenta la llamada al api para hacer las pruebas mas rapidas ya que lo he probado
                //productList.Add(new ProductViewModel()
                //{
                //    Id = 1,
                //    Name = "Louis Vuitton",
                //    Description = "Louis Vuitton ha acumulado 130.727 menciones y mantiene su lugar entre las marcas más codiciadas. Su herencia atemporal, combinada con diseños modernos en bolsos y demás accesorios, la mantiene en lo más alto de la industria de la moda de lujo",
                //    Price = 200.00m,
                //    Stock = 100

                //});
                //productList.Add(new ProductViewModel()
                //{
                //    Id = 2,
                //    Name = "Prada",
                //    Description = "Prada está ganando popularidad entre los influencers gracias a su estilo vanguardista y diseños innovadores. La marca italiana destaca por su mezcla única de minimalismo y elegancia. Generó 129.596 menciones en las redes.",
                //    Price = 400.00m,
                //    Stock = 150

                //});
                //productList.Add(new ProductViewModel()
                //{
                //    Id = 3,
                //    Name = " Saint Laurent",
                //    Description = "Saint Laurent, sinónimo de elegancia y sofisticación, mantiene un sólido lugar en el top 10. Los influencers se sienten atraídos por sus diseños atrevidos, su sastrería impecable y su estética rock-chic. La mencionaron 100.088 veces en las redes sociales,",
                //    Price = 400.00m,
                //    Stock = 150

                //});
                var test=productList[0].ProductImages.ToList();
                ViewBag.ProductList = productList;
            }
            catch (Exception ex)
            {
                //Insert log
                Console.WriteLine("ERROR");
            }
           

            return View();
        }

        // Handle the form submission for creating a new product
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //return View(model);
                return BadRequest(ModelState);
            }

            try
            {
                using var content = new MultipartFormDataContent
                {
                    // Add form fields
                    { new StringContent(model.Name), "Name" },
                    { new StringContent(model.Description), "Description" },
                    { new StringContent(model.Price.ToString()), "Price" },
                    { new StringContent(model.Stock.ToString()), "Stock" }
                    };

                    // Add images to form content
                if (model.Images != null)
                {
                    foreach (var image in model.Images)
                    {
                        if (image.Length > 0)
                        {
                            using var ms = new MemoryStream();
                            await image.CopyToAsync(ms);
                            var fileBytes = ms.ToArray();
                            var fileContent = new ByteArrayContent(fileBytes);
                            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(image.ContentType);
                            content.Add(fileContent, "Images", image.FileName);
                        }
                    }
                }

                // Send the request
                var response = await _httpClient.PostAsync(_configuration.GetValue<string>("ApiParam:serviceprodcreateurl"), content);

                // Handle response
                if (response.IsSuccessStatusCode)
                {
                    //return RedirectToAction("Index", "Product"); 
                     return Ok("OK");
                }
                // Handle API errors
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = System.Text.Json.JsonSerializer.Deserialize<ApiResponse<object>>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                if (apiResponse != null && apiResponse.Errors.Any())
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                    return StatusCode(int.Parse(apiResponse.Code), string.Join("; ", apiResponse.Errors));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "A ocurrido un error mientras creamos el producto.");
                    return StatusCode(500, "Error mientras creamos el producto y no obtuvimos respuesta del api.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "A ocurrido un error con el  API: " + ex.Message });
               
            }
            //return View(model);
        }
    }
}
