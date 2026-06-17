namespace MedConsulta.Models;

public class Paciente(string nome, string cpf, string numeroCarteirinha, DateTime dataNascimento)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Nome { get; private set; } = nome;
    public string Cpf { get; private set; } = cpf;
    public string NumeroCarteirinha { get; private set; } = numeroCarteirinha;
    public DateTime DataNascimento { get; private set; } = dataNascimento;

    public void AlterarCpf(string cpf) => Cpf = cpf;

    public void AlterarNumeroCarteirinha(string numeroCarteirinha) => NumeroCarteirinha = numeroCarteirinha;

    public void AlterarDados(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public override string ToString() => $"Id: {Id} | Nome: {Nome} | Número Carteirinha: {NumeroCarteirinha} | Cpf: {Cpf} | Data de Nascimento: {DataNascimento:d}";
}
