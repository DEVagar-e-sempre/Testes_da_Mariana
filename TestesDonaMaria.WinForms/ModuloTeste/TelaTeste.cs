using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Dominio.ModuloTeste;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;
using TestesDonaMaria.Infra.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloTeste;

namespace TestesDonaMaria.WinForms.ModuloTeste
{
    public partial class TelaTeste : Form
    {
        private RepositorioSQLQuestao repQuestao;
        private RepositorioSQLMateria repMateria;
        private RepositorioSQLDisciplina repDisciplina;
        private int disciplina_id;
        private Teste teste;

        public TelaTeste(RepositorioSQLTeste repTeste, RepositorioSQLQuestao repQuestao, RepositorioSQLMateria repMateria, RepositorioSQLDisciplina repDisciplina)
        {
            InitializeComponent();
            this.ConfigurarTelas();

            this.repQuestao = repQuestao;
            this.repMateria = repMateria;
            this.repDisciplina = repDisciplina;

            CarregarDisciplina();
            CarregarMateria();
        }

        public Teste Teste
        {
            set
            {
                txtID.Text = value.id.ToString();
                txb_titulo.Text = value.titulo;
                cbxMateria.SelectedItem = value.materia;
                cbxDisciplina.SelectedItem = value.materia.disciplina;
            }

            get => teste;
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

        private void btn_gravar_Click(object sender, EventArgs e)
        {

        }

        private void cbxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.disciplina_id = ((Disciplina)cbxDisciplina.SelectedItem).id;
            cbxSerie.Enabled = true;
            cbxMateria.Enabled = true;

            CarregarMateria();
        }

        private void btn_sortear_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            if(teste.listaQuestoes.Count == 0)
            {
                MessageBox.Show($"Não há Questões cadastradas!",
                    "ERRO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                for (int i = 0; i < qtdQuestao.Value; i++)
                {
                    int sorteio = rand.Next(1, teste.listaQuestoes.Count);
                    lb_questoesSorteadas.Items.Add(teste.listaQuestoes[i]);
                }
            }

        }
    }
}
