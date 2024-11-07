using Microsoft.AspNetCore.Mvc;

namespace managementorder.Controllers
{
    public class ProductController : Controller
    {

        private Uri BaseAddress;
        private IConfiguration _configuration;

        public ProductController(IConfiguration configuration) {
            _configuration = configuration;
            BaseAddress = new Uri(_configuration.GetValue<string>("ApiParam:url"));
        }
        public IActionResult Index()
        {
          
            return View();
        }
    }
}
