using System.Text;

namespace exercicio2;

class Program
{
    static void Main(string[] args)
    {
        var name = InputTypeString("Digite seu nome: ");

        var encrypted = Crypt(name);

        Console.WriteLine("Nome criptografado:");
        Console.WriteLine(encrypted);
    }

    private static string Crypt(string value)
    {
        char[] alphabet =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z'
        };

        var encrypted = new StringBuilder();

        foreach (var t in value)
        {
            if (!char.IsLetter(t))
            {
                encrypted.Append(t);
                continue;
            }

            var letter = char.ToLower(t);
            var index = Array.IndexOf(alphabet, letter);

            if (index == -1)
            {
                encrypted.Append(t);
                continue;
            }

            var shiftedChar = ShiftChar(alphabet, index, 2);

            encrypted.Append(char.IsUpper(t) ? char.ToUpper(shiftedChar) : shiftedChar);
        }

        return encrypted.ToString();
    }

    private static char ShiftChar(char[] array, int currIndex, int shift)
    {
        var newIndex = currIndex + shift;

        // It's necessary to check if the new index is greater than the array length
        // to avoid an IndexOutOfRangeException
        if (newIndex >= array.Length)
        {
            newIndex -= array.Length;
        }

        return array[newIndex];
    }

    private static string InputTypeString(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }
}