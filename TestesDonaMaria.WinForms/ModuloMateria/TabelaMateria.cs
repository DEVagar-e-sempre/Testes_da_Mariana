using TestesDonaMaria.Dominio.ModuloMateria;

namespace TestesDonaMaria.WinForms.ModuloMateria
{
    public partial class TabelaMateria : UserControl
    {
        public TabelaMateria()
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

            DataGridViewTextBoxColumn disciplina = new DataGridViewTextBoxColumn();
            disciplina.Name = "disciplina";

            grid.Columns.AddRange(id);
            grid.Columns.AddRange(nome);
            grid.Columns.AddRange(disciplina);
        }

        public void AtualizarRegistros(List<Materia> listaMateria)
        {
            grid.Rows.Clear();

            foreach (Materia materia in listaMateria)
            {
                grid.Rows.Add(materia.id, materia.nome, materia.disciplina.nome);
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
