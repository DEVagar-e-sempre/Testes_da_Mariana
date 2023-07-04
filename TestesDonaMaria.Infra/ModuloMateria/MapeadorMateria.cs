﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.Infra.ModuloMateria
{
    public class MapeadorMateria : MapeadorBase<Materia>
    {
        public override void ConfigurarParametros(SqlCommand comando, Materia registro)
        {
            comando.Parameters.AddWithValue("@nome", registro.nome);
            comando.Parameters.AddWithValue("@disciplina_id", registro.disciplina.id);
        }

        public override Materia ConverterRegistro(SqlDataReader leitorRegistros)
        {
            int materia_id = Convert.ToInt32(leitorRegistros["materia_id"]);
            string nome_materia = Convert.ToString(leitorRegistros["nome_materia"]);
            int disciplina_id = Convert.ToInt32(leitorRegistros["disciplina_id"]);
            string nome_disciplina = Convert.ToString(leitorRegistros["nome_disciplina"]);

            Disciplina disciplina = new Disciplina(disciplina_id, nome_disciplina);

            Materia materia = new Materia(materia_id, nome_materia, disciplina);

            return materia;
        }
    }
}