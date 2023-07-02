using Microsoft.Data.SqlClient;

namespace TestesDonaMaria.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {

        public EntidadeBase(SqlDataReader registro)
        {
            AtualizarInformacoes(registro);
        }
        public EntidadeBase()
        {

        }

        public int id { get; set; }

        public abstract string[] Validar();

        public abstract void AtualizarInformacoes(T entidade);

        public abstract void AtualizarInformacoes(SqlDataReader registro);

        public abstract bool VerificarRepeticao(T registro);

        public abstract string ObterCampoSQL(bool ehParametro = false);

        public abstract SqlParameter[] ObterParametroSQL();

        public abstract string ObterCampoUpdate();
    }
}
