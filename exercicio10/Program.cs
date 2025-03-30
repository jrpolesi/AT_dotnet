namespace exercicio10;

class Program
{
    static void Main(string[] args)
    {
        var rand = new Random();
        var randomNumber = rand.Next(1, 51);

        var userTryCount = 0;

        var userGuess = InputTypeInt("Digite um número entre 1 e 50: ");

        var isCorrect = userGuess == randomNumber;
        while (!isCorrect && userTryCount < 4)
        {
            Console.WriteLine("O número está incorreto.");
            Console.WriteLine($"O número correto é {(userGuess < randomNumber ? "MAIOR" : "MENOR")}.");

            userGuess = InputTypeInt("Tente novamente:");
            userTryCount++;

            if (userGuess == randomNumber)
            {
                isCorrect = true;
            }
        }

        var finishMessage = isCorrect ? "Parabéns, você acertou!" : "Você perdeu por exceder o número de tentativas.";
        Console.WriteLine(finishMessage);
    }

    private static int InputTypeInt(string message)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine() ?? "0", out var value) && value >= 1 && value <= 50)
        {
            return value;
        }

        Console.WriteLine("Valor inválido, tente novamente.");
        return InputTypeInt(message);
    }
}