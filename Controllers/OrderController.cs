using Microsoft.AspNetCore.Mvc;

namespace managementorder.Controllers
{
    public class OrderController : Controller
    {
        
        public IActionResult Index()
        {
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
