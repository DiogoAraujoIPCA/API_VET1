using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    public class VeterinarioController : Controller
    {
        [HttpPost("Veterinario/CriarVeterinario")]
        public IActionResult CriarVeterinario(int id,int NumeroTelemovel)
        {

            foreach (Pessoa pessoa1 in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa1.NumeroTelemovel == NumeroTelemovel)
                {
                    Veterinario Vet1 = new Veterinario(id,pessoa1);

                    ListaPessoas.ListasVeterinario.Add(Vet1);
                    
                     return View("~/Views/Veterinario/TabelaVeterinario.cshtml",ListaPessoas.ListasVeterinario);
                }
            }
             return NotFound("Não foi possivel Criar Pessoa");

           
        }

        [HttpDelete("Veterinario/ApagarVeterinario")]
        public IActionResult ApagarVeterinario(int id,int NumeroTelemovel)
        {

            foreach (Pessoa pessoa1 in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa1.NumeroTelemovel == NumeroTelemovel)
                {
                    Veterinario Vet1 = new Veterinario(id,pessoa1);

                    ListaPessoas.ListasVeterinario.Remove(Vet1);

                    return Ok("Veterinario Removido com sucesso");
                }
            }
             return NotFound("Não foi possivel Remover Veterinario");  
        }
        
           [HttpPost("Veterinario/AtualizarVeterinario")]
        public IActionResult AtualizarVeterinario(int id,int NumeroTelemovel)
        {

            foreach (Pessoa pessoa1 in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa1.NumeroTelemovel == NumeroTelemovel)
                {
                    Veterinario Vet1 = new Veterinario(id,pessoa1);

                    Vet1._Pessoa=pessoa1;
                    return Ok(" Veterinario atualizado com sucesso");
                }
            }
             return NotFound("Não foi possivel Remover Veterinario");

           
        }


        [HttpPost("Veterinario/ObterDadosVeterinario")]
        public IActionResult ObterDadosVeterinario(int id)
        {

            foreach (Veterinario Vet1 in ListaPessoas.ListasVeterinario)
            {
                if (Vet1.ID_Veterinario == id)
                {
        
                    return Ok(Vet1);
                }
            }
             return NotFound("Não foi possivel obter dados veterinario");

           
        }



        
    }
}
