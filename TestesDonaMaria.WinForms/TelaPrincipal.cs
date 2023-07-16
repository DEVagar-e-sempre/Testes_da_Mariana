using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;
using TestesDonaMaria.Infra.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloTeste;
using TestesDonaMaria.WinForms.ModuloDisciplina;
using TestesDonaMaria.WinForms.ModuloMateria;
using TestesDonaMaria.WinForms.ModuloQuestao;
using TestesDonaMaria.WinForms.ModuloTeste;

namespace TestesDonaMaria.WinForms
{
    public partial class TelaPrincipal : Form
    {
        private RepositorioSQLDisciplina repDisciplina = new RepositorioSQLDisciplina();
        private RepositorioSQLMateria repMateria = new RepositorioSQLMateria();
        private RepositorioSQLQuestao repQuestao = new RepositorioSQLQuestao();
        private RepositorioSQLTeste repTeste = new RepositorioSQLTeste();
        private ControladorBase controlador = null;
        private static TelaPrincipal telaPrincipal;
        public TelaPrincipal()
        {
            InitializeComponent();

            this.ConfigurarTelas();

            ObterEntidade();

            telaPrincipal = this;

        }
        public static TelaPrincipal InstanciaAtual => telaPrincipal;

        private void ObterEntidade()
        {
            foreach (Control ctrl in painel_botoesEntidades.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;
                    btn.Click += EscolherEntidade;
                }
            }
        }

        private void EscolherEntidade(object? sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "btn_disciplina":
                    controlador = new ControladorDisciplina(repDisciplina);
                    break;

                case "btn_materia":
                    controlador = new ControladorMateria(repMateria, repDisciplina);
                    break;

                case "btn_questao":
                    controlador = new ControladorQuestao(repQuestao, repMateria, repDisciplina);
                    break;

                case "btn_teste":
                    controlador = new ControladorTeste(repTeste, repQuestao, repMateria, repDisciplina);
                    break;
            }

            ConfigurarEstados(controlador);

            ConfigurarTelaPrincipal(controlador);
        }

        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            lbl_tipoCad.Text = controladorBase.ObterTipo;

            ConfigurarToolTips(controlador);

            ConfigurarListagem(controlador);
        }

        private void ConfigurarListagem(ControladorBase controladorBase)
        {

            UserControl listagem = controladorBase.ObterListagem();

            listagem.Dock = DockStyle.Fill;

            painel_principal.Controls.Clear();//precisa disso para limpar o painel principal e poder
                                              //colocar outro painel por cima, sem que haja conflito

            painel_principal.Controls.Add(listagem);

        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btn_inserir.ToolTipText = controlador.ToolTipInserir;
            btn_editar.ToolTipText = controlador.ToolTipEditar;
            btn_excluir.ToolTipText = controlador.ToolTipExcluir;

            btn_filtrar.ToolTipText = controlador.ToolTipFiltrar;
            btn_listar.ToolTipText = controlador.ToolTipListar;
        }

        public void AtualizarRodape(string msg)
        {
            lbl_status.Text = msg;
        }

        private void botaoBarraFerramentas_Click(object sender, EventArgs e)
        {
            ToolStripButton btnClicado = (ToolStripButton)sender;

            if (controlador == null)
            {
                MessageBox.Show("Selecione alguma categoria antes de realizar uma ação",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                switch (btnClicado.Name)
                {
                    case "btn_inserir":
                        controlador.Inserir();
                        break;

                    case "btn_editar":
                        controlador.Editar();
                        break;

                    case "btn_excluir":
                        controlador.Excluir();
                        break;

                    case "btn_filtrar":
                        controlador.Filtrar();
                        break;

                    case "btn_listar":
                        controlador.Listar();
                        break;

                    case "btn_pdf":
                        controlador.GerarPDF();
                        break;


                }
            }
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btn_inserir.Enabled = controlador.InserirHabilitado;
            btn_editar.Enabled = controlador.EditarHabilitado;
            btn_excluir.Enabled = controlador.ExcluirHabilitado;
            btn_filtrar.Enabled = controlador.FiltrarHabilitado;
            btn_listar.Enabled = controlador.ListarHabilitado;
            btn_pdf.Enabled = controlador.GerarPDFHabilitado;
        }
    }
}