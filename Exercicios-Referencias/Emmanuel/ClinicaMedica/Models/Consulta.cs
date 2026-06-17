using MedConsulta.Enums;

namespace MedConsulta.Models;

public class Consulta
{
    private static int contador = 0;

    public Consulta(Medico medico, string local, DateTime dataHoraPrevista, int duracaoMinutos)
    {
        Medico = medico;
        Codigo = GerarCodigo();
        Local = local;
        DataHoraPrevista = dataHoraPrevista;
        DuracaoMinutos = duracaoMinutos;
        Status = StatusConsultaEnum.Pendente;
    }

    public string Codigo { get; }
    public Medico Medico { get; }
    public string Local { get; private set; }
    public DateTime DataHoraPrevista { get; private set; }
    public int DuracaoMinutos { get; private set; }
    public StatusConsultaEnum Status { get; private set; }

    private static string GerarCodigo()
    {
        ++contador;
        return $"CONS{contador:D4}";
    }

    public void AlterarLocal(string local) => Local = local;
    public void AlterarDataHoraPrevista(DateTime dataHora) => DataHoraPrevista = dataHora;
    public void AlterarDuracao(int duracao) => DuracaoMinutos = duracao;
    public void Confirmar() => Status = StatusConsultaEnum.Confirmada;
    public void MarcarRealizada() => Status = StatusConsultaEnum.Realizada;
    public void Cancelar() => Status = StatusConsultaEnum.Cancelada;

    public override string ToString()
    {
        return $"Consulta: {Codigo} | Médico: {Medico.Nome} | Local: {Local} | Data/Hora: {DataHoraPrevista} | Duração: {DuracaoMinutos}min | Status: {Status}";
    }
}
