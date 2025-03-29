using System.Globalization;

namespace exercicio5;

class Program
{
    private static readonly DateTime GraduationDate = new DateTime(2026, 12, 15);

    static void Main(string[] args)
    {
        Console.Write("Digite a data atual (dd/MM/yyyy): ");
        var input = Console.ReadLine();

        if (DateTime.TryParseExact(input, "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var currentDate))
        {
            if (currentDate > DateTime.Today)
            {
                Console.WriteLine("Erro: A data informada não pode ser no futuro!");
                return;
            }

            ProcessDatesAndDisplayDates(currentDate);
        }
        else
        {
            Console.WriteLine("Erro: Data inválida!");
        }
    }

    private static void ProcessDatesAndDisplayDates(DateTime currentDate)
    {
        var difference = GetDateDifference(currentDate, GraduationDate);

        if (currentDate > GraduationDate)
        {
            Console.WriteLine("Parabéns! Você já deveria estar formado!");
            return;
        }

        if (difference.Years == 0 && difference.Months < 6)
        {
            Console.WriteLine($"Faltam {difference.Months} meses e {difference.Days} dias para sua formatura!");
            Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
            return;
        }

        Console.WriteLine(
            $"Faltam {difference.Years} anos, {difference.Months} meses e {difference.Days} dias para sua formatura!");
    }

    private static DateDifference GetDateDifference(DateTime startDate, DateTime endDate)
    {
        var years = endDate.Year - startDate.Year;
        var months = endDate.Month - startDate.Month;
        var days = endDate.Day - startDate.Day;

        if (days < 0)
        {
            months--;
            days += DateTime.DaysInMonth(startDate.Year, startDate.Month);
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }

        return new DateDifference { Years = years, Months = months, Days = days };
    }
}