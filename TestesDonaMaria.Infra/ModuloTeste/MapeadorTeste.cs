using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloTeste;

namespace TestesDonaMaria.Infra.ModuloTeste
{
    public class MapeadorTeste : MapeadorBase<Teste>
    {
        public override void ConfigurarParametros(SqlCommand comando, Teste registro)
        {
            comando.Parameters.AddWithValue("@id", registro.id);
            comando.Parameters.AddWithValue("@titulo", registro.titulo);
            comando.Parameters.AddWithValue("@disciplina_id", registro.disciplina.id);
            comando.Parameters.AddWithValue("@materia_id", registro.materia.id);
            comando.Parameters.AddWithValue("@quantQuestoes", registro.quantQuestoes);
            comando.Parameters.AddWithValue("@serie", registro.serie);
        }

        public override Teste ConverterRegistro(SqlDataReader leitorRegistros)
        {
            //int id, string titulo, Disciplina disciplina, Materia materia, int quantQuestoes, int serie
            int id = Convert.ToInt32(leitorRegistros["teste_id"]);
            string titulo = Convert.ToString(leitorRegistros["titulo"]);
            int disciplina_id = Convert.ToInt32(leitorRegistros["disciplina_id"]);
            int materia_id = Convert.ToInt32(leitorRegistros["materia_id"]);
            int qtdQuestao = Convert.ToInt32(leitorRegistros["quantQuestoes"]);
            int serie = Convert.ToInt32(leitorRegistros["serie"]);

            Teste teste = new Teste(id, titulo, disciplina_id, materia_id, qtdQuestao, serie);
        }
    }
}
