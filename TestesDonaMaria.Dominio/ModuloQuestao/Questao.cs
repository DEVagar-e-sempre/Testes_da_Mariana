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

        public override string[] Validar()
        {
            List<String> erros = new();
            if (string.IsNullOrEmpty(enunciado))
            {
                erros.Add("O enunciado não pode ser vazio");
            }
            if (materia == null)
            {
                erros.Add("A questão deve estar associada a uma matéria");
            }
            if (alternativas.Count < 2)
            {
                erros.Add("A questão deve ter pelo menos 2 alternativas");
            }
            if(alternativas.Count(x => x.correta == true) == 0)
            {
                erros.Add("A questão deve ter pelo menos uma alternativa correta");
            }
            if (alternativas.Count(x => x.correta == true) > 1)
            {
                erros.Add("A questão não pode ter mais de uma alternativa correta");
            }
            return erros.ToArray();
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
