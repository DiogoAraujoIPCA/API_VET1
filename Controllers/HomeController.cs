using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    public class HomeController : Controller
    {



        // Rota padrão: GET /Home
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }


        // Rota personalizada: GET /Home/teste
        [HttpGet("Home/teste")]
        public IActionResult Teste()
        {
            return Content("Teste executado com sucesso!");
        }

      
        
    }
}