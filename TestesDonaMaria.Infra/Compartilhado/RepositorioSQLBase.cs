using Microsoft.Data.SqlClient;
<<<<<<< Updated upstream
using System.Data;
=======
using Microsoft.Win32;
>>>>>>> Stashed changes
using TestesDonaMaria.Dominio.Compartilhado;

namespace TestesDonaMaria.Infra.Compartilhado
{
    public abstract class RepositorioSQLBase<TEntidade>
        where TEntidade : EntidadeBase<TEntidade>
    {
        private SqlConnection conexao;

<<<<<<< Updated upstream
        public RepositorioSQLBase(SqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public bool Inserir(TEntidade registro)
=======
        protected abstract string StrInserir { get; }
        protected abstract string StrEditar { get; }
        protected abstract string StrSelecionarTodos { get; }
        protected abstract string StrSelecionarPorId { get; }

        protected const string strRemover = @"DELETE FROM [TESTEDB] WHERE [ID] = @ID";

        private void IniciarConexaoBD()
>>>>>>> Stashed changes
        {
            conexao.ConnectionString = @"Data Source=(Localdb)\\MSSQLLocaldb;
                                        Initial Catalog=TesteMarianaDB;
                                        Integrated Security=True;
                                        Pooling=False";

<<<<<<< Updated upstream
            SqlCommand comando = new SqlCommand(inserirSQL, conexao);
            comando.Parameters.AddRange(registro.ObterParametroSQL());
            comando.ExecuteScalar();
=======
            conexao.Open();
        }

        public virtual bool Inserir(TEntidade registro)
        {
            IniciarConexaoBD();
            

            conexao.Close();
>>>>>>> Stashed changes
            return true;
        }
        public virtual bool Editar(int id, TEntidade registroAtualizado)
        {
            IniciarConexaoBD();
            string editarSQL;

            return true;
        }

        public virtual void Excluir(TEntidade registroSelecionado)
        {
            IniciarConexaoBD();

            SqlCommand comando = new SqlCommand(strRemover, conexao);

            comando.Parameters.AddWithValue("@ID", registroSelecionado.id);

            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public virtual void AdicionarRegistroEContador(List<TEntidade> listaRegistros, int contador)
        {
           String editarSQL;
            editarSQL = $"UPDATE TB{typeof(TEntidade).Name} SET {registroAtualizado.ObterCampoUpdate()} WHERE id = {id}";

            SqlCommand comando = new SqlCommand(editarSQL, conexao);
            comando.Parameters.AddRange(registroAtualizado.ObterParametroSQL());
            comando.ExecuteScalar();
            return true;
        }

        public virtual bool EhRepetido(TEntidade entidade)
        {
            String excluirSQL;
            excluirSQL = $"DELETE FROM TB{typeof(TEntidade).Name} WHERE id = {registroSelecionado.id}";
            SqlCommand comando = new SqlCommand(excluirSQL, conexao);
            comando.ExecuteScalar();
        }
<<<<<<< Updated upstream
        public TEntidade SelecionarPorId(int id, String campo = "")
=======

        public virtual TEntidade SelecionarPorId(int id)
>>>>>>> Stashed changes
        {
            if (String.IsNullOrEmpty(campo))
            {
                campo = "*";
            }
            String selecionarPorIDSQL;
            selecionarPorIDSQL = $"SELECT {campo} FROM TB{typeof(TEntidade).Name} WHERE id = {id}";
            SqlCommand comando = new SqlCommand(selecionarPorIDSQL, conexao);

<<<<<<< Updated upstream
            SqlDataReader leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                return (TEntidade)Activator.CreateInstance(typeof(TEntidade), leitor);
            }

            return null;
        }

        public List<TEntidade> SelecionarTodos()
=======
        public virtual List<TEntidade> SelecionarTodos()
>>>>>>> Stashed changes
        {
            List<TEntidade> registros = new List<TEntidade>();
            String selecionarTodosSQL;

            selecionarTodosSQL = $"SELECT * FROM TB{typeof(TEntidade).Name}";
            SqlCommand comando = new SqlCommand(selecionarTodosSQL, conexao);
            SqlDataReader leitor = comando.ExecuteReader();
            
            while (leitor.Read())
            {
                registros.Add((TEntidade)Activator.CreateInstance(typeof(TEntidade), leitor));
            }
            return registros;
        }
    }
}