using Atividade_MedConsulta.Enums;
namespace Atividade_MedConsulta.Models;

public class Consulta
{
    public Consulta(string codigoUnico, string localAtendimento, DateTime dataHoraPrevista, int duracaoEstimada, Medico medicoResponsavel, StatusConsultaEnum statusConsulta)
    {
       CodigoUnico = codigoUnico;
       LocalAtendimento = localAtendimento;
       DataHoraPrevista = dataHoraPrevista;
       DuracaoEstimada = duracaoEstimada;
       MedicoResponsavel = medicoResponsavel;
       StatusConsulta = statusConsulta; 
    }
public string CodigoUnico {get; private set;} // por exemplo, "CONS0512"
public string LocalAtendimento {get; private set;}
public DateTime DataHoraPrevista {get;private set;} 
public int DuracaoEstimada {get;private set;} // Em minutos 
public Medico MedicoResponsavel {get;private set;}
public StatusConsultaEnum StatusConsulta  {get;private set;}
}
