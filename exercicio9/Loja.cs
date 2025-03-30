using System.Globalization;

namespace exercicio9;

public class Loja
{
    private readonly string _persistentFilePath = Path.Combine(Directory.GetCurrentDirectory(), "example.txt");
    private readonly List<Produto> _produtos;

    public Loja()
    {
        _produtos = CarregarProdutos();
    }

    public List<Produto> Produtos => _produtos;

    public void InserirProduto(Produto produto)
    {
        _produtos.Add(produto);
        PersistirProduto(produto);
    }

    public void ListarProdutos()
    {
        if (_produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("Produtos cadastrados");
        foreach (var produto in _produtos)
        {
            var precoFormatado = produto.PrecoUnitario.ToString("N2", new CultureInfo("pt-BR"));
            Console.WriteLine(
                $"Produto: {produto.Nome} | Quantidade: {produto.QuantidadeEmEstoque} | Preço: R$ {precoFormatado}");
        }

        Console.WriteLine();
    }

    private void PersistirProduto(Produto produto)
    {
        using var writer = File.AppendText(_persistentFilePath);

        var row = $"{produto.Nome},{produto.QuantidadeEmEstoque},{produto.PrecoUnitario}";
        writer.WriteLine(row);
    }

    private List<Produto> CarregarProdutos()
    {
        var produtos = new List<Produto>();
        if (!File.Exists(_persistentFilePath))
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            File.Create(_persistentFilePath).Dispose();
            return produtos;
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
            var quantidade = int.Parse(values[1]);
            var preco = double.Parse(values[2]);

            var produto = new Produto(nome, quantidade, preco);
            produtos.Add(produto);
        }

        return produtos;
    }
}