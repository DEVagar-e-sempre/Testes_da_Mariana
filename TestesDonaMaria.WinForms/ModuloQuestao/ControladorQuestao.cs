using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;
using TestesDonaMaria.Infra.ModuloQuestao;

namespace TestesDonaMaria.WinForms.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        public override string ObterTipo => "Questão";
        public override bool FiltrarHabilitado => true;
        public override bool ListarHabilitado => true;

        private RepositorioSQLQuestao repQuestao;

        private RepositorioSQLMateria repMateria;

        private RepositorioSQLDisciplina repDisciplina;

        private TabelaQuestao tabelaQuestao;

        public ControladorQuestao(RepositorioSQLQuestao repQuestao, RepositorioSQLMateria repMateria, RepositorioSQLDisciplina repDisciplina)
        {
            this.repQuestao = repQuestao;
            this.repMateria = repMateria;
            this.repDisciplina = repDisciplina;
        }

        public override void Editar()
        {
            Questao questaoSelecionada = ObterIdSelecionado();
            if (questaoSelecionada == null)
            {
                MessageBox.Show($"Selecione uma {ObterTipo} primeiro!",
                                $"Edição de {ObterTipo}",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }
            if(repQuestao.TemDependente(questaoSelecionada))
            {
                MessageBox.Show($"Não é possível editar uma {ObterTipo} que esteja relacionada a um Teste!",
                                $"Edição de {ObterTipo}",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                return;
            }
            TelaQuestao telaQuestao = new TelaQuestao(repQuestao, repMateria, repDisciplina);

            telaQuestao.ConfigurarTela(questaoSelecionada);

            DialogResult opcaoEscolhida = telaQuestao.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Questao auxQuestao = telaQuestao.ObterQuestao();

                repQuestao.Editar(auxQuestao.id, auxQuestao);

                CarregarQuestao();
            }
        }

        public override void Excluir()
        {
            Questao questaoSelecionada = ObterIdSelecionado();
            if (questaoSelecionada == null)
            {
                MessageBox.Show($"Selecione uma {ObterTipo} primeiro!",
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
            TelaQuestao telaQuestao = new TelaQuestao(repQuestao, repMateria, repDisciplina);

            telaQuestao.DefinirID(repQuestao.ObterProximoID());

            DialogResult opcaoEscolhida = telaQuestao.ShowDialog();

            Questao auxQuestao = null;

            if (opcaoEscolhida == DialogResult.OK)
            {
                auxQuestao = telaQuestao.ObterQuestao();

                repQuestao.Inserir(auxQuestao);

                CarregarQuestao();
            }
            /*
            MessageBox.Show($"{auxQuestao.id}, {auxQuestao.enunciado}",
                              $"Inserção de {ObterTipo}",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            TelaPrincipal.InstanciaAtual.AtualizarRodape($"Nova {ObterTipo} inserida com sucesso");
            */
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
