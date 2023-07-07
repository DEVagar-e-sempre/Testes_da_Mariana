using Microsoft.Data.SqlClient;
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
                                                        INNER JOIN TBDisciplina AS D ON D.id = M.disciplina_id ";
        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE M.id = @id";
        public RepositorioSQLMateria() : base()
        {
        }

        public override bool EhRepetido(Materia registro)
        {
            Conexao();
            string verificarDepedenteSQL = @" SELECT COUNT(*)
                                                FROM 
                                                    TBMATERIA
                                                WHERE 
                                                    TBMATERIA.NOME = @nome";

            SqlCommand comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@nome", registro.nome);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }

        public override bool TemDependente(Materia registro)
        {
            SqlCommand comando;
            int quantidade = 0;

            string verificarDepedenteSQL = @" SELECT COUNT(*)
                                                FROM 
                                                    TBTeste, TBQuestao
                                                WHERE 
                                                    TBTeste.materia_id = @id
                                                OR
                                                    TBQuestao.materia_id = @id";

            comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@id", registro.id);

            quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }
        public List<Materia> SelecionarTodosPorDisciplina(int disciplinaId)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(selecionarTodosSQL + " WHERE disciplina_id = @disciplina_id", conexao);

            comando.Parameters.AddWithValue("@disciplina_id", disciplinaId);

            SqlDataReader leitor = comando.ExecuteReader();

            List<Materia> materias = new List<Materia>();

            while (leitor.Read())
            {
                materias.Add(mapeador.ConverterRegistro(leitor));
            }

            conexao.Close();

            return materias;
        }
    }
}
