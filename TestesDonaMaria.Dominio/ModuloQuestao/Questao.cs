using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.Dominio.ModuloQuestao
{
    public class Questao : EntidadeBase<Questao>
    {
        public string titulo;
        public string questaoCorreta;
        public int serie;
        public Disciplina disciplina;
        public Materia materia;

        public Questao(string titulo, string questaoCorreta, int serie, Disciplina disciplina, Materia materia)
        {
            this.titulo = titulo;
            this.questaoCorreta = questaoCorreta;
            this.serie = serie;
            this.disciplina = disciplina;
            this.materia = materia;
        }

        public Questao()
        {

        }
        public override void AtualizarInformacoes(Questao entidade)
        {
            this.titulo = entidade.titulo;
            this.questaoCorreta = entidade.questaoCorreta;
        }

        public override string ObterCampoSQL(bool ehParametro = false)
        {
            string sufixo = "]";
            string prefixo = "[";
            string campo = "";

            if (ehParametro)
            {
                prefixo = "@";
                sufixo = "";
            }

            campo += $"{prefixo}titulo{sufixo},";
            campo += $"{prefixo}questaoCorreta{sufixo}";

            return campo;
        }

        public override SqlParameter[] ObterParametroSQL()
        {
            return new SqlParameter[]
            {
                 new SqlParameter("@titulo", titulo),
                 new SqlParameter("@questaoCorreta", questaoCorreta)
            };
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();
            if (string.IsNullOrEmpty(titulo))
            {
                erros.Add("O titulo não pode ser vazio.");
            }
            if(string.IsNullOrEmpty(questaoCorreta))
            {
                erros.Add("É necessario definir a alternativa correta.");
            }
            return erros.ToArray();
        }

        public override bool VerificarRepeticao(Questao registro)
        {
            return id != registro.id && titulo == registro.titulo;
        }
    }
}
