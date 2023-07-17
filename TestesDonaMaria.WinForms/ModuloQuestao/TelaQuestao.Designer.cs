namespace TestesDonaMaria.WinForms.ModuloQuestao
{
    partial class TelaQuestao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtID = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cbxSerie = new ComboBox();
            cbxDisciplina = new ComboBox();
            label3 = new Label();
            cbxMateria = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            txtEnunciado = new RichTextBox();
            label6 = new Label();
            txtAdicionarAlternativa = new TextBox();
            btnAdicionarAlternativa = new Button();
            gpbAlternativas = new GroupBox();
            btnRemoverAlternativa = new Button();
            clbAlternativas = new CheckedListBox();
            btn_cancelar = new Button();
            btn_gravar = new Button();
            gpbAlternativas.SuspendLayout();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.Location = new Point(118, 27);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(56, 23);
            txtID.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(65, 59);
            label2.Name = "label2";
            label2.Size = new Size(47, 23);
            label2.TabIndex = 7;
            label2.Text = "Série:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(84, 25);
            label1.Name = "label1";
            label1.Size = new Size(28, 23);
            label1.TabIndex = 6;
            label1.Text = "ID:";
            // 
            // cbxSerie
            // 
            cbxSerie.Enabled = false;
            cbxSerie.FormattingEnabled = true;
            cbxSerie.Items.AddRange(new object[] { "1", "2" });
            cbxSerie.Location = new Point(118, 61);
            cbxSerie.Name = "cbxSerie";
            cbxSerie.Size = new Size(121, 23);
            cbxSerie.TabIndex = 9;
            // 
            // cbxDisciplina
            // 
            cbxDisciplina.FormattingEnabled = true;
            cbxDisciplina.Location = new Point(348, 27);
            cbxDisciplina.Name = "cbxDisciplina";
            cbxDisciplina.Size = new Size(121, 23);
            cbxDisciplina.TabIndex = 11;
            cbxDisciplina.SelectedValueChanged += cbxDisciplina_SelectedValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(265, 25);
            label3.Name = "label3";
            label3.Size = new Size(77, 23);
            label3.TabIndex = 10;
            label3.Text = "Disciplina:";
            // 
            // cbxMateria
            // 
            cbxMateria.Enabled = false;
            cbxMateria.FormattingEnabled = true;
            cbxMateria.Location = new Point(348, 61);
            cbxMateria.Name = "cbxMateria";
            cbxMateria.Size = new Size(121, 23);
            cbxMateria.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(276, 59);
            label4.Name = "label4";
            label4.Size = new Size(66, 23);
            label4.TabIndex = 12;
            label4.Text = "Matéria:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(46, 98);
            label5.Name = "label5";
            label5.Size = new Size(66, 23);
            label5.TabIndex = 14;
            label5.Text = "Questão:";
            // 
            // txtEnunciado
            // 
            txtEnunciado.Location = new Point(46, 124);
            txtEnunciado.Name = "txtEnunciado";
            txtEnunciado.Size = new Size(423, 113);
            txtEnunciado.TabIndex = 15;
            txtEnunciado.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(46, 246);
            label6.Name = "label6";
            label6.Size = new Size(90, 23);
            label6.TabIndex = 16;
            label6.Text = "Alternativa:";
            // 
            // txtAdicionarAlternativa
            // 
            txtAdicionarAlternativa.Location = new Point(46, 272);
            txtAdicionarAlternativa.Name = "txtAdicionarAlternativa";
            txtAdicionarAlternativa.Size = new Size(322, 23);
            txtAdicionarAlternativa.TabIndex = 17;
            // 
            // btnAdicionarAlternativa
            // 
            btnAdicionarAlternativa.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdicionarAlternativa.Location = new Point(374, 266);
            btnAdicionarAlternativa.Name = "btnAdicionarAlternativa";
            btnAdicionarAlternativa.Size = new Size(95, 31);
            btnAdicionarAlternativa.TabIndex = 18;
            btnAdicionarAlternativa.Text = "Adicionar";
            btnAdicionarAlternativa.UseVisualStyleBackColor = true;
            btnAdicionarAlternativa.Click += btnAdicionarAlternativa_Click;
            // 
            // gpbAlternativas
            // 
            gpbAlternativas.Controls.Add(btnRemoverAlternativa);
            gpbAlternativas.Controls.Add(clbAlternativas);
            gpbAlternativas.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gpbAlternativas.Location = new Point(46, 312);
            gpbAlternativas.Name = "gpbAlternativas";
            gpbAlternativas.Size = new Size(423, 155);
            gpbAlternativas.TabIndex = 19;
            gpbAlternativas.TabStop = false;
            gpbAlternativas.Text = "Alternativas";
            // 
            // btnRemoverAlternativa
            // 
            btnRemoverAlternativa.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemoverAlternativa.Location = new Point(6, 22);
            btnRemoverAlternativa.Name = "btnRemoverAlternativa";
            btnRemoverAlternativa.Size = new Size(75, 28);
            btnRemoverAlternativa.TabIndex = 1;
            btnRemoverAlternativa.Text = "Remover";
            btnRemoverAlternativa.UseVisualStyleBackColor = true;
            btnRemoverAlternativa.Click += btnRemoverAlternativa_Click;
            // 
            // clbAlternativas
            // 
            clbAlternativas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            clbAlternativas.FormattingEnabled = true;
            clbAlternativas.Location = new Point(6, 53);
            clbAlternativas.Name = "clbAlternativas";
            clbAlternativas.Size = new Size(411, 94);
            clbAlternativas.TabIndex = 0;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_cancelar.DialogResult = DialogResult.Cancel;
            btn_cancelar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancelar.Location = new Point(388, 483);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(81, 31);
            btn_cancelar.TabIndex = 21;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // btn_gravar
            // 
            btn_gravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_gravar.DialogResult = DialogResult.OK;
            btn_gravar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_gravar.Location = new Point(298, 483);
            btn_gravar.Name = "btn_gravar";
            btn_gravar.Size = new Size(81, 31);
            btn_gravar.TabIndex = 20;
            btn_gravar.Text = "Gravar";
            btn_gravar.UseVisualStyleBackColor = true;
            btn_gravar.Click += btn_gravar_Click;
            // 
            // TelaQuestao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 526);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_gravar);
            Controls.Add(gpbAlternativas);
            Controls.Add(btnAdicionarAlternativa);
            Controls.Add(txtAdicionarAlternativa);
            Controls.Add(label6);
            Controls.Add(txtEnunciado);
            Controls.Add(label5);
            Controls.Add(cbxMateria);
            Controls.Add(label4);
            Controls.Add(cbxDisciplina);
            Controls.Add(label3);
            Controls.Add(cbxSerie);
            Controls.Add(txtID);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaQuestao";
            Text = "Tela Questao";
            gpbAlternativas.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtID;
        private Label label2;
        private Label label1;
        private ComboBox cbxSerie;
        private ComboBox cbxDisciplina;
        private Label label3;
        private ComboBox cbxMateria;
        private Label label4;
        private Label label5;
        private RichTextBox txtEnunciado;
        private Label label6;
        private TextBox txtAdicionarAlternativa;
        private Button btnAdicionarAlternativa;
        private GroupBox gpbAlternativas;
        private Button btnRemoverAlternativa;
        private CheckedListBox clbAlternativas;
        private Button btn_cancelar;
        private Button btn_gravar;
    }
}