using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public string titulo;
        public string alternativaCorreta;
        public int serie;
        public Disciplina disciplina;
        public Materia materia;

        public Questao(string titulo, string questaoCorreta, int serie, Materia materia)
        {
            this.titulo = titulo;
            this.alternativaCorreta = questaoCorreta;
            this.serie = serie;
            this.disciplina = disciplina;
            this.materia = materia;
        }
        public override void AtualizarInformacoes(Questao entidade)
        {
            this.titulo = entidade.titulo;
            this.alternativaCorreta = entidade.alternativaCorreta;
            this.serie = entidade.serie;
            this.disciplina = entidade.disciplina;
            this.materia = entidade.materia;
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
            if (string.IsNullOrEmpty(alternativaCorreta))
            {
                erros.Add("A alternativa correta não pode ser vazia");
            }
            return erros.ToArray();
        }
    }
}
