using Microsoft.Data.SqlClient;
using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.Infra.ModuloDisciplina
{
    public class RepositorioSQLDisciplina : RepositorioSQLBase<Disciplina, MapeadorDisciplina>
    {
        protected override string inserirSQL => @"INSERT INTO TBDISCIPLINA 
                                                        (
                                                        NOME
                                                        ) 
                                                        VALUES 
                                                        (
                                                        @NOME
                                                        ) 
                                                        SELECT SCOPE_IDENTITY();";
        protected override string editarSQL => @"UPDATE TBDISCIPLINA SET NOME = @NOME WHERE ID = @ID";
        protected override string excluirSQL => @"DELETE FROM TBDISCIPLINA WHERE ID = @ID";
        protected override string selecionarTodosSQL => @"SELECT 
                                                            [ID]
                                                            ,[NOME]
                                                        FROM 
                                                            [TBDISCIPLINA]";
        protected override string selecionarPorIdSQL => selecionarTodosSQL + " WHERE [ID] = @ID";
        protected override string verificarRepeticaoNome => @"
                            SELECT COUNT(*)
                            FROM TBDISCIPLINA
                            WHERE TBDISCIPLINA.NOME = @NOME 
                            AND TBDISCIPLINA.ID != @ID";

        public RepositorioSQLDisciplina()
        {
            
        }

        public RepositorioSQLDisciplina(string conexaoStrBD) : base(conexaoStrBD)
        {

        }

        public override bool EhRepetido(Disciplina registro)
        {
            Conexao();

            SqlCommand comando = new SqlCommand(verificarRepeticaoNome, conexao);

            comando.Parameters.AddWithValue("@NOME", registro.nome);
            comando.Parameters.AddWithValue("@ID", registro.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }

        public override bool TemDependente(Disciplina registro)
        {
            Conexao();
            string verificarDepedenteSQL = @"
                            SELECT COUNT(*) 
                            FROM TBMATERIA 
                            WHERE TBMATERIA.DISCIPLINA_ID = @ID
";

            SqlCommand comando = new SqlCommand(verificarDepedenteSQL, conexao);

            comando.Parameters.AddWithValue("@ID", registro.id);

            int quantidade = Convert.ToInt32(comando.ExecuteScalar());

            conexao.Close();

            return quantidade > 0;
        }
    }
}
