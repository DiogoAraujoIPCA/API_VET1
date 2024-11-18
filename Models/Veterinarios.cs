 
 
 public partial class Veterinario
{
    public  int ID_Veterinario{get;set;}

    public Pessoa _Pessoa{get;set;}

    public Veterinario(int id, Pessoa PessoaParam)
    {
        ID_Veterinario = id;
        _Pessoa = PessoaParam;
    }
}