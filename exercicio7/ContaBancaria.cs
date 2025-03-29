using System.Globalization;

namespace exercicio7;

public class ContaBancaria(string nome)
{
    public string Nome = nome;
    private decimal _saldo = 0;

    public void Depositar(decimal valor)
    {
        if (valor < 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo!\n");
            return;
        }

        _saldo += valor;
        Console.WriteLine($"Depósito de R$ {FormatDecimal(valor)} realizado com sucesso!\n");
    }

    public void Sacar(decimal valor)
    {
        var newSaldo = _saldo - valor;
        if (newSaldo < 0)
        {
            Console.WriteLine($"Tentativa de saque: R$ {FormatDecimal(valor)}\n");
            Console.WriteLine("Saldo insuficiente para realizar o saque!\n");
            return;
        }

        _saldo = newSaldo;
        Console.WriteLine($"Saque de R$ {FormatDecimal(valor)} realizado com sucesso!\n");
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: R$ {FormatDecimal(_saldo)}\n");
    }

    private string FormatDecimal(decimal valor)
    {
        return valor.ToString("N2", new CultureInfo("pt-BR"));
    }
}