using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    public class AnimalController : Controller
    {
        // Adicionar Animal
        [HttpPost("Animal/CriarAnimal")]
        public IActionResult CriarAnimal(
            int NumeroChip,
            string NomeAnimal,
            string nomeraca,
            int NumeroTelemovel
        )
        {
            if (
                HelperController.Helper.VerificarExistenciaPessoa(NumeroTelemovel) == true
                && HelperController.Helper.VerificarExistenciaRaca(nomeraca)
            )
            {
                //Instância o Objeto e Adiciona á Lista
                if (
                    HelperController.Helper.ObterRaca(nomeraca) != null
                    && HelperController.Helper.ObterPessoa(NumeroTelemovel) != null
                )
                {
                    Animal animal = new Animal(
                        NumeroChip,
                        NomeAnimal,
                        HelperController.Helper.ObterRaca(nomeraca),
                        HelperController.Helper.ObterPessoa(NumeroTelemovel)
                    );
                    ListaPessoas.ListaAnimais.Add(animal);

                    return View("~/Views/Animal/TabelaAnimal.cshtml", ListaPessoas.ListaAnimais);
                }
            }
            else
            {
                return NotFound(
                    "Não foi possível criar o animal. Raça ou responsável não encontrado."
                );
            }
            return null;
        }

        [HttpGet("Animal/ObterInfoAnimal")]
        public IActionResult ObterInfoAnimal(int NumeroChip, string NomeAnimal)
        {
            if (HelperController.Helper.AtualizarDadosAnimal(NomeAnimal, NumeroChip, "NomeAnimal"))
            {
                return Ok("Foi atualizado com sucesso");
            }
            else
            {
                return NotFound("Não foi possivel atualizar o Nome Animal");
            }
        }

        [HttpPost("Animal/AtualizarNomeAnimal")]
        public IActionResult AtualizarNomeAnimal(int NumeroChip, string NomeAnimal)
        {
            if (HelperController.Helper.AtualizarDadosAnimal(NomeAnimal, NumeroChip, "NomeAnimal"))
            {
                return Ok("Foi atualizado com sucesso");
            }
            else
            {
                return NotFound("Não foi possivel atualizar o Nome Animal");
            }
        }

        [HttpPost("Animal/AtualizarNomeRaca")]
        public IActionResult AtualizarNomeRaca(int NumeroChip, string nomeracanovo)
        {
            if (
                HelperController.Helper.AtualizarDadosAnimal(
                    nomeracanovo,
                    NumeroChip,
                    "NumeroTelemovel"
                )
            )
            {
                return Ok("Foi atualizado com sucesso");
            }
            else
            {
                return NotFound("Não foi possivel atualizar o Nome Animal");
            }
        }

        [HttpPost("Animal/AtualizarResponsavel")]
        public IActionResult AtualizarResponsavel(int NumeroChip, int numeroTelemovel)
        {
            if (
                HelperController.Helper.AtualizarDadosAnimal(
                    Convert.ToString(numeroTelemovel),
                    NumeroChip,
                    "NumeroTelemovel"
                )
            )
            {
                return Ok("Foi atualizado com sucesso");
            }
            else
            {
                return NotFound("Não foi possivel atualizar o Nome Animal");
            }
        }

        // Remover Animal

        [HttpPost("Animal/ApagarAnimal")]
        public IActionResult ApagarAnimal(int NumeroChip)
        {
            foreach (Animal animal in ListaPessoas.ListaAnimais)
            {
                if (animal.NumeroChip == NumeroChip)
                {
                    ListaPessoas.ListaAnimais.Remove(animal);
                    return Ok("Removido com sucesso");
                }
            }
            return NotFound("Não foi possivel remover animal");
        }
    }
}
