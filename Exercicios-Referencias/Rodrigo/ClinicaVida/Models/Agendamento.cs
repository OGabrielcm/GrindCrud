namespace ClinicaVida.Models;

public class Agendamento
{
    public Agendamento(Paciente paciente, Consulta consulta, TipoAtendimentoEnum tipo, decimal valorConsulta)
    {
        Id = Guid.NewGuid();
        Paciente = paciente;
        Consulta = consulta;
        Tipo = tipo;
        ValorConsulta = valorConsulta;
        DataAgendamento = DateTime.Now;
    }
    public Guid Id { get; }
    public Paciente Paciente { get; private set; }
    public Consulta Consulta { get; private set; }
    public TipoAtendimentoEnum Tipo { get; private set; }
    public decimal ValorConsulta { get; private set; }
    public DateTime DataAgendamento { get; private set; }

    public void AlterarAgendamento(Paciente paciente, Consulta consulta, TipoAtendimentoEnum tipo, decimal valorConsulta)
    {
        Paciente = paciente;
        Consulta = consulta;
        Tipo = tipo;
        ValorConsulta = valorConsulta;
        DataAgendamento = DateTime.Now;
    }

    public override string ToString() =>
        $"IdAgendamento: {Id}\n" +
        $"Paciente: {Paciente.NomeCompleto} | {Paciente.NumeroCarteirinha}\n" +
        $"Consulta: Local: {Consulta.Local} | Médico: {Consulta.Medico.Nome} | Especialidade: {Consulta.Medico.Especialidade} | Horário: {Consulta.DataHora}\n" +
        $"Atendimento: {Tipo}\n" +
        $"Valor: {ValorConsulta:C}\n" +
        $"Data Agendamento: {DataAgendamento}";
}
