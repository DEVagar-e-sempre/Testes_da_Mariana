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
            
        }
    }
}
