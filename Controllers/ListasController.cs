using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    public static class ListaPessoas
    {
        public static List<Raca> racas = new List<Raca>();
        public static List<Pessoa> Lista_Pessoas = new List<Pessoa>();
        public static List<Consulta> consultas = new List<Consulta>();

        public static List<Veterinario> ListasVeterinario = new List<Veterinario>();

         public static List<Animal> ListaAnimais = new List<Animal>();  // Lista de Animais




        public static void AdicionarRaca(Raca raca)
        {
           ListaPessoas .racas.Add(raca);
        }

        public static void AdicionarPessoas(Pessoa pessoa)
        {
            ListaPessoas.Lista_Pessoas.Add(pessoa);
        }

        public static void AdicionarConsultas(Consulta consulta)
        {
            //.Add(consulta);
        }
       
    }
    public class ListasController:Controller{

      

       [HttpGet("Listas/ObterTodosAnimais")]
        public IActionResult ObterTodosAnimais()
        {
          return View("~/Views/Animal/TabelaAnimal.cshtml",ListaPessoas.ListaAnimais);
        }

        [HttpGet("Listas/ObterTodasPessoas")]
        public IActionResult ObterTodasPessoas()
        {
          return View("~/Views/Pessoa/TabelaPessoa.cshtml",ListaPessoas.Lista_Pessoas);
        }

        [HttpGet("Listas/ObterRacas")]
        public IActionResult ObterRacas()
        {
          return View("~/Views/Racas/TabelaRacas.cshtml",ListaPessoas.racas);
        }

        [HttpGet("Listas/ObterTodosVeterinarios")]
        public IActionResult ObterTodosVeterinarios()
        {
          return View("~/Views/Veterinario/TabelaVeterinario.cshtml",ListaPessoas.ListasVeterinario);
        }

      
    }
    

    
}
