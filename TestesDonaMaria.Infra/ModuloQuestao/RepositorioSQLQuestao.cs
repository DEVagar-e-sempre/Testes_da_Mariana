using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Dominio.ModuloTeste;

namespace TestesDonaMaria.Infra.ModuloQuestao
{
    public class RepositorioSQLQuestao : RepositorioSQLBase<Questao, MapeadorQuestao>
    {
        protected override string inserirSQL => "INSERT INTO TBQuestao (titulo, materia_id, serie) VALUES (@titulo, @materia_id, @serie) SELECT SCOPE_IDENTITY();";

        protected override string editarSQL => "UPDATE TBQuestao SET titulo = @titulo, materia_id = @materia_id, serie = @serie WHERE id = @id";

        protected override string excluirSQL => "DELETE FROM TBQuestao WHERE id = @id";

        protected override string selecionarTodosSQL => @"
                                                            SELECT 
	                                                            Q.id AS QUESTAO_ID,
	                                                            Q.titulo AS QUESTAO_TITULO,
	                                                            Q.serie AS QUESTAO_SERIE,
	                                                            M.id AS MATERIA_ID,
	                                                            M.nome AS MATERIA_NOME,
	                                                            D.id AS DISCIPLINA_ID,
	                                                            D.nome AS DISCIPLINA_NOME
                                                            FROM 
                                                                TBQuestao AS Q
                                                            INNER JOIN 
                                                                TBMateria AS M ON M.id = Q.materia_id
                                                            INNER JOIN 
                                                                TBDisciplina AS D ON D.id = M.disciplina_id

";

        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE Q.id = @id";

        protected string inserirAlternativaSQL => "INSERT INTO TBAlternativa (alternativa,alternativa_correta, questao_id) VALUES (@alternativa,@alternativa_correta, @questao_id) SELECT SCOPE_IDENTITY();";

        protected string carregarAlternativasSQL => "SELECT * FROM TBAlternativa WHERE questao_id = @questao_id";
        protected string excluirAlternativasSQL => "DELETE FROM TBAlternativa WHERE questao_id = @questao_id";

        protected string selecionarAleatoriamenteSQL => @"
                                                        SELECT TOP (@quantidade)
	                                                        Q.id AS QUESTAO_ID,
	                                                        Q.titulo AS QUESTAO_TITULO,
	                                                        Q.serie AS QUESTAO_SERIE,
	                                                        M.id AS MATERIA_ID,
	                                                        M.nome AS MATERIA_NOME,
	                                                        D.id AS DISCIPLINA_ID,
	                                                        D.nome AS DISCIPLINA_NOME
                                                        FROM 
                                                            TBQuestao AS Q
                                                        INNER JOIN 
                                                            TBMateria AS M ON M.id = Q.materia_id
                                                        INNER JOIN 
                                                            TBDisciplina AS D ON D.id = M.disciplina_id
                                                        WHERE Q.serie = @serie AND M.id = @materia_id
                                                        ORDER BY NEWID()
";
        protected string selecionarPorTesteIdSQL => selecionarTodosSQL + " INNER JOIN TBTeste_TBQuestao AS TQ ON TQ.questao_id = Q.id WHERE TQ.teste_id = @teste_id";
        protected override string verificarRepeticaoNome => @"
                            SELECT COUNT(*)
                            FROM TBQuestao
                            WHERE TBQuestao.titulo = titulo
                            AND TBQuestao.id != @id;";

        public RepositorioSQLQuestao()
        {
            
        }

        public RepositorioSQLQuestao(string conexaoBD) : base(conexaoBD)
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
            comando.Parameters.AddWithValue("@teste_id", teste_id);
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

            comando.Parameters.AddWithValue("@quantidade", quantidade);
            comando.Parameters.AddWithValue("@materia_id", materia_id);
            comando.Parameters.AddWithValue("@serie", serie);

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
            comando.Parameters.AddWithValue("questao_id", questao.id);
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
            comando.Parameters.AddWithValue("@questao_id", questao.id);

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

            comando.Parameters.AddWithValue("@titulo", registro.enunciado);
            comando.Parameters.AddWithValue("@id", registro.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }

        public override bool TemDependente(Questao registro)
        {
            Conexao();
            String verificarDepedenteSQL = @"
                            SELECT COUNT(*)
                            FROM TBTeste_TBQuestao
                            WHERE TBTeste_TBQuestao.questao_id = @id
";

            SqlCommand comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@id", registro.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }
    }
}
