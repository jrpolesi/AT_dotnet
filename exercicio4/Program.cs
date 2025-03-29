using System.Globalization;

namespace exercicio4;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite sua data de nascimento (eg. dd/MM/yyyy): ");
        var input = Console.ReadLine();

        if (DateTime.TryParseExact(input, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var birthDate))
        {
            var daysRemaining = DaysUntilNextBirthday(birthDate);

            Console.WriteLine(daysRemaining < 7
                ? $"Seu aniversário está próximo, faltam {daysRemaining}"
                : $"Faltam {daysRemaining} dias para o seu aniversário");
        }
        else
        {
            Console.WriteLine("Data inválida");
        }
    }

    private static int DaysUntilNextBirthday(DateTime birthDate)
    {
        var today = DateTime.Today;
        DateTime nextBirthday;

        if (birthDate.Month == 2 && birthDate.Day == 29)
        {
            nextBirthday = DateTime.IsLeapYear(today.Year)
                ? new DateTime(today.Year, birthDate.Month, birthDate.Day)
                : new DateTime(today.Year, 2, 28);
        }
        else
        {
            nextBirthday = new DateTime(today.Year, birthDate.Month, birthDate.Day);
        }

        if (nextBirthday < today)
        {
            nextBirthday = nextBirthday.AddYears(1);

            // If the next year is a leap year and the user was born on Feb 29, adjust to Feb 29
            if (birthDate.Month == 2 && birthDate.Day == 29 && DateTime.IsLeapYear(nextBirthday.Year))
            {
                nextBirthday = new DateTime(nextBirthday.Year, birthDate.Month, birthDate.Day);
            }
        }

        return (nextBirthday - today).Days;
    }
}