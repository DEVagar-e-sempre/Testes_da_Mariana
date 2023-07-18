using FluentResults;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;
using TestesDonaMaria.Infra.ModuloQuestao;

namespace TestesDonaMaria.WinForms.ModuloQuestao
{
    public partial class TelaQuestao : Form
    {

        private RepositorioSQLQuestao repQuestao;
        private RepositorioSQLMateria repMateria;
        private RepositorioSQLDisciplina repDisciplina;

        private int disciplina_id;
        private int serie;
        private bool ehEdicao;

        public event GravarRegistroDelegate<Questao> onGravarRegistro;
        public TelaQuestao(RepositorioSQLQuestao repQuestao, RepositorioSQLMateria repMateria, RepositorioSQLDisciplina repDisciplina)
        {
            InitializeComponent();
            this.ConfigurarTelas();
            this.repQuestao = repQuestao;
            this.repMateria = repMateria;
            this.repDisciplina = repDisciplina;
            CarregarDisciplina();
            CarregarMateria();
            this.Text = "Cadastro de Questão";
            this.ehEdicao = false;
        }

        private void TelaQuestao_Load(object sender, EventArgs e)
        {
            CarregarDisciplina();
            CarregarMateria();
        }

        private void CarregarMateria()
        {
            cbxMateria.Items.Clear();
            cbxMateria.Items.AddRange(repMateria.SelecionarTodosPorDisciplina(disciplina_id).ToArray());
        }

        private void CarregarDisciplina()
        {
            cbxDisciplina.Items.Clear();
            foreach (Disciplina disciplina in repDisciplina.SelecionarTodos())
            {
                cbxDisciplina.Items.Add(disciplina);
            }
        }

        public void DefinirID(int id)
        {
            txtID.Text = id.ToString();
        }

        public Questao ObterQuestao()
        {
            Materia materia = (Materia)cbxMateria.SelectedItem;
            string enunciado = txtEnunciado.Text;
            int serie = cbxSerie.SelectedIndex + 1;
            int id = Convert.ToInt32(txtID.Text);

            Questao questao = new Questao(id, enunciado, serie, materia);

            ObterAlternativas(questao);

            return questao;
        }
        private void ObterAlternativas(Questao questao)
        {
            for (int i = 0; i < clbAlternativas.Items.Count; i++)
            {
                string alternativa = clbAlternativas.Items[i].ToString();
                bool correta = clbAlternativas.GetItemChecked(i);

                questao.alternativas.Add(new(alternativa, correta, questao.id));
            }
        }
        private void btn_gravar_Click(object sender, EventArgs e)
        {
            Questao questao = ObterQuestao();

            Result resultado = onGravarRegistro(questao);

            if (resultado.IsFailed)
            {
                string msgErro = resultado.Errors[0].Message;
                TelaPrincipal.InstanciaAtual.AtualizarRodape(msgErro);
                DialogResult = DialogResult.None;
                return;
            }
            TelaPrincipal.InstanciaAtual.AtualizarRodape("Status");
        }

        private void btnAdicionarAlternativa_Click(object sender, EventArgs e)
        {
            if (txtAdicionarAlternativa.Text == "")
            {
                MessageBox.Show("Digite uma alternativa");
                return;
            }

            if (clbAlternativas.Items.Count == 5)
            {
                MessageBox.Show("Limite de alternativas atingido");
                return;
            }

            String alternativa = txtAdicionarAlternativa.Text;

            clbAlternativas.Items.Add(alternativa);

            txtAdicionarAlternativa.Text = "";
        }

        private void btnRemoverAlternativa_Click(object sender, EventArgs e)
        {
            clbAlternativas.Items.RemoveAt(clbAlternativas.SelectedIndex);
        }

        private void cbxDisciplina_SelectedValueChanged(object sender, EventArgs e)
        {
            this.disciplina_id = ((Disciplina)cbxDisciplina.SelectedItem).id;
            cbxSerie.Enabled = true;
            cbxMateria.Enabled = true;

            CarregarMateria();
        }

        internal void ConfigurarTela(Questao questaoSelecionada)
        {
            this.Text = "Atualização de Questão";
            CarregarDisciplina();
            txtID.Text = questaoSelecionada.id.ToString();
            txtEnunciado.Text = questaoSelecionada.enunciado;

            cbxSerie.SelectedIndex = questaoSelecionada.serie - 1;
            cbxDisciplina.SelectedItem = questaoSelecionada.materia.disciplina;
            cbxDisciplina.Text = questaoSelecionada.materia.disciplina.nome;

            this.disciplina_id = questaoSelecionada.materia.disciplina.id;
            cbxMateria.SelectedItem = questaoSelecionada.materia;
            cbxMateria.Text = questaoSelecionada.materia.nome;

            foreach (Alternativa alternativa in questaoSelecionada.alternativas)
            {
                clbAlternativas.Items.Add(alternativa.alternativa, alternativa.correta);
            }

            btn_gravar.Text = "Atualizar";

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            TelaPrincipal.InstanciaAtual.AtualizarRodape("Status");
        }
    }
}
