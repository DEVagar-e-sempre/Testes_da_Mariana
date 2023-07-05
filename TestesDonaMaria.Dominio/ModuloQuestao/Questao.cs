using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public string titulo;
        public int serie;
        public Materia materia;
        public List<Alternativa> alternativas;

        public Questao(int id, string titulo, int serie, Materia materia) : this()
        {
            this.id = id;
            this.titulo = titulo;
            this.serie = serie;
            this.materia = materia;
        }
        public Questao(string titulo, int serie, Materia materia) : this()
        {
            this.titulo = titulo;
            this.serie = serie;
            this.materia = materia;
        }
        public Questao()
        {
            this.alternativas = new List<Alternativa>();
        }
        public override void AtualizarInformacoes(Questao entidade)
        {
            this.titulo = entidade.titulo;
            this.serie = entidade.serie;
            this.materia = entidade.materia;
            this.alternativas = entidade.alternativas;
        }

        public override string[] Validar()
        {
            List<String> erros = new();
            if (string.IsNullOrEmpty(titulo))
            {
                erros.Add("O título não pode ser vazio");
            }
            if (titulo.Length > 5)
            {
                erros.Add("O título deve ter mais de 5 caracteres");
            }
            if (alternativas.Count < 2)
            {
                erros.Add("A questão deve ter pelo menos 2 alternativas");
            }
            return erros.ToArray();
        }
    }
}
