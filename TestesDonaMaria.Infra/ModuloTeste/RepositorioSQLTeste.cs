using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloQuestao;
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

        protected string inserirRelacaoQuestaoSQL => @"INSERT INTO TBTESTE_TBQUESTAO (TESTE_ID, QUESTAO_ID) VALUES (@teste_id, @questao_id)";

        protected string carregarQuestaoSQL => @"SELECT 
	                                                TBTESTE_TBQUESTAO.questao_id 
                                                FROM 
	                                                TBTeste_TBQuestao INNER JOIN 
	                                                TBQuestao ON TBQuestao.id = TBTeste_TBQuestao.questao_id 
                                                WHERE 
	                                                TBTeste_TBQuestao.teste_id = @teste_id";

        protected string excluirQuestaoSQL => @"DELETE FROM TBTESTE_TBQUESTAO WHERE TESTE_ID = @teste_id";

        public RepositorioSQLTeste() : base()
        {
        }

        public override void Inserir(Teste teste)
        {
            base.Inserir(teste);
            InserirRelacaoQuestao(teste);
        }

        public override void Editar(int id, Teste testeAtualizado)
        {
            base.Editar(id, testeAtualizado);
            EditarQuestao(testeAtualizado);
        }

        public override void Excluir(Teste teste)
        {
            base.Excluir(teste);
            ExcluirQuestao(teste);
        }
        private void InserirRelacaoQuestao(Teste teste)
        {
            Conexao();

            foreach(Questao questao in teste.listaQuestoes)
            {
                SqlCommand comando = new SqlCommand(inserirRelacaoQuestaoSQL, conexao);
                mapeador.ConfigurarParametrosRelacaoQuestao(comando, questao.id, teste.id);
            }

            conexao.Close();
        }

        public override Teste SelecionarPorId(int id)
        {
            Teste teste = base.SelecionarPorId(id);
            CarregarQuestao(teste);
            return teste;
        }
        public override List<Teste> SelecionarTodos()
        {
            List<Teste> listaTestes = base.SelecionarTodos();

            foreach (Teste teste in listaTestes)
            {
                CarregarQuestao(teste);
            }
            return listaTestes;
        }

        private void EditarQuestao(Teste teste)
        {
            base.Editar(teste.id, teste);
            ExcluirQuestao(teste);
            InserirRelacaoQuestao(teste);
        }

        private void ExcluirQuestao(Teste teste)
        {
            Conexao();
            SqlCommand comando = new SqlCommand(excluirQuestaoSQL, conexao);
            comando.Parameters.AddWithValue("teste_id", teste.id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        protected void CarregarQuestao(Teste teste)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(carregarQuestaoSQL, conexao);
            comando.Parameters.AddWithValue("@teste_id", teste.id);

            SqlDataReader leitorRegistros = comando.ExecuteReader();

            teste.listaQuestoes.Clear();

            while (leitorRegistros.Read())
            {
                Questao questao = mapeador.ConverterRegistroQuestao(leitorRegistros);
                teste.listaQuestoes.Add(questao);
            }
            conexao.Close();
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
