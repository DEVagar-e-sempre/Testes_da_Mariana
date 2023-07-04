using TestesDonaMaria.Infra.ModuloMateria;

namespace TestesDonaMaria.WinForms.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        public override string ObterTipoCadastro => "Cadastro de Materia";
        
        private RepositorioSQLMateria repMateria;
        private TabelaMateria tabelaMateria;

        public ControladorMateria(RepositorioSQLMateria repMateria)
        {
            this.repMateria = repMateria;
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
            if(tabelaMateria == null)
            {
                tabelaMateria = new TabelaMateria();
            }

            CarregarMateria();
            return tabelaMateria;
        }

        private void CarregarMateria()
        {
            //List<Materia> listaMaterias = repMateria.Selecionartodos();
            //tabelaMateria.AtualizarRegistros(listaMaterias);
        }
    }
}
