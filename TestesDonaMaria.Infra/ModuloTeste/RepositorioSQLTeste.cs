namespace TestesDonaMaria.Infra.ModuloTeste
{
    public class RepositorioSQLTeste : RepositorioSQLBase<Teste,MapeadorTeste>
    {
        protected override string inserirSQL => "INSERT INTO Teste (titulo, disciplina_id, materia_id, quantQuestoes, serie) VALUES (@titulo, @disciplina_id, @materia_id, @quantQuestoes, @serie)";
        protected override string editarSQL => "UPDATE Teste SET titulo = @titulo, disciplina_id = @disciplina_id, materia_id = @materia_id, quantQuestoes = @quantQuestoes, serie = @serie WHERE id = @id";
        protected override string excluirSQL => "DELETE FROM Teste WHERE id = @id";
        protected override string selecionarTodosSQL => "SELECT * FROM Teste";
        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE id = @id";
        public RepositorioSQLTeste() : base()
        {
        }
    }
}
