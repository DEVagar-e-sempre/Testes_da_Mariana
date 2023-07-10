using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Dominio.ModuloTeste;

namespace TestesDonaMaria.Infra.ModuloTeste
{
    public class MapeadorTeste : MapeadorBase<Teste>
    {
        private Disciplina disciplina;
        private Materia materia;
        private Teste teste;
        public override void ConfigurarParametros(SqlCommand comando, Teste teste)
        {
            comando.Parameters.AddWithValue("@titulo", teste.titulo);
            comando.Parameters.AddWithValue("@materia_id", teste.materia.id);
            comando.Parameters.AddWithValue("@quantQuestoes", teste.quantQuestoes);
            comando.Parameters.AddWithValue("@serie", teste.serie);
            comando.Parameters.AddWithValue("@recuperacao", teste.recuperacao);
        }

        public void ConfigurarParametrosRelacaoQuestao(SqlCommand comando, int questao_id, int teste_id)
        {
            comando.Parameters.AddWithValue("@teste_id", teste_id);
            comando.Parameters.AddWithValue("@questao_id", questao_id);
        }

        public void ConfigurarParamentrosAlternativa(SqlCommand comando, Alternativa alternativa)
        {
            comando.Parameters.AddWithValue("@alternativa", alternativa.alternativa);
            comando.Parameters.AddWithValue("@questao_id", alternativa.questaoId);
            comando.Parameters.AddWithValue("@correta", alternativa.correta);
        }

        public override Teste ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["TESTE_ID"]);
            string titulo = leitorRegistros["TESTE_TITULO"].ToString();
            int qtdQuestao = Convert.ToInt32(leitorRegistros["TESTE_QTD_QUESTOES"]);
            int serie = Convert.ToInt32(leitorRegistros["TESTE_SERIE"]);
            bool recuperacao = Convert.ToBoolean(leitorRegistros["TESTE_RECUPERACAO"]);

            int disciplina_id = Convert.ToInt32(leitorRegistros["DISCIPLINA_ID"]);
            string nomeDisci = leitorRegistros["DISCIPLINA_NOME"].ToString();

            int materia_id = Convert.ToInt32(leitorRegistros["MATERIA_ID"]);
            string materiaNome = leitorRegistros["MATERIA_NOME"].ToString();

            this.disciplina = new Disciplina(disciplina_id, nomeDisci);
            this.materia = new Materia(materia_id, materiaNome, this.disciplina);
            this.teste = new Teste(id, titulo, this.materia, qtdQuestao, serie, recuperacao);

            return teste;
        }

        public Questao ConverterRegistroQuestao(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["ID"]);

            string titulo = leitorRegistros["QUESTAO_TITULO"].ToString();

            Questao questaoObj = new Questao(id, titulo, this.teste.serie, this.materia);

            return questaoObj;
        }

        public Alternativa ConverterRegistroAlternativa(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["id"]);

            string alternativa = leitorRegistros["alternativa"].ToString();

            bool correta = Convert.ToBoolean(leitorRegistros["correta"]);

            int questao_id = Convert.ToInt32(leitorRegistros["questao_id"]);

            Alternativa alternativaObj = new(id, alternativa, correta, questao_id);

            return alternativaObj;
        }
    }
}
