using Microsoft.Data.SqlClient;
using System.Data;
using TestesDonaMaria.Dominio.Compartilhado;

namespace TestesDonaMaria.Infra.Compartilhado
{
    public abstract class RepositorioSQLBase<TEntidade>
        where TEntidade : EntidadeBase<TEntidade>
    {
        protected SqlConnection conexao;

        public RepositorioSQLBase(SqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public bool Inserir(TEntidade registro)
        {
            String inserirSQL;
            inserirSQL = $"INSERT INTO TB{typeof(TEntidade).Name} ({registro.ObterCampoSQL()}) VALUES ({registro.ObterCampoSQL(true)})";

            SqlCommand comando = new SqlCommand(inserirSQL, conexao);
            comando.Parameters.AddRange(registro.ObterParametroSQL());
            comando.ExecuteScalar();
            return true;
        }
        public bool Editar(int id, TEntidade registroAtualizado)
        {
           String editarSQL;
            editarSQL = $"UPDATE TB{typeof(TEntidade).Name} SET {registroAtualizado.ObterCampoUpdate()} WHERE id = {id}";

            SqlCommand comando = new SqlCommand(editarSQL, conexao);
            comando.Parameters.AddRange(registroAtualizado.ObterParametroSQL());
            comando.ExecuteScalar();
            return true;
        }

        public void Excluir(TEntidade registroSelecionado)
        {
            String excluirSQL;
            excluirSQL = $"DELETE FROM TB{typeof(TEntidade).Name} WHERE id = {registroSelecionado.id}";
            SqlCommand comando = new SqlCommand(excluirSQL, conexao);
            comando.ExecuteScalar();
        }
        public TEntidade SelecionarPorId(int id, String campo = "")
        {
            if (String.IsNullOrEmpty(campo))
            {
                campo = "*";
            }
            String selecionarPorIDSQL;
            selecionarPorIDSQL = $"SELECT {campo} FROM TB{typeof(TEntidade).Name} WHERE id = {id}";
            SqlCommand comando = new SqlCommand(selecionarPorIDSQL, conexao);

            SqlDataReader leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                return (TEntidade)Activator.CreateInstance(typeof(TEntidade), leitor);
            }

            return null;
        }

        public List<TEntidade> SelecionarTodos()
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