public partial class Raca
{
    private string Nome;
    private string Informacoes;
    private List<Diagnostico> _Diagnostico;

    public Raca(string _Nome, string _Informacoes = null)
    {

        Nome = _Nome;
        Informacoes = _Informacoes;
       

    }
}
