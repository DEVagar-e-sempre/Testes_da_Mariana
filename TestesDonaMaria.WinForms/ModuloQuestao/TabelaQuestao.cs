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

            DataGridViewColumn[] colunas = new DataGridViewColumn[]
                        {
                new DataGridViewTextBoxColumn() { Name  = "id", HeaderText = "ID" },
                new DataGridViewTextBoxColumn() { Name  = "questao", HeaderText = "Questão" },
                new DataGridViewTextBoxColumn() { Name  = "alternativaCorreta", HeaderText = "Alternativa Correta" },
                new DataGridViewTextBoxColumn() { Name  = "materia", HeaderText = "Matéria" },
                new DataGridViewTextBoxColumn() { Name  = "disciplina", HeaderText = "Disciplina" },
                        };
            grid.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Questao> listaQuestoes)
        {
            grid.Rows.Clear();

            foreach (Questao questao in listaQuestoes)
            {
                Alternativa tempAlternativa = questao.ObterAlternativaCorreta();
                if(tempAlternativa == null)
                {
                    continue;
                }
                grid.Rows.Add(questao.id, questao.enunciado, tempAlternativa.alternativa, questao.materia.nome, questao.materia.disciplina.nome);
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
