using TestesDonaMaria.Dominio.ModuloQuestao;

namespace TestesDonaMaria.WinForms.ModuloQuestao
{
    public partial class TabelaQuestao : UserControl
    {
        public TabelaQuestao()
        {
            InitializeComponent();

            ConfigurarColunas();
            grid.ConfigurarGrid();
            grid.ConfigurarGridZebrado();
        }

        private void ConfigurarColunas()
        {
            //    public string titulo;
            //    public string questaoCorreta;
            //    public int serie;
            //    public Disciplina disciplina;
            //    public Materia materia;

            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.Name = "ID";
            id.HeaderText = "ID";

            DataGridViewTextBoxColumn disciplina = new DataGridViewTextBoxColumn();
            disciplina.Name = "disciplina";
            disciplina.HeaderText = "Disciplina";

            DataGridViewTextBoxColumn materia = new DataGridViewTextBoxColumn();
            materia.Name = "materia";
            materia.HeaderText = "Matéria";

            grid.Columns.AddRange(id);
            grid.Columns.AddRange(disciplina);
            grid.Columns.AddRange(materia);
        }

        public void AtualizarRegistros(List<Questao> listaQuestoes)
        {
            grid.Rows.Clear();

            foreach (Questao questao in listaQuestoes)
            {
                grid.Rows.Add(questao.id, questao.materia.disciplina.nome, questao.materia.nome);
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
