using TestesDonaMaria.Infra.ModuloQuestao;

namespace TestesDonaMaria.WinForms.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        public override string ObterTipoCadastro => "Cadastro de Questão";
        
        private RepositorioSQLQuestao repQuestao;
        private TabelaQuestao tabelaQuestao;

        public ControladorQuestao(RepositorioSQLQuestao repQuestao)
        {
            this.repQuestao = repQuestao;
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override UserControl ObterListagem()
        {
            if(tabelaQuestao == null)
            {
                tabelaQuestao = new TabelaQuestao();
            }

            CarregarQuestao();
            return tabelaQuestao;
        }

        private void CarregarQuestao()
        {
            //List<Questao> listaQuestoes = repQuestao.;
            //tabelaQuestao.AtualizarRegistros(listaQuestoes);
        }
    }
}
