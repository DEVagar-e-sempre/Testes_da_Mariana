using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloDisciplina;

namespace TestesDonaMaria.WinForms.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {
        public override string ObterTipo => "Cadastro de Disciplina";

        private RepositorioSQLDisciplina repDisciplina;
        private TabelaDisciplina tabelaDisc;
        private TelaDisciplina telaCadDisciplina;

        public ControladorDisciplina(RepositorioSQLDisciplina repDisciplina)
        {
            this.repDisciplina = repDisciplina;
        }

        public override void Inserir()
        {
            telaCadDisciplina = new TelaDisciplina(repDisciplina);

            DialogResult opcaoEscolhida = telaCadDisciplina.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                repDisciplina.Inserir(telaCadDisciplina.Disciplina);
                MessageBox.Show("Matéria gravado com Sucesso!");
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
                telaCadDisciplina = new TelaDisciplina(repDisciplina);
                telaCadDisciplina.Disciplina = disciplinaSelec;
                
                DialogResult opcaoEscolhida = telaCadDisciplina.ShowDialog();

                if (opcaoEscolhida == DialogResult.OK)
                {
                    repDisciplina.Editar(telaCadDisciplina.Disciplina.id, telaCadDisciplina.Disciplina);

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
            }
            else
            {
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
        }

        private Disciplina ObterDisciplinaSelecionado()
        {
            int id = tabelaDisc.ObterIdSelecionado();

            return repDisciplina.SelecionarPorId(id);
        }

        public override UserControl ObterListagem()
        {
            if(tabelaDisc == null)
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
