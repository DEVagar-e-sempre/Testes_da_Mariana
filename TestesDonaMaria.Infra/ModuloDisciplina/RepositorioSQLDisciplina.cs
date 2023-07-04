using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Infra.ModuloDisciplina
{
    public class RepositorioSQLDisciplina : RepositorioSQLBase<Disciplina>
    {
        public RepositorioSQLDisciplina(SqlConnection conexao) : base(conexao)
        {
        }

        public override bool Inserir(Disciplina registro)
        {
            String inserirSQL;
            inserirSQL = $"INSERT INTO TBDisciplina (nome) VALUES (@nome)";
            conexao.Open();
            SqlCommand comando = new SqlCommand(inserirSQL, conexao);
            comando.Parameters.AddRange(registro.ObterParametroSQL());
            comando.ExecuteScalar();
            return true;
        }
        public override bool Editar(int id, Disciplina registroAtualizado)
        {
            String editarSQL;
            editarSQL = $"UPDATE TB{typeof(Disciplina).Name} SET {registroAtualizado.ObterCampoUpdate()} WHERE id = {id}";

            SqlCommand comando = new SqlCommand(editarSQL, conexao);
            comando.Parameters.AddRange(registroAtualizado.ObterParametroSQL());
            comando.ExecuteScalar();
            return true;
        }

        public override void Excluir(Disciplina registroSelecionado)
        {
            String excluirSQL;
            excluirSQL = $"DELETE FROM TB{typeof(Disciplina).Name} WHERE id = {registroSelecionado.id}";
            SqlCommand comando = new SqlCommand(excluirSQL, conexao);
            comando.ExecuteScalar();
        }
        public override Disciplina SelecionarPorId(int id, String campo = "")
        {
            if (String.IsNullOrEmpty(campo))
            {
                campo = "*";
            }
            String selecionarPorIDSQL;
            selecionarPorIDSQL = $"SELECT {campo} FROM TB{typeof(Disciplina).Name} WHERE id = {id}";
            SqlCommand comando = new SqlCommand(selecionarPorIDSQL, conexao);

            SqlDataReader leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                return (Disciplina)Activator.CreateInstance(typeof(Disciplina), leitor);
            }

            return null;
        }

        public override List<Disciplina> SelecionarTodos()
        {
            List<Disciplina> registros = new List<Disciplina>();
            String selecionarTodosSQL;

            selecionarTodosSQL = $"SELECT * FROM TB{typeof(Disciplina).Name}";
            SqlCommand comando = new SqlCommand(selecionarTodosSQL, conexao);
            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                registros.Add((Disciplina)Activator.CreateInstance(typeof(Disciplina), leitor));
            }
            return registros;
        }
}
}
