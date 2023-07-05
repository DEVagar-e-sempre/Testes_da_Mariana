using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Infra.ModuloDisciplina
{
    public class RepositorioSQLDisciplina : RepositorioSQLBase<Disciplina, MapeadorDisciplina>
    {
        protected override string inserirSQL => "INSERT INTO TBDisciplina (nome) VALUES (@nome) SELECT SCOPE_IDENTITY();";
        protected override string editarSQL => "UPDATE TBDisciplina SET nome = @nome WHERE id = @id";
        protected override string excluirSQL => "DELETE FROM TBDisciplina WHERE id = @id";
        protected override string selecionarPorIdSQL => "";
        protected override string selecionarTodosSQL => "";
        public RepositorioSQLDisciplina() : base()
        {
        }

        public override bool EhRepetido(Disciplina registro)
        {
            Conexao();
            String verificarDepedenteSQL = @"
                            SELECT COUNT(*)
                            FROM TBDisciplina
                            WHERE TBDisciplina.nome LIKE '%@nome%';

";

            SqlCommand comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@nome", registro.nome);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }

        public override bool TemDependente(Disciplina registro)
        {
            Conexao();
            String verificarDepedenteSQL = @"
                            SELECT COUNT(*) 
                            FROM TBMateria 
                            WHERE TBMateria.disciplina_id = @id
";

            SqlCommand comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@id", registro.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }
    }
}
