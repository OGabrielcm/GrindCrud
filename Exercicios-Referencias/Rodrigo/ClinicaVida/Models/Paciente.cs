namespace ClinicaVida.Models;

public class Paciente
{
    public Paciente(string nomeCompleto, DateTime dataNascimento, string cpf, string numeroCarteirinha)
    {
        Id = Guid.NewGuid();
        NomeCompleto = nomeCompleto;
        DataNascimento = dataNascimento;
        CPF = cpf;
        NumeroCarteirinha = numeroCarteirinha;
    }
    public Guid Id { get; }
    public string NomeCompleto { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string CPF { get; private set; }
    public string NumeroCarteirinha { get; private set; }

    public void AlterarDadosPaciente(string nomeCompleto, DateTime? novaDataNascimento, string cpf, string numeroCarteirinha)
    {
        if(nomeCompleto != null)
            NomeCompleto = nomeCompleto;
        
        if(novaDataNascimento != null)
            DataNascimento = novaDataNascimento.Value;

        if(cpf != null)
            CPF = cpf;

        if(numeroCarteirinha != null)
            NumeroCarteirinha = numeroCarteirinha;
    }

    public override string ToString() => 
        $"IdPaciente: {Id}\n" +
        $"Paciente: {NomeCompleto}\n" +
        $"CPF: {CPF}\n" +
        $"Data Nascimento: {DataNascimento}\n" +
        $"Carteirinha: {NumeroCarteirinha}";
}
