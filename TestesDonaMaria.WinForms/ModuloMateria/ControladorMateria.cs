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

            DialogResult opcao = telaCadMateria.ShowDialog();

            if(opcao == DialogResult.OK)
            {
                repMateria.Inserir(telaCadMateria.MateriaP);
                MessageBox.Show("Matéria gravado com Sucesso!");
                CarregarMateria();
            }
        }

        public override void Editar()
        {
            throw new NotImplementedException();
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
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
