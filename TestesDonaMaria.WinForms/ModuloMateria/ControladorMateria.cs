using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Infra.ModuloMateria;

namespace TestesDonaMaria.WinForms.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        public override string ObterTipoCadastro => "Cadastro de Materia";
        
        private RepositorioSQLMateria repMateria;
        private TabelaMateria tabelaMateria;
        private TelaCadMateria telaCadMateria;

        public ControladorMateria(RepositorioSQLMateria repMateria)
        {
            this.repMateria = repMateria;
        }

        public override void Inserir()
        {
            telaCadMateria = new TelaCadMateria(repMateria);

            DialogResult opcaoEscolhida = telaCadMateria.ShowDialog();

            if(opcaoEscolhida == DialogResult.OK)
            {
                repMateria.Inserir(telaCadMateria.MateriaP);
                MessageBox.Show("Matéria gravado com Sucesso!");
                CarregarMateria();
            }
        }

        public override void Editar()
        {
            Materia materiaSelec = ObterMateriaSelecionada();

            if(materiaSelec == null)
            {
                MessageBox.Show($"Selecione uma Materia primeiro!", 
                    "Edição de Materia",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                telaCadMateria = new TelaCadMateria(repMateria);
                telaCadMateria.MateriaP = materiaSelec;

                DialogResult opcaoEscolhida = telaCadMateria.ShowDialog();

                if (opcaoEscolhida == DialogResult.OK)
                {
                    repMateria.Editar(telaCadMateria.MateriaP.id, telaCadMateria.MateriaP);
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
            }
            else
            {
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
        }

        private Materia ObterMateriaSelecionada()
        {
            int id = tabelaMateria.ObterIdSelecionado();

            return repMateria.SelecionarPorId(id);
        }

        public override UserControl ObterListagem()
        {
            if(tabelaMateria == null)
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
