using System.Data;

public  partial class Animal
{

    #region Atributos
    public int NumeroChip {get;set;}

    public string NomeAnimal {get;set;}

    public Raca NomeRaca {get;set;}

    public Pessoa Responsavel {get;set;}

    public List<string> ListaDoencas;
   

    #endregion


    #region  Construtor
     public Animal(int _NumeroChip, string _Nome, Raca _NomeRaca = null, Pessoa _Responsavel = null)
    {
        NumeroChip = _NumeroChip;
        NomeAnimal = _Nome;
        NomeRaca = _NomeRaca;  // Pode ser null
        Responsavel = _Responsavel;  // Pode ser null
      
    }
    #endregion
}