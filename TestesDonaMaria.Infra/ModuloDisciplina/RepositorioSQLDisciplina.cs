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

    }
}
