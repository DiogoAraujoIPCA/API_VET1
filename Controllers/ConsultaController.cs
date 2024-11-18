using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    public class ConsultaController : Controller
    {

        
        public  List<Pessoa> Pessoas = new List<Pessoa>();
        public  List<Consulta> consultas = new List<Consulta>();
        // Rota padrão: GET /Home
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Bem-vindo à Home!");
        }

        // Rota personalizada: GET /Home/teste
        [HttpPost("Home/Consulta/CriarConsulta")]
        public IActionResult CriarConsulta(string Descricaoconsulta ,DateTime DataInicio,DateTime DataFim,int numeroTelemovel,int NumeroChipAnimal , int ID_Veterinario){
            
            //Obter Pessoa

            //Obter Animal

            //Obter Veterinario

          //  Consulta consulta = new Consulta(Descricaoconsulta,DataInicio,DataFim,PessoaResponsavel,animal,VeterinarioResponsavel);


            return Content("Teste executado com sucesso!");
        }
    }
    
    
}