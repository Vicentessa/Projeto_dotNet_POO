using System;

namespace DIO.ProverdorStreaming
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
		static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
			string opcaoUsuario = null;
			do
			{
				opcaoUsuario = ObterOpcaoUsuario();

				switch (opcaoUsuario)
				{
					case "1":
						Streaming_Serie();
						break;
					case "2":
						Streaming_Filme();
						break;
					case "C":
						Console.Clear();
						break;
					case "X":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				
			} while (opcaoUsuario.ToUpper() != "X");

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void Streaming_Serie()
        {
			Console.Clear();
			string opcaoUsuario;

			// Substituí o (While) por (do...while) para não repetir a chamada do método MenuSerie
            do
			{
				// Método MenuSerie para apresentar as opções para o usuário
				opcaoUsuario = MenuSerie();
				
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
					case "X":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				/* 
				   Uma pausa para que o usuário veja as informações e depois 
				   ao pressionar uma tecla apresente o Menu.
				*/
				if (opcaoUsuario.ToUpper() != "X")
				{
					Console.WriteLine("");
					Console.Write("Pressione uma tecla p/ continuar... ");
					Console.ReadLine();
					Console.Clear();
				}
				
			} while (opcaoUsuario.ToUpper() != "X");
        }

        private static void Streaming_Filme()
        {
			Console.Clear();
			string opcaoUsuario;
            do
			{
				opcaoUsuario = MenuFilme();

				switch (opcaoUsuario)
				{
					case "1":
						ListarFilmes();
						break;
					case "2":
						InserirFilme();
						break;
					case "3":
						AtualizarFilme();
						break;
					case "4":
						ExcluirFilme();
						break;
					case "5":
						VisualizarFilme();
						break;
					case "C":
						Console.Clear();
						break;
					case "X":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				/* 
				   Uma pausa para que o usuário veja as informações e depois 
				   ao pressionar uma tecla apresente o Menu.
				*/
				if (opcaoUsuario.ToUpper() != "X")
				{
					Console.WriteLine("");
					Console.Write("Pressione uma tecla p/ continuar... ");
					Console.ReadLine();
					Console.Clear();
				}

			} while (opcaoUsuario.ToUpper() != "X");
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorioSerie.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			bool encontrado = false;
			var lista = repositorioSerie.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Catálogo de série vazio!");
				return;
			}
			else
			{
				// Verifica se a série foi encontrada
				for (int i = 0; i < lista.Count; i++)
				{
					if (lista[i].Id == indiceSerie)
					{
						encontrado = true;
					}
				}

				if (encontrado)
				{
					var serie = repositorioSerie.RetornaPorId(indiceSerie);
					Console.WriteLine(serie);
				}
				else
				{
					Console.WriteLine("Série não cadastrada!");
				}
			}
			
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorioSerie.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioSerie.Insere(novaSerie);
		}

		// Manutenção de filmes

		private static void ExcluirFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorioFilme.Exclui(indiceFilme);
		}
        
		private static void VisualizarFilme()
		{
			Console.Write("Digite o id do Filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
			bool encontrado = false;

			var lista = repositorioFilme.Lista();

			// Verifica se o catálogo está vazio
			if (lista.Count == 0)
			{
				Console.WriteLine("Catálogo de filmes vazio!");
			}
			else
			{
				// Verifica se o filme foi encontrado
				for (int i = 0; i < lista.Count; i++)
				{
					if (lista[i].Id == indiceFilme)
					{
						encontrado = true;
					}
				}

				if (encontrado)
				{
					var filme = repositorioFilme.RetornaPorId(indiceFilme);
					Console.WriteLine(filme);
				}
				else
				{
					Console.WriteLine("Filme não cadastrado!");
				}
			}
			
		}

        private static void AtualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
		
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			
			foreach (int i in Enum.GetValues(typeof(Classificacao)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Classificacao), i));
			}
			Console.WriteLine("Digite a classificação entre as opções acima: ");
			int entradaClassificacao = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										classificacao: (Classificacao)entradaClassificacao,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
		}
		
        private static void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorioFilme.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());
			
			foreach (int i in Enum.GetValues(typeof(Classificacao)))
			{
				Console.WriteLine("{0}-{1} ", i, Enum.GetName(typeof(Classificacao), i));
			}

			Console.WriteLine("Digite a Classificação entre as opções acima: ");
			int entradaClassificacao = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
										genero: (Genero)entradaGenero,
										classificacao: (Classificacao)entradaClassificacao,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioFilme.Insere(novoFilme);

		}

		// Menus com as opções
		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Provedor de Streaming a seu dispor!!!");
			Console.WriteLine("-----------------------------------------");
			Console.WriteLine("1 - Séries");
			Console.WriteLine("2 - Filmes");
			Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("X - Sair");
			Console.WriteLine("-----------------------------------------");
			Console.WriteLine("Informe a opção desejada:");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			return opcaoUsuario;
		}

        private static string MenuSerie()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("--------------------------");
			Console.WriteLine("1 - Listar Séries");
			Console.WriteLine("2 - Inserir nova Série");
			Console.WriteLine("3 - Atualizar Série");
			Console.WriteLine("4 - Excluir Série");
			Console.WriteLine("5 - Visualizar Série");
			Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("--------------------------");			
			Console.WriteLine("X - Sair");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			return opcaoUsuario;
		}

		private static string MenuFilme()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Filmes a seu dispor!!!");
			Console.WriteLine("--------------------------");
			Console.WriteLine("1 - Listar filmes");
			Console.WriteLine("2 - Inserir novo filme");
			Console.WriteLine("3 - Atualizar filme");
			Console.WriteLine("4 - Excluir filme");
			Console.WriteLine("5 - Visualizar filme");
			Console.WriteLine("C - Limpar Tela");
			Console.WriteLine("--------------------------");			
			Console.WriteLine("X - Sair");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			return opcaoUsuario;
		}
    }
}
