using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Infra.ModuloDisciplina
{
    public class RepositorioSQLDisciplina : RepositorioSQLBase<Disciplina, MapeadorDisciplina>
    {
        protected String inseriSQL = "INSERT INTO TBDisciplina (nome) VALUES (@nome)";
        protected String editarSQL = "UPDATE TBDisciplina SET nome = @nome WHERE id = @id";
        public RepositorioSQLDisciplina() : base()
        {
        }

    }
}
