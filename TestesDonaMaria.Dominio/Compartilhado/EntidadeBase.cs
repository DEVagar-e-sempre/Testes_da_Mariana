using Microsoft.Data.SqlClient;

namespace TestesDonaMaria.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public int id { get; set; }

        public abstract string[] Validar();

        public abstract void AtualizarInformacoes(T entidade);

        public abstract bool VerificarRepeticao(T registro);

        public abstract string ObterCampoSQL(bool ehParametro = false);

        public abstract SqlParameter[] ObterParametroSQL();
    }
}
