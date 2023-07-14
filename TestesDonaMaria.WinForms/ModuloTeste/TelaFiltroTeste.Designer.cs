namespace TestesDonaMaria.WinForms.ModuloTeste
{
    partial class TelaFiltroTeste
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
            panel1 = new Panel();
            btn_cancelar = new Button();
            btn_aplicar = new Button();
            rdb_filtroDisc = new RadioButton();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            radioButton1 = new RadioButton();
            comboBox3 = new ComboBox();
            radioButton2 = new RadioButton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBox3);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(rdb_filtroDisc);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(461, 169);
            panel1.TabIndex = 0;
            // 
            // btn_cancelar
            // 
            btn_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_cancelar.DialogResult = DialogResult.Cancel;
            btn_cancelar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancelar.Location = new Point(387, 203);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(81, 31);
            btn_cancelar.TabIndex = 25;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_aplicar
            // 
            btn_aplicar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_aplicar.DialogResult = DialogResult.OK;
            btn_aplicar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_aplicar.Location = new Point(297, 203);
            btn_aplicar.Name = "btn_aplicar";
            btn_aplicar.Size = new Size(81, 31);
            btn_aplicar.TabIndex = 24;
            btn_aplicar.Text = "Aplicar";
            btn_aplicar.UseVisualStyleBackColor = true;
            // 
            // rdb_filtroDisc
            // 
            rdb_filtroDisc.AutoSize = true;
            rdb_filtroDisc.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rdb_filtroDisc.Location = new Point(3, 3);
            rdb_filtroDisc.Name = "rdb_filtroDisc";
            rdb_filtroDisc.Size = new Size(196, 32);
            rdb_filtroDisc.TabIndex = 1;
            rdb_filtroDisc.TabStop = true;
            rdb_filtroDisc.Text = "Filtrar por disciplina";
            rdb_filtroDisc.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(20, 41);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(196, 23);
            comboBox1.TabIndex = 25;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(20, 118);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(196, 23);
            comboBox2.TabIndex = 27;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton1.Location = new Point(3, 80);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(182, 32);
            radioButton1.TabIndex = 26;
            radioButton1.TabStop = true;
            radioButton1.Text = "Filtrar por materia";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(257, 41);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(196, 23);
            comboBox3.TabIndex = 27;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton2.Location = new Point(239, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(156, 32);
            radioButton2.TabIndex = 26;
            radioButton2.TabStop = true;
            radioButton2.Text = "Filtrar por serie";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // TelaFiltroTeste
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 246);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_aplicar);
            Controls.Add(panel1);
            Name = "TelaFiltroTeste";
            Text = "TelaFiltroTeste";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_cancelar;
        private Button btn_aplicar;
        private RadioButton rdb_filtroDisc;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ComboBox comboBox1;
    }
}