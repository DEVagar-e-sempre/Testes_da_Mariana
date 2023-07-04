using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Infra.ModuloDisciplina
{
    public class RepositorioSQLDisciplina : RepositorioSQLBase<Disciplina, MapeadorDisciplina>
    {
        public RepositorioSQLDisciplina(SqlConnection conexao) : base(conexao)
        {
        }
        protected String inseriSQL = "INSERT INTO TBDisciplina (nome) VALUES (@nome)";
        protected String editarSQL = "UPDATE TBDisciplina SET nome = @nome WHERE id = @id";

    }
}
