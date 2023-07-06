using System.Windows.Forms;
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
            cbxMateria.SelectedIndex = -1;
            cbxMateria.Text = "";
            cbxMateria.SelectedItem = null;
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
            String enunciado = txtEnunciado.Text;
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
                String alternativa = clbAlternativas.Items[i].ToString();
                bool correta = clbAlternativas.GetItemChecked(i);

                questao.alternativas.Add(new(alternativa, correta, questao.id));
            }
        }
        private void btn_gravar_Click(object sender, EventArgs e)
        {
            Questao aluguel = ObterQuestao();
            string[] erros = aluguel.Validar();

            if (repQuestao.EhRepetido(aluguel))
            {
                TelaPrincipal.InstanciaAtual.AtualizarRodape("Questão repetida");
                return;
            }

            if (erros.Length > 0)
            {
                TelaPrincipal.InstanciaAtual.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
            }
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

            this.disciplina_id = questaoSelecionada.materia.disciplina.id;
            CarregarMateria();
            cbxMateria.SelectedItem = questaoSelecionada.materia;

            foreach (Alternativa alternativa in questaoSelecionada.alternativas)
            {
                clbAlternativas.Items.Add(alternativa.alternativa, alternativa.correta);
            }

            btn_gravar.Text = "Atualizar";

        }
    }
}
