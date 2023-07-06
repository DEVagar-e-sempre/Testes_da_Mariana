using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloQuestao;

namespace TestesDonaMaria.Infra.ModuloQuestao
{
    public class RepositorioSQLQuestao : RepositorioSQLBase<Questao, MapeadorQuestao>
    {
        protected override string inserirSQL => @"INSERT INTO TBQuestao (titulo, materia_id, serie) VALUES (@titulo, @materia_id, @serie) SELECT SCOPE_IDENTITY();";

        protected override string editarSQL => @"UPDATE TBQuestao SET titulo = @titulo, materia_id = @materia_id, serie = @serie WHERE id = @id";

        protected override string excluirSQL => @"DELETE FROM TBQuestao WHERE id = @id";

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
                                                                TBMateria AS M ON M.id = Q.id
                                                            INNER JOIN 
                                                                TBDisciplina AS D ON D.id = M.disciplina_id

";

        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE Q.id = @id";

        protected string inserirAlternativaSQL => "INSERT INTO TBAlternativa (alternativa, questao_id) VALUES (@alternativa, @questao_id) SELECT SCOPE_IDENTITY();";

        protected string carregarAlternativasSQL => "SELECT * FROM TBAlternativa WHERE questao_id = @questao_id";
        protected string excluirAlternativasSQL => "DELETE FROM TBAlternativa WHERE questao_id = @questao_id";

        public RepositorioSQLQuestao() : base()
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
            base.Excluir(questao);
            ExcluirAlternativas(questao);
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
            String verificarDepedenteSQL = @"
                            SELECT COUNT(*)
                            FROM TBQuestao
                            WHERE TBQuestao.titulo LIKE '%@titulo%';

";

            SqlCommand comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@titulo", registro.enunciado);

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

        public int ObterProximoID()
        {
            String proximoIdSQL = @"SELECT IDENT_CURRENT('TBQuestao') + IDENT_INCR('TBQuestao')";
            Conexao();
            SqlCommand comando = new SqlCommand(proximoIdSQL, conexao);
            int proximoId = Convert.ToInt32(comando.ExecuteScalar());
            conexao.Close();
            return proximoId;
        }
    }
}
