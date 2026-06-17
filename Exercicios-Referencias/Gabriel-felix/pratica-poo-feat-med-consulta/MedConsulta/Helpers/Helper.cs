using MedConsulta.Enums;

namespace MedConsulta.Helpers;

public static class Helper
{
    public static int ValidadorMenu()
    {
        int opcao;

        while (!int.TryParse(Console.ReadLine().Trim(), out opcao) || opcao < 0 || opcao > 25)
            Console.Write("\nOpção inválida, digite novamente: ");

        return opcao;
    }

    public static string ValidadorTexto()
    {
        string texto = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(texto))
        {
            Console.Write("\nInformação inválida, digite novamente :");
            texto = Console.ReadLine().Trim();
        }

        return texto;
    }

    public static string ValidadorCrm()
    {
        string texto = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(texto) || texto.Length > 7 || texto.Length < 4 || !texto.All(char.IsDigit))
        {
            Console.Write("\nCrm informado inválido, digite novamente (4 a 7 dígitos): ");
            texto = Console.ReadLine().Trim();
        }

        return $"CRM{texto}";
    }

    public static bool ValidadorListaVazia<T>(List<T> lista, string texto)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine($"\nNenhum(a) {texto} cadastrado(a).");
            ReduzirTempo();
            return true;
        }
        return false;
    }

    public static bool ValidadorObjetoNulo(object objeto)
    {
        if (objeto == null)
            return true;

        return false;
    }

    public static Guid ValidadorGuid()
    {
        Guid guid;

        while (!Guid.TryParse(Console.ReadLine().Trim(), out guid))
            Console.Write("\nId inválido, digite novamente: ");

        return guid;
    }

    public static string ValidadorNumeroConsulta()
    {
        string texto = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(texto) || texto.Length < 4 || !texto.All(char.IsDigit))
        {
            Console.Write("\nCódigo informado inválido, digite novamente (4 dígitos - Exemplo:  0512): ");
            texto = Console.ReadLine().Trim();
        }

        return $"CONS{texto}";
    }

    public static DateTime ValidadorDataHoraConsulta()
    {
        DateTime datahora;

        while (!DateTime.TryParse(Console.ReadLine().Trim(), out datahora) || datahora < DateTime.Now)
            Console.Write("\nData inválida, digite novamente: ");

        return datahora;
    }

    public static DateTime ValidadorDataNascimento()
    {
        DateTime datahora;

        while (!DateTime.TryParse(Console.ReadLine().Trim(), out datahora) || datahora > DateTime.Now)
            Console.Write("\nData inválida, digite novamente: ");

        return datahora;
    }

    public static int ValidadorNumeroInteiro()
    {
        int numero;

        while (!int.TryParse(Console.ReadLine().Trim(), out numero) || numero < 0)
            Console.Write("\nValor inválido, digite novamente: ");

        return numero;
    }

    public static decimal ValidadorDecimal()
    {
        decimal numero;

        while (!decimal.TryParse(Console.ReadLine().Trim(), out numero) || numero < 0)
            Console.Write("\nValor inválido, digite novamente: ");

        return numero;
    }

    public static int ValidadorStatusConsultaEnum()
    {
        StatusConsultaEnum[] opcoes = Enum.GetValues<StatusConsultaEnum>();
        int numero;

        while (!int.TryParse(Console.ReadLine().Trim(), out numero) || numero < 0 || numero > opcoes.Length)
            Console.Write("\nOpção inválida, digite novamente: ");

        return numero;
    }

    public static int ValidadorTipoAtendimentoEnum()
    {
        TipoAtendimentoEnum[] opcoes = Enum.GetValues<TipoAtendimentoEnum>();
        int numero;

        while (!int.TryParse(Console.ReadLine().Trim(), out numero) || numero < 0 || numero > opcoes.Length)
            Console.Write("\nOpção inválida, digite novamente: ");

        return numero;
    }

    public static string ValidadorCpf()
    {
        string texto = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(texto) || !texto.All(char.IsDigit) || (texto.Length > 11 && texto.Length < 11))
        {
            Console.Write("Cpf inválido, digite novamente (somente números): ");
            texto = Console.ReadLine();
        }

        return texto;
    }

    public static string ValidadorCarteirinha()
    {
        string texto = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(texto) || !texto.All(char.IsDigit) || (texto.Length < 12 && texto.Length > 12))
        {
            Console.Write("Número de carteirinha inválido, digite novamente (12 caracteres): ");
            texto = Console.ReadLine();
        }

        return texto;
    }

    static void ReduzirTempo() => Thread.Sleep(1500);
}
