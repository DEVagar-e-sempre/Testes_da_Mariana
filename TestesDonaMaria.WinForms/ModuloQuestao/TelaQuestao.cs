using TestesDonaMaria.Dominio.ModuloQuestao;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;

namespace TestesDonaMaria.WinForms.ModuloQuestao
{
    public partial class TelaQuestao : Form
    {
        private RepositorioSQLMateria repMateria;

        private RepositorioSQLDisciplina repDisciplina;

        public TelaQuestao(RepositorioSQLMateria repMateria, RepositorioSQLDisciplina repDisciplina)
        {
            InitializeComponent();
            this.repMateria = repMateria;
            this.repDisciplina = repDisciplina;
        }

        private void TelaQuestao_Load(object sender, EventArgs e)
        {
            CarregarDisciplina();
            CarregarMateria();
        }

        private void CarregarMateria()
        {
            cbxMateria.Items.Clear();
            cbxMateria.Items.AddRange(repMateria.SelecionarTodos().ToArray());
        }

        private void CarregarDisciplina()
        {
            cbxDisciplina.Items.Clear();
            cbxDisciplina.Items.AddRange(repDisciplina.SelecionarTodos().ToArray());
        }

        public void DefinirID(int id)
        {

        }

        internal Questao ObterQuestao()
        {
            return null;
        }
    }
}
