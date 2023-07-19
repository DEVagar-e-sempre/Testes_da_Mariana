using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Dominio.ModuloTeste;

namespace TestesDonaMaria.Infra.ModuloTeste
{
    public class RepositorioSQLTeste : RepositorioSQLBase<Teste,MapeadorTeste>
    {
        protected override string inserirSQL => @"INSERT INTO [TBTESTE] 
                                                    (
                                                        TITULO
                                                        ,MATERIA_ID
                                                        ,QUANTQUESTOES
                                                        ,SERIE
                                                        ,RECUPERACAO
                                                    )
                                                    VALUES 
                                                    (
                                                        @TITULO
                                                        ,@MATERIA_ID
                                                        ,@QUANTQUESTOES
                                                        ,@SERIE
                                                        ,@RECUPERACAO
                                                    ); SELECT SCOPE_IDENTITY();";

        protected override string editarSQL => @"UPDATE [TBTESTE] 
                                                    SET 
                                                        TITULO = @TITULO
                                                        , MATERIA_ID = @MATERIA_ID
                                                        , QUANTQUESTOES = @QUANTQUESTOES
                                                        , SERIE = @SERIE
                                                        ,RECUPERACAO = @RECUPERACAO
                                                    WHERE ID = @ID";

        protected override string excluirSQL => @"DELETE FROM TBTeste WHERE ID = @ID";
        protected override string selecionarTodosSQL => @"SELECT 
	                                                           T.[ID]            AS TESTE_ID
                                                              ,T.[TITULO]		 AS TESTE_TITULO
                                                              ,T.[QUANTQUESTOES] AS TESTE_QTD_QUESTOES
                                                              ,T.[SERIE]		 AS TESTE_SERIE
                                                              ,T.[RECUPERACAO] AS TESTE_RECUPERACAO

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

        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE T.ID = @ID";

        protected string inserirRelacaoQuestaoSQL => @"INSERT INTO TBTESTE_TBQUESTAO 
                                                        (
                                                            TESTE_ID, QUESTAO_ID
                                                        ) 
                                                        VALUES 
                                                        (
                                                            @TESTE_ID, @QUESTAO_ID
                                                        )";

        protected string carregarQuestaoSQL => @"SELECT 
	                                                TBTESTE_TBQUESTAO.QUESTAO_ID 
                                                FROM 
	                                                TBTESTE_TBQUESTAO INNER JOIN 
	                                                TBQUESTAO ON TBQUESTAO.ID = TBTESTE_TBQUESTAO.QUESTAO_ID 
                                                WHERE 
	                                                TBTESTE_TBQUESTAO.TESTE_ID = @TESTE_ID";

        protected string excluirRelacaoQuestaoSQL => @"DELETE FROM TBTESTE_TBQUESTAO WHERE TESTE_ID = @TESTE_ID";
        protected override string verificarRepeticaoNome => @" SELECT COUNT(*)
                                                                FROM 
                                                                    TBTESTE
                                                                WHERE 
                                                                    TBTESTE.TITULO = @TITULO 
                                                                AND 
                                                                    TBTESTE.MATERIA_ID = @MATERIA_ID
                                                                AND TBTESTE.ID != @ID";

        public RepositorioSQLTeste()
        {

        }

        public override void Inserir(Teste teste)
        {
            base.Inserir(teste);
            InserirRelacaoQuestao(teste);
        }

        public override void Editar(int id, Teste testeAtualizado)
        {
            ExcluirRelacaoQuestao(testeAtualizado);
            base.Editar(id, testeAtualizado);
            InserirRelacaoQuestao(testeAtualizado);
        }

        public override void Excluir(Teste teste)
        {
            ExcluirRelacaoQuestao(teste);
            base.Excluir(teste);
        }
        private void InserirRelacaoQuestao(Teste teste)
        {
            Conexao();

            foreach(Questao questao in teste.listaQuestoes)
            {
                SqlCommand comando = new SqlCommand(inserirRelacaoQuestaoSQL, conexao);
                mapeador.ConfigurarParametrosRelacaoQuestao(comando, questao.id, teste.id);
                comando.ExecuteScalar();
            }

            conexao.Close();
        }
        public void ExcluirRelacaoQuestao(Teste teste)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(excluirRelacaoQuestaoSQL, conexao);
            comando.Parameters.AddWithValue("@TESTE_ID", teste.id);

            comando.ExecuteNonQuery();

            conexao.Close();
        }
        public override Teste SelecionarPorId(int id)
        {
            Teste teste = base.SelecionarPorId(id);
            return teste;
        }
        public override List<Teste> SelecionarTodos()
        {
            List<Teste> listaTestes = base.SelecionarTodos();

            return listaTestes;
        }

        public override bool EhRepetido(Teste registro)
        {
            Conexao(); // LIKE é comparador de strings

            SqlCommand comando = new SqlCommand(verificarRepeticaoNome, conexao);

            comando.Parameters.AddWithValue("@TITULO", registro.titulo);
            comando.Parameters.AddWithValue("@MATERIA_ID", registro.materia.id);
            comando.Parameters.AddWithValue("@ID", registro.id);

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
