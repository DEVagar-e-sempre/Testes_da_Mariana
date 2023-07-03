using Microsoft.Data.SqlClient;

namespace TestesDonaMaria.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {

        public EntidadeBase(SqlDataReader leitor)
        {
            AtualizarInformacoes(leitor);
        }
        public EntidadeBase()
        {

        }

        public int id { get; set; }

        public abstract string[] Validar();

        public abstract void AtualizarInformacoes(T entidade);

        public abstract void AtualizarInformacoes(SqlDataReader leitor);

        public abstract string ObterCampoSQL(bool ehParametro = false);

        public abstract SqlParameter[] ObterParametroSQL();

        public abstract string ObterCampoUpdate();
    }
}
