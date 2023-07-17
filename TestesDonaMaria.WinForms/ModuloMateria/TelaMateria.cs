using FluentResults;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;

namespace TestesDonaMaria.WinForms.ModuloMateria
{
    public partial class TelaMateria : Form
    {
        private Materia materia;
        private RepositorioSQLMateria repMateria;
        private RepositorioSQLDisciplina repDisciplina;

        public event GravarRegistroDelegate<Materia> onGravarRegistro;

        public TelaMateria(RepositorioSQLMateria repMateria, RepositorioSQLDisciplina repDisciplina, bool ehEdicao)
        {
            InitializeComponent();
            this.ConfigurarTelas();

            if (ehEdicao)
            {
                this.Text = "Edição de Materia";
            }

            this.repMateria = repMateria;
            this.repDisciplina = repDisciplina;

            CarregarDisciplinaCbox(repDisciplina);
        }
        public void DefinirID(int id)
        {
            txb_id.Text = id.ToString();
        }


        private void CarregarDisciplinaCbox(RepositorioSQLDisciplina repDisciplina)
        {
            foreach (Disciplina disc in repDisciplina.SelecionarTodos())
            {
                cbox_disciplina.Items.Add(disc);
            }
        }

        public Materia MateriaP
        {
            set
            {
                txb_id.Text = value.id.ToString();
                txb_nome.Text = value.nome;
                cbox_disciplina.Text = value.disciplina.nome;
            }

            get => materia;
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            TelaPrincipal telaPrincipal = TelaPrincipal.InstanciaAtual;

            int id = Convert.ToInt32(txb_id.Text);

            string nome = txb_nome.Text;

            Disciplina disciplina = (Disciplina)cbox_disciplina.SelectedItem;

            materia = new Materia(id, nome, disciplina);

            Result resultado = onGravarRegistro(materia);

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
