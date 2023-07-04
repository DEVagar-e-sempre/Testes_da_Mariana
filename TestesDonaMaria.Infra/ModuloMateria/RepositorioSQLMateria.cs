using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.Infra.ModuloMateria
{
    public class RepositorioSQLMateria : RepositorioSQLBase<Materia, MapeadorMateria>
    {
        protected override string inserirSQL => "INSERT INTO TBMateria (nome, disciplina_id) VALUES (@nome, @disciplina_id) SELECT SCOPE_IDENTITY();";

        protected override string editarSQL => "UPDATE TBMateria SET nome = @nome, disciplina_id = @disciplina_id WHERE id = @id";

        protected override string excluirSQL => "DELETE FROM TBMateria WHERE id = @id";

        protected override string selecionarPorIdSQL => "SELECT m.id AS materia_id, m.nome AS nome_materia, d.id AS disciplina_id, d.nome AS nome_disciplina FROM TBMateria AS m INNER JOIN TBDisciplina AS d ON m.disciplina_id = d.id WHERE m.id = @id";

        protected override string selecionarTodosSQL => "SELECT m.id AS materia_id, m.nome AS nome_materia, d.id AS disciplina_id, d.nome AS nome_disciplina FROM TBMateria AS m INNER JOIN TBDisciplina AS d ON m.disciplina_id = d.id";
        public RepositorioSQLMateria(SqlConnection conexao) : base(conexao)
        {
        }
    }
}
