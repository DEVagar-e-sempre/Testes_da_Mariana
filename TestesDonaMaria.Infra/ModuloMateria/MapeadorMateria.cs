using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.Infra.ModuloMateria
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            comando.Parameters.AddWithValue("@NOME", registro.nome);
            comando.Parameters.AddWithValue("@DISCIPLINA_ID", registro.disciplina.id);
        }

        public override Materia ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int materia_id = Convert.ToInt32(leitorRegistros["MATERIA_ID"]);
            string nome_materia = Convert.ToString(leitorRegistros["MATERIA_NOME"]);
            int disciplina_id = Convert.ToInt32(leitorRegistros["DISCIPLINA_ID"]);
            string nome_disciplina = Convert.ToString(leitorRegistros["DISCIPLINA_NOME"]);

            Disciplina disciplina = new Disciplina(disciplina_id, nome_disciplina);

            Materia materia = new Materia(materia_id, nome_materia, disciplina);

            return materia;
        }
    }
}
