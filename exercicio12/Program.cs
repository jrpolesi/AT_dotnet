namespace exercicio12;

class Program
{
    private static Agenda _agenda;

    static void Main(string[] args)
    {
        _agenda = new Agenda();

        while (true)
        {
            Console.WriteLine("=== Gerenciador de Contatos ===");
            var command = InputTypeCommand("Escolha uma opção: ");
            HandleCommand(command);
        }
    }

    private static void HandleCommand(int command)
    {
        switch (command)
        {
            case 1:
                InserirContato();
                break;
            case 2:
                ListarContatos();
                break;
            case 3:
                Console.WriteLine("Encerrando programa...");
                Environment.Exit(0);
                break;
        }
    }

    private static int InputTypeCommand(string message)
    {
        Console.WriteLine("1 - Adicionar novo contato");
        Console.WriteLine("2 - Listar contatos cadastrados");
        Console.WriteLine("3 - Sair");
        Console.Write(message);

        if (int.TryParse(Console.ReadLine() ?? "1", out var value) && value >= 1 && value <= 3)
        {
            return value;
        }

        Console.WriteLine("Opção inválida, tente novamente.");
        return InputTypeCommand(message);
    }

    private static int InputTypeFormat(string message)
    {
        Console.WriteLine("1 - Markdown (formato estruturado para exibição em Markdown)");
        Console.WriteLine("2 - Tabela (formatado como uma tabela no terminal)");
        Console.WriteLine("3 - Texto Puro (exibição simples em texto)");
        Console.Write(message);

        if (int.TryParse(Console.ReadLine() ?? "1", out var value) && value >= 1 && value <= 3)
        {
            return value;
        }

        Console.WriteLine("Opção inválida, tente novamente.");
        return InputTypeFormat(message);
    }

    private static void InserirContato()
    {
        var nome = InputTypeString("Nome: ");
        var telefone = InputTypeString("Telefone: ");
        var email = InputTypeString("Email: ");

        _agenda.InserirContato(new Contato(nome, telefone, email));

        Console.WriteLine("Contato cadastrado com sucesso!");
    }

    private static void ListarContatos()
    {
        var chooseFormat = InputTypeFormat("Escolha um formato: ");

        ContatoFormatter formatter = chooseFormat switch
        {
            1 => new MarkdownFormatter(),
            2 => new TabelaFormatter(),
            3 => new RawTextFormatter(),
            _ => new ContatoFormatter()
        };

        _agenda.ListarContatos(formatter);
    }

    private static string InputTypeString(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? "";
    }
}