namespace TestesDonaMaria.Infra.ModuloQuestao
{
    public class RepositorioSQLQuestao : RepositorioSQLBase<Questao, MapeadorQuestao> 
    { 
        protected override string inserirSQL => "INSERT INTO TBQuestao (titulo, alternativaCorreta) VALUES (@titulo, @alternativaCorreta) SELECT SCOPE_IDENTITY();";
        protected override string editarSQL => "UPDATE TBQuestao SET titulo = @titulo, alternativaCorreta = @alternativaCorreta WHERE id = @id";
        protected override string excluirSQL => "DELETE FROM TBQuestao WHERE id = @id";
        protected override string selecionarPorIdSQL => "";
        protected override string selecionarTodosSQL => "";
        public RepositorioSQLQuestao() : base()
        {
        }
    }
}
