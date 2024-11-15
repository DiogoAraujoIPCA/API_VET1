public  class Diagnostico{
     protected int id ;

     protected string Nome_Comum;

     protected string Nome_Especifico;

    
    public Diagnostico(string _NomeComum, string _Nome_Especifico )
    {
       
        Nome_Comum = _NomeComum;
        Nome_Especifico = _Nome_Especifico;
        
    }

    public string RetornarNomeDiagnostico(){
        return Nome_Comum + "_"+Nome_Especifico;
    }


    public void RetornarNomeDiagnosticoUtilizador(){
        Console.WriteLine(Nome_Comum + "_"+Nome_Especifico);
    }
}