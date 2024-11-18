public partial class Consulta
{

   public int id_Marcacao{get;set;}

   public string DescricaoConsulta{get;set;}

   public DateTime DataInicial{get;set;}

   public DateTime DataFinal{get;set;}

   public Pessoa PessoaResponsavel{get;set;}

   public Animal AnimalConsulta{get;set;}

   public Veterinario VeterinarioResponsavel{get;set;}

   public List<int> ListaMarcacoes{get;set;}

   public List<Diagnostico> ListaCondicoes{get;set;}

   public string condicaoanimal{get;set;}

   public bool Estado{get;set;}

  

   public Consulta(int _id_Marcacao,string _DescricaoConsulta,DateTime _DataInicial, DateTime _DataFinal, Pessoa _PessoaResponsavel, Animal _animal , Veterinario _VeterinarioResponsavel )
   {
      _id_Marcacao=id_Marcacao;
      DescricaoConsulta=_DescricaoConsulta;
      DataInicial = _DataInicial;
      DataFinal = _DataFinal;
      PessoaResponsavel = _PessoaResponsavel;
      AnimalConsulta = _animal;
      ListaMarcacoes = new List<int>();
      VeterinarioResponsavel= _VeterinarioResponsavel;
      Estado=true;
      ListaCondicoes = new List<Diagnostico>();
      
      
      
   }

   


}