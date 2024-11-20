using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Controllers;

namespace MyWebApi.Controllers
{
    public class HelperController : Controller
    {
        public static class Helper
        {
            #region Atualizar Dados

            public static bool AtualizarDadoPessoa(
                string valorDoCampo,
                int numeroTelemovel,
                string Atributo
            )
            {
                foreach (var pessoa in ListaPessoas.Lista_Pessoas)
                {
                    if (pessoa.NumeroTelemovel == numeroTelemovel)
                    {
                        switch (Atributo)
                        {
                            case "Nome":
                                pessoa.Nome = valorDoCampo;
                                return true;

                            case "Morada":
                                pessoa.Morada = valorDoCampo;
                                return true;

                            case "NumeroTelemovel":
                                pessoa.NumeroTelemovel = Convert.ToInt32(valorDoCampo);
                                return true;

                            default:
                                return false;
                                break;
                        }
                    }
                }
                return false;
            }

            public static bool AtualizarDadosAnimal(
                string valorDoCampo,
                int NumeroChip,
                string Atributo
            )
            {
                foreach (var animal in ListaPessoas.ListaAnimais)
                {
                    if (animal.NumeroChip == NumeroChip)
                    {
                        switch (Atributo)
                        {
                            case "NomeAnimal":
                                animal.NomeAnimal = valorDoCampo;
                                return true;

                            case "NomeRaca":
                                if (VerificarExistenciaRaca(valorDoCampo))
                                {
                                    animal.NomeRaca = ObterRaca(valorDoCampo);
                                }
                                else
                                {
                                    return false;
                                }

                                return true;

                            case "Responsavel":
                                animal.Responsavel = HelperController.Helper.ObterPessoa(
                                    Convert.ToInt32(valorDoCampo)
                                );
                                return true;

                            default:

                                break;
                        }
                    }
                }
                return false;
            }

            public static bool AtualizarDadosRaca(
                string valorDoCampo,
                string NomeRaca,
                string Atributo,
                string valorDoCampo2 = null
            )
            {
                foreach (var racas in ListaPessoas.racas)
                {
                    if (racas.Nome == NomeRaca)
                    {
                        switch (Atributo)
                        {
                            case "NomeRaca":
                                racas.Nome = valorDoCampo;
                                return true;

                            case "Informacoes":
                                racas.Informacoes = valorDoCampo;
                                return true;

                            case "TodosCampos":
                                racas.Nome = valorDoCampo;
                                racas.Informacoes = valorDoCampo2;
                                return true;
                            default:
                                return false;
                        }
                    }
                }
                return false;
            }

        
            #endregion

            #region Verificar Listas
            public static bool VerificarExistenciaAnimal(int numerochip)
            {
                foreach (Animal animal in ListaPessoas.ListaAnimais)
                {
                    if (animal.NumeroChip == numerochip)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static bool VerificarExistenciaPessoa(int NumeroTelemovel)
            {
                foreach (Pessoa pessoa in ListaPessoas.Lista_Pessoas)
                {
                    if (pessoa.NumeroTelemovel == NumeroTelemovel)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static bool VerificarExistenciaRaca(string NomeRaca)
            {
                foreach (Raca raca in ListaPessoas.racas)
                {
                    if (raca.Nome == NomeRaca)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static bool VerificarVeterinario(int IDVeterinario)
            {
                foreach (Veterinario veterinario in ListaPessoas.ListasVeterinario)
                {
                    if (veterinario.ID_Veterinario == IDVeterinario)
                    {
                        return true;
                    }
                }
                return false;
            }

            #endregion

            #region Obter Objetos

            public static Animal ObterAnimal(int NumeroChip)
            {
                foreach (Animal animal in ListaPessoas.ListaAnimais)
                {
                    if (animal.NumeroChip == NumeroChip)
                    {
                        return animal;
                    }
                }
                return null;
            }

            public static Raca ObterRaca(string nomeraca)
            {
                foreach (Raca raca in ListaPessoas.racas)
                {
                    if (raca.Nome == nomeraca)
                    {
                        return raca;
                    }
                }
                return null;
            }

            public static Pessoa ObterPessoa(int numeroTelemovel)
            {
                foreach (Pessoa pessoa in ListaPessoas.Lista_Pessoas)
                {
                    if (pessoa.NumeroTelemovel == numeroTelemovel)
                    {
                        return pessoa;
                    }
                }

                return null;
            }

            public static Veterinario ObterVeterinario(int IDVeterinario)
            {
                foreach (Veterinario veterinario in ListaPessoas.ListasVeterinario)
                {
                    if (veterinario.ID_Veterinario == IDVeterinario)
                    {
                        return veterinario;
                    }
                }
                return null;
            }

            public static Consulta ObterConsulta(int id)
            {
                foreach (Consulta consulta in ListaPessoas.consultas)
                {
                    if (consulta.id_Marcacao == id)
                    {
                        return consulta;
                    }
                }
                return null;
            }

            #endregion
        }
    }
}
