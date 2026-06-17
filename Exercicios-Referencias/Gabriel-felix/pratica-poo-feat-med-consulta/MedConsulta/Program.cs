using MedConsulta.Enums;
using MedConsulta.Helpers;
using MedConsulta.Models;

List<Medico> medicos = [];
List<Consulta> consultas = [];
List<Paciente> pacientes = [];
List<Agendamento> agendamentos = [];

Console.WriteLine("#### - Clínica MedConsulta - ####");

while (true)
{
    Menu();
    var opcao = Helper.ValidadorMenu();

    switch (opcao)
    {
        case 1:
            Console.Write("\nInforme o nome do médico: ");
            var nomeMedico = Helper.ValidadorTexto();

            Console.Write("\nInforme o Crm do médico (4 a 7 dígitos): ");
            var crmMedico = Helper.ValidadorCrm();

            if (medicos.Any(x => x.Crm.Equals(crmMedico)))
            {
                Console.WriteLine("\nCRM já cadastrado.");
                ReduzirTempo();
                continue;
            }

            Console.Write("\nInforme a Especialidade do médico: ");
            var especialidadeMedico = Helper.ValidadorTexto();

            Medico medico = new(crmMedico, nomeMedico, especialidadeMedico);

            medicos.Add(medico);

            MensagemSucesso();
            break;
        case 2:
            if (Helper.ValidadorListaVazia(medicos, "Médico"))
                continue;

            ListarItens(medicos, "Medico");
            ReduzirTempo();
            break;
        case 3:
            medico = ValidadorMedico();

            if (Helper.ValidadorObjetoNulo(medico))
                continue;

            Console.Write("\nInforme o nome do médico: ");
            nomeMedico = Helper.ValidadorTexto();

            Console.Write("\nInforme a Especialidade do médico: ");
            especialidadeMedico = Helper.ValidadorTexto();

            medico.AtulizarDados(nomeMedico, especialidadeMedico);

            MensagemSucesso();
            break;
        case 4:
            medico = ValidadorMedico();

            if (Helper.ValidadorObjetoNulo(medico))
                continue;

            Console.Write("\nInforme o Crm do médico (4 a 7 dígitos): ");
            crmMedico = Helper.ValidadorCrm();

            if (medicos.Any(x => x.Crm.Equals(crmMedico)))
            {
                Console.WriteLine("\nCRM já cadastrado.");
                ReduzirTempo();
                continue;
            }

            medico.AtulizarCrm(crmMedico);

            MensagemSucesso();
            break;
        case 5:
            medico = ValidadorMedico();

            if (Helper.ValidadorObjetoNulo(medico))
                continue;

            var posicao = medicos.IndexOf(medico);

            medicos.RemoveAt(posicao);
            MensagemSucesso();
            break;
        case 6:
            medico = ValidadorMedico();

            if (Helper.ValidadorObjetoNulo(medico))
                continue;

            Console.Write("\nInforme o código da consulta (4 dígitos - Exemplo:  0512): ");
            var codigoConsulta = Helper.ValidadorNumeroConsulta();

            if (consultas.Any(x => x.CodigoUnico.Equals(codigoConsulta)))
            {
                Console.WriteLine("\nConsulta já cadastrada.");
                ReduzirTempo();
                continue;
            }

            Console.Write("\nInforme o local de atendimento da consulta: ");
            var localAtendimentoConsulta = Helper.ValidadorTexto();

            Console.Write("\nInforme a data e hora previstas para a consulta: ");
            var dataHoraPrevistaConsulta = Helper.ValidadorDataHoraConsulta();

            Console.Write("\nInforme a duração em minutos da consulta: ");
            var duracaoConsulta = Helper.ValidadorNumeroInteiro();

            StatusConsultaEnum[] opcoes = Enum.GetValues<StatusConsultaEnum>();
            Console.WriteLine("\nStatus Consulta: \n");
            for (int i = 0; i < opcoes.Length; i++)
                Console.WriteLine($"{i + 1} - {opcoes[i]}");

            Console.Write("\nEscolha: ");
            var opcaoMenuStatusConsultaEnum = Helper.ValidadorStatusConsultaEnum();

            var opcaoStatusConsultaEnum = opcaoMenuStatusConsultaEnum switch
            {
                1 => StatusConsultaEnum.Pendente,
                2 => StatusConsultaEnum.Confirmada,
                3 => StatusConsultaEnum.Realizada,
                _ => StatusConsultaEnum.Cancelada,
            };

            Consulta consulta = new(medico, codigoConsulta, localAtendimentoConsulta, dataHoraPrevistaConsulta, duracaoConsulta, opcaoStatusConsultaEnum);

            consultas.Add(consulta);

            MensagemSucesso();
            break;
        case 7:
            if (Helper.ValidadorListaVazia(consultas, "Consulta"))
                continue;

            ListarItens(consultas, "Consulta");
            ReduzirTempo();
            break;
        case 8:
            consulta = ValidadorConsulta();

            if (Helper.ValidadorObjetoNulo(consulta))
                continue;

            Console.Write("\nInforme o novo código de consulta (4 dígitos - Exemplo:  0512): ");
            codigoConsulta = Helper.ValidadorNumeroConsulta();

            if (consultas.Any(x => x.CodigoUnico.Equals(codigoConsulta)))
            {
                Console.WriteLine("\nConsulta já cadastrada.");
                ReduzirTempo();
                continue;
            }

            consulta.AlterarCodigoUnico(codigoConsulta);

            MensagemSucesso();
            break;
        case 9:
            consulta = ValidadorConsulta();

            if (Helper.ValidadorObjetoNulo(consulta))
                continue;

            medico = ValidadorMedico();

            if (Helper.ValidadorObjetoNulo(medico))
                continue;

            Console.Write("\nInforme o local de atendimento da consulta: ");
            localAtendimentoConsulta = Helper.ValidadorTexto();

            Console.Write("\nInforme a data e hora previstas para a consulta: ");
            dataHoraPrevistaConsulta = Helper.ValidadorDataHoraConsulta();

            Console.Write("\nInforme a duração em minutos da consulta: ");
            duracaoConsulta = Helper.ValidadorNumeroInteiro();

            opcoes = Enum.GetValues<StatusConsultaEnum>();
            Console.WriteLine("\nStatus Consulta: \n");
            for (int i = 0; i < opcoes.Length; i++)
                Console.WriteLine($"{i + 1} - {opcoes[i]}");

            Console.Write("\nEscolha: ");
            opcaoMenuStatusConsultaEnum = Helper.ValidadorStatusConsultaEnum();

            opcaoStatusConsultaEnum = opcaoMenuStatusConsultaEnum switch
            {
                1 => StatusConsultaEnum.Pendente,
                2 => StatusConsultaEnum.Confirmada,
                3 => StatusConsultaEnum.Realizada,
                _ => StatusConsultaEnum.Cancelada,
            };

            consulta.AlterarDados(medico, localAtendimentoConsulta, dataHoraPrevistaConsulta, duracaoConsulta, opcaoStatusConsultaEnum);

            MensagemSucesso();
            break;
        case 10:
            consulta = ValidadorConsulta();

            if (Helper.ValidadorObjetoNulo(consulta))
                continue;

            if (!consulta.StatusConsulta.Equals(StatusConsultaEnum.Pendente) && !consulta.StatusConsulta.Equals(StatusConsultaEnum.Cancelada))
            {
                Console.WriteLine($"\nEstá consulta não pode ser excluída por ela está {consulta.StatusConsulta}.");
                ReduzirTempo();
                continue;
            }

            posicao = consultas.IndexOf(consulta);

            consultas.RemoveAt(posicao);

            MensagemSucesso();
            break;
        case 11:
            Console.Write("\nInforme o nome do paciente: ");
            var nomePaciente = Helper.ValidadorTexto();

            Console.Write("\nInforme o CPF do paciente (somente os dígitos): ");
            var cpfPaciente = Helper.ValidadorCpf();

            if (pacientes.Any(x => x.Cpf.Equals(cpfPaciente)))
            {
                Console.Write("\nCpf já cadastrado no sistema.");
                ReduzirTempo();
                continue;
            }

            Console.Write("\nInforme o número da carteirinha (12 caracteres): ");
            var carteirinhaPaciente = Helper.ValidadorCarteirinha();

            if (pacientes.Any(x => x.NumeroCarteirinha.Equals(carteirinhaPaciente)))
            {
                Console.WriteLine("\nCarteirinha já cadastrada no sistema.");
                ReduzirTempo();
                continue;
            }

            Console.Write("\nInforme a data de nascimento do pacietene: ");
            var dataNascimentoPaciente = Helper.ValidadorDataNascimento();

            Paciente paciente = new(nomePaciente, cpfPaciente, carteirinhaPaciente, dataNascimentoPaciente);

            pacientes.Add(paciente);

            MensagemSucesso();
            break;
        case 12:
            if (Helper.ValidadorListaVazia(pacientes, "Paciente"))
                continue;

            ListarItens(pacientes, "Paciente");

            ReduzirTempo();
            break;
        case 13:
            if (Helper.ValidadorListaVazia(pacientes, "Paciente"))
                continue;

            Console.Write("\nDigite o nome do paciente para busca: ");
            nomePaciente = Helper.ValidadorTexto().ToLower();

            var resultadoBusca = pacientes.Where(x => x.Nome.ToLower().Contains(nomePaciente)).ToList();

            if (resultadoBusca.Count == 0)
            {
                Console.WriteLine("\nNenhum paciente encontrado.");
                ReduzirTempo();
                continue;
            }

            Console.WriteLine($"\nPacientes encontrados com o nome \"{nomePaciente}\": \n");
            resultadoBusca.ForEach(x => Console.WriteLine($"# - {x}"));

            ReduzirTempo();
            break;
        case 14:
            if (Helper.ValidadorListaVazia(pacientes, "Paciente"))
                continue;

            Console.Write("\nDigite o nome do paciente para busca: ");
            nomePaciente = Helper.ValidadorTexto();

            resultadoBusca = pacientes.Where(x => x.Nome.Contains(nomePaciente)).ToList();

            if (resultadoBusca.Count == 0)
            {
                Console.WriteLine("\nNenhum paciente encontrado.");
                ReduzirTempo();
                continue;
            }

            Console.WriteLine($"\nPacientes encontrados com o nome \"{nomePaciente}\": \n");
            resultadoBusca.ForEach(x => Console.WriteLine($"# - {x}"));

            ReduzirTempo();
            break;
        case 15:
            paciente = ValidadorPaciente();

            if (Helper.ValidadorObjetoNulo(paciente))
                continue;

            Console.Write("\nInforme o novo Cpf para do paciente: ");
            cpfPaciente = Helper.ValidadorCpf();

            if (pacientes.Any(x => x.Cpf.Equals(cpfPaciente)))
            {
                Console.WriteLine("\nCpf já cadastrado.");
                ReduzirTempo();
                continue;
            }

            paciente.AlterarCpf(cpfPaciente);

            MensagemSucesso();
            break;
        case 16:
            paciente = ValidadorPaciente();

            if (Helper.ValidadorObjetoNulo(paciente))
                continue;

            Console.Write("\nInforme o novo número para a carteirinha (12 dígitos): ");
            carteirinhaPaciente = Helper.ValidadorCarteirinha();

            if (pacientes.Any(x => x.NumeroCarteirinha.Equals(carteirinhaPaciente)))
            {
                Console.WriteLine("\nCarteirinha já cadastrada.");
                ReduzirTempo();
                continue;
            }

            paciente.AlterarNumeroCarteirinha(carteirinhaPaciente);

            MensagemSucesso();
            break;
        case 17:
            paciente = ValidadorPaciente();

            if (Helper.ValidadorObjetoNulo(paciente))
                continue;

            Console.Write("\nInforme o nome do paciente: ");
            nomePaciente = Helper.ValidadorTexto();

            Console.Write("\nInforme a data de nascimento do pacietene: ");
            dataNascimentoPaciente = Helper.ValidadorDataNascimento();

            paciente.AlterarDados(nomePaciente, dataNascimentoPaciente);

            MensagemSucesso();
            break;
        case 18:
            paciente = ValidadorPaciente();

            if (Helper.ValidadorObjetoNulo(paciente))
                continue;

            if (!Helper.ValidadorListaVazia(agendamentos, "Agendamentos"))
            {
                var agendamentosPaciente = agendamentos.Where(x => x.Paciente.Id.Equals(paciente.Id)).ToList();

                var consultasAgendamentoPaciente = agendamentosPaciente.Where(x => !x.Consulta.StatusConsulta.Equals(StatusConsultaEnum.Cancelada)
                                                                                && !x.Consulta.StatusConsulta.Equals(StatusConsultaEnum.Realizada))
                                                                        .ToList();

                if (consultasAgendamentoPaciente.Count > 0)
                {
                    Console.WriteLine($"\nO Paciente deve cancelar ou realizar a consulta antes de ser cancelado.");
                    ReduzirTempo();
                    continue;
                }
            }

            posicao = pacientes.IndexOf(paciente);

            pacientes.RemoveAt(posicao);
            MensagemSucesso();
            break;
        case 19:
            consulta = ValidadorConsulta();

            if (Helper.ValidadorObjetoNulo(consulta))
                continue;

            if (consulta.DataHoraPrevista < DateTime.Now)
            {
                Console.WriteLine("A data da consulta não pode ser menor que hoje.");
                ReduzirTempo();
                continue;
            }

            paciente = ValidadorPaciente();

            if (Helper.ValidadorObjetoNulo(paciente))
                continue;

            if (agendamentos.Any(x => x.Paciente.Id.Equals(paciente.Id)) && agendamentos.Any(x => x.Consulta.Id.Equals(consulta.Id)))
            {
                Console.WriteLine("O paciente não pode está ter dois agendamentos para a mesma consulta.");
                continue;
            }

            TipoAtendimentoEnum[] opcoesAtendimento = Enum.GetValues<TipoAtendimentoEnum>();

            Console.WriteLine("\nTipo Atendimento: \n");
            for (int i = 0; i < opcoesAtendimento.Length; i++)
                Console.WriteLine($"{i + 1} - {opcoesAtendimento[i]}");

            Console.Write("\nEscolha: ");
            var opcaoMenuTiposAtendimentoltaEnum = Helper.ValidadorTipoAtendimentoEnum();

            var opcaoTipoAtendimentoEnum = opcaoMenuTiposAtendimentoltaEnum switch
            {
                1 => TipoAtendimentoEnum.Presencial,
                2 => TipoAtendimentoEnum.Telemedicina,
                _ => TipoAtendimentoEnum.ProcedimentoComplexo,
            };

            Console.Write("\nInforme o valor cobrado: ");
            var valorCobradoAgendamento = Helper.ValidadorDecimal();

            Agendamento agendamento = new(paciente, consulta, opcaoTipoAtendimentoEnum, valorCobradoAgendamento);

            agendamentos.Add(agendamento);

            MensagemSucesso();
            break;
        case 20:
            if (Helper.ValidadorListaVazia(agendamentos, "Agendamento"))
                continue;

            ListarItens(agendamentos, "Agendamento");
            break;
        case 21:
            agendamento = ValidadorAgendamento();

            if (Helper.ValidadorObjetoNulo(agendamento))
                continue;

            consulta = ValidadorConsulta();

            if (Helper.ValidadorObjetoNulo(consulta))
                continue;

            if (consulta.DataHoraPrevista < DateTime.Now)
            {
                Console.WriteLine("A data da consulta não pode ser menor que hoje.");
                ReduzirTempo();
                continue;
            }

            paciente = ValidadorPaciente();

            if (Helper.ValidadorObjetoNulo(paciente))
                continue;

            if (agendamentos.Any(x => x.Paciente.Id.Equals(paciente.Id)) && agendamentos.Any(x => x.Consulta.Id.Equals(consulta.Id)))
            {
                Console.WriteLine("O paciente não pode está ter dois agendamentos para a mesma consulta.");
                continue;
            }

            opcoesAtendimento = Enum.GetValues<TipoAtendimentoEnum>();

            Console.WriteLine("\nTipo Atendimento: \n");
            for (int i = 0; i < opcoesAtendimento.Length; i++)
                Console.WriteLine($"{i + 1} - {opcoesAtendimento[i]}");

            Console.Write("\nEscolha: ");
            opcaoMenuTiposAtendimentoltaEnum = Helper.ValidadorTipoAtendimentoEnum();

            opcaoTipoAtendimentoEnum = opcaoMenuTiposAtendimentoltaEnum switch
            {
                1 => TipoAtendimentoEnum.Presencial,
                2 => TipoAtendimentoEnum.Telemedicina,
                _ => TipoAtendimentoEnum.ProcedimentoComplexo,
            };

            Console.Write("\nInforme o valor cobrado: ");
            valorCobradoAgendamento = Helper.ValidadorDecimal();

            agendamento.AlterarDados(paciente, consulta, opcaoTipoAtendimentoEnum, valorCobradoAgendamento);

            MensagemSucesso();
            break;
        case 22:
            agendamento = ValidadorAgendamento();

            if (Helper.ValidadorObjetoNulo(agendamento))
                continue;

            if (!agendamento.Consulta.StatusConsulta.Equals(StatusConsultaEnum.Cancelada) || !agendamento.Consulta.StatusConsulta.Equals(StatusConsultaEnum.Realizada))
            {
                Console.WriteLine("\nA Consulta do agendamento precisa está realizada ou cancelada para ser excluída.");
                ReduzirTempo();
                continue;
            }

            posicao = agendamentos.IndexOf(agendamento);

            agendamentos.RemoveAt(posicao);
            break;
        case 23:
            Console.WriteLine("23 - Ranking de Agendamentos\n");
            // Ranking de Agendamentos por Consulta
            // -> Dado o código de uma consulta, exibir a quantidade de pacientes agendados
            // -> Detalhar a quantidade por tipo de atendimento
            // -> Ordenar os grupos em ordem decrescente de quantidade de pacientes

            consulta = ValidadorConsulta();

            if (Helper.ValidadorObjetoNulo(consulta))
                continue;

            var listaPacientesAgendados = agendamentos.Where(x => x.Consulta.Id.Equals(consulta.Id))
                                                      .ToList();

            break;
        case 24:
            Console.WriteLine("24 - Histórico de Consultas por Paciente\n");
            break;
        case 25:
            Console.WriteLine("25 - Filtro por Tipo de Atendimento\n");
            break;
        default:
            Console.WriteLine("Sistema encerrado.");
            ReduzirTempo();
            Environment.Exit(0);
            break;
    }
    continue;
}

void MensagemSucesso()
{
    Console.WriteLine($"\nAção concluída com sucesso!");
    ReduzirTempo();
}

void ListarItens<T>(List<T> lista, string texto)
{
    Console.WriteLine($"\nListar {texto} Cadastrados: \n");
    lista.ForEach(x => Console.WriteLine($"# - {x}"));
}

Medico ValidadorMedico()
{
    if (Helper.ValidadorListaVazia(medicos, "Médico"))
        return null;

    ListarItens(medicos, "Médico");

    Console.Write("\nInforme o Id do médico desejado: ");
    var idMedico = Helper.ValidadorGuid();

    var medico = medicos.FirstOrDefault(x => x.Id.Equals(idMedico));

    return medico;
}

Consulta ValidadorConsulta()
{
    if (Helper.ValidadorListaVazia(consultas, "Consulta"))
        return null;

    ListarItens(consultas, "Consulta");

    Console.Write("\nInforme o Id da consulta desejada: ");
    var idConsulta = Helper.ValidadorGuid();

    var consulta = consultas.FirstOrDefault(x => x.Id.Equals(idConsulta));

    return consulta;
}

Paciente ValidadorPaciente()
{
    if (Helper.ValidadorListaVazia(pacientes, "Paciente"))
        return null;

    ListarItens(pacientes, "Paciente");

    Console.Write("\nInforme o Id da paciente desejado: ");
    var idPaciente = Helper.ValidadorGuid();

    var paciente = pacientes.FirstOrDefault(x => x.Id.Equals(idPaciente));

    return paciente;
}

Agendamento ValidadorAgendamento()
{
    if (Helper.ValidadorListaVazia(agendamentos, "Agendamento"))
        return null;

    ListarItens(agendamentos, "Agendamento");

    Console.Write("\nInforme o Id da agendamento desejado: ");
    var idAgendamento = Helper.ValidadorGuid();

    var agendamento = agendamentos.FirstOrDefault(x => x.Id.Equals(idAgendamento));

    return agendamento;
}

void Menu()
{
    Console.WriteLine("\nEscolha uma das opções: \n");

    Console.WriteLine("#### - Médico - ####\n");

    Console.WriteLine("1 - Cadastrar Médico\n");
    Console.WriteLine("2 - Listar Médicos Cadastrados\n");
    Console.WriteLine("3 - Alterar Nome e Especialidade\n");
    Console.WriteLine("4 - Alterar CRM\n");
    Console.WriteLine("5 - Excluir Médico");

    Console.WriteLine("\n#### - Consulta - ####\n");

    Console.WriteLine("6 - Cadastrar Consulta\n");
    Console.WriteLine("7 - Listar Consultas Cadastradas\n");
    Console.WriteLine("8 - Alterar Código de uma Consulta\n");
    Console.WriteLine("9 - Alterar Informações da Consulta\n");
    Console.WriteLine("10 - Excluir Consulta");

    Console.WriteLine("\n#### - Paciente - ####\n");

    Console.WriteLine("11 - Cadastrar Paciente\n");
    Console.WriteLine("12 - Listar Pacientes Cadastrados\n");
    Console.WriteLine("13 - Procurar Pacientes por Nome\n");
    Console.WriteLine("14 - Procurar Pacientes por Nome Específico\n");
    Console.WriteLine("15 - Alterar Cpf\n");
    Console.WriteLine("16 - Alterar Número Carteirinha\n");
    Console.WriteLine("17 - Alterar Dados do Paciente\n");
    Console.WriteLine("18 - Excluir Paciente");

    Console.WriteLine("\n#### - Agendamento - ####\n");

    Console.WriteLine("19 - Cadastrar Agendamento\n");
    Console.WriteLine("20 - Listar Agendamentos Cadastrados\n");
    Console.WriteLine("21 - Alterar Dados de Agendamento\n");
    Console.WriteLine("22 - Excluir Agendamento");

    Console.WriteLine("\n#### - Funcionalidades - ####\n");

    Console.WriteLine("23 - Ranking de Agendamentos\n");
    Console.WriteLine("24 - Histórico de Consultas por Paciente\n");
    Console.WriteLine("25 - Filtro por Tipo de Atendimento\n");

    Console.WriteLine("0 - Sair");

    Console.Write("\nDigite uma opção: ");
}

void ReduzirTempo() => Thread.Sleep(1500);
