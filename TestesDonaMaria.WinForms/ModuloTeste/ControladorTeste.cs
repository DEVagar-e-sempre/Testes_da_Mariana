using TestesDonaMaria.Dominio.ModuloTeste;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;
using TestesDonaMaria.Infra.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloTeste;
using TestesDonaMaria.WinForms.ModuloDisciplina;

namespace TestesDonaMaria.WinForms.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        public override string ObterTipo => "Cadastro de Testes";
        
        private RepositorioSQLTeste repTeste;
        private RepositorioSQLQuestao repQuestao;
        private RepositorioSQLMateria repMateria;
        private RepositorioSQLDisciplina repDisciplina;
        private TelaTeste telaTeste;
        private TabelaTeste tabelaTeste;


        public ControladorTeste(RepositorioSQLTeste repTeste, RepositorioSQLQuestao repQuestao, RepositorioSQLMateria repMateria, RepositorioSQLDisciplina repDisciplina)
        {
            this.repTeste = repTeste;
            this.repQuestao = repQuestao;
            this.repMateria = repMateria;
            this.repDisciplina = repDisciplina;
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
            telaTeste = new TelaTeste(repTeste, repQuestao, repMateria, repDisciplina);

            telaTeste.DefinirID(repTeste.ObterProximoID());

            DialogResult opcaoEscolhida = telaTeste.ShowDialog();

            if(opcaoEscolhida == DialogResult.OK)
            {
                repTeste.Inserir(telaTeste.Teste);
                MessageBox.Show("Matéria gravado com Sucesso!");
                CarregarTeste();
            }
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

        private void CarregarTeste()
        {
            List<Teste> listaTestes = repTeste.SelecionarTodos();
            tabelaTeste.AtualizarRegistros(listaTestes);
        }
    }
}
