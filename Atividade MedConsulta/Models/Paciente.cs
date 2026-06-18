namespace Atividade_MedConsulta.Models;

public class Paciente
{
    public Paciente(string nomeCompleto, string cpf, string numeroPlano, DateTime dataNascimento)
    {
       NomeCompleto = nomeCompleto;
       Cpf = cpf;
       NumeroPlano = numeroPlano; 
       DataNascimento = dataNascimento;
    }
    public string NomeCompleto {get; private set;}
    public string Cpf {get;}
    public string NumeroPlano {get; private set;}
    public DateTime DataNascimento {get; private set;}

    public void Atualizar(string nomeCompleto, string numeroPlano, DateTime dataNascimento)
    {
        NomeCompleto = nomeCompleto;
        NumeroPlano = numeroPlano;
        DataNascimento = dataNascimento;
    }

    public override string ToString()
    {
        return $"Numero do Plano: {NumeroPlano} | Nome: {NomeCompleto} | Data de Nascimento: {DataNascimento.ToShortDateString()}  | Cpf: {Cpf}";
    }
}
