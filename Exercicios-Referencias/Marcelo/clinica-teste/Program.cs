using System.Globalization;
using clinica_teste.Enums;
using MedConsulta.Enums;
using MedConsulta.SistemaMedConsulta;

SistemaMedConsulta sistema = new SistemaMedConsulta();

while (true)
{
    Console.WriteLine("\n=== MedConsulta ===");
    Console.WriteLine("1. Médicos");
    Console.WriteLine("2. Pacientes");
    Console.WriteLine("3. Consultas");
    Console.WriteLine("4. Agendamentos");
    Console.WriteLine("5. Relatórios");
    Console.WriteLine("0. Sair");
    Console.Write("\nEscolha: ");
    string entrada = Console.ReadLine();

    int opcao;
    while (!int.TryParse(entrada, out opcao) || opcao < 0 || opcao > 5)
    {
        Console.Write("Opção inválida. Escolha: ");
        entrada = Console.ReadLine();
    }

    switch (opcao)
    {
        case 1:
            MenuMedicos();
            break;

        case 2:
            MenuPacientes();
            break;

        case 3:
            MenuConsultas();
            break;

        case 4:
            MenuAgendamentos();
            break;

        case 5:
            MenuRelatorios();
            break;

        case 0:
            return;
    }
}

void MenuMedicos()
{
    while (true)
    {
        Console.WriteLine("\n=== Médicos ===");
        Console.WriteLine("1. Cadastrar | 2. Listar | 3. Editar | 4. Excluir | 0. Voltar");
        Console.Write("Escolha: ");
        string entrada = Console.ReadLine();

        int opcao;
        while (!int.TryParse(entrada, out opcao) || opcao < 0 || opcao > 4)
        {
            Console.Write("Opção inválida. Escolha: ");
            entrada = Console.ReadLine();
        }

        switch (opcao)
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
                ExcluirMedico();
                break;

            case 0:
                return;
        }
    }
}

void MenuPacientes()
{
    while (true)
    {
        Console.WriteLine("\n=== Pacientes ===");
        Console.WriteLine("1. Cadastrar | 2. Listar | 3. Editar | 4. Excluir | 0. Voltar");
        Console.Write("Escolha: ");
        string entrada = Console.ReadLine();

        int opcao;
        while (!int.TryParse(entrada, out opcao) || opcao < 0 || opcao > 4)
        {
            Console.Write("Opção inválida. Escolha: ");
            entrada = Console.ReadLine();
        }

        switch (opcao)
        {
            case 1:
                CadastrarPaciente();
                break;

            case 2:
                ListarPacientes();
                break;

            case 3:
                EditarPaciente();
                break;

            case 4:
                ExcluirPaciente();
                break;

            case 0:
                return;
        }
    }
}

void MenuConsultas()
{
    while (true)
    {
        Console.WriteLine("\n=== Consultas ===");
        Console.WriteLine("1. Cadastrar | 2. Listar | 3. Editar | 4. Excluir | 5. Alterar Status | 0. Voltar");
        Console.Write("Escolha: ");
        string entrada = Console.ReadLine();

        int opcao;
        while (!int.TryParse(entrada, out opcao) || opcao < 0 || opcao > 5)
        {
            Console.Write("Opção inválida. Escolha: ");
            entrada = Console.ReadLine();
        }

        switch (opcao)
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
                ExcluirConsulta();
                break;

            case 5:
                AlterarStatusConsulta();
                break;

            case 0:
                return;
        }
    }
}

void MenuAgendamentos()
{
    while (true)
    {
        Console.WriteLine("\n=== Agendamentos ===");
        Console.WriteLine("1. Cadastrar | 2. Listar | 3. Editar | 4. Excluir | 0. Voltar");
        Console.Write("Escolha: ");
        string entrada = Console.ReadLine();

        int opcao;
        while (!int.TryParse(entrada, out opcao) || opcao < 0 || opcao > 4)
        {
            Console.Write("Opção inválida. Escolha: ");
            entrada = Console.ReadLine();
        }

        switch (opcao)
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
                ExcluirAgendamento();
                break;

            case 0:
                return;
        }
    }
}

void MenuRelatorios()
{
    while (true)
    {
        Console.WriteLine("\n=== Relatórios ===");
        Console.WriteLine("1. Buscar Paciente por Nome | 2. Ranking de Agendamentos por Consulta | 3. Histórico de Consultas por Paciente | 4. Filtrar Pacientes por Tipo de Atendimento | 0. Voltar");
        Console.Write("Escolha: ");
        string entrada = Console.ReadLine();

        int opcao;
        while (!int.TryParse(entrada, out opcao) || opcao < 0 || opcao > 4)
        {
            Console.Write("Opção inválida. Escolha: ");
            entrada = Console.ReadLine();
        }

        switch (opcao)
        {
            case 1:
                BuscarPacientePorNome();
                break;

            case 2:
                RankingAgendamentosPorConsulta();
                break;

            case 3:
                HistoricoConsultasPorPaciente();
                break;

            case 4:
                FiltrarPacientesConsultaPorTipo();
                break;

            case 0:
                return;
        }
    }
}

void CadastrarMedico()
{
    Console.WriteLine("=== Cadastrar Médico ===");

    Console.Write("Nome: ");
    string nome = ValidarString(Console.ReadLine());

    if (nome == null)
        return;

    Console.Write("CRM (ex.: CRM12345): ");
    string crm = ValidarString(Console.ReadLine());

    if (crm == null)
        return;

    Console.Write("Especialidade: ");
    string especialidade = ValidarString(Console.ReadLine());

    if (especialidade == null)
        return;

    Console.WriteLine(sistema.CadastrarMedico(nome, crm, especialidade));
}

void ListarMedicos()
{
    Console.WriteLine("=== Lista de Médicos ===");
    Console.WriteLine(sistema.ListarMedicos());
}

void EditarMedico()
{
    Console.WriteLine("=== Editar Médico ===");
    string medicos = sistema.ListarMedicos();
    Console.WriteLine(medicos);

    if (medicos == "Erro: lista vazia")
        return;

    Console.Write("ID do médico: ");
    Guid? idOpcional = ValidarId(Console.ReadLine());

    if (idOpcional == null)
        return;

    Guid id = idOpcional.Value;

    Console.Write("Novo nome (Enter para manter): ");
    string nome = Console.ReadLine();

    Console.Write("Nova especialidade (Enter para manter): ");
    string especialidade = Console.ReadLine();

    Console.WriteLine(sistema.EditarMedico(id, nome, especialidade));
}

void ExcluirMedico()
{
    Console.WriteLine("=== Excluir Médico ===");
    string medicos = sistema.ListarMedicos();
    Console.WriteLine(medicos);

    if (medicos == "Erro: lista vazia")
        return;

    Console.Write("ID do médico: ");
    Guid? idOpcional = ValidarId(Console.ReadLine());

    if (idOpcional == null)
        return;

    Guid id = idOpcional.Value;

    Console.WriteLine(sistema.ExcluirMedico(id));
}

void CadastrarPaciente()
{
    Console.WriteLine("=== Cadastrar Paciente ===");

    Console.Write("Nome completo: ");
    string nomeCompleto = ValidarString(Console.ReadLine());

    if (nomeCompleto == null)
        return;

    Console.Write("Data de nascimento (dd/MM/yyyy): ");
    DateTime? dataNascimentoOpcional = ValidarData(Console.ReadLine());

    if (dataNascimentoOpcional == null)
        return;

    DateTime dataNascimento = dataNascimentoOpcional.Value;

    Console.Write("CPF (11 dígitos): ");
    string cpf = ValidarString(Console.ReadLine());

    if (cpf == null)
        return;

    Console.Write("Carteirinha do plano: ");
    string carteirinha = ValidarString(Console.ReadLine());

    if (carteirinha == null)
        return;

    Console.WriteLine(sistema.CadastrarPaciente(nomeCompleto, dataNascimento, cpf, carteirinha));
}

void ListarPacientes()
{
    Console.WriteLine("=== Lista de Pacientes ===");
    Console.WriteLine(sistema.ListarPacientes());
}

void EditarPaciente()
{
    Console.WriteLine("=== Editar Paciente ===");
    string pacientes = sistema.ListarPacientes();
    Console.WriteLine(pacientes);

    if (pacientes == "Erro: lista vazia")
        return;

    Console.Write("ID do paciente: ");
    Guid? idOpcional = ValidarId(Console.ReadLine());

    if (idOpcional == null)
        return;

    Guid id = idOpcional.Value;

    Console.Write("Novo nome completo (Enter para manter): ");
    string nomeCompleto = Console.ReadLine();

    Console.Write("Nova data de nascimento (dd/MM/yyyy, Enter para manter): ");
    string dataNascTexto = Console.ReadLine();
    int tentativasNasc = 0;

    DateTime dataNascConvertida = default;
    while (!string.IsNullOrWhiteSpace(dataNascTexto) && !DateTime.TryParseExact(dataNascTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataNascConvertida))
    {
        if (++tentativasNasc >= 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return;
        }

        Console.Write("Data inválida. Tente novamente: ");
        dataNascTexto = Console.ReadLine();
    }
    DateTime? dataNascimento = string.IsNullOrWhiteSpace(dataNascTexto) ? null : dataNascConvertida;

    Console.Write("Nova carteirinha (Enter para manter): ");
    string carteirinha = Console.ReadLine();

    Console.WriteLine(sistema.EditarPaciente(id, nomeCompleto, dataNascimento, carteirinha));
}

void ExcluirPaciente()
{
    Console.WriteLine("=== Excluir Paciente ===");
    string pacientes = sistema.ListarPacientes();
    Console.WriteLine(pacientes);

    if (pacientes == "Erro: lista vazia")
        return;

    Console.Write("ID do paciente: ");
    Guid? idOpcional = ValidarId(Console.ReadLine());

    if (idOpcional == null)
        return;

    Guid id = idOpcional.Value;

    Console.WriteLine(sistema.ExcluirPaciente(id));
}

void CadastrarConsulta()
{
    Console.WriteLine("=== Cadastrar Consulta ===");

    Console.Write("Código (ex.: CONS0512): ");
    string codigo = ValidarString(Console.ReadLine());

    if (codigo == null)
        return;

    Console.Write("Local de atendimento: ");
    string local = ValidarString(Console.ReadLine());

    if (local == null)
        return;

    Console.Write("Data e hora prevista (dd/MM/yyyy HH:mm): ");
    DateTime? dataHoraOpcional = ValidarDataHora(Console.ReadLine());

    if (dataHoraOpcional == null)
        return;

    DateTime dataHoraPrevista = dataHoraOpcional.Value;

    int duracaoMinutos;
    Console.Write("Duração em minutos: ");
    string entradaDuracao = Console.ReadLine();
    while (!int.TryParse(entradaDuracao, out duracaoMinutos))
    {
        Console.Write("Valor inválido. Tente novamente: ");
        entradaDuracao = Console.ReadLine();
    }

    string medicos = sistema.ListarMedicos();
    Console.WriteLine(medicos);

    if (medicos == "Erro: lista vazia")
        return;

    Console.Write("CRM do médico responsável: ");
    string crm = ValidarString(Console.ReadLine());

    if (crm == null)
        return;

    var medico = sistema.BuscarMedicoPorCrm(crm);

    if (medico == null)
    {
        Console.WriteLine("Erro: médico não encontrado");
        return;
    }

    Console.WriteLine(sistema.CadastrarConsulta(codigo, local, dataHoraPrevista, duracaoMinutos, medico.Id));
}

void ListarConsultas()
{
    Console.WriteLine("=== Lista de Consultas ===");
    Console.WriteLine(sistema.ListarConsultas());
}

void EditarConsulta()
{
    Console.WriteLine("=== Editar Consulta ===");
    string consultas = sistema.ListarConsultas();
    Console.WriteLine(consultas);

    if (consultas == "Erro: lista vazia")
        return;

    Console.Write("ID da consulta: ");
    Guid? idOpcional = ValidarId(Console.ReadLine());

    if (idOpcional == null)
        return;

    Guid id = idOpcional.Value;

    Console.Write("Novo local (Enter para manter): ");
    string local = Console.ReadLine();

    Console.Write("Nova data e hora prevista (dd/MM/yyyy HH:mm, Enter para manter): ");
    string dataHoraTexto = Console.ReadLine();
    int tentativasDataHora = 0;

    DateTime dataHoraConvertida = default;
    while (!string.IsNullOrWhiteSpace(dataHoraTexto) && !DateTime.TryParseExact(dataHoraTexto, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataHoraConvertida))
    {
        if (++tentativasDataHora >= 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return;
        }

        Console.Write("Data/hora inválida. Tente novamente: ");
        dataHoraTexto = Console.ReadLine();
    }
    DateTime? dataHoraPrevista = string.IsNullOrWhiteSpace(dataHoraTexto) ? null : dataHoraConvertida;

    Console.Write("Nova duração em minutos (Enter para manter): ");
    string duracaoTexto = Console.ReadLine();
    int tentativasDuracao = 0;

    while (!string.IsNullOrWhiteSpace(duracaoTexto) && !int.TryParse(duracaoTexto, out int _))
    {
        if (++tentativasDuracao >= 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return;
        }

        Console.Write("Valor inválido. Tente novamente: ");
        duracaoTexto = Console.ReadLine();
    }
    int? duracaoMinutos = string.IsNullOrWhiteSpace(duracaoTexto) ? null : int.Parse(duracaoTexto);

    Console.WriteLine(sistema.EditarConsulta(id, local, dataHoraPrevista, duracaoMinutos));
}

void ExcluirConsulta()
{
    Console.WriteLine("=== Excluir Consulta ===");
    string consultas = sistema.ListarConsultas();
    Console.WriteLine(consultas);

    if (consultas == "Erro: lista vazia")
        return;

    Console.Write("ID da consulta: ");
    Guid? idOpcional = ValidarId(Console.ReadLine());

    if (idOpcional == null)
        return;

    Guid id = idOpcional.Value;

    Console.WriteLine(sistema.ExcluirConsulta(id));
}

void AlterarStatusConsulta()
{
    Console.WriteLine("=== Alterar Status da Consulta ===");
    string consultas = sistema.ListarConsultas();
    Console.WriteLine(consultas);

    if (consultas == "Erro: lista vazia")
        return;

    Console.Write("Código da consulta: ");
    string codigo = ValidarString(Console.ReadLine());

    if (codigo == null)
        return;

    int opcaoStatus = 0;
    string entradaStatus;
    int tentativas = 0;

    while (opcaoStatus < 1 || opcaoStatus > 4)
    {
        if (++tentativas > 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return;
        }

        Console.WriteLine("Status: 1. Pendente | 2. Confirmada | 3. Realizada | 4. Cancelada");
        Console.Write("Escolha: ");
        entradaStatus = Console.ReadLine();
        int.TryParse(entradaStatus, out opcaoStatus);
    }
    StatusConsultaEnum novoStatus = (StatusConsultaEnum)opcaoStatus;

    Console.WriteLine(sistema.AlterarStatusConsulta(codigo, novoStatus));
}

void CadastrarAgendamento()
{
    Console.WriteLine("=== Cadastrar Agendamento ===");

    string pacientes = sistema.ListarPacientes();
    Console.WriteLine(pacientes);

    if (pacientes == "Erro: lista vazia")
        return;

    Console.Write("CPF do paciente: ");
    string cpf = ValidarString(Console.ReadLine());

    if (cpf == null)
        return;

    var paciente = sistema.BuscarPacientePorCpf(cpf);

    if (paciente == null)
    {
        Console.WriteLine("Erro: paciente não encontrado");
        return;
    }

    string consultas = sistema.ListarConsultas();
    Console.WriteLine(consultas);

    if (consultas == "Erro: lista vazia")
        return;

    Console.Write("Código da consulta: ");
    string codigoConsulta = ValidarString(Console.ReadLine());

    if (codigoConsulta == null)
        return;

    var consulta = sistema.BuscarConsultaPorCodigo(codigoConsulta);

    if (consulta == null)
    {
        Console.WriteLine("Erro: consulta não encontrada");
        return;
    }

    int opcaoTipo = 0;
    string entradaTipo;
    int tentativasTipo = 0;

    while (opcaoTipo < 1 || opcaoTipo > 3)
    {
        if (++tentativasTipo > 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return;
        }

        Console.WriteLine("Tipo de atendimento: 1. Presencial | 2. Telemedicina | 3. Procedimento Complexo");
        Console.Write("Escolha: ");
        entradaTipo = Console.ReadLine();
        int.TryParse(entradaTipo, out opcaoTipo);
    }
    TipoAtendimentoEnum tipoAtendimento = (TipoAtendimentoEnum)opcaoTipo;

    Console.Write("Valor cobrado (R$): ");
    decimal? valorOpcional = ValidarDecimal(Console.ReadLine());

    if (valorOpcional == null)
        return;

    decimal valorCobrado = valorOpcional.Value;

    Console.WriteLine(sistema.CadastrarAgendamento(paciente.Id, consulta.Id, tipoAtendimento, valorCobrado));
}

void ListarAgendamentos()
{
    Console.WriteLine("=== Lista de Agendamentos ===");
    Console.WriteLine(sistema.ListarAgendamentos());
}

void EditarAgendamento()
{
    Console.WriteLine("=== Editar Agendamento ===");
    string agendamentos = sistema.ListarAgendamentos();
    Console.WriteLine(agendamentos);

    if (agendamentos == "Erro: lista vazia")
        return;

    Console.Write("ID do agendamento: ");
    Guid? idOpcional = ValidarId(Console.ReadLine());

    if (idOpcional == null)
        return;

    Guid id = idOpcional.Value;

    Console.WriteLine("Novo tipo de atendimento (0 para manter): 1. Presencial | 2. Telemedicina | 3. Procedimento Complexo");
    Console.Write("Escolha: ");
    string entradaTipo = Console.ReadLine();
    int opcaoTipo;
    int tentativasTipo = 0;

    while (!int.TryParse(entradaTipo, out opcaoTipo) || opcaoTipo < 0 || opcaoTipo > 3)
    {
        if (++tentativasTipo >= 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return;
        }

        Console.Write("Opção inválida. Escolha: ");
        entradaTipo = Console.ReadLine();
    }
    TipoAtendimentoEnum? tipoAtendimento = opcaoTipo > 0 ? (TipoAtendimentoEnum)opcaoTipo : null;

    Console.Write("Novo valor cobrado (Enter para manter): ");
    string valorTexto = Console.ReadLine();
    int tentativasValor = 0;

    while (!string.IsNullOrWhiteSpace(valorTexto) && !decimal.TryParse(valorTexto, out decimal _))
    {
        if (++tentativasValor >= 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return;
        }

        Console.Write("Valor inválido. Tente novamente: ");
        valorTexto = Console.ReadLine();
    }
    decimal? valorCobrado = string.IsNullOrWhiteSpace(valorTexto) ? null : decimal.Parse(valorTexto);

    Console.WriteLine(sistema.EditarAgendamento(id, tipoAtendimento, valorCobrado));
}

void ExcluirAgendamento()
{
    Console.WriteLine("=== Excluir Agendamento ===");
    string agendamentos = sistema.ListarAgendamentos();
    Console.WriteLine(agendamentos);

    if (agendamentos == "Erro: lista vazia")
        return;

    Console.Write("ID do agendamento: ");
    Guid? idOpcional = ValidarId(Console.ReadLine());

    if (idOpcional == null)
        return;

    Guid id = idOpcional.Value;

    Console.WriteLine(sistema.ExcluirAgendamento(id));
}

void BuscarPacientePorNome()
{
    Console.WriteLine("=== Buscar Paciente por Nome ===");

    Console.Write("Nome (parcial): ");
    string termo = ValidarString(Console.ReadLine());

    if (termo == null)
        return;

    Console.WriteLine(sistema.BuscarPacientesPorNome(termo));
}

void RankingAgendamentosPorConsulta()
{
    Console.WriteLine("=== Ranking de Agendamentos por Consulta ===");
    string consultas = sistema.ListarConsultas();
    Console.WriteLine(consultas);

    if (consultas == "Erro: lista vazia")
        return;

    Console.Write("Código da consulta: ");
    string codigo = ValidarString(Console.ReadLine());

    if (codigo == null)
        return;

    Console.WriteLine(sistema.RankingAgendamentosPorConsulta(codigo));
}

void HistoricoConsultasPorPaciente()
{
    Console.WriteLine("=== Histórico de Consultas por Paciente ===");
    string pacientes = sistema.ListarPacientes();
    Console.WriteLine(pacientes);

    if (pacientes == "Erro: lista vazia")
        return;

    Console.Write("CPF do paciente: ");
    string cpf = ValidarString(Console.ReadLine());

    if (cpf == null)
        return;

    Console.WriteLine(sistema.HistoricoConsultasPorPaciente(cpf));
}

void FiltrarPacientesConsultaPorTipo()
{
    Console.WriteLine("=== Filtrar Pacientes por Tipo de Atendimento ===");
    string consultas = sistema.ListarConsultas();
    Console.WriteLine(consultas);

    if (consultas == "Erro: lista vazia")
        return;

    Console.Write("Código da consulta: ");
    string codigo = ValidarString(Console.ReadLine());

    if (codigo == null)
        return;

    int opcaoTipo = 0;
    string entradaTipo;
    int tentativas = 0;

    while (opcaoTipo < 1 || opcaoTipo > 3)
    {
        if (++tentativas > 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return;
        }

        Console.WriteLine("Tipo de atendimento: 1. Presencial | 2. Telemedicina | 3. Procedimento Complexo");
        Console.Write("Escolha: ");
        entradaTipo = Console.ReadLine();
        int.TryParse(entradaTipo, out opcaoTipo);
    }
    TipoAtendimentoEnum tipoAtendimento = (TipoAtendimentoEnum)opcaoTipo;

    Console.WriteLine(sistema.FiltrarPacientesConsultaPorTipo(codigo, tipoAtendimento));
}

string ValidarString(string texto)
{
    int tentativas = 0;
    while (string.IsNullOrWhiteSpace(texto))
    {
        if (++tentativas >= 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return null;
        }

        Console.Write("Valor inválido, tente novamente: ");
        texto = Console.ReadLine();
    }
    return texto;
}

Guid? ValidarId(string texto)
{
    int tentativas = 0;
    Guid id;
    while (!Guid.TryParse(texto, out id))
    {
        if (++tentativas >= 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return null;
        }

        Console.Write("ID inválido, tente novamente: ");
        texto = Console.ReadLine();
    }
    return id;
}

DateTime? ValidarData(string texto)
{
    int tentativas = 0;
    DateTime data;
    while (!DateTime.TryParseExact(texto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
    {
        if (++tentativas >= 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return null;
        }

        Console.Write("Data inválida, tente novamente (dd/MM/yyyy): ");
        texto = Console.ReadLine();
    }
    return data;
}

DateTime? ValidarDataHora(string texto)
{
    int tentativas = 0;
    DateTime dataHora;
    while (!DateTime.TryParseExact(texto, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataHora))
    {
        if (++tentativas >= 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return null;
        }

        Console.Write("Data/hora inválida, tente novamente (dd/MM/yyyy HH:mm): ");
        texto = Console.ReadLine();
    }
    return dataHora;
}

decimal? ValidarDecimal(string texto)
{
    int tentativas = 0;
    decimal valor;
    while (!decimal.TryParse(texto, out valor))
    {
        if (++tentativas >= 3)
        {
            Console.WriteLine("Número máximo de tentativas atingido. Voltando ao menu.");
            return null;
        }

        Console.Write("Valor inválido, tente novamente: ");
        texto = Console.ReadLine();
    }
    return valor;
}
