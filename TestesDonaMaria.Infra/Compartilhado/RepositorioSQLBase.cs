using Microsoft.Data.SqlClient;
using System.Data;
using TestesDonaMaria.Dominio.Compartilhado;
using TestesDonaMaria.Dominio.ModuloDisciplina;

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
        
        public RepositorioSQLBase(SqlConnection conexao)
        {
            this.conexao = conexao;
            this.mapeador = new TMapeador();
        }

        public bool Inserir(TEntidade registro)
        {
            conexao.Open();

            SqlCommand comando = new SqlCommand(inserirSQL, conexao);

            mapeador.ConfigurarParametros(comando, registro);

            comando.ExecuteScalar();

            conexao.Close();

            return true;
        }
        public bool Editar(int id, TEntidade registroAtualizado)
        {
            conexao.Open();

            SqlCommand comando = new SqlCommand(editarSQL, conexao);

            mapeador.ConfigurarParametros(comando, registroAtualizado);

            comando.ExecuteScalar();

            conexao.Close();

            return true;
        }

        public void Excluir(TEntidade registroSelecionado)
        {
            conexao.Open();

            SqlCommand comando = new SqlCommand(excluirSQL, conexao);

            comando.ExecuteScalar();

            conexao.Close();
        }
        public TEntidade SelecionarPorId(int id)
        {
            conexao.Open();

            SqlCommand comando = new SqlCommand(selecionarPorIdSQL, conexao);

            comando.Parameters.AddWithValue("@id", id);

            SqlDataReader leitor = comando.ExecuteReader();

            return mapeador.ConverterRegistro(leitor);
        }

        public List<TEntidade> SelecionarTodos()
        {
            List<TEntidade> registros = new List<TEntidade>();

            SqlCommand comando = new SqlCommand(selecionarTodosSQL, conexao);

            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
               registros.Add(mapeador.ConverterRegistro(leitor));
            }

            return registros;
        }
    }
}