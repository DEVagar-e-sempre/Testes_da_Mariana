using FluentResults;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloDisciplina;

namespace TestesDonaMaria.WinForms.ModuloDisciplina
{
    public partial class TelaDisciplina : Form
    {
        private Disciplina disciplina;
        private RepositorioSQLDisciplina repDisc;
        public event GravarRegistroDelegate<Disciplina> onGravarRegistro;

        public TelaDisciplina(RepositorioSQLDisciplina repDisc, bool ehEdicao)
        {
            InitializeComponent();
            this.ConfigurarTelas();

            if (ehEdicao)
            {
                this.Text = "Edição de Disciplina";
            }

            this.repDisc = repDisc;
        }

        public Disciplina Disciplina
        {
            set
            {
                txb_id.Text = value.id.ToString();
                txb_nome.Text = value.nome;
            }

            get => disciplina;
        }

        public void DefinirID(int id)
        {
            txb_id.Text = id.ToString();
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txb_id.Text);
            string nome = txb_nome.Text;

            disciplina = new Disciplina(id, nome);

            Result resultado = onGravarRegistro(disciplina);

            if (resultado.IsFailed)
            {
                string msgErro = resultado.Errors[0].Message;
                TelaPrincipal.InstanciaAtual.AtualizarRodape(msgErro);
                DialogResult = DialogResult.None;
                return;
            }
            TelaPrincipal.InstanciaAtual.AtualizarRodape("Status");
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TelaPrincipal.InstanciaAtual.AtualizarRodape("Status");
        }
    }
}
