namespace Atividade_MedConsulta.Helpers;

public static class Validador
{
    public static string ValidarTexto(string msg)
    {
        Console.Write(msg);
        string entrada = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(entrada))
        {
            Console.Write("Entrada Invalida. Tente novamente: ");
            entrada = Console.ReadLine().Trim();
        }

        return entrada; 
    }

    public static string ValidarCrm(string msg)
    {
        Console.Write(msg);
        string entrada = Console.ReadLine().Trim().ToUpper();

        while (string.IsNullOrWhiteSpace(entrada) 
            || !entrada.StartsWith("CRM") 
            || entrada.Length <= 3 
            || !entrada.Substring(3).All(char.IsDigit))
        {
            Console.Write("CRM invalido (formato CRM12345). Tente Novamente: ");
            entrada = Console.ReadLine().Trim().ToUpper();
        }

        return entrada;
    }
}

