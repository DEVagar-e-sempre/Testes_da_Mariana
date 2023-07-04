using Microsoft.Data.SqlClient;

namespace TestesDonaMaria.Dominio.Compartilhado
{
    public abstract class EntidadeBase<T>
    {
        public EntidadeBase()
        {

        }

        public int id { get; set; }

        public abstract string[] Validar();

        public abstract void AtualizarInformacoes(T entidade);


    }
}
