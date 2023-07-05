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
        private ControladorBase controlador;
        private static TelaPrincipal telaPrincipal;
        public TelaPrincipal()
        {
            InitializeComponent();

            this.ConfigurarTelas();

            ObterEntidade();

            telaPrincipal = this;
        }

        public static TelaPrincipal TelaPrincipalP
        {
            get
            {
                return telaPrincipal;
            }
        }
        private void ObterEntidade()
        {
            foreach (Button btn in painel_botoesEntidades.Controls)
            {
                btn.Click += EscolherEntidade;
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
                    controlador = new ControladorMateria(repMateria);
                    break;

                case "btn_questao":
                    controlador = new ControladorQuestao(repQuestao);
                    break;

                case "btn_teste":
                    controlador = new ControladorTeste(repTeste);
                    break;
            }

            ConfigurarEstados(controlador);

            ConfigurarTelaPrincipal(controlador);
        }

        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            lbl_tipoCad.Text = controladorBase.ObterTipoCadastro;

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

            //btn_filtrar.ToolTipText = controlador.ToolTipFiltrar;
            //btn_addItem.ToolTipText = controlador.ToolTipAdd;
            //btn_list.ToolTipText = controlador.ToolTipListar;
        }

        public void AtualizarRodape(string msg)
        {
            lbl_status.Text = msg;
        }

        private void botaoBarraFerramentas_Click(object sender, EventArgs e)
        {
            ToolStripButton btnClicado = (ToolStripButton)sender;

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

            }
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btn_inserir.Enabled = controlador.InserirHabilitado;
            btn_editar.Enabled = controlador.EditarHabilitado;
            btn_excluir.Enabled = controlador.ExcluirHabilitado;
            //btn_addItem.Enabled = controlador.AddItemHabilitado;
            //btn_filtrar.Enabled = controlador.FiltrarHabilitado;
            //btn_list.Enabled = controlador.ListarHabilitado;
        }
    }
}