using System;

namespace DIO.series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine(" OBRIGADO... ATË A PRÓXIMA !!!");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listagem de Séries: ");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Ainda não há Nenhuma Série Cadastrada !");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluída!*" : ""));
            }
        }

        private static void InserirSerie()
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Escolha o Gênero:");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o Título da Série?");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Qual o Ano de Início?");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite uma Descrição para a Série:");
            string entradaDescricao = Console.ReadLine();
            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }
        
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série a ser Atualizada: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Atualiza o Gênero: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine("Atualize o Título da Série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine("Atualize o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine("Atualize a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();
            Serie serieAtualizada = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, serieAtualizada);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID de Série a ser Excluída: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série que Desejas Visualizar: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("    Decca Séries !!!    ");
            Console.WriteLine();
            Console.WriteLine("========= MENU =========");
            Console.WriteLine();
            Console.WriteLine("1 - Listagem de Séries..");
            Console.WriteLine("2 - Inserir Série.......");
            Console.WriteLine("3 - Atualizar Série.....");
            Console.WriteLine("4 - Excluir Série.......");
            Console.WriteLine("5 - Visualizar Série....");
            Console.WriteLine("C - Limpar Tela.........");
            Console.WriteLine("X - Sair................");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
