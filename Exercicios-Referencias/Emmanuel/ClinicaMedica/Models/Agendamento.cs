using MedConsulta.Enums;

namespace MedConsulta.Models;

public class Agendamento
{
    public Agendamento(Paciente paciente, Consulta consulta, TipoAtendimentoEnum tipoAtendimento, decimal valor)
    {
        Paciente = paciente;
        Consulta = consulta;
        TipoAtendimento = tipoAtendimento;
        Valor = valor;
        DataConfirmacao = DateTime.Now;
    }

    public Paciente Paciente { get; }
    public Consulta Consulta { get; private set; }
    public TipoAtendimentoEnum TipoAtendimento { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime DataConfirmacao { get; }

    public void AlterarConsulta(Consulta consulta) => Consulta = consulta;
    public void AlterarTipoAtendimento(TipoAtendimentoEnum tipo) => TipoAtendimento = tipo;
    public void AlterarValor(decimal valor) => Valor = valor;

    public override string ToString()
    {
        return $"Paciente: {Paciente.Nome} | Consulta: {Consulta.Codigo} | Tipo: {TipoAtendimento} | Valor: {Valor:C} | Confirmado em: {DataConfirmacao}";
    }
}
