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
        private int materia_id;
        private int serie;
        private int qtdQuestao;

        private Teste teste;


        public TelaTeste(RepositorioSQLTeste repTeste, RepositorioSQLQuestao repQuestao, RepositorioSQLMateria repMateria, RepositorioSQLDisciplina repDisciplina)
        {
            InitializeComponent();
            this.ConfigurarTelas();

            this.repTeste = repTeste;
            this.repQuestao = repQuestao;
            this.repMateria = repMateria;
            this.repDisciplina = repDisciplina;

            this.materia_id = 0;
            this.serie = 0;
            this.qtdQuestao = 2;

            CarregarDisciplina();
            CarregarMateria();
        }

        public Teste Teste
        {
            set
            {
                txtID.Text = value.id.ToString();
                txb_titulo.Text = value.titulo;

                cbxSerie.SelectedIndex = value.serie-1;
                txtQtdQuestao.Value = value.quantQuestoes;
                CarregarDisciplina();
                cbxDisciplina.SelectedItem = value.materia.disciplina;
                cbxMateria.SelectedItem = value.materia;
                cb_provaRec.Checked= value.recuperacao;

                lb_questoesSorteadas.Items.AddRange(value.listaQuestoes.ToArray());
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

        public void ObterQuestoes(Teste teste)
        {
            for(int i = 0; i < lb_questoesSorteadas.Items.Count; i++)
            {
                teste.listaQuestoes.Add((Questao)lb_questoesSorteadas.Items[i]);
            }
        }
        private void btn_gravar_Click(object sender, EventArgs e)
        {
            TelaPrincipal telaPrincipal = TelaPrincipal.InstanciaAtual;

            string titulo = txb_titulo.Text;

            int id = Convert.ToInt32(txtID.Text);

            int numQtdQuestao = (int)txtQtdQuestao.Value;

            bool recuperacao = cb_provaRec.Checked;

            Materia materia = (Materia)cbxMateria.SelectedItem;



            teste = new Teste(id, titulo, materia, numQtdQuestao, this.serie, recuperacao);
            ObterQuestoes(teste);

            if (repTeste.EhRepetido(teste))
            {
                telaPrincipal.AtualizarRodape("Teste com essas caracteristicas já existente, por favor insira um novo Teste!");

                DialogResult = DialogResult.None;

                return;
            }

            string[] erros = teste.Validar();

            if (erros.Length > 0)
            {
                telaPrincipal.AtualizarRodape(erros[0]);
                DialogResult = DialogResult.None;
                return;
            }
            telaPrincipal.AtualizarRodape("Status");

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
            int numQtdQuestao = (int)txtQtdQuestao.Value;

            if (materia_id == 0 && serie == 0)
            {
                MessageBox.Show($"Selecione uma matéria e uma série!",
                                 "ERRO",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
                return;
            }
            lb_questoesSorteadas.Items.Clear();
            lb_questoesSorteadas.Items.AddRange(repQuestao.SelecionarAleatoriamente(numQtdQuestao, materia_id, serie).ToArray());

        }

        private void cbxMateria_SelectedValueChanged(object sender, EventArgs e)
        {
            this.materia_id = ((Materia)cbxMateria.SelectedItem).id;
            lb_questoesSorteadas.Items.Clear();
        }

        private void cbxSerie_SelectedValueChanged(object sender, EventArgs e)
        {
            this.serie = cbxSerie.SelectedIndex + 1;
            lb_questoesSorteadas.Items.Clear();
        }

        private void qtdQuestao_ValueChanged(object sender, EventArgs e)
        {
            this.qtdQuestao = (int)txtQtdQuestao.Value;
            lb_questoesSorteadas.Items.Clear();
        }
    }
}
