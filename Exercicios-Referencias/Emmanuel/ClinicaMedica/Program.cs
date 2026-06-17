using MedConsulta.Enums;
using MedConsulta.Helpers;
using MedConsulta.Models;

List<Medico> medicos = [];
List<Paciente> pacientes = [];
List<Consulta> consultas = [];
List<Agendamento> agendamentos = [];

while (true)
{
    Console.WriteLine("\n§§§§§§§§ -- CLÍNICA MEDCONSULTA -- §§§§§§§§");
    Console.WriteLine("§ 1 -            Menu Médico              §");
    Console.WriteLine("§ 2 -           Menu Paciente              §");
    Console.WriteLine("§ 3 -           Menu Consulta              §");
    Console.WriteLine("§ 4 -          Menu Agendamento            §");
    Console.WriteLine("§ 5 -        Menu Consultas/Rank           §");
    Console.WriteLine("§ 0 -               Sair                  §");
    Console.WriteLine("§§§§§§§§ -------------------------------- §§§§§§§§\n");

    int escolha = Validador.ValidarIntIntervalo("Escolha o menu desejado: ", 0, 5);

    switch (escolha)
    {
        case 1:
            MenuMedico();
            break;

        case 2:
            MenuPaciente();
            break;

        case 3:
            MenuConsulta();
            break;

        case 4:
            MenuAgendamento();
            break;

        case 5:
            MenuConsultasRank();
            break;

        case 0:
            Console.WriteLine("Obrigado por usar o MedConsulta, até logo.");
            Thread.Sleep(1500);
            return;
    }
}

// ---------------- MÉDICO ----------------

void MenuMedico()
{
    while (true)
    {
        Console.WriteLine("\n§§§ ---  MENU MÉDICOS  --- §§§");
        Console.WriteLine("§ 1 -   Cadastrar Médico    §");
        Console.WriteLine("§ 2 -    Listar Médicos     §");
        Console.WriteLine("§ 3 -     Editar Médico     §");
        Console.WriteLine("§ 4 -    Remover Médico     §");
        Console.WriteLine("§ 0 -         Voltar        §");
        Console.WriteLine("§§§ ----------------------- §§§\n");

        int escolha = Validador.ValidarIntIntervalo("Escolha a opção desejada: ", 0, 4);

        switch (escolha)
        {
            case 1:
                CadastrarMedico();
                break;

            case 2:
                ListarMedicos();
                break;

            case 3:
                EditarMedico();
                break;

            case 4:
                RemoverMedico();
                break;

            case 0:
                Console.WriteLine("Retornando...");
                Thread.Sleep(1000);
                return;
        }
    }
}

void CadastrarMedico()
{
    string crm = Validador.ValidarStringCrm("Digite o CRM (ex: CRM12345): ");

    if (medicos.Any(m => m.Crm == crm))
    {
        Console.WriteLine("Já existe médico com esse CRM\n");
        return;
    }

    string nome = Validador.ValidarString("Nome do médico: ");
    string especialidade = Validador.ValidarString("Especialidade: ");

    var medico = new Medico(crm, nome, especialidade);
    medicos.Add(medico);

    Console.WriteLine($"\nMédico cadastrado com sucesso - {medico}\n");
    Thread.Sleep(1500);
}

void ListarMedicos()
{
    if (medicos.Count == 0)
    {
        Console.WriteLine("\nNenhum médico cadastrado\n");
        return;
    }

    int indice = 0;
    medicos.ForEach(m => Console.WriteLine($"{++indice} - {m}"));
    Continuar();
}

void EditarMedico()
{
    ListarMedicos();
    string crm = Validador.ValidarStringCrm("\nCRM do médico que deseja editar: ");
    var medico = medicos.FirstOrDefault(m => m.Crm == crm);

    if (medico == null)
    {
        Console.WriteLine("Médico não encontrado\n");
        return;
    }

    string novoNome = Validador.ValidarString("Novo nome: ");
    string novaEspecialidade = Validador.ValidarString("Nova especialidade: ");
    medico.AlterarNome(novoNome);
    medico.AlterarEspecialidade(novaEspecialidade);

    Console.WriteLine($"\nMédico editado com sucesso - {medico}\n");
    Thread.Sleep(1500);
}

void RemoverMedico()
{
    ListarMedicos();
    string crm = Validador.ValidarStringCrm("\nCRM do médico que deseja remover: ");
    var medico = medicos.FirstOrDefault(m => m.Crm == crm);

    if (medico == null)
    {
        Console.WriteLine("Médico não encontrado\n");
        return;
    }

    bool temConsultaAtiva = consultas.Any(c => c.Medico.Crm == crm && (c.Status != StatusConsultaEnum.Cancelada || c.Status != StatusConsultaEnum.Realizada));
    if (temConsultaAtiva)
    {
        Console.WriteLine("Médico possui consultas ativas. Exclusão negada\n");
        return;
    }

    medicos.Remove(medico);
    Console.WriteLine($"\nMédico {medico.Nome} removido com sucesso\n");
    Thread.Sleep(1500);
}

// ---------------- PACIENTE ----------------

void MenuPaciente()
{
    while (true)
    {
        Console.WriteLine("\n§§§ ---  MENU PACIENTES  --- §§§");
        Console.WriteLine("§ 1 -   Cadastrar Paciente     §");
        Console.WriteLine("§ 2 -    Listar Pacientes      §");
        Console.WriteLine("§ 3 -     Buscar Paciente      §");
        Console.WriteLine("§ 4 -     Editar Paciente      §");
        Console.WriteLine("§ 5 -    Remover Paciente      §");
        Console.WriteLine("§ 0 -          Voltar          §");
        Console.WriteLine("§§§ ------------------------ §§§\n");

        int escolha = Validador.ValidarIntIntervalo("Escolha a opção desejada: ", 0, 5);

        switch (escolha)
        {
            case 1:
                CadastrarPaciente();
                break;

            case 2:
                ListarPacientes();
                break;

            case 3:
                BuscarPaciente();
                break;

            case 4:
                EditarPaciente();
                break;

            case 5:
                RemoverPaciente();
                break;

            case 0:
                Console.WriteLine("Retornando...");
                Thread.Sleep(1000);
                return;
        }
    }
}

void CadastrarPaciente()
{
    string nome = Validador.ValidarString("\nNome completo: ");
    DateOnly dataNascimento = Validador.ValidarData("Data de nascimento (dd/MM/yyyy): ");
    string cpf = Validador.ValidarStringCpf("CPF (apenas números): ");

    if (pacientes.Any(p => p.Cpf == cpf))
    {
        Console.WriteLine("CPF já cadastrado no sistema\n");
        return;
    }

    string carteirinha = Validador.ValidarStringCarteirinha("Número da carteirinha do plano: ");

    if (pacientes.Any(p => p.Carteirinha == carteirinha))
    {
        Console.WriteLine("Carteirinha já cadastrada no sistema\n");
        return;
    }

    var paciente = new Paciente(nome, dataNascimento, cpf, carteirinha);
    pacientes.Add(paciente);

    Console.WriteLine($"\nPaciente {paciente.Nome} cadastrado com sucesso\n");
    Thread.Sleep(1500);
}

void ListarPacientes()
{
    if (pacientes.Count == 0)
    {
        Console.WriteLine("\nNenhum paciente cadastrado\n");
        return;
    }

    int indice = 0;
    pacientes.ForEach(p => Console.WriteLine($"{++indice} - {p}"));
    Continuar();
}

void BuscarPaciente()
{
    string nomeParcial = Validador.ValidarString("\nDigite o nome ou parte do nome: ").ToLower();
    var busca = pacientes.Where(p => p.Nome.ToLower().Contains(nomeParcial)).ToList();

    if (busca.Count == 0)
    {
        Console.WriteLine("Nenhum paciente encontrado\n");
        return;
    }

    int indice = 0;
    busca.ForEach(p => Console.WriteLine($"{++indice} - {p}"));
    Continuar();
}

void EditarPaciente()
{
    ListarPacientes();
    string cpf = Validador.ValidarStringCpf("\nCPF do paciente que deseja editar: ");
    var paciente = pacientes.FirstOrDefault(p => p.Cpf == cpf);

    if (paciente == null)
    {
        Console.WriteLine("Paciente não encontrado\n");
        return;
    }

    string novoNome = Validador.ValidarString("Novo nome: ");
    paciente.AlterarNome(novoNome);

    Console.WriteLine($"\nPaciente editado com sucesso - {paciente}\n");
    Thread.Sleep(1500);
}

void RemoverPaciente()
{
    ListarPacientes();
    string cpf = Validador.ValidarStringCpf("\nCPF do paciente que deseja remover: ");
    var paciente = pacientes.FirstOrDefault(p => p.Cpf == cpf);

    if (paciente == null)
    {
        Console.WriteLine("Paciente não encontrado\n");
        return;
    }

    bool temAgendamento = agendamentos.Any(a => a.Paciente.Cpf == cpf);
    if (temAgendamento)
    {
        Console.WriteLine("Paciente possui agendamentos registrados. Exclusão negada\n");
        return;
    }

    pacientes.Remove(paciente);
    Console.WriteLine($"\nPaciente {paciente.Nome} removido com sucesso\n");
    Thread.Sleep(1500);
}

// ---------------- CONSULTA ----------------

void MenuConsulta()
{
    while (true)
    {
        Console.WriteLine("\n§§§ ---  MENU CONSULTAS  --- §§§");
        Console.WriteLine("§ 1 -   Cadastrar Consulta     §");
        Console.WriteLine("§ 2 -    Listar Consultas      §");
        Console.WriteLine("§ 3 -     Editar Consulta      §");
        Console.WriteLine("§ 4 -    Remover Consulta      §");
        Console.WriteLine("§ 0 -          Voltar          §");
        Console.WriteLine("§§§ ------------------------ §§§\n");

        int escolha = Validador.ValidarIntIntervalo("Escolha a opção desejada: ", 0, 4);

        switch (escolha)
        {
            case 1:
                CadastrarConsulta();
                break;

            case 2:
                ListarConsultas();
                break;

            case 3:
                EditarConsulta();
                break;

            case 4:
                RemoverConsulta();
                break;

            case 0:
                Console.WriteLine("Retornando...");
                Thread.Sleep(1000);
                return;
        }
    }
}

void CadastrarConsulta()
{
    ListarMedicos();
    string crm = Validador.ValidarStringCrm("\nCRM do médico responsável: ");
    var medico = medicos.FirstOrDefault(m => m.Crm == crm);

    if (medico == null)
    {
        Console.WriteLine("Médico não encontrado. Consulta exige médico responsável\n");
        return;
    }

    string local = Validador.ValidarString("Local de atendimento: ");
    DateTime dataHora = Validador.ValidarDataHota("Data e hora prevista (dd/MM/yyyy HH:mm): ");
    int duracao = Validador.ValidarInt("Duração estimada (minutos): ");

    var consulta = new Consulta(medico, local, dataHora, duracao);
    consultas.Add(consulta);

    Console.WriteLine($"\nConsulta cadastrada com sucesso - {consulta}\n");
    Thread.Sleep(1500);
}

void ListarConsultas()
{
    if (consultas.Count == 0)
    {
        Console.WriteLine("\nNenhuma consulta cadastrada\n");
        return;
    }

    int indice = 0;
    consultas.ForEach(c => Console.WriteLine($"{++indice} - {c}"));
    Continuar();
}

void EditarConsulta()
{
    ListarConsultas();
    string codigo = Validador.ValidarString("\nCódigo da consulta a editar: ").ToUpper();
    var consulta = consultas.FirstOrDefault(c => c.Codigo == codigo);

    if (consulta == null)
    {
        Console.WriteLine("Consulta não encontrada\n");
        return;
    }

    Console.WriteLine("\nOpções: ");
    Console.WriteLine("1 - Confirmar consulta");
    Console.WriteLine("2 - Marcar como realizada");
    Console.WriteLine("3 - Cancelar consulta");
    Console.WriteLine("4 - Alterar local");
    Console.WriteLine("5 - Alterar data e hora");
    Console.WriteLine("6 - Alterar duração");

    int escolha = Validador.ValidarIntIntervalo("Escolha: ", 1, 6);

    switch (escolha)
    {
        case 1:
            consulta.Confirmar();
            Console.WriteLine("\nConsulta confirmada\n");
            break;

        case 2:
            consulta.MarcarRealizada();
            Console.WriteLine("\nConsulta marcada como realizada\n");
            break;

        case 3:
            consulta.Cancelar();
            Console.WriteLine("\nConsulta cancelada\n");
            break;

        case 4:
            string novoLocal = Validador.ValidarString("Novo local: ");
            consulta.AlterarLocal(novoLocal);
            Console.WriteLine("\nLocal alterado\n");
            break;

        case 5:
            DateTime novaData = Validador.ValidarDataHota("Nova data e hora: ");
            consulta.AlterarDataHoraPrevista(novaData);
            Console.WriteLine("\nData e hora alteradas\n");
            break;

        case 6:
            int novaDuracao = Validador.ValidarInt("Nova duração: ");
            consulta.AlterarDuracao(novaDuracao);
            Console.WriteLine("\nDuração alterada\n");
            break;
    }

    Thread.Sleep(1500);
}

void RemoverConsulta()
{
    ListarConsultas();
    string codigo = Validador.ValidarString("\nCódigo da consulta a remover: ").ToUpper();
    var consulta = consultas.FirstOrDefault(c => c.Codigo == codigo);

    if (consulta == null)
    {
        Console.WriteLine("Consulta não encontrada\n");
        return;
    }

    if (consulta.Status != StatusConsultaEnum.Cancelada)
    {
        Console.WriteLine("Apenas consultas canceladas podem ser excluídas\n");
        return;
    }

    bool temAgendamento = agendamentos.Any(a => a.Consulta.Codigo == codigo);
    if (temAgendamento)
    {
        Console.WriteLine("Consulta possui agendamentos vinculados. Exclusão negada\n");
        return;
    }

    consultas.Remove(consulta);
    Console.WriteLine($"\nConsulta {consulta.Codigo} removida com sucesso\n");
    Thread.Sleep(1500);
}

// ---------------- AGENDAMENTO ----------------

void MenuAgendamento()
{
    while (true)
    {
        Console.WriteLine("\n§§§ ---  MENU AGENDAMENTOS  --- §§§");
        Console.WriteLine("§ 1 -   Cadastrar Agendamento     §");
        Console.WriteLine("§ 2 -    Listar Agendamentos      §");
        Console.WriteLine("§ 3 -     Editar Agendamento      §");
        Console.WriteLine("§ 4 -    Remover Agendamento      §");
        Console.WriteLine("§ 0 -          Voltar             §");
        Console.WriteLine("§§§ -------------------------- §§§\n");

        int escolha = Validador.ValidarIntIntervalo("Escolha a opção desejada: ", 0, 4);

        switch (escolha)
        {
            case 1:
                CadastrarAgendamento();
                break;

            case 2:
                ListarAgendamentos();
                break;

            case 3:
                EditarAgendamento();
                break;

            case 4:
                RemoverAgendamento();
                break;

            case 0:
                Console.WriteLine("Retornando...");
                Thread.Sleep(1000);
                return;
        }
    }
}

TipoAtendimentoEnum EscolherTipoAtendimento()
{
    Console.WriteLine("\nEscolha o tipo de atendimento: ");
    Console.WriteLine("1 - Presencial");
    Console.WriteLine("2 - Telemedicina");
    Console.WriteLine("3 - Procedimento Complexo");

    int escolha = Validador.ValidarIntIntervalo("Escolha: ", 1, 3);

    return escolha switch
    {
        1 => TipoAtendimentoEnum.Presencial,
        2 => TipoAtendimentoEnum.Telemedicina,
        _ => TipoAtendimentoEnum.ProcedimentoComplexo,
    };
}

void CadastrarAgendamento()
{
    ListarPacientes();
    string cpf = Validador.ValidarStringCpf("\nCPF do paciente: ");
    var paciente = pacientes.FirstOrDefault(p => p.Cpf == cpf);

    if (paciente == null)
    {
        Console.WriteLine("Paciente não encontrado\n");
        return;
    }

    ListarConsultas();
    string codigo = Validador.ValidarString("Código da consulta: ").ToUpper();
    var consulta = consultas.FirstOrDefault(c => c.Codigo == codigo);

    if (consulta == null)
    {
        Console.WriteLine("Consulta não encontrada\n");
        return;
    }

    bool jaAgendado = agendamentos.Any(a => a.Consulta.Codigo == codigo && a.Paciente.Cpf == cpf);
    if (jaAgendado)
    {
        Console.WriteLine("Paciente já possui agendamento nessa consulta\n");
        return;
    }

    TipoAtendimentoEnum tipo = EscolherTipoAtendimento();
    decimal valor = Validador.ValidarDecimal("Valor cobrado: ");

    var agendamento = new Agendamento(paciente, consulta, tipo, valor);
    agendamentos.Add(agendamento);

    Console.WriteLine("\nAgendamento realizado com sucesso\n");
    Thread.Sleep(1500);
}

void ListarAgendamentos()
{
    if (agendamentos.Count == 0)
    {
        Console.WriteLine("\nNenhum agendamento cadastrado\n");
        return;
    }

    int indice = 0;
    agendamentos.ForEach(a => Console.WriteLine($"{++indice} - {a}"));
    Continuar();
}

void EditarAgendamento()
{
    ListarAgendamentos();
    string cpf = Validador.ValidarStringCpf("\nCPF do paciente: ");
    string codigo = Validador.ValidarString("Código da consulta: ").ToUpper();
    var agendamento = agendamentos.FirstOrDefault(a => a.Paciente.Cpf == cpf && a.Consulta.Codigo == codigo);

    if (agendamento == null)
    {
        Console.WriteLine("Agendamento não encontrado\n");
        return;
    }

    Console.WriteLine("\nEscolha uma das opções");
    Console.WriteLine("1 - Alterar tipo de atendimento");
    Console.WriteLine("2 - Alterar valor cobrado");
    Console.WriteLine("3 - Mover para outra consulta");

    int escolha = Validador.ValidarIntIntervalo("Digite: ", 1, 3);

    switch (escolha)
    {
        case 1:
            agendamento.AlterarTipoAtendimento(EscolherTipoAtendimento());
            break;

        case 2:
            decimal novoValor = Validador.ValidarDecimal("Novo valor: ");
            agendamento.AlterarValor(novoValor);
            break;

        case 3:
            ListarConsultas();
            string novoCodigo = Validador.ValidarString("Código da nova consulta: ").ToUpper();
            var novaConsulta = consultas.FirstOrDefault(c => c.Codigo == novoCodigo);

            if (novaConsulta == null)
            {
                Console.WriteLine("Consulta não encontrada\n");
                return;
            }

            bool jaAgendado = agendamentos.Any(a => a.Consulta.Codigo == novoCodigo && a.Paciente.Cpf == agendamento.Paciente.Cpf);
            if (jaAgendado)
            {
                Console.WriteLine("Paciente já possui agendamento nessa consulta\n");
                return;
            }

            agendamento.AlterarConsulta(novaConsulta);
            break;
    }

    Console.WriteLine("\nAgendamento atualizado com sucesso\n");
    Thread.Sleep(1500);
}

void RemoverAgendamento()
{
    ListarAgendamentos();
    string cpf = Validador.ValidarStringCpf("\nCPF do paciente: ");
    string codigo = Validador.ValidarString("Código da consulta: ").ToUpper();
    var agendamento = agendamentos.FirstOrDefault(a => a.Paciente.Cpf == cpf && a.Consulta.Codigo == codigo);

    if (agendamento == null)
    {
        Console.WriteLine("Agendamento não encontrado\n");
        return;
    }

    agendamentos.Remove(agendamento);
    Console.WriteLine("\nAgendamento removido com sucesso\n");
    Thread.Sleep(1500);
}

// ---------------- CONSULTAS / RANKING ----------------

void MenuConsultasRank()
{
    while (true)
    {
        Console.WriteLine("\n§§§ -----  MENU CONSULTAS E RANK  ----- §§§");
        Console.WriteLine("§ 1 - Ranking de Agendamentos por Consulta §");
        Console.WriteLine("§ 2 - Histórico de Consultas por Paciente  §");
        Console.WriteLine("§ 3 - Filtrar Pacientes por Tipo Atendim.  §");
        Console.WriteLine("§ 0 -              Voltar                 §");
        Console.WriteLine("§§§ ------------------------------------- §§§\n");

        int escolha = Validador.ValidarIntIntervalo("Escolha a opção desejada: ", 0, 3);

        switch (escolha)
        {
            case 1:
                RankingAgendamentosPorConsulta();
                break;

            case 2:
                HistoricoConsultasPorPaciente();
                break;

            case 3:
                FiltrarPacientesPorTipoAtendimento();
                break;

            case 0:
                Console.WriteLine("Retornando...");
                Thread.Sleep(1000);
                return;
        }
    }
}

void RankingAgendamentosPorConsulta()
{
    ListarConsultas();
    string codigo = Validador.ValidarString("\nCódigo da consulta: ").ToUpper();
    var consulta = consultas.FirstOrDefault(c => c.Codigo == codigo);

    if (consulta == null)
    {
        Console.WriteLine("Consulta não encontrada\n");
        return;
    }

    var grupos = agendamentos.Where(a => a.Consulta.Codigo == codigo)
                              .GroupBy(a => a.TipoAtendimento)
                              .OrderByDescending(g => g.Count())
                              .ToList();

    if (grupos.Count == 0)
    {
        Console.WriteLine("Consulta sem pacientes agendados\n");
        return;
    }

    int total = 0;
    Console.WriteLine($"\nRanking de agendamentos - Consulta {codigo}");
    foreach (var grupo in grupos)
    {
        int quantidade = grupo.Count();
        total += quantidade;
        Console.WriteLine($"  {grupo.Key}: {quantidade} paciente(s)");
    }
    Console.WriteLine($"\nTotal de pacientes agendados: {total}");
    Continuar();
}

void HistoricoConsultasPorPaciente()
{
    ListarPacientes();
    string cpf = Validador.ValidarStringCpf("\nCPF do paciente: ");
    var paciente = pacientes.FirstOrDefault(p => p.Cpf == cpf);

    if (paciente == null)
    {
        Console.WriteLine("Paciente não encontrado\n");
        return;
    }

    var historico = agendamentos.Where(a => a.Paciente.Cpf == cpf)
                                 .OrderBy(a => a.Consulta.DataHoraPrevista)
                                 .ToList();

    if (historico.Count == 0)
    {
        Console.WriteLine("Paciente sem consultas agendadas\n");
        return;
    }

    Console.WriteLine($"\nHistórico de consultas - {paciente.Nome}");
    foreach (var agendamento in historico)
    {
        Console.WriteLine($"Consulta: {agendamento.Consulta.Codigo}");
        Console.WriteLine($"Médico responsável: {agendamento.Consulta.Medico.Nome}");
        Console.WriteLine($"Data prevista: {agendamento.Consulta.DataHoraPrevista}");
        Console.WriteLine($"Tipo de atendimento: {agendamento.TipoAtendimento}");
        Console.WriteLine($"Status: {agendamento.Consulta.Status}\n");
    }
    Continuar();
}

void FiltrarPacientesPorTipoAtendimento()
{
    ListarConsultas();
    string codigo = Validador.ValidarString("\nCódigo da consulta: ").ToUpper();
    var consulta = consultas.FirstOrDefault(c => c.Codigo == codigo);

    if (consulta == null)
    {
        Console.WriteLine("Consulta não encontrada\n");
        return;
    }

    TipoAtendimentoEnum tipo = EscolherTipoAtendimento();

    var filtrados = agendamentos.Where(a => a.Consulta.Codigo == codigo && a.TipoAtendimento == tipo)
                                 .OrderBy(a => a.Paciente.Nome)
                                 .ToList();

    if (filtrados.Count == 0)
    {
        Console.WriteLine($"Nenhum paciente do tipo {tipo} na consulta {codigo}\n");
        return;
    }

    int indice = 0;
    Console.WriteLine($"\nPacientes - Consulta {codigo} | Tipo {tipo}");
    foreach (var agendamento in filtrados)
    {
        Console.WriteLine($"{++indice}º - {agendamento.Paciente.Nome}");
    }
    Continuar();
}

void Continuar()
{
    Console.WriteLine("\nAperte qualquer tecla para continuar\n");
    Console.ReadKey();
}
