using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloDisciplina;

namespace TestesDonaMaria.WinForms.ModuloDisciplina
{
    public partial class TelaDisciplina : Form
    {
        private Disciplina disciplina;
        private RepositorioSQLDisciplina repDisc;

        public TelaDisciplina(RepositorioSQLDisciplina repDisc)//o repositorio é para compara e ver se é repetido
        {
            InitializeComponent();

            this.repDisc = repDisc;
        }

        public Disciplina Disciplina
        {
            set
            {
                txb_id.Text = value.id.ToString();
                txb_nome.Text = value.nome;
            }

            get => disciplina;
        }

        public void DefinirID(int id)
        {
            txb_id.Text = id.ToString();
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            TelaPrincipal telaPrincipal = TelaPrincipal.InstanciaAtual;

            int id = Convert.ToInt32(txb_id.Text);
            string nome = txb_nome.Text;

            disciplina = new Disciplina(nome);

            disciplina.id = id;

            if (repDisc.EhRepetido(disciplina))
            {
                telaPrincipal.AtualizarRodape("Nome de disciplina já existente, por favor insira um novo nome!");

                DialogResult = DialogResult.None;
            }
            else
            {
                string[] erros = disciplina.Validar();

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
    }
}
