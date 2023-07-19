using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Dominio.ModuloQuestao;

namespace TestesDonaMaria.Infra.ModuloQuestao
{
    public class MapeadorQuestao : MapeadorBase<Questao>
    {
        public override void ConfigurarParametros(SqlCommand comando, Questao registro)
        {
            comando.Parameters.AddWithValue("@TITULO", registro.enunciado);
            comando.Parameters.AddWithValue("@SERIE", registro.serie);
            comando.Parameters.AddWithValue("@MATERIA_ID", registro.materia.id);

        }

        public override Questao ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int questao_id = Convert.ToInt32(leitorRegistros["QUESTAO_ID"]);
            String questao_titulo = leitorRegistros["QUESTAO_TITULO"].ToString();
            int questao_serie = Convert.ToInt32(leitorRegistros["QUESTAO_SERIE"]);
            
            int materia_id = Convert.ToInt32(leitorRegistros["MATERIA_ID"]);
            String materia_nome = leitorRegistros["MATERIA_NOME"].ToString();

            int disciplina_id = Convert.ToInt32(leitorRegistros["DISCIPLINA_ID"]);
            String disciplina_nome = leitorRegistros["DISCIPLINA_NOME"].ToString();
            
            Disciplina disciplina = new(disciplina_id, disciplina_nome);
            Materia materia = new(materia_id, materia_nome, disciplina);
            Questao questao = new(questao_id, questao_titulo, questao_serie, materia);
            return questao;
        }

        public Alternativa ConverterRegistroAlternativa(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["ID"]);

            String alternativa = leitorRegistros["ALTERNATIVA"].ToString();

            bool correta = Convert.ToBoolean(leitorRegistros["ALTERNATIVA_CORRETA"]);

            int questao_id = Convert.ToInt32(leitorRegistros["QUESTAO_ID"]);

            Alternativa alternativaObj = new(id, alternativa, correta, questao_id);

            return alternativaObj;
        }
        public void ConfigurarParamentrosAlternativa(SqlCommand comando, Alternativa alternativa)
        {
            comando.Parameters.AddWithValue("@ALTERNATIVA", alternativa.alternativa);
            comando.Parameters.AddWithValue("@QUESTAO_ID", alternativa.questaoId);
            comando.Parameters.AddWithValue("@ALTERNATIVA_CORRETA", alternativa.correta);
        }
    }
}
