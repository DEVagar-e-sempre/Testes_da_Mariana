using TestesDonaMaria.Infra.ModuloTeste;

namespace TestesDonaMaria.WinForms.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        public override string ObterTipoCadastro => "Cadastro de Testes";
        
        private RepositorioSQLTeste repTeste;
        private TabelaTeste tabelaTeste;


        public ControladorTeste(RepositorioSQLTeste repTeste)
        {
            this.repTeste = repTeste;
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
            
        }

        private void CarregarTeste()
        {
            //List<Teste> listaTestes = repTeste.Selecionartodos();
            //tabelaTeste.AtualizarRegistros(listaTestes);
        }

        public override UserControl ObterListagem()
        {
            if(tabelaTeste == null)
            {
                tabelaTeste = new TabelaTeste();
            }

            CarregarTeste();

            return tabelaTeste;
        }
    }
}
