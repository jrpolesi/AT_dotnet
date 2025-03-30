namespace exercicio8;

public class Gerente : Funcionario
{
    public Gerente(string nome, string cargo, double salarioBase)
        : base(nome, cargo, salarioBase)
    {
    }

    public override double CalcularSalario()
    {
        var extra = SalarioBase * (20.0 / 100);
        return SalarioBase + extra;
    }
}