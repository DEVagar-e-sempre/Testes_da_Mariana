using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Dominio.ModuloQuestao;

namespace TestesDonaMaria.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string titulo;
        public Materia materia;
        public int quantQuestoes;
        public int serie;
        public bool recuperacao;
        public List<Questao> listaQuestoes;

        public int PegarQuantQuestoes => listaQuestoes.Count;

        public Teste(string titulo, Materia materia, int quantQuestoes, int serie, bool recuperacao) : this()
        {
            this.titulo = titulo;
            this.materia = materia;
            this.quantQuestoes = quantQuestoes;
            this.serie = serie;
            this.recuperacao = recuperacao;
        }

        public Teste(int id, string titulo, Materia materia, int quantQuestoes, int serie, bool recuperacao) : this()
        {
            this.id = id;
            this.titulo = titulo;
            this.materia = materia;
            this.quantQuestoes = quantQuestoes;
            this.serie = serie;
            this.recuperacao = recuperacao;
        }

        public Teste()
        {
            this.listaQuestoes = new List<Questao>();
        }

        public override void AtualizarInformacoes(Teste entidade)
        {
            this.titulo = entidade.titulo;
            this.materia = entidade.materia;
            this.quantQuestoes = entidade.quantQuestoes;
            this.serie = entidade.serie;
            this.recuperacao = entidade.recuperacao;
            this.listaQuestoes = entidade.listaQuestoes;
        }

        public override string[] Validar()
        {
            List<String> erros = new();
            if (string.IsNullOrEmpty(titulo))
            {
                erros.Add("O título não pode ser vazio");
            }
            if(titulo.Length < 5)
            {
                erros.Add("O título deve ter pelo menos 5 caracteres");
            }
            if (materia == null)
            {
                erros.Add("O teste deve estar associado a uma matéria");
            }
            if (quantQuestoes < 2 || listaQuestoes.Count < 2)
            {
                erros.Add("O teste deve ter pelo menos 2 questão");
            }
            return erros.ToArray();
        }
        public override string ToString()
        {
            return titulo;
        }
        public override bool Equals(object obj)
        {
            return obj is Teste teste &&
                   id == teste.id;
        }

    }
}
