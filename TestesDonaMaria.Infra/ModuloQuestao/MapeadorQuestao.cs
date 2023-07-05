using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMaria.Dominio.ModuloQuestao;

namespace TestesDonaMaria.Infra.ModuloQuestao
{
    public class MapeadorQuestao : MapeadorBase<Questao>
    {
        public override void ConfigurarParametros(SqlCommand comando, Questao registro)
        {
            comando.Parameters.AddWithValue("@id", registro.id);
            comando.Parameters.AddWithValue("@titulo", registro.titulo);
            //comando.Parameters.AddWithValue("@enunciado", registro.enunciado);
            comando.Parameters.AddWithValue("@alternativaCorreta", registro.alternativaCorreta);

        }

        public override Questao ConverterRegistro(SqlDataReader leitorRegistros)
        {
            throw new NotImplementedException();
        }
    }
}
