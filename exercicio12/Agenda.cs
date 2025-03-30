namespace exercicio12;

public class Agenda
{
    private readonly string _persistentFilePath = Path.Combine(Directory.GetCurrentDirectory(), "contatos.txt");
    private readonly List<Contato> _contatos;

    public Agenda()
    {
        _contatos = CarregarContatos();
    }

    public void InserirContato(Contato contato)
    {
        _contatos.Add(contato);
        PersistirContato(contato);
    }

    public void ListarContatos(ContatoFormatter formatter)
    {
        if (_contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("Contatos cadastrados");
        formatter.ExibirContatos(_contatos);
    }

    private void PersistirContato(Contato contato)
    {
        using var writer = File.AppendText(_persistentFilePath);

        var row = $"{contato.Nome},{contato.Telefone},{contato.Email}";
        writer.WriteLine(row);
    }

    private List<Contato> CarregarContatos()
    {
        var contatos = new List<Contato>();
        if (!File.Exists(_persistentFilePath))
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            File.Create(_persistentFilePath).Dispose();
            return contatos;
        }

        using var reader = new StreamReader(_persistentFilePath);
        var rows = reader.ReadToEnd().Split("\n");

        foreach (var row in rows)
        {
            if (string.IsNullOrWhiteSpace(row))
            {
                continue;
            }

            var values = row.Split(',');

            var nome = values[0];
            var telefone = values[1];
            var email = values[2];

            var contato = new Contato(nome, telefone, email);
            contatos.Add(contato);
        }

        return contatos;
    }
}