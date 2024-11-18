using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyWebApi.Controllers
{
    public class PessoaController : Controller
    {
       
       

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

        #region Atualizações

        [HttpPut("Pessoa/AdicionarPessoa/AtualizarNomePessoa")]
        public IActionResult AtualizarNome(string nome, int numeroTelemovel)
        {
            bool estado = false;
            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == numeroTelemovel)
                {
                    estado = true;
                    pessoa.Nome = nome;
                }
            }
            if (estado)
            {
                return Ok("Atualizado com sucesso ");
            }
            else
            {
                return NotFound("Não foi possivel atualizar  ");
            }
        }

        [HttpPut("Pessoa/AdicionarPessoa/AtualizarMorada")]
        public IActionResult AtualizarMorada(string morada, int numeroTelemovel)
        {
            bool estado = false;
            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == numeroTelemovel)
                {
                    estado = true;
                    pessoa.Morada = morada;
                }
            }
            if (estado)
            {
                return Ok("Atualizado com sucesso ");
            }
            else
            {
                return NotFound("Não foi possivel atualizar  ");
            }
        }

        [HttpPut("Pessoa/AdicionarPessoa/AtualizarNumeroTelemovel")]
        public IActionResult AtualizarNumeroTelemovel(
            int numerotelemovelNovo,
            int numeroTelemovelAntigo
        )
        {
            bool estado = false;
            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == numeroTelemovelAntigo)
                {
                    estado = true;
                    pessoa.NumeroTelemovel = numerotelemovelNovo;
                }
            }
            if (estado)
            {
                return Ok("Atualizado com sucesso ");
            }
            else
            {
                return NotFound("Não foi possivel atualizar  ");
            }
        }

        #endregion

        #region Criar

        [HttpPost("Pessoa/AdicionarPessoa")]
        public IActionResult AdicionarPessoa(string nome, string morada, int NumeroTelemovel)
        {

            Console.Write(nome, morada ,NumeroTelemovel );
            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == NumeroTelemovel)
                {
                    return NotFound("Pessoa já existente");
                }
            }

            Pessoa pessoa1 = new Pessoa(nome, morada, NumeroTelemovel);
            ListaPessoas.Lista_Pessoas.Add(pessoa1);
            return Ok("Pessoa Adicionada");
        }

        [HttpPost("Pessoa/AdicionarAnimal")]
        public IActionResult AdicionarAnimal(int numerochip)
        {
            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
               
                foreach (Animal animal in ListaPessoas.ListaAnimais)
                {
                    if (animal.NumeroChip == numerochip)
                    {
                        pessoa.Animais.Add(animal);

                        return Ok("Animal adicionado");
                    }
                }
            }
            return NotFound("Não foi possivel adicionar animal");
        }

        #endregion

        #region Procurar
        [HttpGet("Pessoa/ProcurarPessoa")]
        public IActionResult ProcurarPessoa(int NumeroTelemovel)
        {
            // Lista para armazenar o resultado da pesquisa
            List<Pessoa> ResultadoPesquisa = new List<Pessoa>();

            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == NumeroTelemovel)
                {
                    ResultadoPesquisa.Add(pessoa);
                }
            }

            if (ResultadoPesquisa.Count > 0)
            {
                var respostaComTitulo = new
                {
                    Titulo = "Informações da Pessoa",
                    Dados = ResultadoPesquisa,
                };
                return Ok(respostaComTitulo);
            }
            else
            {
                return NotFound("Nenhuma pessoa encontrada com o número de telemóvel fornecido.");
            }
        }

        [HttpGet("Pessoa/ProcurarAnimaisPessoa")]
        public IActionResult ProcurarAnimaisPessoa(int NumeroTelemovel)
        {
            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == NumeroTelemovel)
                {
                    string jsonString = JsonConvert.SerializeObject(pessoa.Animais);

                    var respostaComTitulo = new { Titulo = "ListaAnimais", Dados = jsonString };

                    return Ok(respostaComTitulo);
                }
            }

            return NotFound("Nenhuma pessoa encontrada com o número de telemóvel fornecido.");
        }

        [HttpGet("Pessoa/ProcurarNomePessoa")]
        public IActionResult ProcurarNomePessoa(int NumeroTelemovel)
        {
            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == NumeroTelemovel)
                {
                    string jsonString = JsonConvert.SerializeObject(pessoa.Nome);
                    return Ok(jsonString);
                }
            }

            return NotFound("Nenhuma pessoa encontrada com o número de telemóvel fornecido.");
        }

        [HttpGet("Pessoa/ProcurarMoradaPessoa")]
        public IActionResult ProcurarMoradaPessoa(int NumeroTelemovel)
        {
            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == NumeroTelemovel)
                {
                    string jsonString = JsonConvert.SerializeObject(pessoa.Morada);
                    return Ok(jsonString);
                }
            }

            return NotFound("Nenhuma pessoa encontrada com o número de telemóvel fornecido.");
        }

        #endregion

        #region Apagar

        [HttpDelete("Pessoa/ApagarPessoa")]
        public IActionResult ApagarPessoa(int NumeroTelemovel)
        {
            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == NumeroTelemovel)
                {
                    ListaPessoas.Lista_Pessoas.Remove(pessoa);
                    return Ok("Pessoa Removida com sucesso");
                }
            }
              return NotFound("Não foi possivel remover a pessoa");
        }

         [HttpDelete("Pessoa/RemoverAnimal")]
        public IActionResult RemoverAnimal(int NumeroTelemovel , int numerochip)
        {
            foreach (var pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == NumeroTelemovel)
                {
                    foreach(Animal animal in pessoa.Animais){
                        if(animal.NumeroChip==numerochip){
                            pessoa.Animais.Remove(animal);
                            return Ok("Animal Removido com sucesso");
                        }

                    }
                   
                    
                }
            }
              return NotFound("Não foi possivel remover o animal");
        }
        #endregion
    }
}
