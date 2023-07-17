using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;

namespace TestesDonaMaria.WinForms.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        public override string ObterTipo => "Materia";
        public override bool FiltrarHabilitado => true;
        public override bool ListarHabilitado => true;

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

        public override void Filtrar()
        {
            TelaFiltroMateria telaFiltro = new TelaFiltroMateria(repDisciplina);

            DialogResult op = telaFiltro.ShowDialog();

            if(op == DialogResult.OK)
            {
                Disciplina discSelecionada = telaFiltro.ObterDisciplinaMateria();
                StatusFiltroMateriaEnum status = telaFiltro.ObterStatus();

                switch (status)
                {
                    case StatusFiltroMateriaEnum.Nenhum:
                    break;

                    case StatusFiltroMateriaEnum.PorDisciplina:
                        List<Materia> listaMaterias = repMateria.SelecionarTodosPorDisciplina(discSelecionada.id);
                        CarregarMateria(listaMaterias);
                    break;

                    case StatusFiltroMateriaEnum.Todos:
                        CarregarMateria();
                    break;
                }
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
        private void CarregarMateria(List<Materia> listaMaterias)
        {
            tabelaMateria.AtualizarRegistros(listaMaterias);
        }
    }
}
