using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Dominio.ModuloQuestao;

namespace TestesDonaMaria.Dominio.ModuloTeste
{
    public class Teste : EntidadeBase<Teste>
    {
        public string titulo;
        public Materia materia;
        public int quantQuestoes;
        public int PegarQuantQuestoes
        {
            get
            {
                return listaQuestoes.Count;
            }
        }

        public int serie;
        public List<Questao> listaQuestoes;

        public Teste(string titulo, Materia materia, int quantQuestoes, int serie)
        {
            this.titulo = titulo;
            this.materia = materia;
            this.quantQuestoes = quantQuestoes;
            this.serie = serie;
            this.listaQuestoes = new List<Questao>();

        }

        public Teste(int id, string titulo, Materia materia, int quantQuestoes, int serie)
        {
            this.id = id;
            this.titulo = titulo;
            this.materia = materia;
            this.quantQuestoes = quantQuestoes;
            this.serie = serie;
            this.listaQuestoes = new List<Questao>();

        }

        public override void AtualizarInformacoes(Teste entidade)
        {
            throw new NotImplementedException();
        }

        public override string[] Validar()
        {
            throw new NotImplementedException();
        }
    }
}
