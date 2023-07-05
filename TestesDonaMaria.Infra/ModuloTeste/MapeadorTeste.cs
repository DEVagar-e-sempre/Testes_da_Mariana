using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Dominio.ModuloTeste;

namespace TestesDonaMaria.Infra.ModuloTeste
{
    public class MapeadorTeste : MapeadorBase<Teste>
    {
        public override void ConfigurarParametros(SqlCommand comando, Teste registro)
        {
            comando.Parameters.AddWithValue("@id", registro.id);
            comando.Parameters.AddWithValue("@titulo", registro.titulo);
            comando.Parameters.AddWithValue("@materia_id", registro.materia.id);
            comando.Parameters.AddWithValue("@quantQuestoes", registro.quantQuestoes);
            comando.Parameters.AddWithValue("@serie", registro.serie);
        }

        public override Teste ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["TESTE_ID"]);
            string titulo = leitorRegistros["TESTE_TITULO"].ToString();
            int qtdQuestao = Convert.ToInt32(leitorRegistros["TESTE_QTD_QUESTOES"]);
            int serie = Convert.ToInt32(leitorRegistros["TESTE_SERIE"]);

            int disciplina_id = Convert.ToInt32(leitorRegistros["MATERIA_DISCIPLINA_ID"]);
            string nomeDisci = leitorRegistros["DISCIPLINA_NOME"].ToString();

            int materia_id = Convert.ToInt32(leitorRegistros["MATERIA_ID"]);
            string materiaNome = leitorRegistros["MATERIA_NOME"].ToString();

            Disciplina disciplina = new Disciplina(disciplina_id, nomeDisci);
            Materia materia = new Materia(materia_id, materiaNome, disciplina);

            return new Teste(id, titulo, materia, qtdQuestao, serie);
        }
    }
}
