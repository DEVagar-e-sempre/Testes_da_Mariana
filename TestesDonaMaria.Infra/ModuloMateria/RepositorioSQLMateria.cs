using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.Infra.ModuloMateria
{
    public class RepositorioSQLMateria : RepositorioSQLBase<Materia, MapeadorMateria>
    {
        protected override string inserirSQL => @"INSERT INTO TBMATERIA 
                                                (
                                                NOME
                                                ,DISCIPLINA_ID
                                                ) 
                                                VALUES 
                                                (
                                                @NOME
                                                ,@DISCIPLINA_ID
                                                ) 
                                                SELECT SCOPE_IDENTITY();";

        protected override string editarSQL => @"UPDATE TBMATERIA 
                                                SET 
                                                NOME = @NOME
                                                ,DISCIPLINA_ID = @DISCIPLINA_ID
                                                WHERE ID = @ID";

        protected override string excluirSQL => @"DELETE FROM TBMATERIA WHERE ID = @ID";

        protected override string selecionarTodosSQL => @"
                                                        SELECT 
	                                                        M.ID AS MATERIA_ID, 
	                                                        M.NOME AS MATERIA_NOME, 
                                                            
	                                                        D.ID AS DISCIPLINA_ID, 
	                                                        D.NOME AS DISCIPLINA_NOME 
                                                        FROM 
                                                            TBMATERIA AS M
                                                            INNER JOIN TBDISCIPLINA AS D 
                                                        ON 
                                                            D.ID = M.DISCIPLINA_ID ";
        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE M.ID = @ID";
        protected override string verificarRepeticaoNome => @" SELECT COUNT(*)
                                                                FROM 
                                                                    TBMATERIA
                                                                WHERE 
                                                                    TBMATERIA.NOME = @NOME
                                                                AND 
                                                                    TBMATERIA.ID != @ID";

        public RepositorioSQLMateria()
        {
            
        }
        public RepositorioSQLMateria(string conexaoStrBD) : base(conexaoStrBD)
        {

        }

        public override bool EhRepetido(Materia registro)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(verificarRepeticaoNome, conexao);

            comando.Parameters.AddWithValue("@NOME", registro.nome);
            comando.Parameters.AddWithValue("@ID", registro.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }

        public override bool TemDependente(Materia registro)
        {
            Conexao();
            SqlCommand comando;
            int quantidade = 0;

            string verificarDepedenteSQL = @" SELECT COUNT(*)
                                                FROM 
                                                    TBTESTE, TBQUESTAO
                                                WHERE 
                                                    TBTESTE.MATERIA_ID = @ID
                                                OR
                                                    TBQUESTAO.MATERIA_ID = @ID";

            comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@ID", registro.id);

            quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }
        public List<Materia> SelecionarTodosPorDisciplina(int disciplinaId)
        {
            Conexao();
            List<Materia> materias = new List<Materia>();

            SqlCommand comando = new SqlCommand(selecionarTodosSQL + " WHERE DISCIPLINA_ID = @DISCIPLINA_ID", conexao);

            comando.Parameters.AddWithValue("@DISCIPLINA_ID", disciplinaId);

            SqlDataReader leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                materias.Add(mapeador.ConverterRegistro(leitor));
            }

            conexao.Close();

            return materias;
        }
    }
}
