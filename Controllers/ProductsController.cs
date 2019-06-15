using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVC.Controllers
{
  public class ProductsController : Controller
  {

    ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      
      return View();
    }
  }
}



























































