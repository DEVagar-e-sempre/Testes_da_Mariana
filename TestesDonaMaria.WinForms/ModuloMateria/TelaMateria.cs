using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Infra.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloMateria;

namespace TestesDonaMaria.WinForms.ModuloMateria
{
    public partial class TelaMateria : Form
    {
        private Materia materia;
        private RepositorioSQLMateria repMateria;
        private RepositorioSQLDisciplina repDisciplina;

        public TelaMateria(RepositorioSQLMateria repMateria, RepositorioSQLDisciplina repDisciplina)
        {
            InitializeComponent();

            this.repMateria = repMateria;
            this.repDisciplina = repDisciplina;

            CarregarDisciplinaCbox(repDisciplina);
        }

        private void CarregarDisciplinaCbox(RepositorioSQLDisciplina repDisciplina)
        {
            foreach (Disciplina disc in repDisciplina.SelecionarTodos())
            {
                cbox_disciplina.Items.Add(disc.nome);
            }
        }

        public Materia MateriaP
        {
            set
            {
                txb_id.Text = value.id.ToString();
                txb_nome.Text = value.nome;
                cbox_disciplina.Text = value.disciplina.nome;
            }

            get => materia;
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            TelaPrincipal telaPrincipal = TelaPrincipal.TelaPrincipalP;

            int id = Convert.ToInt32(txb_id.Text);

            string nome = txb_nome.Text;

            string nomeDisc = cbox_disciplina.SelectedText;

            Disciplina disc = ProcuradorDeDisciplina(nomeDisc);

            materia = new Materia(nome, disc);

            materia.id = id;

            if (repMateria.EhRepetido(materia))
            {
                telaPrincipal.AtualizarRodape("Nome de materia já existente, por favor insira um novo nome!");

                DialogResult = DialogResult.None;
            }
            else
            {
                string[] erros = materia.Validar();

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

        private Disciplina ProcuradorDeDisciplina(string nomeDisc)
        {
            foreach (Disciplina disc in repDisciplina.SelecionarTodos())
            {
                if (disc.nome.Equals(nomeDisc))
                {
                    return disc;
                }

            }

            return null;
        }
    }
}
