using MedConsulta.Enums;

namespace MedConsulta.Models;

public class Agendamento(Paciente paciente, Consulta consulta, TipoAtendimentoEnum tipoAtendimento, decimal valorCobrado)
{
    public Guid Id { get; } = Guid.NewGuid();
    public Paciente Paciente { get; private set; } = paciente;
    public Consulta Consulta { get; private set; } = consulta;
    public TipoAtendimentoEnum TipoAtendimento { get; private set; } = tipoAtendimento;
    public decimal ValorCobrado { get; private set; } = valorCobrado;
    public DateTime DataHoraConfirmacao { get; private set; } = DateTime.Now;



    public void AlterarDados(Paciente paciente, Consulta consulta, TipoAtendimentoEnum tipoAtendimento, decimal valorCobrado)
    {
        Paciente = paciente;
        Consulta = consulta;
        TipoAtendimento = tipoAtendimento;
        ValorCobrado = valorCobrado;
    }

    public override string ToString() => $"Id: {Id} | Tipo de Atendimento: {TipoAtendimento} | Valor Cobrado: {ValorCobrado:c} | Data e Hora da Confirmação: {DataHoraConfirmacao:G} | Paciente: {Paciente.Nome}";
}
