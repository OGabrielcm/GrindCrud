namespace ProvaSexta.Models;
using ProvaSexta.Enums;

public class Paciente
{
    public Paciente(string nome, DateTime dataNascimento, string cpf, int numeroCarteira)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = cpf;
        NumeroCarteira = numeroCarteira;
    }

    public Guid Id { get; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; }
    public string CPF { get; }
    public int NumeroCarteira { get; private set; }

    public void AlterarNome(string nome)
    {
        Nome = nome;
    }

    public void AlterarNumeroCarteira(int numeroCarteira)
    {
        NumeroCarteira = numeroCarteira;
    }
}
