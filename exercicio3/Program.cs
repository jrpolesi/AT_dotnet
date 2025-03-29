namespace exercicio3;

class Program
{
    static void Main(string[] args)
    {
        var numA = InputTypeDouble("Digite o primeiro número: ");
        var numB = InputTypeDouble("Digite o segundo número: ");

        var operation = InputTypeOperation("Digite o número da operação desejada: ");

        try
        {
            var result = Calculate(numA, numB, operation);
            Console.WriteLine($"Resultado: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Não é possível dividir por zero.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static double Calculate(double a, double b, int operation)
    {
        return operation switch
        {
            // Sum operation (+)
            1 => Sum(a, b),
            // Subtract operation (-)
            2 => Subtract(a, b),
            // Multiply operation (*)
            3 => Multiply(a, b),
            // Divide operation (/)
            4 => Divide(a, b),
            // Invalid operation
            _ => throw new Exception("Operação inválida."),
        };
    }

    private static double Sum(double a, double b)
    {
        return a + b;
    }

    private static double Subtract(double a, double b)
    {
        return a - b;
    }

    private static double Multiply(double a, double b)
    {
        return a * b;
    }

    private static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }

        return a / b;
    }

    private static double InputTypeDouble(string message)
    {
        Console.Write(message);
        if (double.TryParse(Console.ReadLine() ?? "0", out var value))
        {
            return value;
        }

        Console.WriteLine("Valor inválido, tente novamente.");
        return InputTypeDouble(message);
    }

    private static int InputTypeOperation(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");

        if (int.TryParse(Console.ReadLine() ?? "1", out var value) && value >= 1 && value <= 4)
        {
            return value;
        }

        Console.WriteLine("Operação inválida, tente novamente.");
        return InputTypeOperation(message);
    }
}