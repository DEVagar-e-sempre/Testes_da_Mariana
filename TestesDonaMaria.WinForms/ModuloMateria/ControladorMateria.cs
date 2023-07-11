using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;

namespace TestesDonaMaria.WinForms.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        public override string ObterTipo => "Cadastro de Materia";

        private RepositorioSQLDisciplina repDisciplina;
        private RepositorioSQLMateria repMateria;
        private TabelaMateria tabelaMateria;
        private TelaMateria telaMateria;

        public ControladorMateria(RepositorioSQLMateria repMateria, RepositorioSQLDisciplina repDisciplina)
        {
            this.repMateria = repMateria;
            this.repDisciplina = repDisciplina;
        }

        public override void Inserir()
        {
            telaMateria = new TelaMateria(repMateria, repDisciplina, false);

            telaMateria.DefinirID(repMateria.ObterProximoID());

            DialogResult opcaoEscolhida = telaMateria.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                repMateria.Inserir(telaMateria.MateriaP);
                MessageBox.Show("Matéria gravado com Sucesso!");
                CarregarMateria();
            }
        }

        public override void Editar()
        {
            Materia materiaSelec = ObterMateriaSelecionada();

            if (materiaSelec == null)
            {
                MessageBox.Show($"Selecione uma Materia primeiro!",
                    "Edição de Materia",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                telaMateria = new TelaMateria(repMateria, repDisciplina, true);
                telaMateria.MateriaP = materiaSelec;

                DialogResult opcaoEscolhida = telaMateria.ShowDialog();

                if (opcaoEscolhida == DialogResult.OK)
                {
                    repMateria.Editar(telaMateria.MateriaP.id, telaMateria.MateriaP);
                    CarregarMateria();
                }
            }
        }

        public override void Excluir()
        {
            Materia materiaSelec = ObterMateriaSelecionada();

            if (materiaSelec == null)
            {
                MessageBox.Show($"Selecione uma Materia primeiro!",
                    "Exclusão de Materia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
            if (repMateria.TemDependente(materiaSelec))
            {
                MessageBox.Show($"Não é possível excluir uma {ObterTipo} que esteja relacionada a uma Questao ou Teste",
                    $"Exclusão de {ObterTipo}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }
            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir a Materia {materiaSelec.nome}?",
                "Exclusão de Materia",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repMateria.Excluir(materiaSelec);

                CarregarMateria();
            }
        }

        private Materia ObterMateriaSelecionada()
        {
            int id = tabelaMateria.ObterIdSelecionado();

            return repMateria.SelecionarPorId(id);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaMateria == null)
            {
                tabelaMateria = new TabelaMateria();
            }

            CarregarMateria();
            return tabelaMateria;
        }

        private void CarregarMateria()
        {
            List<Materia> listaMaterias = repMateria.SelecionarTodos();
            tabelaMateria.AtualizarRegistros(listaMaterias);
        }
    }
}
