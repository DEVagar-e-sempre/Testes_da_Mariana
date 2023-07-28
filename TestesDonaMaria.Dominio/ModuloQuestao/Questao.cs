using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public string enunciado;
        public int serie;
        public Materia materia;
        public List<Alternativa> alternativas;

        public Questao(int id, string enunciado, int serie, Materia materia) : this()
        {
            this.id = id;
            this.enunciado = enunciado;
            this.serie = serie;
            this.materia = materia;
        }
        public Questao(string enunciado, int serie, Materia materia) : this()
        {
            this.enunciado = enunciado;
            this.serie = serie;
            this.materia = materia;
        }
        public Questao()
        {
            this.alternativas = new List<Alternativa>();
        }
        public override void AtualizarInformacoes(Questao entidade)
        {
            this.enunciado = entidade.enunciado;
            this.serie = entidade.serie;
            this.materia = entidade.materia;
            this.alternativas = entidade.alternativas;
        }

        public Alternativa ObterAlternativaCorreta()
        {
            return alternativas.Find(x => x.correta == true);
        }
        public override string ToString()
        {
            return enunciado;
        }
        public override bool Equals(object obj)
        {
            return obj is Questao questao &&
                   id == questao.id;
        }

    }
}
