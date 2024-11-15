 
 
 public partial class Veterinario
{
 protected int ID_Veterinario;

    protected Pessoa _Pessoa;

    public Veterinario(int id, Pessoa PessoaParam)
    {
        ID_Veterinario = id;
        _Pessoa = PessoaParam;
    }
}