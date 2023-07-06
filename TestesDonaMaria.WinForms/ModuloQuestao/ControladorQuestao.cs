using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;
using TestesDonaMaria.Infra.ModuloQuestao;

namespace TestesDonaMaria.WinForms.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        public override string ObterTipo => "Questão";
        
        private RepositorioSQLQuestao repQuestao;

        private RepositorioSQLMateria repMateria;

        private RepositorioSQLDisciplina repDisciplina;

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
            Questao questaoSelecionada = ObterIdSelecionado();
            if (questaoSelecionada == null)
            {
                MessageBox.Show($"Selecione um {ObterTipo} primeiro!",
                    $"Exclusão de {ObterTipo}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            if (repQuestao.TemDependente(questaoSelecionada))
            {
                MessageBox.Show($"Não é possível excluir uma {ObterTipo} que esteja relacionada a um Teste!",
                    $"Exclusão de {ObterTipo}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show(
                $"Deseja excluir o {ObterTipo} selecionado?",
                $"Exclusão de {ObterTipo}",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repQuestao.Excluir(questaoSelecionada);
                CarregarQuestao();
            }
        }

        public override void Inserir()
        {
            TelaQuestao telaQuestao = new TelaQuestao(repMateria, repDisciplina);
            telaQuestao.DefinirID(repQuestao.ObterProximoID());

            DialogResult opcaoEscolhida = telaQuestao.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Questao auxQuestao = telaQuestao.ObterQuestao();

                repQuestao.Inserir(auxQuestao);

                CarregarQuestao();
            }
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
            List<Questao> listaQuestoes = repQuestao.SelecionarTodos();
            tabelaQuestao.AtualizarRegistros(listaQuestoes);
        }
        private Questao ObterIdSelecionado()
        {
            int id = tabelaQuestao.ObterIdSelecionado();

            if (id < 1) {
                return null;
            }


            Questao questaoSelecionada = repQuestao.SelecionarPorId(id);

            return questaoSelecionada;
        }
    }
}
