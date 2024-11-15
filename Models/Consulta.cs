public partial class Consulta
{

   protected int id_Marcacao;

   protected string DescricaoConsulta;

   protected DateTime DataInicial;

   protected DateTime DataFinal;

   protected Pessoa PessoaResponsavel;

   protected Animal AnimalConsulta;

   protected Veterinario VeterinarioResponsavel;

   protected List<int> ListaMarcacoes;

   protected List<Diagnostico> ListaCondicoes;

   protected string condicaoanimal;

   protected bool Estado;

  

   public Consulta(string _DescricaoConsulta,DateTime _DataInicial, DateTime _DataFinal, Pessoa _PessoaResponsavel, Animal _animal , Veterinario _VeterinarioResponsavel )
   {
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