namespace MedConsulta.Helpers;

public class Validador
{
    public static string ValidarString(string mensagem)
    {
        Console.WriteLine(mensagem);
        string entrada = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(entrada))
        {
            Console.WriteLine("Erro. Entrada inválida. Tente novamente: ");
            entrada = Console.ReadLine();
        }
        return entrada;
    }

    public static string ValidarStringCpf(string mensagem)
    {
        Console.WriteLine(mensagem);
        string entrada = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(entrada) || entrada.Length != 11 || !entrada.All(char.IsDigit))
        {
            Console.WriteLine("Erro. Entrada inválida (11 dígitos). Tente novamente: ");
            entrada = Console.ReadLine().Trim();
        }
        return entrada;
    }

    public static string ValidarStringCarteirinha(string mensagem)
    {
        Console.WriteLine(mensagem);
        string entrada = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(entrada))
        {
            Console.WriteLine("Erro. Entrada inválida. Tente novamente: ");
            entrada = Console.ReadLine().Trim();
        }
        return entrada;
    }

    public static string ValidarStringCrm(string mensagem)
    {
        Console.WriteLine(mensagem);
        string entrada = Console.ReadLine().Trim().ToUpper();
        while (string.IsNullOrWhiteSpace(entrada) || !entrada.StartsWith("CRM") || entrada.Length <= 3 || !entrada.Substring(3).All(char.IsDigit))
        {
            Console.WriteLine("Erro. Entrada inválida (formato: CRM12345). Tente novamente: ");
            entrada = Console.ReadLine().Trim().ToUpper();
        }
        return entrada;
    }

    public static int ValidarInt(string mensagem)
    {
        int entrada;
        Console.WriteLine(mensagem);
        while (!int.TryParse(Console.ReadLine(), out entrada))
            Console.WriteLine("Erro. Entrada inválida. Tente novamente: ");
        return entrada;
    }

    public static int ValidarIntIntervalo(string mensagem, int min, int max)
    {
        int entrada;
        Console.WriteLine(mensagem);
        while (!int.TryParse(Console.ReadLine(), out entrada) || entrada < min || entrada > max)
            Console.WriteLine($"Erro. Entrada inválida. Tente novamente ({min} - {max}): ");
        return entrada;
    }

    public static decimal ValidarDecimal(string mensagem)
    {
        decimal entrada;
        Console.WriteLine(mensagem);
        while (!decimal.TryParse(Console.ReadLine(), out entrada) || entrada <= 0)
            Console.WriteLine("Erro. Entrada inválida. Tente novamente: ");
        return entrada;
    }

    public static DateTime ValidarDataHota(string mensagem)
    {
        DateTime entrada;
        Console.WriteLine(mensagem);
        while (!DateTime.TryParse(Console.ReadLine(), out entrada))
            Console.WriteLine("Erro. Entrada inválida. Tente novamente: ");
        return entrada;
    }

    public static DateOnly ValidarData(string mensagem)
    {
        DateOnly entrada;
        DateOnly hoje = DateOnly.FromDateTime(DateTime.Now);
        Console.WriteLine(mensagem);
        while (!DateOnly.TryParse(Console.ReadLine(), out entrada) || entrada > hoje)
            Console.WriteLine("Erro. Entrada inválida. Tente novamente: ");
        return entrada;
    }
}
