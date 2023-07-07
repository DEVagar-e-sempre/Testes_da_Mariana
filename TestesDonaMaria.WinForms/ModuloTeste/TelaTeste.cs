using System.Drawing.Text;
using System.Globalization;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
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
        private RepositorioSQLTeste repTeste;
        private RepositorioSQLQuestao repQuestao;
        private RepositorioSQLMateria repMateria;
        private RepositorioSQLDisciplina repDisciplina;
        private int disciplina_id;
        private Teste teste;

        public TelaTeste(RepositorioSQLTeste repTeste, RepositorioSQLQuestao repQuestao, RepositorioSQLMateria repMateria, RepositorioSQLDisciplina repDisciplina)
        {
            InitializeComponent();
            this.ConfigurarTelas();

            this.repTeste = repTeste;
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
                cbxSerie.SelectedIndex = value.serie;
                qtdQuestao.Value = value.quantQuestoes;
                CarregarDisciplina();
                cbxDisciplina.SelectedItem = value.materia.disciplina;
                CarregarMateria();
                cbxMateria.SelectedItem = value.materia;
                foreach (Questao questao in teste.listaQuestoes)
                {
                    lb_questoesSorteadas.Items.Add(questao);
                }
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
            TelaPrincipal telaPrincipal = TelaPrincipal.InstanciaAtual;

            string titulo = txb_titulo.Text;

            int id = Convert.ToInt32(txtID.Text);

            int numQtdQuestao = (int)qtdQuestao.Value;

            //Disciplina disc = (Disciplina)cbxDisciplina.SelectedItem;

            Materia materia = (Materia)cbxMateria.SelectedItem;

            int serie = (int)cbxSerie.SelectedItem;

            teste = new Teste(id, titulo, materia, numQtdQuestao, serie);

            if (repTeste.EhRepetido(teste))
            {
                telaPrincipal.AtualizarRodape("Teste com essas caracteristicas já existente, por favor insira um novo Teste!");

                DialogResult = DialogResult.None;
            }
            else
            {
                string[] erros = teste.Validar();

                if (erros.Length > 0)
                {
                    telaPrincipal.AtualizarRodape(erros[0]);
                    DialogResult = DialogResult.None;
                }
                else
                {
                    telaPrincipal.AtualizarRodape("Status");

                }
            }
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
            int numQtdQuestao = (int)qtdQuestao.Value;

            if(repQuestao.SelecionarTodos().Count == 0)
            {
                MessageBox.Show($"Não há Questões cadastradas!",
                    "ERRO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                int j = 0;
                lb_questoesSorteadas.Items.Clear();
                int auxSorteio = 0;
                for (int i = 0; i < qtdQuestao.Value; i++)
                {
                    int sorteio = rand.Next(0, repQuestao.SelecionarTodos().Count - 1);

                    if (sorteio != auxSorteio) {
                        lb_questoesSorteadas.Items.Add($"{j} - {repQuestao.SelecionarPorId(sorteio)}");
                        j++;
                        auxSorteio = sorteio;
                    }
                }
            }

        }
    }
}
