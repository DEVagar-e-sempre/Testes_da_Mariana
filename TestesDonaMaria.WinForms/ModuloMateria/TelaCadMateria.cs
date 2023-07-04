using TestesDonaMaria.Dominio.ModuloMateria;
using TestesDonaMaria.Infra.ModuloMateria;

namespace TestesDonaMaria.WinForms.ModuloMateria
{
    public partial class TelaCadMateria : Form
    {
        private Materia materia;
        private RepositorioSQLMateria repMateria;

        public TelaCadMateria(RepositorioSQLMateria repMateria)
        {
            InitializeComponent();

            this.repMateria = repMateria;
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

        }
    }
}
