using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TestesDonaMaria.Dominio.Compartilhado;

namespace TestesDonaMaria.Infra.Compartilhado
{
    public abstract class RepositorioSQLBase<TEntidade, TMapeador> : IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase<TEntidade>
        where TMapeador : MapeadorBase<TEntidade>, new()
    {
        private string conexaoStrBD = @"Data Source=(Localdb)\MSSQLLocaldb; Initial Catalog=TesteMarianaDB; Integrated Security=True;";

        protected SqlConnection conexao;

        protected TMapeador mapeador;

        protected virtual string inserirSQL => "";
        protected virtual string editarSQL => "";
        protected virtual string excluirSQL => "";
        protected virtual string selecionarTodosSQL => "";
        protected virtual string selecionarPorIdSQL => selecionarTodosSQL + " WHERE ID = @ID";
        protected virtual string verificarRepeticaoNome => "";

        public RepositorioSQLBase(string conexaoStrBD)
        {
            this.conexaoStrBD = conexaoStrBD;
            this.mapeador = new TMapeador();
        }
        public RepositorioSQLBase()
        {
        }

        protected void Conexao()
        {
            conexao = new SqlConnection(conexaoStrBD);
            
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

            comando.Parameters.AddWithValue("@ID", id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public virtual void Excluir(TEntidade registroSelecionado)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(excluirSQL, conexao);

            comando.Parameters.AddWithValue("@ID", registroSelecionado.id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }
        public virtual TEntidade SelecionarPorId(int id)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(selecionarPorIdSQL, conexao);

            TEntidade registro = null;

            comando.Parameters.AddWithValue("@ID", id);

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

        public virtual bool EhRepetido(TEntidade registro) { return  false; }
        public abstract bool TemDependente(TEntidade registro);
        public virtual int ObterProximoID()
        {
            string tipo = typeof(TEntidade).Name;
            string proximoIdSQL = $"SELECT IDENT_CURRENT('TB{tipo.ToUpper()}')";
            Conexao();
            SqlCommand comando = new SqlCommand(proximoIdSQL, conexao);
            int proximoId = Convert.ToInt32(comando.ExecuteScalar());
            conexao.Close();
            if(proximoId == 1)
            {
                return proximoId;
            }
            return proximoId+1;
        }
    }
}