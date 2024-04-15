using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using kortlagnin_vefur.Services;
using kortlagnin_vefur.Models;

namespace kortlagnin_vefur.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileProductService Produuctservice;
        public IEnumerable<Product> Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;

            Produuctservice = productService;
        }

        public void OnGet()
        {
            Products = Produuctservice.GetProducts();
        }
    }
}