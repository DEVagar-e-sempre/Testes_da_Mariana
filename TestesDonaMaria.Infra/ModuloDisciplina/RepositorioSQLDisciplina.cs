﻿using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Infra.ModuloDisciplina
{
    public class RepositorioSQLDisciplina : RepositorioSQLBase<Disciplina, MapeadorDisciplina>
    {
        protected override string inserirSQL => "INSERT INTO TBDisciplina (nome) VALUES (@nome) SELECT SCOPE_IDENTITY();";
        protected override string editarSQL => "UPDATE TBDisciplina SET nome = @nome WHERE id = @id";
        protected override string excluirSQL => "DELETE FROM TBDisciplina WHERE id = @id";
        protected override string selecionarTodosSQL => @"SELECT 
                                                            [ID]
                                                            ,[NOME]
                                                        FROM 
                                                            [TBDISCIPLINA]";
        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE [ID] = @ID";
        protected override string verificarRepeticaoNome => @"
                            SELECT COUNT(*)
                            FROM TBDisciplina
                            WHERE TBDisciplina.nome = @nome 
                            AND TBDisciplina.id != @id";


        public RepositorioSQLDisciplina()
        {
            
        }
        public RepositorioSQLDisciplina(string conexaoBD) : base(conexaoBD)
        {
        }

        public override bool EhRepetido(Disciplina registro)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(verificarRepeticaoNome, conexao);

            comando.Parameters.AddWithValue("@nome", registro.nome);
            comando.Parameters.AddWithValue("@id", registro.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }

        public override bool TemDependente(Disciplina registro)
        {
            Conexao();
            string verificarDepedenteSQL = @"
                            SELECT COUNT(*) 
                            FROM TBMateria 
                            WHERE TBMateria.disciplina_id = @id
";

            SqlCommand comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@id", registro.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }
    }
}
