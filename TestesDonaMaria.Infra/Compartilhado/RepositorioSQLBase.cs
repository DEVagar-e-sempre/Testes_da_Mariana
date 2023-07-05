using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.Compartilhado;

namespace TestesDonaMaria.Infra.Compartilhado
{
    public abstract class RepositorioSQLBase<TEntidade, TMapeador> 
        where TEntidade : EntidadeBase<TEntidade>
        where TMapeador : MapeadorBase<TEntidade>, new()
    {
        protected SqlConnection conexao;

        protected TMapeador mapeador;

        protected virtual String inserirSQL => "";
        protected virtual String editarSQL => "";
        protected virtual String excluirSQL => "";
        protected virtual String selecionarTodosSQL => "";
        protected virtual String selecionarPorIdSQL => selecionarTodosSQL + " WHERE id = @id";
        
        public RepositorioSQLBase()
        {
            this.mapeador = new TMapeador();
        }

        private void Conexao()
        {
            conexao.ConnectionString = @"Data Source=(Localdb)\MSSQLLocaldb;
                                        Initial Catalog=TesteMarianaDB;
                                        Integrated Security=True;";
            
            conexao.Open();
        }

        /*protected void EhRepetido(TEntidade registros){} --> verificação de repetição dos objetos*/

        public bool Inserir(TEntidade registro)
        {
            Conexao();
            int id;

            SqlCommand comando = new SqlCommand(inserirSQL, conexao);

            mapeador.ConfigurarParametros(comando, registro);

            id = Convert.ToInt32(comando.ExecuteScalar());

            registro.id = id;

            conexao.Close();

            return true;
        }
        public bool Editar(int id, TEntidade registroAtualizado)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(editarSQL, conexao);

            mapeador.ConfigurarParametros(comando, registroAtualizado);

            comando.ExecuteScalar();

            conexao.Close();

            return true;
        }

        public void Excluir(TEntidade registroSelecionado)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(excluirSQL, conexao);

            comando.ExecuteScalar();

            conexao.Close();
        }
        public TEntidade SelecionarPorId(int id)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(selecionarPorIdSQL, conexao);

            comando.Parameters.AddWithValue("@id", id);

            SqlDataReader leitor = comando.ExecuteReader();

            conexao.Close();
            return mapeador.ConverterRegistro(leitor);
        }

        public List<TEntidade> SelecionarTodos()
        {
            Conexao();

            List<TEntidade> registros = new List<TEntidade>();

            SqlCommand comando = new SqlCommand(selecionarTodosSQL, conexao);

            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
               registros.Add(mapeador.ConverterRegistro(leitor));
            }

            conexao.Close();
            return registros;
        }
    }
}