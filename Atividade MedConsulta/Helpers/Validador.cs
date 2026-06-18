namespace Atividade_MedConsulta.Helpers;

public static class Validador
{
    public static string ValidarTexto(string msg)
    {
        Console.Write(msg);
        string? entrada = Console.ReadLine()?.Trim();

        while (string.IsNullOrWhiteSpace(entrada))
        {
            Console.Write("Entrada Invalida. Tente novamente: ");
            entrada = Console.ReadLine()?.Trim();
        }

        return entrada;
    }

    public static string ValidarCrm(string msg)
    {
        Console.Write(msg);
        string? entrada = Console.ReadLine()?.Trim().ToUpper();

        while (string.IsNullOrWhiteSpace(entrada))
        {
            Console.Write("CRM invalido. Tente Novamente: ");
            entrada = Console.ReadLine()?.Trim().ToUpper();
        }

        return entrada;
    }

    public static DateTime ValidarDataPassada(string msg)
    {
        Console.Write(msg);
        DateTime data;

        while (!DateTime.TryParse(Console.ReadLine(), out data) || data > DateTime.Now)
            Console.Write("Data invalida (nao pode ser no futuro). Tente novamente: ");

        return data;
    }

    public static DateTime ValidarDataFutura(string msg)
    {
        Console.Write(msg);
        DateTime data;

        while (!DateTime.TryParse(Console.ReadLine(), out data) || data < DateTime.Now)
            Console.Write("Data invalida (nao pode ser no passado).Tente novamente: ");

        return data;
    }

    public static string ValidarCpf(string msg)
    {
        Console.Write(msg);
        string? cpf = Console.ReadLine()?.Trim();

        while (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(Char.IsDigit))
        {
            Console.Write("[ERRO] CPF invalido (11 digitos, apenas numeros)");
            cpf = Console.ReadLine()?.Trim();
        }

        return cpf;
    }

    public static int ValidarInt(string msg)
    {
        Console.Write(msg);
        int valor;

        while(!int.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            Console.Write("Valor invalido (Informe um numero inteiro positivo)");

        return valor;
    }

    public static T ValidarOpcaoEnum<T>(string msg) where T : struct, Enum
    {
        Console.WriteLine(msg); 

        T[] valores = Enum.GetValues<T>();
        for( int i = 0; i < valores.Length; i++)
            Console.WriteLine($"{i + 1}. {valores[i]}");

        int escolha = ValidarInt("Escolha: ");
        while ( escolha < 1 || escolha > valores.Length)
        {
            Console.WriteLine("Opcao Invalida");
            escolha = ValidarInt("Escolha: ");
        }

        return valores[escolha - 1];
    }

    public static decimal ValidarDecimal(string msg)
    {
        Console.Write(msg);
        decimal valor;

        while(!decimal.TryParse(Console.ReadLine(), out valor) || valor < 0)
            Console.WriteLine("Valor invalido (informe um numero maior ou igual a zero): ");

            return valor;
    }


}
