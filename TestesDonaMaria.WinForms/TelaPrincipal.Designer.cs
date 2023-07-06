namespace TestesDonaMaria.WinForms
{
    partial class TelaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            painel_botoesEntidades = new Panel();
            btn_teste = new Button();
            btn_materia = new Button();
            btn_questao = new Button();
            btn_disciplina = new Button();
            painel_principal = new Panel();
            ts_ferramentas = new ToolStrip();
            btn_inserir = new ToolStripButton();
            btn_editar = new ToolStripButton();
            btn_excluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btn_filtrar = new ToolStripButton();
            btn_listar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton6 = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            lbl_tipoCad = new ToolStripLabel();
            panel1 = new Panel();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            statusStrip1 = new StatusStrip();
            lbl_status = new ToolStripStatusLabel();
            painel_botoesEntidades.SuspendLayout();
            ts_ferramentas.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // painel_botoesEntidades
            // 
            painel_botoesEntidades.BackColor = Color.CornflowerBlue;
            painel_botoesEntidades.Controls.Add(label3);
            painel_botoesEntidades.Controls.Add(btn_teste);
            painel_botoesEntidades.Controls.Add(btn_materia);
            painel_botoesEntidades.Controls.Add(btn_questao);
            painel_botoesEntidades.Controls.Add(btn_disciplina);
            painel_botoesEntidades.Dock = DockStyle.Left;
            painel_botoesEntidades.Location = new Point(0, 0);
            painel_botoesEntidades.Name = "painel_botoesEntidades";
            painel_botoesEntidades.Size = new Size(192, 457);
            painel_botoesEntidades.TabIndex = 0;
            // 
            // btn_teste
            // 
            btn_teste.BackColor = Color.CornflowerBlue;
            btn_teste.FlatAppearance.BorderColor = Color.CornflowerBlue;
            btn_teste.FlatStyle = FlatStyle.Flat;
            btn_teste.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btn_teste.ForeColor = Color.Black;
            btn_teste.Image = Properties.Resources.task_FILL0_wght400_GRAD200_opsz24;
            btn_teste.ImageAlign = ContentAlignment.MiddleLeft;
            btn_teste.Location = new Point(3, 297);
            btn_teste.Name = "btn_teste";
            btn_teste.Size = new Size(186, 47);
            btn_teste.TabIndex = 4;
            btn_teste.Text = "Teste";
            btn_teste.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_teste.UseVisualStyleBackColor = false;
            // 
            // btn_materia
            // 
            btn_materia.BackColor = Color.CornflowerBlue;
            btn_materia.FlatAppearance.BorderColor = Color.CornflowerBlue;
            btn_materia.FlatStyle = FlatStyle.Flat;
            btn_materia.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btn_materia.ForeColor = Color.Black;
            btn_materia.Image = Properties.Resources.menu_book_FILL0_wght400_GRAD200_opsz24;
            btn_materia.ImageAlign = ContentAlignment.MiddleLeft;
            btn_materia.Location = new Point(3, 191);
            btn_materia.Name = "btn_materia";
            btn_materia.Size = new Size(186, 47);
            btn_materia.TabIndex = 3;
            btn_materia.Text = "Matéria";
            btn_materia.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_materia.UseVisualStyleBackColor = false;
            // 
            // btn_questao
            // 
            btn_questao.BackColor = Color.CornflowerBlue;
            btn_questao.FlatAppearance.BorderColor = Color.CornflowerBlue;
            btn_questao.FlatStyle = FlatStyle.Flat;
            btn_questao.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btn_questao.ForeColor = Color.Black;
            btn_questao.Image = Properties.Resources.format_list_numbered_FILL0_wght400_GRAD200_opsz24;
            btn_questao.ImageAlign = ContentAlignment.MiddleLeft;
            btn_questao.Location = new Point(3, 244);
            btn_questao.Name = "btn_questao";
            btn_questao.Size = new Size(186, 47);
            btn_questao.TabIndex = 2;
            btn_questao.Text = "Questão";
            btn_questao.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_questao.UseVisualStyleBackColor = false;
            // 
            // btn_disciplina
            // 
            btn_disciplina.BackColor = Color.CornflowerBlue;
            btn_disciplina.FlatAppearance.BorderColor = Color.CornflowerBlue;
            btn_disciplina.FlatStyle = FlatStyle.Flat;
            btn_disciplina.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btn_disciplina.ForeColor = Color.Black;
            btn_disciplina.Image = Properties.Resources.collections_bookmark_FILL0_wght400_GRAD200_opsz24;
            btn_disciplina.ImageAlign = ContentAlignment.MiddleLeft;
            btn_disciplina.Location = new Point(3, 138);
            btn_disciplina.Name = "btn_disciplina";
            btn_disciplina.Size = new Size(186, 47);
            btn_disciplina.TabIndex = 1;
            btn_disciplina.Text = "Disciplina";
            btn_disciplina.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn_disciplina.UseVisualStyleBackColor = false;
            // 
            // painel_principal
            // 
            painel_principal.Location = new Point(192, 112);
            painel_principal.Name = "painel_principal";
            painel_principal.Size = new Size(644, 320);
            painel_principal.TabIndex = 1;
            // 
            // ts_ferramentas
            // 
            ts_ferramentas.BackColor = Color.Transparent;
            ts_ferramentas.Dock = DockStyle.None;
            ts_ferramentas.Items.AddRange(new ToolStripItem[] { btn_inserir, btn_editar, btn_excluir, toolStripSeparator1, btn_filtrar, btn_listar, toolStripSeparator2, toolStripButton6, toolStripSeparator3, lbl_tipoCad });
            ts_ferramentas.Location = new Point(195, 78);
            ts_ferramentas.Name = "ts_ferramentas";
            ts_ferramentas.Size = new Size(295, 31);
            ts_ferramentas.TabIndex = 1;
            ts_ferramentas.Text = "toolStrip1";
            // 
            // btn_inserir
            // 
            btn_inserir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_inserir.Image = Properties.Resources.add_circle_FILL0_wght400_GRAD0_opsz24;
            btn_inserir.ImageTransparentColor = Color.Magenta;
            btn_inserir.Name = "btn_inserir";
            btn_inserir.Padding = new Padding(4);
            btn_inserir.Size = new Size(28, 28);
            btn_inserir.Text = "Adicionar";
            btn_inserir.Click += botaoBarraFerramentas_Click;
            // 
            // btn_editar
            // 
            btn_editar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_editar.Image = Properties.Resources.edit_FILL0_wght400_GRAD0_opsz24;
            btn_editar.ImageTransparentColor = Color.Magenta;
            btn_editar.Name = "btn_editar";
            btn_editar.Padding = new Padding(4);
            btn_editar.Size = new Size(28, 28);
            btn_editar.Text = "Editar";
            btn_editar.Click += botaoBarraFerramentas_Click;
            // 
            // btn_excluir
            // 
            btn_excluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_excluir.Image = Properties.Resources.delete_forever_FILL0_wght400_GRAD0_opsz24;
            btn_excluir.ImageTransparentColor = Color.Magenta;
            btn_excluir.Name = "btn_excluir";
            btn_excluir.Padding = new Padding(4);
            btn_excluir.Size = new Size(28, 28);
            btn_excluir.Text = "Remover";
            btn_excluir.Click += botaoBarraFerramentas_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // btn_filtrar
            // 
            btn_filtrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_filtrar.Image = Properties.Resources.filter_alt_FILL0_wght400_GRAD0_opsz24;
            btn_filtrar.ImageTransparentColor = Color.Magenta;
            btn_filtrar.Name = "btn_filtrar";
            btn_filtrar.Padding = new Padding(4);
            btn_filtrar.Size = new Size(28, 28);
            btn_filtrar.Text = "Filtrar";
            // 
            // btn_listar
            // 
            btn_listar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btn_listar.Image = Properties.Resources.outline_view_list_black_24dp;
            btn_listar.ImageTransparentColor = Color.Magenta;
            btn_listar.Name = "btn_listar";
            btn_listar.Padding = new Padding(4);
            btn_listar.Size = new Size(28, 28);
            btn_listar.Text = "Listagem";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 31);
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Padding = new Padding(4);
            toolStripButton6.Size = new Size(28, 28);
            toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 31);
            // 
            // lbl_tipoCad
            // 
            lbl_tipoCad.Name = "lbl_tipoCad";
            lbl_tipoCad.Size = new Size(97, 28);
            lbl_tipoCad.Text = "Tipo do Cadastro";
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(906, 75);
            panel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(21, 81);
            label3.Name = "label3";
            label3.Size = new Size(144, 43);
            label3.TabIndex = 1;
            label3.Text = "Categorias";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(343, 18);
            label1.Name = "label1";
            label1.Size = new Size(313, 43);
            label1.TabIndex = 0;
            label1.Text = "Testes da Dona Mariana";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(704, 81);
            label2.Name = "label2";
            label2.Size = new Size(132, 23);
            label2.TabIndex = 3;
            label2.Text = "DEVagar e sempre";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Transparent;
            statusStrip1.Items.AddRange(new ToolStripItem[] { lbl_status });
            statusStrip1.Location = new Point(192, 435);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(644, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbl_status
            // 
            lbl_status.Name = "lbl_status";
            lbl_status.Size = new Size(39, 17);
            lbl_status.Text = "Status";
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(836, 457);
            Controls.Add(statusStrip1);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(ts_ferramentas);
            Controls.Add(painel_principal);
            Controls.Add(painel_botoesEntidades);
            Name = "TelaPrincipal";
            Text = "Tela Principal";
            painel_botoesEntidades.ResumeLayout(false);
            painel_botoesEntidades.PerformLayout();
            ts_ferramentas.ResumeLayout(false);
            ts_ferramentas.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel painel_botoesEntidades;
        private Panel painel_principal;
        private Button btn_disciplina;
        private Button btn_teste;
        private Button btn_materia;
        private Button btn_questao;
        private Panel panel1;
        private Label label1;
        private ToolStrip ts_ferramentas;
        private ToolStripButton btn_inserir;
        private ToolStripButton btn_editar;
        private ToolStripButton btn_excluir;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btn_filtrar;
        private ToolStripButton btn_listar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton6;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel lbl_tipoCad;
        private Label label2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbl_status;
        private Label label3;
    }
}