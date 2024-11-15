using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyWebApi.Controllers
{
    public class PessoaController : Controller
    {
       public  List<Pessoa> teste = new List<Pessoa>();

        // Rota padrão: GET /Home
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Bem-vindo à Pessoa!");
        }

        // Rota personalizada: GET /Home/teste
        [HttpGet("Pessoa/teste")]
        public IActionResult Teste()
        {
            return Content("Teste executado com sucesso!");
        }

        [HttpPost("Pessoa/AdicionarPessoa")]
        public IActionResult AdicionarPessoa(string nome, string morada, int NumeroTelemovel)
        {
            var var1 = new Pessoa(nome, morada, NumeroTelemovel);
            var var2 = new Pessoa(nome, morada, 9100000);
            teste.Add(var2);
            teste.Add(var1);
            teste.Add(var1);
            teste.Add(var1);




            string jsonString = JsonConvert.SerializeObject(teste);
            Console.WriteLine(jsonString);

            var respostaComTitulo = new { Titulo = "Informações da Pessoa", Dados = teste };

            return Ok(respostaComTitulo);
        }
        [HttpGet("Pessoa/ProcurarPessoa")]
        public IActionResult ProcurarPessoa(int NumeroTelemovel)
        {
            // Lista para armazenar o resultado da pesquisa
            List<Pessoa> ResultadoPesquisa = new List<Pessoa>();


              List<Pessoa> teste = new List<Pessoa>
            {
                new Pessoa("João", "Lisboa", 912345678),
                new Pessoa("Maria", "Porto", 923456789),
                new Pessoa("Carlos", "Coimbra", 9100000)
            };
            
            // Iterando sobre a lista e adicionando pessoas que correspondem ao critério
            Console.WriteLine(teste.Count());
            foreach (var pessoa in teste)
            {

                
                if (pessoa.NumeroTelemovel == NumeroTelemovel)
                {
                    ResultadoPesquisa.Add(pessoa);
                    Console.WriteLine("foi adicionado");
                }
            }


               



            // Verificando se algum resultado foi encontrado
            Console.WriteLine(ResultadoPesquisa.Count);
            if (ResultadoPesquisa.Count > 0)
            {
                 var respostaComTitulo = new
                {
                    Titulo = "Informações da Pessoa",
                    Dados = ResultadoPesquisa
                };
                return Ok(respostaComTitulo);
            }
            else
            {
                return NotFound("Nenhuma pessoa encontrada com o número de telemóvel fornecido.");
            }







        }


    }
}
