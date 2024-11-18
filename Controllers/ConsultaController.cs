using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    public class Dados
    {
        public Pessoa Pessoa { get; set; }
        public Animal Animal { get; set; }

        public Veterinario Veterinario { get; set; }
    }

    public class ConsultaController : Controller
    {
        public List<Pessoa> Pessoas = new List<Pessoa>();
        public List<Consulta> consultas = new List<Consulta>();

        // Rota padrão: GET /Home
        [HttpGet]
        public IActionResult Index()
        {
            return Content("Bem-vindo à Home!");
        }

        #region CriarConsulta

       
        [HttpPost("Home/Consulta/CriarConsulta")]
        public IActionResult CriarConsulta(
            int IDMarcação,
            string Descricaoconsulta,
            DateTime DataInicio,
            DateTime DataFim,
            int numeroTelemovel,
            int NumeroChipAnimal,
            int ID_Veterinario
        )
        {
            Pessoa Responsavel = null;
            Animal animal = null;
            Veterinario _VeterinarioResponsavel = null;

            // Obter Pessoa
            foreach (Pessoa pessoa in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa.NumeroTelemovel == numeroTelemovel)
                {
                    Responsavel = pessoa;
                    break; // Sai do loop assim que encontra a pessoa
                }
            }

            // Verifica se a pessoa foi encontrada
            if (Responsavel == null)
            {
                return NotFound("Pessoa não encontrada.");
            }

            // Obter Animal
            foreach (var animal1 in ListaPessoas.ListaAnimais)
            {
                if (animal1.NumeroChip == NumeroChipAnimal)
                {
                    animal = animal1;
                    break;
                }
            }

            // Verifica se o animal foi encontrado
            if (animal == null)
            {
                return NotFound("Animal não encontrado.");
            }

            // Obter Animal
            foreach (var Veterinario in ListaPessoas.ListasVeterinario)
            {
                if (Veterinario.ID_Veterinario == ID_Veterinario)
                {
                    _VeterinarioResponsavel = Veterinario;
                    break;
                }
            }

            // Verifica se o animal foi encontrado
            if (animal == null)
            {
                return NotFound("Animal não encontrado.");
            }

            // Criar a consulta
            Consulta consulta = new Consulta(
                IDMarcação,
                Descricaoconsulta,
                DataInicio,
                DataFim,
                Responsavel,
                animal,
                _VeterinarioResponsavel
            );

            ListaPessoas.consultas.Add(consulta);

            return Content("Consulta Adicionada com sucesso com sucesso!");
        }
         #endregion
      

        #region ObterdadosConsulta
        // Obter Descrição
        [HttpGet("Home/Consulta/ObterTodosDadosDaConsulta")]
        public IActionResult ObterDadosConsulta(int id)
        {
            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    return Ok(consulta);
                }
            }

            return NotFound("Não foi possivel Obter dados consulta");
        }

        //Obter DataInicio

        // Obter Descrição
        [HttpGet("Home/Consulta/ObterDescrição")]
        public IActionResult ObterDescricaoConsulta(int id)
        {
            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    return Ok(consulta.DescricaoConsulta);
                }
            }

            return NotFound("Não foi possivel Obter descricao da  consulta");
        }

        //Obter Data Fim

        [HttpGet("Home/Consulta/ObterDataInicial")]
        public IActionResult ObterDataInicial(int id)
        {
            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    return Ok(consulta.DataInicial);
                }
            }

            return NotFound("Não foi possivel Obter data inicial ");
        }

        [HttpGet("Home/Consulta/ObterDataFinal")]
        public IActionResult ObterDataFinal(int id)
        {
            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    return Ok(consulta.DataFinal);
                }
            }

            return NotFound("Não foi possivel Obter Data Final ");
        }

        //Obter Responsavel

        [HttpGet("Home/Consulta/ObterResponsavel")]
        public IActionResult ObterResponsavel(int id)
        {
            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    return Ok(consulta.PessoaResponsavel);
                }
            }

            return NotFound("Não foi possivel obter responsavel ");
        }

        //Obter Veterinario

        [HttpGet("Home/Consulta/ObterVeterinario")]
        public IActionResult ObterVeterinario(int id)
        {
            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    return Ok(consulta.VeterinarioResponsavel);
                }
            }

            return NotFound("Não foi possivel obter veterinario ");
        }
        #endregion

        #region  AtualizarDadosConsulta

        //Atualizar Descrição

        [HttpPost("Home/Consulta/AtualizarDescricao")]
        public IActionResult AtualizarDescricao(int id, string Descricao)
        {
            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    consulta.DescricaoConsulta = Descricao;
                    return Ok("Descricao atualizada com sucesso");
                }
            }

            return NotFound("Não foi possivel atualizar descricao ");
        }

        //Atualizar Data Inicio

        [HttpPost("Home/Consulta/AtualizarDataInicio")]
        public IActionResult AtualizarDataInicio(int id, DateTime datainicio)
        {
            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    consulta.DataInicial = datainicio;
                    return Ok("Data Inicial atualizada com sucesso");
                }
            }

            return NotFound("Não foi possivel atualizar Data Inicial ");
        }

        //Atualizar Data Fim

        [HttpPost("Home/Consulta/AtualizarDataFinal")]
        public IActionResult AtualizarDataFinal(int id, DateTime datafinal)
        {
            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    consulta.DataFinal = datafinal;
                    return Ok("Data Final atualizada com sucesso");
                }
            }

            return NotFound("Não foi possivel atualizar Data Final ");
        }

        //Atualizar Responsavel -> Pelo Numero Telemovel

        [HttpPost("Home/Consulta/AtualizarResponsavel")]
        public IActionResult AtualizarResponsavel(int id, Pessoa Responsavel)
        {

            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    foreach (Pessoa pessoa in ListaPessoas.Lista_Pessoas)
                    {
                        if (pessoa.NumeroTelemovel == Responsavel.NumeroTelemovel)
                        {
                            consulta.PessoaResponsavel = pessoa;
                            return Ok("Data Final atualizada com sucesso");
                        }
                    }

                }


          
            }
                  return NotFound("Não foi possivel atualizar Data Final ");
        }

        //Atualizar Animal -> Pelo Numero Chip
         [HttpPost("Home/Consulta/AtualizarAnimal")]
        public IActionResult AtualizarAnimal(int id, int numerochip)
        {

            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    foreach (Animal animal in ListaPessoas.ListaAnimais)
                    {
                        if (animal.NumeroChip == numerochip)
                        {
                            consulta.AnimalConsulta = animal;
                            return Ok("Data Final atualizada com sucesso");
                        }
                    }

                }


          
            }
                  return NotFound("Não foi possivel atualizar Data Final ");
        }
        //Atualizar Veterinario -> Pelo ID

        // Por fazer 
         [HttpPost("Home/Consulta/AtualizarVeterinario")]
        public IActionResult AtualizarVeterinario(int id, int IdVetNew)
        {

            foreach (Consulta consulta in ListaPessoas.consultas)
            {
                if (consulta.id_Marcacao == id)
                {
                    foreach (Veterinario vet in ListaPessoas.ListasVeterinario)
                    {
                        if (vet.ID_Veterinario == id)
                        {
                            consulta.VeterinarioResponsavel = vet;
                            return Ok("Data Final atualizada com sucesso");
                        }
                    }

                }


          
            }
                  return NotFound("Não foi possivel atualizar Data Final ");
        }
        #endregion

        #region Apagar Consulta
        [HttpDelete("Home/Consulta/ApagarConsulta")]
        public IActionResult ApagarConsulta(int IDMarcação)
        {
            // Obter Animal
            foreach (Consulta consulta1 in ListaPessoas.consultas)
            {
                if (consulta1.id_Marcacao == IDMarcação)
                {
                    ListaPessoas.consultas.Remove(consulta1);
                    return Content("Consulta Adicionada com sucesso com sucesso!");
                }
            }
            return NotFound("Consulta Adicionada com sucesso com sucesso!");
        }
        #endregion
    }
}
