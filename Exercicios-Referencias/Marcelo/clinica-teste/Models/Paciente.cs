namespace MedConsulta.Models;

public class Paciente(string nomeCompleto, DateTime dataNascimento, string cpf, string carteirinha)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string NomeCompleto { get; private set; } = nomeCompleto;
    public DateTime DataNascimento { get; private set; } = dataNascimento;
    public string Cpf { get; private set; } = cpf;
    public string Carteirinha { get; private set; } = carteirinha;

    public void Editar(string nomeCompleto, DateTime? dataNascimento, string carteirinha)
    {
        if (nomeCompleto != null)
            NomeCompleto = nomeCompleto;

        if (dataNascimento != null)
            DataNascimento = dataNascimento.Value;

        if (carteirinha != null)
            Carteirinha = carteirinha;
    }

    public override string ToString() => $"Id: {Id} | Nome: {NomeCompleto} | CPF: {Cpf} | Carteirinha: {Carteirinha} | Nasc.: {DataNascimento:dd/MM/yyyy}";
}
