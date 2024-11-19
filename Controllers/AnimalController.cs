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
            Raca raca1 = null;
            Pessoa pessoa = null;

            // Debugging para ver os valores recebidos
            Console.WriteLine("Número do Chip: " + NumeroChip);
            Console.WriteLine("Nome do Animal: " + NomeAnimal);
            Console.WriteLine("Nome da Raça: " + nomeraca);
            Console.WriteLine("Número do Telemóvel: " + NumeroTelemovel);

            // Verifica se a raça existe
            foreach (Raca raca in ListaPessoas.racas)
            {
                if (raca.Nome == nomeraca)
                {
                    raca1 = raca;
                    break;
                }
            }

            // Verifica se o responsável existe
            foreach (Pessoa pessoa1 in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa1.NumeroTelemovel == NumeroTelemovel)
                {
                    pessoa = pessoa1;
                    break;
                }
            }

            // Adiciona o animal se a raça e o responsável forem encontrados
            if (pessoa != null && raca1 != null)
            {
                Animal animal = new Animal(NumeroChip, NomeAnimal, raca1, pessoa);
                ListaPessoas.ListaAnimais.Add(animal);


                return Ok("Animal adicionado com sucesso.");
            }
            else
            {
                return NotFound(
                    "Não foi possível criar o animal. Raça ou responsável não encontrado."
                );
            }
        }

        [HttpGet("Animal/ObterInfoAnimal")]
        public IActionResult ObterInfoAnimal(int NumeroChip, string NomeAnimal)
        {
            foreach (Animal animal in ListaPessoas.ListaAnimais)
            {
                if (animal.NumeroChip == NumeroChip)
                {
                    animal.NomeAnimal = NomeAnimal;
                    return Ok("Foi atualizado com sucesso");
                }
            }

            return NotFound("Não foi possivel atualizar o Nome Animal");
        }

        public IActionResult AtualizarNomeAnimal(int NumeroChip, string NomeAnimal)
        {
            foreach (Animal animal in ListaPessoas.ListaAnimais)
            {
                if (animal.NumeroChip == NumeroChip)
                {
                    animal.NomeAnimal = NomeAnimal;
                    return Ok("Foi atualizado com sucesso");
                }
            }

            return NotFound("Não foi possivel atualizar o Nome Animal");
        }

        [HttpPost("Animal/AtualizarNomeRaca")]
        public IActionResult AtualizarNomeRaca(int NumeroChip, string nomeracanovo)
        {
            foreach (Raca raca in ListaPessoas.racas)
            {
                if (raca.Nome == nomeracanovo)
                {
                    foreach (Animal animal in ListaPessoas.ListaAnimais)
                    {
                        if (animal.NumeroChip == NumeroChip)
                        {
                            animal.NomeRaca = raca;
                            return Ok("Foi atualizado com sucesso");
                        }
                    }
                }
            }

            return NotFound("Não foi possivel atualizar o Nome Animal");
        }

        [HttpPost("Animal/AtualizarResponsavel")]
        public IActionResult AtualizarResponsavel(int NumeroChip, int numeroTelemovel)
        {
            foreach (Animal animal1 in ListaPessoas.ListaAnimais)
            {
                if (animal1.NumeroChip == NumeroChip)
                {
                    foreach (Pessoa pessoa in ListaPessoas.Lista_Pessoas)
                    {
                        if (pessoa.NumeroTelemovel == numeroTelemovel)
                        {
                            animal1.Responsavel = pessoa;

                            return Ok("Foi atualizado com sucesso");
                        }
                    }
                }
            }

            return NotFound("Não foi possivel atualizar o Nome Animal");
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
