namespace exercicio12;

class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("## Lista de Contatos");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.Nome}");
            Console.WriteLine($"- 📞 Telefone: {contato.Telefone}");
            Console.WriteLine($"- 📧 Email: {contato.Email}");
        }
    }
}