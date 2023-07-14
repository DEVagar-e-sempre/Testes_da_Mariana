using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMaria.Dominio.ModuloDisciplina;
using TestesDonaMaria.Infra.ModuloDisciplina;

namespace TestesDonaMaria.WinForms.ModuloMateria
{
    public partial class TelaFiltroMateria : Form
    {
        public TelaFiltroMateria(RepositorioSQLDisciplina repDisc)
        {
            InitializeComponent();
            this.ConfigurarTelas();

            cbox.Enabled = false;

            AdicionarItensCBOX(repDisc);
        }

        private void AdicionarItensCBOX(RepositorioSQLDisciplina repDisc)
        {
            foreach (Disciplina disc in repDisc.SelecionarTodos())
            {
                cbox.Items.Add(disc);
            }
        }

        public StatusFiltroMateriaEnum ObterStatus()
        {
            if(rdb_filtroDisc.Checked)
            {
                return StatusFiltroMateriaEnum.PorDisciplina;
            }

            if (rdb_todos.Checked)
            {
                return StatusFiltroMateriaEnum.Todos;
            }

            return StatusFiltroMateriaEnum.Nenhum;
        }

        public Disciplina ObterDisciplinaMateria()
        {
            return (Disciplina)cbox.SelectedItem;
        }

        private void rdb_filtroDisc_CheckedChanged(object sender, EventArgs e)
        {
            cbox.Enabled = true;
        }

        private void rdb_todos_CheckedChanged(object sender, EventArgs e)
        {
            cbox.Enabled = false;
        }
    }
}
