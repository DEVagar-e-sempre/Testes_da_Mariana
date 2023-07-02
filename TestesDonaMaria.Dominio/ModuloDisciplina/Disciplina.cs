using Microsoft.Data.SqlClient;

namespace TestesDonaMaria.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string nome;
        public Disciplina(string nome)
        {
            this.nome = nome;
        }
        public Disciplina()
        {

        }
        public override void AtualizarInformacoes(Disciplina entidade)
        {
            nome = entidade.nome;
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

            campo += $"{prefixo}nome{sufixo}";

            return campo;
        }

        public override SqlParameter[] ObterParametroSQL()
        {
            return new SqlParameter[]
            {
                 new SqlParameter("@nome", nome),
            };
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();
            if (string.IsNullOrEmpty(nome))
            {
                erros.Add("O nome não pode ser vazio");
            }
            return erros.ToArray();
        }

        public override bool VerificarRepeticao(Disciplina registro)
        {
            return id != registro.id && nome == registro.nome;
        }
    }
}
