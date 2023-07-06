using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloTeste;

namespace TestesDonaMaria.Infra.ModuloTeste
{
    public class RepositorioSQLTeste : RepositorioSQLBase<Teste,MapeadorTeste>
    {
        protected override string inserirSQL => @"INSERT INTO [TBTESTE] 
                                                    (
                                                        titulo
                                                        ,materia_id
                                                        ,quantquestoes
                                                        ,serie
                                                    )
                                                    VALUES 
                                                    (
                                                        @titulo
                                                        ,@materia_id
                                                        ,@quantquestoes
                                                        ,@serie
                                                    )";

        protected override string editarSQL => @"UPDATE [TBTESTE] 
                                                    SET 
                                                        titulo = @titulo
                                                        , materia_id = @materia_id
                                                        , quantQuestoes = @quantQuestoes
                                                        , serie = @serie 
                                                    WHERE id = @id";

        protected override string excluirSQL => @"DELETE FROM Teste WHERE id = @id";
        protected override string selecionarTodosSQL => @"SELECT 
	                                                           T.[ID]            AS TESTE_ID
                                                              ,T.[TITULO]		 AS TESTE_TITULO
                                                              ,T.[QUANTQUESTOES] AS TESTE_QTD_QUESTOES
                                                              ,T.[SERIE]		 AS TESTE_SERIE

	                                                          ,M.[ID]            AS MATERIA_ID
	                                                          ,M.[NOME]			 AS MATERIA_NOME
	                                                          
	                                                          ,D.[ID]            AS DISCIPLINA_ID
	                                                          ,D.[NOME]			 AS DISCIPLINA_NOME

                                                          FROM 
	                                                           [TBTESTE] AS T INNER JOIN
	                                                           [TBMATERIA] AS M 
                                                          ON 
	                                                           T.[MATERIA_ID] = M.[ID] INNER JOIN
	                                                           [TBDISCIPLINA] AS D
                                                          ON   
	                                                           M.[DISCIPLINA_ID] = D.[ID] ";

        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE id = @id";
        public RepositorioSQLTeste() : base()
        {
        }

        public override bool EhRepetido(Teste registro)
        {
            Conexao(); // LIKE é comparador de strings
            string verificarDepedenteSQL = @" SELECT COUNT(*)
                                                FROM 
                                                    TBTeste
                                                WHERE 
                                                    TBTESTE.TITULO = @titulo 
                                                AND 
                                                    TBTESTE.MATERIA_ID = @materia_id;";

            SqlCommand comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@titulo", registro.titulo);
            comando.Parameters.AddWithValue("@materia_id", registro.materia.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }

        public override bool TemDependente(Teste registro)
        {
            return false;
        }
    }
}
