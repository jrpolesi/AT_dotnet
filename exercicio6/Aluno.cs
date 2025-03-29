namespace exercicio6;

public class Aluno(string nome, string matricula, string curso, double mediaDasNotas)
{
    public string Nome = nome;
    public string Matricula = matricula;
    public string Curso = curso;
    public double MediaDasNotas = mediaDasNotas;

    public void ExibirDados()
    {
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Matrícula: " + Matricula);
        Console.WriteLine("Curso: " + Curso);
        Console.WriteLine("Média das Notas: " + MediaDasNotas);
        Console.WriteLine("Status: " + VerificarAprovacao());
    }

    public string VerificarAprovacao()
    {
        return MediaDasNotas >= 7 ? "Aprovado" : "Reprovado";
    }
}