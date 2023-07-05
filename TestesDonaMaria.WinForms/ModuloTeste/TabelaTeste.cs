using TestesDonaMaria.Dominio.ModuloTeste;

namespace TestesDonaMaria.WinForms.ModuloTeste
{
    public partial class TabelaTeste : UserControl
    {
        public TabelaTeste()
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

            DataGridViewTextBoxColumn titulo = new DataGridViewTextBoxColumn();
            titulo.Name = "titulo";
            titulo.HeaderText = "Título";

            DataGridViewTextBoxColumn disciplina = new DataGridViewTextBoxColumn();
            disciplina.Name = "disciplina";
            disciplina.HeaderText = "Disciplina";

            DataGridViewTextBoxColumn materia = new DataGridViewTextBoxColumn();
            materia.Name = "materia";
            materia.HeaderText = "Matéria";

            DataGridViewTextBoxColumn qtdQuestoes = new DataGridViewTextBoxColumn();
            qtdQuestoes.Name = "qtdQuestoes";
            qtdQuestoes.HeaderText = "Qtd. Questões";

            grid.Columns.AddRange(id);
            grid.Columns.AddRange(titulo);
            grid.Columns.AddRange(disciplina);
            grid.Columns.AddRange(materia);
            grid.Columns.AddRange(qtdQuestoes);
        }

        public void AtualizarRegistros(List<Teste> listaTestes)
        {
            grid.Rows.Clear();

            foreach (Teste teste in listaTestes)
            {
                grid.Rows.Add(teste.id, teste.titulo, teste.materia.disciplina.nome, teste.materia.nome, teste.quantQuestoes);
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
