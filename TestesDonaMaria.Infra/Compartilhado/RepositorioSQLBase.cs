using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.Compartilhado;
using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Infra.Compartilhado
{
    public abstract class RepositorioSQLBase<TEntidade, TMapeador> 
        where TEntidade : EntidadeBase<TEntidade>
        where TMapeador : MapeadorBase<TEntidade>, new()
    {
        protected const string enderecoBD = @"Data Source=(Localdb)\MSSQLLocaldb;
                                        Initial Catalog=TesteMarianaDB;
                                        Integrated Security=True;";

        protected SqlConnection conexao;

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

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public virtual void Excluir(TEntidade registroSelecionado)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(excluirSQL, conexao);

            comando.Parameters.AddWithValue("id", registroSelecionado.id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }
        public virtual TEntidade SelecionarPorId(int id)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(selecionarPorIdSQL, conexao);

            TEntidade registro = null;

            comando.Parameters.AddWithValue("id", id);

            SqlDataReader leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                registro = mapeador.ConverterRegistro(leitor);
            }

            conexao.Close();

            return registro;
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
        public virtual int ObterProximoID()
        {
            string tipo = typeof(TEntidade).Name;
            string proximoIdSQL = $"SELECT IDENT_CURRENT('TB{tipo}')";
            Conexao();
            SqlCommand comando = new SqlCommand(proximoIdSQL, conexao);
            int proximoId = Convert.ToInt32(comando.ExecuteScalar());
            conexao.Close();
            return proximoId;
        }
    }
}