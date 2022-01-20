using System;

namespace projeto01
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    //Incluir Aluno
                        Console.WriteLine("Informe o nome do aluno");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno");

                        if(decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }else
                        {
                            throw new ArgumentException("O Valor da Nota deve ser um decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                    break;
                    case "2":
                    //Listar Alunos
                        foreach (var a in alunos)
                        {   
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                            Console.WriteLine($"Nome: {a.Nome} Nota: {a.Nota}");
                            }
                        }
                        break;

                    case "3":
                    //Calcular Média Geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for(int i=0; i < alunos.Length; i++)
                        {
                            
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;

                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                            if(mediaGeral < 3)
                            {
                                conceitoGeral = Conceito.E;
                            } 
                            else if(mediaGeral > 3 && mediaGeral <= 5)
                            {
                                conceitoGeral = Conceito.D;
                            }
                            else if(mediaGeral > 5 && mediaGeral <= 7)
                            {
                                conceitoGeral= Conceito.C;
                            } 
                            else if(mediaGeral > 7 && mediaGeral <=8)
                            {
                                conceitoGeral = Conceito.B;
                            }
                            else
                            {
                                conceitoGeral = Conceito.A;
                            }
                        


                        Console.WriteLine($" Média Geral: {mediaGeral} com um Conceiro geral:  {conceitoGeral}");
                            
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario =  ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Inserir Novo Aluno");
            Console.WriteLine("2- Listar Alunos");
            Console.WriteLine("3- Calcular Média Geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
