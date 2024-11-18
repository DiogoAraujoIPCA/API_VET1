public partial class Raca
{
    public  string Nome {get;set;}
    public string Informacoes{get;set;}
    public List<Diagnostico> _Diagnostico{get;set;}

    public Raca(string _Nome, string _Informacoes = null)
    {
        Nome = _Nome;
        Informacoes = _Informacoes;
    }
}
