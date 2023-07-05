using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.Compartilhado;

namespace TestesDonaMaria.Infra.Compartilhado
{
    public abstract class RepositorioSQLBase<TEntidade, TMapeador> 
        where TEntidade : EntidadeBase<TEntidade>
        where TMapeador : MapeadorBase<TEntidade>, new()
    {
        protected const string enderecoBD = @"Data Source=(Localdb)\MSSQLLocaldb;
                                        Initial Catalog=TesteMarianaDB;
                                        Integrated Security=True;";

        private SqlConnection conexao;

        protected TMapeador mapeador;

        protected virtual string inserirSQL => "";
        protected virtual string editarSQL => "";
        protected virtual string excluirSQL => "";
        protected virtual string selecionarTodosSQL => "";
        protected virtual string selecionarPorIdSQL => selecionarTodosSQL + " WHERE id = @id";
        
        public RepositorioSQLBase()
        {
            this.mapeador = new TMapeador();
        }

        protected void Conexao()
        {
            conexao = new SqlConnection(enderecoBD);
            
            conexao.Open();
        }

        public virtual void Inserir(TEntidade registro)
        {
            Conexao();
            int id;

            SqlCommand comando = new SqlCommand(inserirSQL, conexao);

            mapeador.ConfigurarParametros(comando, registro);

            id = Convert.ToInt32(comando.ExecuteScalar());

            registro.id = id;

            conexao.Close();
        }
        public virtual void Editar(int id, TEntidade registroAtualizado)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(editarSQL, conexao);

            mapeador.ConfigurarParametros(comando, registroAtualizado);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteScalar();

            conexao.Close();
        }

        public virtual void Excluir(TEntidade registroSelecionado)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(excluirSQL, conexao);

            comando.ExecuteScalar();

            conexao.Close();
        }
        public virtual TEntidade SelecionarPorId(int id)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(selecionarPorIdSQL, conexao);

            comando.Parameters.AddWithValue("@id", id);

            SqlDataReader leitor = comando.ExecuteReader();

            conexao.Close();
            return mapeador.ConverterRegistro(leitor);
        }

        public virtual List<TEntidade> SelecionarTodos()
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

        public abstract bool EhRepetido(TEntidade registro);
        public abstract bool TemDependente(TEntidade registro);
    }
}