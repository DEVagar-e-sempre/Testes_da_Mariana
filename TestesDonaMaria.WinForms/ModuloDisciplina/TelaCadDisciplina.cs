using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloDisciplina;

namespace TestesDonaMaria.WinForms.ModuloDisciplina
{
    public partial class TelaCadDisciplina : Form
    {
        private Disciplina disciplina;
        private RepositorioSQLDisciplina repDisc;

        public TelaCadDisciplina(RepositorioSQLDisciplina repDisc)//o repositorio é para compara e ver se é repetido
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

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            TelaPrincipal telaPrincipal = TelaPrincipal.TelaPrincipalP;

            string nome = txb_nome.Text;

            disciplina = new Disciplina(nome);

            if (repDisc.EhRepetido(disciplina))
            {
                telaPrincipal.AtualizarRodape("Nome de cliente já existente, por favor insira um novo nome!");

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
                    telaPrincipal.AtualizarRodape("");

                }
            }
        }
    }
}
