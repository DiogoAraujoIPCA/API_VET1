using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    public class RacaController : Controller
    {

        //Criar Raca
        [HttpPost("Home/Raca/CriarRaca")]
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



            return Ok("Raca Adicionada com sucesso");
         }

        //Remover Raça
          [HttpDelete("Raca/ApagarRaca")]
         public IActionResult ApagarRaca(string nome, string Informacoes){

            foreach (Raca raca in ListaPessoas.racas)
            {

                if (raca.Nome == nome)
                {
                       ListaPessoas.racas.Remove(raca);
                       return Ok("Raca removida com sucesso");

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
         #endregion
     
         
    }
}