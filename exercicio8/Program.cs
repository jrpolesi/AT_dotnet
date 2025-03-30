namespace exercicio8;

class Program
{
    static void Main(string[] args)
    {
        var funcionario = new Funcionario("João", "Desenvolvedor", 1000);

        funcionario.ExibirDados();

        Console.WriteLine("--------------------");

        var gerente = new Gerente("Maria", "Project manager", 2000);

        gerente.ExibirDados();
    }
}