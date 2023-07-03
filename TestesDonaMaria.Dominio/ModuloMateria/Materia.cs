using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Dominio.ModuloMateria
{
    public class Materia : EntidadeBase<Materia>
    {
        public string nome;
        public Disciplina disciplina;
        public int disciplinaId;

        public Materia(string nome, Disciplina disciplina)
        {
            this.nome = nome;
            this.disciplina = disciplina;
        }
        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(nome))
            {
                erros.Add("O campo do Nome é obrigatório!");
            }
            else if (disciplina == null)
            {
                erros.Add("É obrigatório a seleção da disciplina!");
            }
            /*
            else if (serie == null)
            {
                erros.Add("É obrigatório a seleção de uma série!");
            }
            */
            return erros.ToArray();
        }

        public override void AtualizarInformacoes(Materia entidade)
        {
            this.nome = entidade.nome;
            this.disciplina = entidade.disciplina;
            //this.serie = entidade.serie;
        }
        public override void AtualizarInformacoes(SqlDataReader leitor)
        {
            this.id = (int)leitor["id"];
            this.nome = (string)leitor["nome"];
            this.disciplinaId = (int)leitor["idDisciplina"];
        }

        //public override string ObterCampoSQL(bool ehParametro = false)
        //{
        //    string sufixo = "]";
        //    string prefixo = "[";
        //    string campo = "";

        //    if (ehParametro)
        //    {
        //        prefixo = "@";
        //        sufixo = "";
        //    }

<<<<<<< Updated upstream
            campo += $"{prefixo}nome{sufixo},";
            campo += $"{prefixo}disciplina{sufixo},";
            //campo += $"{prefixo}serie{sufixo}";
=======
        //    campo += $"{prefixo}nome{sufixo},";
        //    campo += $"{prefixo}disciplina{sufixo},";
        //    campo += $"{prefixo}serie{sufixo}";
>>>>>>> Stashed changes

        //    return campo;
        //}

<<<<<<< Updated upstream
        public override SqlParameter[] ObterParametroSQL()
        {
            return new SqlParameter[]
            {
                 new SqlParameter("@nome", nome),
                 new SqlParameter("@disciplina_id", disciplinaId),
            };
        }
=======
        //public override SqlParameter[] ObterParametroSQL()
        //{
        //    return new SqlParameter[]
        //    {
        //         new SqlParameter("@nome", nome),
        //         new SqlParameter("@disciplina", disciplina),
        //         new SqlParameter("@serie", serie)
        //    };
        //}
>>>>>>> Stashed changes

        public override string ObterCampoUpdate()
        {
            string sufixo = "]";
            string prefixo = "[";
            string campo = "";

            campo += $"{prefixo}nome{sufixo} = @nome,";
            campo += $"{prefixo}disciplina_id{sufixo} = @disciplina_id";

            return campo;
        }
    }
}
