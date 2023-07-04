using TestesDonaMaria.Dominio.ModuloDisciplina;

namespace TestesDonaMaria.WinForms.ModuloDisciplina
{
    public partial class TabelaDisciplina : UserControl
    {
        public TabelaDisciplina()
        {
            InitializeComponent();

            ConfigurarColunas();
            grid.ConfigurarGrid();
            grid.ConfigurarGridZebrado();
        }

        private void ConfigurarColunas()
        {
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.Name = "ID";
            id.HeaderText = "ID";

            DataGridViewTextBoxColumn nome = new DataGridViewTextBoxColumn();
            nome.Name = "nome";
            nome.HeaderText = "Nome";

            grid.Columns.AddRange(id);
            grid.Columns.AddRange(nome);
        }

        public void AtualizarRegistros(List<Disciplina> listaDisciplina)
        {
            grid.Rows.Clear();

            foreach (Disciplina disciplina in listaDisciplina)
            {
                grid.Rows.Add(disciplina.id, disciplina.nome);
            }
        }
        public int ObterIdSelecionado()
        {
            if (grid.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(grid.SelectedRows[0].Cells["ID"].Value);

            return id;
        }
    }
}
