using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string nome;
        public Disciplina disciplina;
        public int[] serie;

        public override void AtualizarInformacoes(Materia entidade)
        {
            this.nome = entidade.nome;
            this.disciplina = entidade.disciplina;
            this.serie = entidade.serie;
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

            campo += $"{prefixo}nome{sufixo},";
            campo += $"{prefixo}disciplina{sufixo},";
            campo += $"{prefixo}serie{sufixo}";

            return campo;
        }

        public override SqlParameter[] ObterParametroSQL()
        {
            return new SqlParameter[]
            {
                 new SqlParameter("@nome", nome),
                 new SqlParameter("@disciplina", disciplina),
                 new SqlParameter("@serie", serie)
            };
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(nome))
            {
                erros.Add("O campo do Nome é obrigatório!");
            }
            else if(disciplina == null)
            {
                erros.Add("É obrigatório a seleção da disciplina!");
            }
            else if(serie == null)
            {
                erros.Add("É obrigatório a seleção de uma série!");
            }

            return erros.ToArray();
        }

        public override bool VerificarRepeticao(Materia registro)
        {
            return id != registro.id && nome == registro.nome;
        }
    }
}
