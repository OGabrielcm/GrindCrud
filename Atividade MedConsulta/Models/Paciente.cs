using System.Runtime.CompilerServices;

namespace Atividade_MedConsulta.Models;

public class Paciente
{
    public Paciente(string nomeCompleto, DateTime dataNascimento, string cpf, string numeroPlano)
    {
       NomeCompleto = nomeCompleto;
       DataNascimento = dataNascimento;
       Cpf = cpf;
       NumeroPlano = numeroPlano; 
    }
    public string NomeCompleto {get; private set;}
    public DateTime DataNascimento {get; private set;}
    public string Cpf {get; private set;}
    public string NumeroPlano {get; private set;}
}
