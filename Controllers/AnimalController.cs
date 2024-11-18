using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    public class AnimalController : Controller
    {
        // Adicionar Animal
        //Criar Raca
        [HttpPost("Animal/CriarAnimal")]
        public IActionResult CriarAnimal(int NumeroChip,string NomeAnimal,string nomeraca,int NumeroTelemovel)
        {
            Raca raca1 = null;
            Pessoa pessoa = null;

            foreach (Raca raca in ListaPessoas.racas)
            {
                if (raca.Nome == nomeraca)
                {
                    raca1 = raca;
                }
            }

            foreach (Pessoa pessoa1 in ListaPessoas.Lista_Pessoas)
            {
                if (pessoa1.NumeroTelemovel == NumeroTelemovel)
                {
                    pessoa = pessoa1;
                }
            }

            if (pessoa != null && raca1 != null)
            {
                Animal animal = new Animal(NumeroChip, NomeAnimal, raca1, pessoa);
                ListaPessoas.ListaAnimais.Add(animal);
                return Ok("Raca Adicionada com sucesso");
            }
            else
            {
                return NotFound("Não foi possivel Criar Pessoa");
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
        public IActionResult AtualizarNomeRaca(
            int NumeroChip,
            string nomeracanovo
        )
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
        public IActionResult AtualizarResponsavel( int NumeroChip,int numeroTelemovel)
        {
            foreach (Animal animal1 in ListaPessoas.ListaAnimais)
            {
                if (animal1.NumeroChip == NumeroChip)
                {
                    foreach (Pessoa pessoa  in ListaPessoas.Lista_Pessoas)
                    {
                        if (pessoa.NumeroTelemovel == numeroTelemovel)
                        {
                            animal1.Responsavel=pessoa;

                           
                            return Ok("Foi atualizado com sucesso");
                        }
                    }

                   
                }
            }

            return NotFound("Não foi possivel atualizar o Nome Animal");
        }
        // Remover Animal

               [HttpPost("Animal/ApagarAnimal")]
                  public IActionResult ApagarAnimal( int NumeroChip){

                    foreach( Animal animal in ListaPessoas.ListaAnimais){

                        if(animal.NumeroChip==NumeroChip){
                            ListaPessoas.ListaAnimais.Remove(animal);
                            return Ok("Removido com sucesso");
                        }
                    }
                      return NotFound("Não foi possivel remover animal");
                  }
    }
    }
