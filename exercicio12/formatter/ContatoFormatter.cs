namespace exercicio12;

public class ContatoFormatter
{
    public virtual void ExibirContatos(List<Contato> contatos)
    {
        foreach (var contato in contatos)
        {
            Console.WriteLine($"{contato.Nome},{contato.Telefone},{contato.Email}");
        }
    }
}