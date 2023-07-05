﻿using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Infra.ModuloDisciplina
{
    public class MapeadorDisciplina : MapeadorBase<Disciplina>
    {
        public override void ConfigurarParametros(SqlCommand comando, Disciplina registro)
        {
            comando.Parameters.AddWithValue("id", registro.id);
            comando.Parameters.AddWithValue("nome", registro.nome);
        }

        public override Disciplina ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int id = Convert.ToInt32(leitorRegistros["id"]);
            String nome = leitorRegistros["nome"].ToString();

            Disciplina disciplina = new Disciplina(id, nome);

            return disciplina;
        }
    }
}
