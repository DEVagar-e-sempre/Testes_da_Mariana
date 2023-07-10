using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloDisciplina;

namespace TestesDonaMaria.WinForms.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        public override string ObterTipo => "Cadastro de Disciplina";

        private RepositorioSQLDisciplina repDisciplina;
        private TabelaDisciplina tabelaDisc;
        private TelaDisciplina telaDisciplina;

        public ControladorDisciplina(RepositorioSQLDisciplina repDisciplina)
        {
            this.repDisciplina = repDisciplina;
        }

        public override void Inserir()
        {
            telaDisciplina = new TelaDisciplina(repDisciplina);

            telaDisciplina.DefinirID(repDisciplina.ObterProximoID());


            DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                repDisciplina.Inserir(telaDisciplina.Disciplina);
                MessageBox.Show("Disciplina gravado com Sucesso!");
                CarregarDisciplina();
            }
        }

        public override void Editar()
        {
            Disciplina disciplinaSelec = ObterDisciplinaSelecionado();

            if (disciplinaSelec == null)
            {
                MessageBox.Show($"Selecione uma Disciplina primeiro!",
                    "Edição de Disciplina",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                telaDisciplina = new TelaDisciplina(repDisciplina);
                telaDisciplina.Disciplina = disciplinaSelec;

                DialogResult opcaoEscolhida = telaDisciplina.ShowDialog();

                if (opcaoEscolhida == DialogResult.OK)
                {
                    repDisciplina.Editar(telaDisciplina.Disciplina.id, telaDisciplina.Disciplina);

                    CarregarDisciplina();
                }
            }
        }

        public override void Excluir()
        {
            Disciplina disciplinaSelec = ObterDisciplinaSelecionado();

            if (disciplinaSelec == null)
            {
                MessageBox.Show($"Selecione uma Disciplina primeiro!",
                    "Exclusão de Disciplinas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (repDisciplina.TemDependente(disciplinaSelec))
            {
                MessageBox.Show($"Não é possível excluir uma {ObterTipo} que esteja relacionada a uma Materia",
                    $"Exclusão de {ObterTipo}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a Disciplina {disciplinaSelec.nome}?",
                "Exclusão de Disciplinas",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repDisciplina.Excluir(disciplinaSelec);

                CarregarDisciplina();
            }
        }

        private Disciplina ObterDisciplinaSelecionado()
        {
            int id = tabelaDisc.ObterIdSelecionado();

            return repDisciplina.SelecionarPorId(id);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaDisc == null)
            {
                tabelaDisc = new TabelaDisciplina();
            }

            CarregarDisciplina();
            return tabelaDisc;
        }

        private void CarregarDisciplina()
        {
            List<Disciplina> listaDisc = repDisciplina.SelecionarTodos();
            tabelaDisc.AtualizarRegistros(listaDisc);
        }
    }
}
