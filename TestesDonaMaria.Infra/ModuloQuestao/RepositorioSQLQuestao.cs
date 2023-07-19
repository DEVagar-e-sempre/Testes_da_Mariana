using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Dominio.ModuloTeste;

namespace TestesDonaMaria.Infra.ModuloQuestao
{
    public class RepositorioSQLQuestao : RepositorioSQLBase<Questao, MapeadorQuestao>
    {
        protected override string inserirSQL => @"INSERT INTO TBQUESTAO 
                                                    (
                                                        TITULO
                                                        , MATERIA_ID
                                                        , SERIE
                                                    ) 
                                                    VALUES 
                                                    (
                                                        @TITULO
                                                        , @MATERIA_ID
                                                        , @SERIE
                                                    ) 
                                                    SELECT SCOPE_IDENTITY();";

        protected override string editarSQL => @"UPDATE TBQUESTAO 
                                                SET 
                                                TITULO = @TITULO
                                                , MATERIA_ID = @MATERIA_ID
                                                , SERIE = @SERIE 
                                                WHERE ID = @ID";

        protected override string excluirSQL =>@"DELETE FROM TBQUESTAO 
                                                WHERE ID = @ID";

        protected override string selecionarTodosSQL => @"  SELECT 
	                                                            Q.ID AS QUESTAO_ID,
	                                                            Q.TITULO AS QUESTAO_TITULO,
	                                                            Q.SERIE AS QUESTAO_SERIE,
	                                                            M.ID AS MATERIA_ID,
	                                                            M.NOME AS MATERIA_NOME,
	                                                            D.ID AS DISCIPLINA_ID,
	                                                            D.NOME AS DISCIPLINA_NOME
                                                            FROM 
                                                                TBQUESTAO AS Q
                                                            INNER JOIN 
                                                                TBMATERIA AS M ON M.ID = Q.MATERIA_ID
                                                            INNER JOIN 
                                                                TBDISCIPLINA AS D ON D.ID = M.DISCIPLINA_ID

";

        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE Q.ID = @ID";

        protected string inserirAlternativaSQL => @"INSERT INTO TBALTERNATIVA 
                                                    (
                                                        ALTERNATIVA
                                                        ,ALTERNATIVA_CORRETA
                                                        ,QUESTAO_ID
                                                    ) 
                                                    VALUES 
                                                    (
                                                        @ALTERNATIVA
                                                        ,@ALTERNATIVA_CORRETA
                                                        ,@QUESTAO_ID
                                                    ) 
                                                    SELECT SCOPE_IDENTITY();";

        protected string carregarAlternativasSQL => @"SELECT * FROM TBALTERNATIVA WHERE QUESTAO_ID = @QUESTAO_ID";
        protected string excluirAlternativasSQL => @"DELETE FROM TBALTERNATIVA WHERE QUESTAO_ID = @QUESTAO_ID";

        protected string selecionarAleatoriamenteSQL => @"
                                                        SELECT TOP (@QUANTIDADE)
	                                                        Q.ID AS QUESTAO_ID,
	                                                        Q.TITULO AS QUESTAO_TITULO,
	                                                        Q.SERIE AS QUESTAO_SERIE,
	                                                        M.ID AS MATERIA_ID,
	                                                        M.NOME AS MATERIA_NOME,
	                                                        D.ID AS DISCIPLINA_ID,
	                                                        D.NOME AS DISCIPLINA_NOME
                                                        FROM 
                                                            TBQUESTAO AS Q
                                                        INNER JOIN 
                                                            TBMATERIA AS M ON M.ID = Q.MATERIA_ID
                                                        INNER JOIN 
                                                            TBDISCIPLINA AS D ON D.ID = M.DISCIPLINA_ID
                                                        WHERE Q.SERIE = @SERIE AND M.ID = @MATERIA_ID
                                                        ORDER BY NEWID()
";
        protected string selecionarPorTesteIdSQL => selecionarTodosSQL + " INNER JOIN TBTESTE_TBQUESTAO AS TQ ON TQ.QUESTAO_ID = Q.ID WHERE TQ.TESTE_ID = @TESTE_ID";
        protected override string verificarRepeticaoNome => @"
                            SELECT COUNT(*)
                            FROM TBQUESTAO
                            WHERE TBQUESTAO.TITULO = TITULO
                            AND TBQUESTAO.ID != @ID;";

        public RepositorioSQLQuestao()
        {

        }


        public override void Inserir(Questao questao)
        {
            base.Inserir(questao);
            InserirAlternativas(questao);
        }
        public override void Editar(int id, Questao questaoAtualizada)
        {
            base.Editar(id, questaoAtualizada);
            EditarAlternativas(questaoAtualizada);
        }
        public override void Excluir(Questao questao)
        {
            ExcluirAlternativas(questao);
            base.Excluir(questao);
        }

        public override Questao SelecionarPorId(int id)
        {
            Questao questao = base.SelecionarPorId(id);
            CarregarAlternativas(questao);
            return questao;
        }
        public override List<Questao> SelecionarTodos()
        {
            List<Questao> questoes = base.SelecionarTodos();
            foreach (Questao questao in questoes)
            {
                CarregarAlternativas(questao);
            }
            return questoes;
        }

        public List<Questao> SelecionarPorTesteId(int teste_id) { 
            List<Questao> questoes = new List<Questao>();
            Conexao();
            SqlCommand comando = new SqlCommand(selecionarPorTesteIdSQL, conexao);
            comando.Parameters.AddWithValue("@TESTE_ID", teste_id);
            SqlDataReader leitorRegistros = comando.ExecuteReader();
            while (leitorRegistros.Read())
            {
                Questao questao = mapeador.ConverterRegistro(leitorRegistros);
                questoes.Add(questao);
            }

            conexao.Close();

            foreach (Questao questao in questoes)
            {
                CarregarAlternativas(questao);
            }
            
            return questoes;
        }

        public List<Questao> SelecionarAleatoriamente(int quantidade, int materia_id, int serie)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(selecionarAleatoriamenteSQL, conexao);

            comando.Parameters.AddWithValue("@QUANTIDADE", quantidade);
            comando.Parameters.AddWithValue("@MATERIA_ID", materia_id);
            comando.Parameters.AddWithValue("@SERIE", serie);

            SqlDataReader leitorRegistros = comando.ExecuteReader();

            List<Questao> listaQuestoes = new List<Questao>();

            while (leitorRegistros.Read())
            {
                Questao questao = mapeador.ConverterRegistro(leitorRegistros);
                listaQuestoes.Add(questao);
            }

            conexao.Close();

            foreach (Questao questao in listaQuestoes)
            {
                CarregarAlternativas(questao);
            }

            return listaQuestoes;
        }

        public void EditarAlternativas(Questao questao)
        {
            base.Editar(questao.id, questao);
            ExcluirAlternativas(questao);
            InserirAlternativas(questao);
        }

        private void ExcluirAlternativas(Questao questao)
        {
            Conexao();
            SqlCommand comando = new SqlCommand(excluirAlternativasSQL, conexao);
            comando.Parameters.AddWithValue("QUESTAO_ID", questao.id);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public void InserirAlternativas(Questao questao)
        {
            Conexao();

            foreach (Alternativa alternativa in questao.alternativas)
            {
                SqlCommand comando = new SqlCommand(inserirAlternativaSQL, conexao);
                alternativa.questaoId = questao.id;
                mapeador.ConfigurarParamentrosAlternativa(comando, alternativa);
                alternativa.id = Convert.ToInt32(comando.ExecuteScalar());
            }
            conexao.Close();
        }
        protected void CarregarAlternativas(Questao questao)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(carregarAlternativasSQL, conexao);
            comando.Parameters.AddWithValue("@QUESTAO_ID", questao.id);

            SqlDataReader leitorRegistros = comando.ExecuteReader();

            questao.alternativas.Clear();

            while (leitorRegistros.Read())
            {
                Alternativa alternativa = mapeador.ConverterRegistroAlternativa(leitorRegistros);
                questao.alternativas.Add(alternativa);
            }
            conexao.Close();
        }

        public override bool EhRepetido(Questao registro)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(verificarRepeticaoNome, conexao);

            comando.Parameters.AddWithValue("@TITULO", registro.enunciado);
            comando.Parameters.AddWithValue("@ID", registro.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }

        public override bool TemDependente(Questao registro)
        {
            Conexao();
            String verificarDepedenteSQL = @"
                            SELECT COUNT(*)
                            FROM TBTESTE_TBQUESTAO
                            WHERE TBTESTE_TBQUESTAO.QUESTAO_ID = @ID
";

            SqlCommand comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@ID", registro.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }
    }
}
