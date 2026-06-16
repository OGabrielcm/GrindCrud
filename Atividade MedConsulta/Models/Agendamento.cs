using Atividade_MedConsulta.Enums;
namespace Atividade_MedConsulta.Models;

public class Agendamento
{
    public Agendamento(TipoAtendimentoEnum tipoAtendimento, decimal valorCobrado, DateTime dataConfirmada, Paciente paciente, Consulta consulta)
    {
        TipoAtendimento = tipoAtendimento;
        ValorCobrado = valorCobrado;
        DataConfirmada = dataConfirmada;
        Paciente = paciente;
        Consulta = consulta;
    }
    public TipoAtendimentoEnum TipoAtendimento {get; private set;}
    public decimal ValorCobrado {get; private set;}
    public DateTime DataConfirmada {get; private set;}
    public Paciente Paciente {get; private set;}
    public Consulta Consulta {get; private set;}
}

