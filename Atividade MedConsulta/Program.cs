using Atividade_MedConsulta.Models;
using Atividade_MedConsulta.Helpers;
using Atividade_MedConsulta.Enums;

List<Medico> medicos = [];
List<Paciente> pacientes = [];
List<Consulta> consultas = [];
List<Agendamento> agendamentos = [];

while (true)
{
    Console.WriteLine($"\n=== MedConsulta ===");
    Console.WriteLine($"1. Medicos");
    Console.WriteLine($"2. Pacientes");
    Console.WriteLine($"3. Consultas");
    Console.WriteLine($"4. Agendamentos");
    Console.WriteLine($"5. Relatorios");
    Console.WriteLine($"0. Sair");
    Console.Write($"Escolha: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1": 
            MenuMedicos();
            break;
        case "2":
            MenuPacientes();
            break;
        case "3":
            MenuConsultas();
            break;
        case "4":
            MenuAgendamentos();
            break;
        case "5":
            MenuRelatorios();
            break;
        case "0":
            return;
        default: 
            Console.WriteLine("Opcao Invalida.");
            break;
    }
}

void MenuMedicos(){
    while (true)
    {
        Console.WriteLine("\n=== Medicos ===");
        Console.WriteLine($"1. Cadastrar");
        Console.WriteLine($"2. Listar");
        Console.WriteLine($"3. Editar");
        Console.WriteLine($"4. Excluir");
        Console.WriteLine($"0. Voltar");
        Console.Write("Escolha: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1": 
                CadastrarMedico();
                break;
            case "2":
                ListarMedico();
                break;
            case "3":
                EditarMedico();
                break;
            case "4":
                ExcluirMedico();
                break;
            case "0": 
                return;
            default:
                Console.WriteLine("Opcao Invalida");
                break;
        }
    }
        void CadastrarMedico()
    {
        string crm = Validador.ValidarCrm("CRM (ex: CRM123456): ");
        string nome = Validador.ValidarTexto("Nome: ");
        string especialidade = Validador.ValidarTexto("Especialidade: ");

        if(medicos.Any(m => m.Crm == crm))
        {
            Console.WriteLine("[ERRO] CRM ja cadastrado.");
            return;
        }

        medicos.Add(new Medico(crm,nome,especialidade));
        Console.WriteLine("[OK] Medico cadastrado com sucesso");
    }
        void ListarMedico()
    {
        if (medicos.Count == 0)
        {
            Console.WriteLine("Nenhum medico registrado encontrado");
            return;
        }

        medicos.ForEach(m => Console.WriteLine(m));
    }
        void EditarMedico()
    {
        
        string crm = Validador.ValidarCrm("CRM do medico a editar: ");
    }
        void ExcluirMedico(){}
} 

void MenuPacientes()
{
    while (true)
    {
        Console.WriteLine($"\n=== Pacientes ===");
        Console.WriteLine($"1. Cadastrar");
        Console.WriteLine($"2. Listar");
        Console.WriteLine($"3. Editar");
        Console.WriteLine($"4. Excluir");
        Console.WriteLine($"0. Voltar");
        Console.Write("Escolha: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CadastrarPaciente();
                break;
            case "2":
                ListarPaciente();
                break;
            case "3":
                EditarPaciente();
                break;
            case "4":
                ExcluirPaciente();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opcao Invalida. Tente novamente");
                break;
        }
    }
        void CadastrarPaciente(){}
        void ListarPaciente(){}
        void EditarPaciente(){}
        void ExcluirPaciente(){}
}

void MenuConsultas()
{
    while (true)
    {
        Console.WriteLine($"\n=== Consultas ===");
        Console.WriteLine($"1. Cadastrar");
        Console.WriteLine($"2. Listar");
        Console.WriteLine($"3. Editar");
        Console.WriteLine($"4. Excluir");
        Console.WriteLine($"0. Voltar");
        Console.Write($"Escolha: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CadastrarConsulta();
                break;
            case "2":
                ListarConsulta();
                break;
            case "3":
                EditarConsulta();
                break;
            case "4":
                ExcluirConsulta();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opcao Invalida. Tente Novamente");
                break;
        }
    }
    void CadastrarConsulta(){}
    void ListarConsulta(){}
    void EditarConsulta(){}
    void ExcluirConsulta(){}
}

void MenuAgendamentos()
{
    while (true)
    {
        Console.WriteLine("=== Agendamentos ===");
        Console.WriteLine($"1. Cadastrar");
        Console.WriteLine($"2. Listar");
        Console.WriteLine($"3. Editar");
        Console.WriteLine($"4. Excluir");
        Console.WriteLine($"0. Sair");
        Console.Write($"Escolha: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1": 
                CadastrarAgendamento();
                break;
            case "2":
                ListarAgendamento();
                break;
            case "3":
                EditarAgendamento();
                break;
            case "4":
                ExcluirAgendamento();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opcao Invalida.");
                break;
        }
    }
    void CadastrarAgendamento(){}
    void ListarAgendamento(){}
    void EditarAgendamento(){}
    void ExcluirAgendamento(){}
}

void MenuRelatorios()
{
    while (true)
    {
        Console.WriteLine($"\n=== Relatorios ===");
        Console.WriteLine($"1. Buscar Paciente por Nome");
        Console.WriteLine($"2. Ranking de Agendamentos por Consulta");
        Console.WriteLine($"3. Historico de Consultas por Paciente");
        Console.WriteLine($"4. Filtrar Pacientes por Tipo de Atendimento");
        Console.WriteLine($"0. Voltar");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                BuscarPacientePorNome();
                break;
            case "2":
                RankingAgendamentosConsulta();
                break;
            case "3":
                HistoricoConsultasPaciente();
                break;
            case "4":
                FiltrarPacientesPorTipoAtendimento();
                break;
            case "0":
                return;
            default: 
                Console.WriteLine("Opcao Invalida");
                break;
        }
    }
    
    void BuscarPacientePorNome(){}
    void RankingAgendamentosConsulta(){}
    void HistoricoConsultasPaciente(){}
    void FiltrarPacientesPorTipoAtendimento(){}
}
