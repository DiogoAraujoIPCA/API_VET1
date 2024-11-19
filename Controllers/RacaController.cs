using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyWebApi.Controllers
{
    public class RacaController : Controller
    {

        //Criar Raca
        [HttpPost("Raca/CriarRaca")]
         public IActionResult CriarRaca(string nome, string Informacoes){


          
            foreach (Raca raca in ListaPessoas.racas)
            {

                if (raca.Nome == nome)
                {
                       return NotFound("Raça já existente");
                       

                }
            }
            Raca NovaRaca = new Raca(nome,Informacoes);
            ListaPessoas.racas.Add(NovaRaca);

            string teste = JsonConvert.SerializeObject(NovaRaca);
            Console.WriteLine(teste);



           return View("~/Views/Raca/TabelaRacas.cshtml",ListaPessoas.racas);
         }

        //Remover Raça
          [HttpPost("Raca/ApagarRaca")]
         public IActionResult ApagarRaca(string nome, string Informacoes){


            Console.Write(nome);
            foreach (Raca raca in ListaPessoas.racas)
            {

                if (raca.Nome == nome)
                {
                       ListaPessoas.racas.Remove(raca);
                             return View("~/Views/Raca/TabelaRacas.cshtml",ListaPessoas.racas);

                }
            }

              return NotFound("Não foi possivel remover raça ");
         
         }

         //Atualizar Dados Raça
         #region AtualizarDadosRaca


               [HttpPost("Raca/AtualizarRaca")]
         public IActionResult AtualizarRaca(string nomeantigo, string novonome){

            foreach (Raca raca in ListaPessoas.racas)
            {

                if (raca.Nome == nomeantigo)
                {
                       raca.Nome=novonome;
                       return Ok("Nome raca atualizada com sucesso");

                }
            }
              return NotFound("Não foi possivel atualizar raça ");
         
         }

         //Atualizar Informacoes Raça
        [HttpPost("Raca/AtualizarInformacoesRaca")]
         public IActionResult AtualizarInformacoesRaca(string nomeantigo, string novonome){

            foreach (Raca raca in ListaPessoas.racas)
            {

                if (raca.Nome == nomeantigo)
                {
                       raca.Nome=novonome;
                       return Ok("Nome raca atualizada com sucesso");

                }
            }
              return NotFound("Não foi possivel atualizar raça ");
         
         }

          //Atualizar Informacoes Raça
        [HttpPost("Raca/AtualizarTodasInformacoesRaca")]
         public IActionResult AtualizarTodasInformacoesRaca(string nome ,string informacoes){

            foreach (Raca raca in ListaPessoas.racas)
            {

                if (raca.Nome == nome)
                {
                       raca.Nome=nome;
                       raca.Informacoes=informacoes;
                         return View("~/Views/Raca/TabelaRacas.cshtml",ListaPessoas.racas);

                     

                }
            }
              return NotFound("Não foi possivel atualizar raça ");
         
         }
         #endregion
     
         
    }
}