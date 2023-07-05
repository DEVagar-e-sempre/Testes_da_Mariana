using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.Infra.ModuloMateria
{
    public class RepositorioSQLMateria : RepositorioSQLBase<Materia, MapeadorMateria>
    {
        protected override string inserirSQL => "INSERT INTO TBMateria (nome, disciplina_id) VALUES (@nome, @disciplina_id) SELECT SCOPE_IDENTITY();";

        protected override string editarSQL => "UPDATE TBMateria SET nome = @nome, disciplina_id = @disciplina_id WHERE id = @id";

        protected override string excluirSQL => "DELETE FROM TBMateria WHERE id = @id";

        protected override string selecionarTodosSQL => @"
                                                         SELECT 
	                                                        M.id AS materia_id, 
	                                                        M.nome AS materia_nome, 
	                                                        D.id AS disciplina_id, 
	                                                        D.nome AS disciplina_nome 
                                                        FROM TBMateria AS M
                                                        INNER JOIN TBDisciplina AS D ON D.id = M.disciplina_id 
";
        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE TBMateria.id = @id";
        public RepositorioSQLMateria() : base()
        {
        }
    }
}
