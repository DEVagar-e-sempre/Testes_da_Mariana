namespace TestesDonaMaria.WinForms.ModuloDisciplina
{
    partial class TelaDisciplina
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
            btn_gravar = new Button();
            btn_cancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            txb_id = new TextBox();
            txb_nome = new TextBox();
            SuspendLayout();
            // 
            // btn_gravar
            // 
            btn_gravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_gravar.DialogResult = DialogResult.OK;
            btn_gravar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_gravar.Location = new Point(70, 110);
            btn_gravar.Name = "btn_gravar";
            btn_gravar.Size = new Size(81, 31);
            btn_gravar.TabIndex = 0;
            btn_gravar.Text = "Gravar";
            btn_gravar.UseVisualStyleBackColor = true;
            btn_gravar.Click += btn_gravar_Click;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_cancelar.DialogResult = DialogResult.Cancel;
            btn_cancelar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancelar.Location = new Point(151, 110);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(81, 31);
            btn_cancelar.TabIndex = 1;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(35, 18);
            label1.Name = "label1";
            label1.Size = new Size(28, 23);
            label1.TabIndex = 2;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(51, 23);
            label2.TabIndex = 3;
            label2.Text = "Nome:";
            // 
            // txb_id
            // 
            txb_id.Location = new Point(69, 20);
            txb_id.Name = "txb_id";
            txb_id.ReadOnly = true;
            txb_id.Size = new Size(56, 23);
            txb_id.TabIndex = 4;
            // 
            // txb_nome
            // 
            txb_nome.Location = new Point(69, 52);
            txb_nome.Name = "txb_nome";
            txb_nome.Size = new Size(134, 23);
            txb_nome.TabIndex = 5;
            // 
            // TelaDisciplina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(241, 153);
            Controls.Add(txb_nome);
            Controls.Add(txb_id);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_gravar);
            Name = "TelaDisciplina";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Disciplina";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_gravar;
        private Button btn_cancelar;
        private Label label1;
        private Label label2;
        private TextBox txb_id;
        private TextBox txb_nome;
    }
}