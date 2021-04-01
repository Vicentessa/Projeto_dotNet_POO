using System;

namespace DIO.ProverdorStreaming
{
    public class Filme : EntidadeBase
    {
        // Atributos
		private Genero Genero { get; set; }
        private Classificacao Classificacao { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Filme(int id, Genero genero, Classificacao classificacao, string titulo, string descricao, int ano)
		{
			this.Id = id;
			this.Genero = genero;
			this.Classificacao = classificacao;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;
		}

		public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
			// Serve para fazer a quebra de linha independente de sistema operacional
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
			retorno += "Classificação: " + this.Classificacao + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de estreia: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}
		public string retornaClassificacao()
		{
			return this.Classificacao.ToString();
		}


		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }

    }
}