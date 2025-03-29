namespace exercicio7;

class Program
{
    static void Main(string[] args)
    {
        var conta = new ContaBancaria("José Ricardo");

        Console.WriteLine($"Titular: {conta.Nome}\n");

        conta.Depositar(500);

        conta.ExibirSaldo();

        conta.Sacar(700);

        conta.Sacar(200);

        conta.ExibirSaldo();
    }
}