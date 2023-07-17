namespace TestesDonaMaria.WinForms.ModuloMateria
{
    partial class TelaMateria
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
            btn_cancelar = new Button();
            btn_gravar = new Button();
            txb_nome = new TextBox();
            txb_id = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            cbox_disciplina = new ComboBox();
            SuspendLayout();
            // 
            // btn_cancelar
            // 
            btn_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_cancelar.DialogResult = DialogResult.Cancel;
            btn_cancelar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancelar.Location = new Point(179, 157);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(81, 31);
            btn_cancelar.TabIndex = 3;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            btn_cancelar.Click += btn_cancelar_Click;
            // 
            // btn_gravar
            // 
            btn_gravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_gravar.DialogResult = DialogResult.OK;
            btn_gravar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_gravar.Location = new Point(98, 157);
            btn_gravar.Name = "btn_gravar";
            btn_gravar.Size = new Size(81, 31);
            btn_gravar.TabIndex = 2;
            btn_gravar.Text = "Gravar";
            btn_gravar.UseVisualStyleBackColor = true;
            btn_gravar.Click += btn_gravar_Click;
            // 
            // txb_nome
            // 
            txb_nome.Location = new Point(97, 46);
            txb_nome.Name = "txb_nome";
            txb_nome.Size = new Size(134, 23);
            txb_nome.TabIndex = 9;
            // 
            // txb_id
            // 
            txb_id.Location = new Point(97, 13);
            txb_id.Name = "txb_id";
            txb_id.ReadOnly = true;
            txb_id.Size = new Size(56, 23);
            txb_id.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(40, 46);
            label2.Name = "label2";
            label2.Size = new Size(51, 23);
            label2.TabIndex = 7;
            label2.Text = "Nome:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(63, 11);
            label1.Name = "label1";
            label1.Size = new Size(28, 23);
            label1.TabIndex = 6;
            label1.Text = "ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(14, 82);
            label3.Name = "label3";
            label3.Size = new Size(77, 23);
            label3.TabIndex = 10;
            label3.Text = "Disciplina:";
            // 
            // cbox_disciplina
            // 
            cbox_disciplina.FormattingEnabled = true;
            cbox_disciplina.Location = new Point(97, 84);
            cbox_disciplina.Name = "cbox_disciplina";
            cbox_disciplina.Size = new Size(134, 23);
            cbox_disciplina.TabIndex = 11;
            // 
            // TelaMateria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(272, 200);
            Controls.Add(cbox_disciplina);
            Controls.Add(label3);
            Controls.Add(txb_nome);
            Controls.Add(txb_id);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_gravar);
            Name = "TelaMateria";
            Text = "Cadastro de Materia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_cancelar;
        private Button btn_gravar;
        private TextBox txb_nome;
        private TextBox txb_id;
        private Label label2;
        private Label label1;
        private Label label3;
        private ComboBox cbox_disciplina;
    }
}