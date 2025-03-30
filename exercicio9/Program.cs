namespace exercicio9;

class Program
{
    private static Loja _loja;

    static void Main(string[] args)
    {
        _loja = new Loja();
        
        while (true)
        {
            var command = InputTypeCommand("Escolha uma opção:");
            HandleCommand(command);
        }
    }

    private static void HandleCommand(int command)
    {
        switch (command)
        {
            case 1:
                InserirProduto();
                break;
            case 2:
                _loja.ListarProdutos();
                break;
            case 3:
                Console.WriteLine("Obrigado por utilizar o sistema.");
                Environment.Exit(0);
                break;
        }
    }

    private static int InputTypeCommand(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("1 - Inserir Produto");
        Console.WriteLine("2 - Listar Produtos");
        Console.WriteLine("3 - Sair");

        if (int.TryParse(Console.ReadLine() ?? "1", out var value) && value >= 1 && value <= 3)
        {
            return value;
        }

        Console.WriteLine("Opção inválida, tente novamente.");
        return InputTypeCommand(message);
    }

    private static void InserirProduto()
    {
        if (_loja.Produtos.Count >= 5)
        {
            Console.WriteLine("Limite de produtos atingido!\n");
            return;
        }

        var nome = InputTypeString("Digite o nome do produto: ");
        var quantidade = InputTypeInt("Digite a quantidade em estoque: ");
        var preco = InputTypeDouble("Digite o preço unitário: ");

        _loja.InserirProduto(new Produto(nome, quantidade, preco));
    }

    private static string InputTypeString(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
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

    private static int InputTypeInt(string message)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine() ?? "0", out var value))
        {
            return value;
        }

        Console.WriteLine("Valor inválido, tente novamente.");
        return InputTypeInt(message);
    }
}