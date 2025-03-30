namespace exercicio8;

public class Funcionario(string nome, string cargo, double salarioBase)
{
    public string Nome = nome;
    public string Cargo = cargo;
    protected readonly double SalarioBase = salarioBase;
    
    public virtual double CalcularSalario()
    {
        return SalarioBase;
    }

    public void ExibirDados()
    {
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Cargo: " + Cargo);
        Console.WriteLine("Salário Final: " + CalcularSalario());
    }
}
