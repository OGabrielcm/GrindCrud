namespace MedConsulta.Models;

public class Paciente
{
    public Paciente(string nome, DateOnly dataNascimento, string cpf, string carteirinha)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Cpf = cpf;
        Carteirinha = carteirinha;
    }

    public string Nome { get; private set; }
    public DateOnly DataNascimento { get; }
    public string Cpf { get; }
    public string Carteirinha { get; }

    public void AlterarNome(string nome) => Nome = nome;

    public override string ToString()
    {
        return $"Paciente: {Nome} | Nascimento: {DataNascimento} | CPF: {Cpf} | Carteirinha: {Carteirinha}";
    }
}
