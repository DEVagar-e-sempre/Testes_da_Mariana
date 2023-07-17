using TestesDonaMaria.Dominio.ModuloTeste;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;
using TestesDonaMaria.Infra.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloTeste;

namespace TestesDonaMaria.WinForms.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        public override string ObterTipo => "Teste";
        public override bool FiltrarHabilitado => true;
        public override bool ListarHabilitado => true;

        public override bool GerarPDFHabilitado => true;

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
            Teste testeSelec = ObterTesteSelecionado();

            if (testeSelec == null)
            {
                MessageBox.Show($"Selecione um Teste primeiro!",
                    "Exclusão de Teste",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            testeSelec.listaQuestoes.AddRange(repQuestao.SelecionarPorTesteId(testeSelec.id));


            telaTeste = new TelaTeste(repTeste, repQuestao, repMateria, repDisciplina, true);
            telaTeste.Teste = testeSelec;

            DialogResult opcaoEscolhida = telaTeste.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                repTeste.Editar(telaTeste.Teste.id, telaTeste.Teste);

                CarregarTeste();
            }
        }

        public override void Excluir()
        {
            Teste TesteSelec = ObterTesteSelecionado();

            if (TesteSelec == null)
            {
                MessageBox.Show($"Selecione um Teste primeiro!",
                    "Exclusão de Teste",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o Teste {TesteSelec.titulo}?",
                    "Exclusão de Teste",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (opcaoEscolhida == DialogResult.OK)
                {
                    repTeste.Excluir(TesteSelec);

                    CarregarTeste();
                }
            }
        }

        private Teste ObterTesteSelecionado()
        {
            int id = tabelaTeste.ObterIdSelecionado();

            return repTeste.SelecionarPorId(id);
        }

        public override void Inserir()
        {
            telaTeste = new TelaTeste(repTeste, repQuestao, repMateria, repDisciplina, false);

            telaTeste.DefinirID(repTeste.ObterProximoID());

            DialogResult opcaoEscolhida = telaTeste.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                repTeste.Inserir(telaTeste.Teste);
                MessageBox.Show("Teste gravado com Sucesso!");
                CarregarTeste();
            }
        }

        public override UserControl ObterListagem()
        {
            if (tabelaTeste == null)
            {
                tabelaTeste = new TabelaTeste();
            }

            CarregarTeste();

            return tabelaTeste;
        }

        public override void GerarPDF()
        {
            Teste testeSelec = ObterTesteSelecionado();
            GeradorPDF gerador = new GeradorPDF();

            if (testeSelec == null)
            {
                MessageBox.Show($"Selecione um Teste primeiro!",
                    "Gerar PDF do Teste",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {

                testeSelec.listaQuestoes.AddRange(repQuestao.SelecionarPorTesteId(testeSelec.id));

                DialogResult op = MessageBox.Show($"Deseja gerar o pdf do gabarito?!",
                    "Gerar PDF do Teste",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (op == DialogResult.Yes)
                {
                    gerador.GerarPDF(testeSelec, true);

                }
                else
                {
                    gerador.GerarPDF(testeSelec, false);
                }
            }
        }

        private void CarregarTeste()
        {
            List<Teste> listaTestes = repTeste.SelecionarTodos();
            tabelaTeste.AtualizarRegistros(listaTestes);
        }
    }
}
