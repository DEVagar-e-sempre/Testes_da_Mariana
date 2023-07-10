namespace TestesDonaMaria.WinForms.ModuloTeste
{
    partial class TelaTeste
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
            cbxMateria = new ComboBox();
            label4 = new Label();
            cbxDisciplina = new ComboBox();
            label3 = new Label();
            cbxSerie = new ComboBox();
            txtID = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            txb_titulo = new TextBox();
            label6 = new Label();
            txtQtdQuestao = new NumericUpDown();
            lb_questoesSorteadas = new ListBox();
            cb_provaRec = new CheckBox();
            btn_cancelar = new Button();
            btn_gravar = new Button();
            btn_sortear = new Button();
            ((System.ComponentModel.ISupportInitialize)txtQtdQuestao).BeginInit();
            SuspendLayout();
            // 
            // cbxMateria
            // 
            cbxMateria.Enabled = false;
            cbxMateria.FormattingEnabled = true;
            cbxMateria.Location = new Point(97, 129);
            cbxMateria.Name = "cbxMateria";
            cbxMateria.Size = new Size(121, 23);
            cbxMateria.TabIndex = 21;
            cbxMateria.SelectedValueChanged += cbxMateria_SelectedValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(25, 127);
            label4.Name = "label4";
            label4.Size = new Size(66, 23);
            label4.TabIndex = 20;
            label4.Text = "Matéria:";
            // 
            // cbxDisciplina
            // 
            cbxDisciplina.FormattingEnabled = true;
            cbxDisciplina.Location = new Point(97, 86);
            cbxDisciplina.Name = "cbxDisciplina";
            cbxDisciplina.Size = new Size(121, 23);
            cbxDisciplina.TabIndex = 19;
            cbxDisciplina.SelectedIndexChanged += cbxDisciplina_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(14, 84);
            label3.Name = "label3";
            label3.Size = new Size(77, 23);
            label3.TabIndex = 18;
            label3.Text = "Disciplina:";
            // 
            // cbxSerie
            // 
            cbxSerie.Enabled = false;
            cbxSerie.FormattingEnabled = true;
            cbxSerie.Items.AddRange(new object[] { "1", "2" });
            cbxSerie.Location = new Point(306, 86);
            cbxSerie.Name = "cbxSerie";
            cbxSerie.Size = new Size(121, 23);
            cbxSerie.TabIndex = 17;
            cbxSerie.SelectedValueChanged += cbxSerie_SelectedValueChanged;
            // 
            // txtID
            // 
            txtID.Location = new Point(97, 12);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(56, 23);
            txtID.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(253, 84);
            label2.Name = "label2";
            label2.Size = new Size(47, 23);
            label2.TabIndex = 15;
            label2.Text = "Série:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(63, 10);
            label1.Name = "label1";
            label1.Size = new Size(28, 23);
            label1.TabIndex = 14;
            label1.Text = "ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(39, 49);
            label5.Name = "label5";
            label5.Size = new Size(52, 23);
            label5.TabIndex = 22;
            label5.Text = "Título:";
            // 
            // txb_titulo
            // 
            txb_titulo.Location = new Point(97, 51);
            txb_titulo.Name = "txb_titulo";
            txb_titulo.Size = new Size(330, 23);
            txb_titulo.TabIndex = 23;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(253, 129);
            label6.Name = "label6";
            label6.Size = new Size(104, 23);
            label6.TabIndex = 24;
            label6.Text = "Qtd. Questões:";
            // 
            // txtQtdQuestao
            // 
            txtQtdQuestao.Location = new Point(379, 129);
            txtQtdQuestao.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            txtQtdQuestao.Name = "txtQtdQuestao";
            txtQtdQuestao.Size = new Size(48, 23);
            txtQtdQuestao.TabIndex = 25;
            txtQtdQuestao.Value = new decimal(new int[] { 2, 0, 0, 0 });
            txtQtdQuestao.ValueChanged += qtdQuestao_ValueChanged;
            // 
            // lb_questoesSorteadas
            // 
            lb_questoesSorteadas.FormattingEnabled = true;
            lb_questoesSorteadas.ItemHeight = 15;
            lb_questoesSorteadas.Location = new Point(14, 219);
            lb_questoesSorteadas.Name = "lb_questoesSorteadas";
            lb_questoesSorteadas.Size = new Size(413, 184);
            lb_questoesSorteadas.TabIndex = 26;
            // 
            // cb_provaRec
            // 
            cb_provaRec.AutoSize = true;
            cb_provaRec.Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point);
            cb_provaRec.Location = new Point(25, 175);
            cb_provaRec.Name = "cb_provaRec";
            cb_provaRec.Size = new Size(163, 25);
            cb_provaRec.TabIndex = 27;
            cb_provaRec.Text = "Prova de Recuperação";
            cb_provaRec.UseVisualStyleBackColor = true;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_cancelar.DialogResult = DialogResult.Cancel;
            btn_cancelar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancelar.Location = new Point(363, 435);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(81, 31);
            btn_cancelar.TabIndex = 29;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_gravar
            // 
            btn_gravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_gravar.DialogResult = DialogResult.OK;
            btn_gravar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_gravar.Location = new Point(273, 435);
            btn_gravar.Name = "btn_gravar";
            btn_gravar.Size = new Size(81, 31);
            btn_gravar.TabIndex = 28;
            btn_gravar.Text = "Gravar";
            btn_gravar.UseVisualStyleBackColor = true;
            btn_gravar.Click += btn_gravar_Click;
            // 
            // btn_sortear
            // 
            btn_sortear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_sortear.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_sortear.Location = new Point(346, 182);
            btn_sortear.Name = "btn_sortear";
            btn_sortear.Size = new Size(81, 31);
            btn_sortear.TabIndex = 30;
            btn_sortear.Text = "Sortear";
            btn_sortear.UseVisualStyleBackColor = true;
            btn_sortear.Click += btn_sortear_Click;
            // 
            // TelaTeste
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(456, 478);
            Controls.Add(btn_sortear);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_gravar);
            Controls.Add(cb_provaRec);
            Controls.Add(lb_questoesSorteadas);
            Controls.Add(txtQtdQuestao);
            Controls.Add(label6);
            Controls.Add(txb_titulo);
            Controls.Add(label5);
            Controls.Add(cbxMateria);
            Controls.Add(label4);
            Controls.Add(cbxDisciplina);
            Controls.Add(label3);
            Controls.Add(cbxSerie);
            Controls.Add(txtID);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaTeste";
            Text = "Cadastro de Teste";
            ((System.ComponentModel.ISupportInitialize)txtQtdQuestao).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbxMateria;
        private Label label4;
        private ComboBox cbxDisciplina;
        private Label label3;
        private ComboBox cbxSerie;
        private TextBox txtID;
        private Label label2;
        private Label label1;
        private Label label5;
        private TextBox txb_titulo;
        private Label label6;
        private NumericUpDown txtQtdQuestao;
        private ListBox lb_questoesSorteadas;
        private CheckBox cb_provaRec;
        private Button btn_cancelar;
        private Button btn_gravar;
        private Button btn_sortear;
    }
}