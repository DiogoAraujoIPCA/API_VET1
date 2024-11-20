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
				public IActionResult CriarRaca(string nome, string Informacoes)
				{
						if (HelperController.Helper.ObterRaca(nome) == null)
						{
								Raca NovaRaca = new Raca(nome, Informacoes);
								ListaPessoas.racas.Add(NovaRaca);

								string teste = JsonConvert.SerializeObject(NovaRaca);
								Console.WriteLine(teste);

								return View("~/Views/Raca/TabelaRacas.cshtml", ListaPessoas.racas);
						}

						return NotFound("Não foi possivel criar raça ");
				}

				//Remover Raça
				[HttpPost("Raca/ApagarRaca")]
				public IActionResult ApagarRaca(string nome, string Informacoes)
				{
					 if(HelperController.Helper.VerificarExistenciaRaca(nome))
					 {
					 			ListaPessoas.racas.Remove(HelperController.Helper.ObterRaca(nome));
										return View("~/Views/Raca/TabelaRacas.cshtml", ListaPessoas.racas);
					 }
					 
								
									return NotFound("Não foi possivel remover raça ");
						

				}

				//Atualizar Dados Raça
				#region AtualizarDadosRaca


				[HttpPost("Raca/AtualizarRaca")]
				public IActionResult AtualizarRaca(string nomeantigo, string novonome)
				{
					
					
					if(	HelperController.Helper.AtualizarDadosRaca(novonome,nomeantigo,"NomeRaca")){
								return Ok("Informacoes da  raca atualizada com sucesso");
					}
						
						
						return NotFound("Não foi possivel atualizar raça ");
				}

				//Atualizar Informacoes Raça
				[HttpPost("Raca/AtualizarInformacoesRaca")]
				public IActionResult AtualizarInformacoesRaca(string informacoes, string nomeraca)
				{
					if(	HelperController.Helper.AtualizarDadosRaca(informacoes,nomeraca,"Informacoes")){
								return Ok("Informacoes da  raca atualizada com sucesso");
					}
						
						return NotFound("Não foi possivel atualizar Informacoes da  raça ");
				}

				//Atualizar Informacoes Raça
				[HttpPost("Raca/AtualizarTodasInformacoesRaca")]
				public IActionResult AtualizarTodasInformacoesRaca(string nome, string informacoes)
				{
						foreach (Raca raca in ListaPessoas.racas)
						{
								if (raca.Nome == nome)
								{
										raca.Nome = nome;
										raca.Informacoes = informacoes;
										return View("~/Views/Raca/TabelaRacas.cshtml", ListaPessoas.racas);
								}
						}
						return NotFound("Não foi possivel atualizar raça ");
				}
				#endregion
		}
}
