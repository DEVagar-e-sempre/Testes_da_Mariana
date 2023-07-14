namespace TestesDonaMaria.WinForms.ModuloMateria
{
    partial class TelaFiltroMateria
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
            btn_aplicar = new Button();
            rdb_filtroDisc = new RadioButton();
            cbox = new ComboBox();
            rdb_todos = new RadioButton();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_cancelar
            // 
            btn_cancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_cancelar.DialogResult = DialogResult.Cancel;
            btn_cancelar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_cancelar.Location = new Point(175, 188);
            btn_cancelar.Name = "btn_cancelar";
            btn_cancelar.Size = new Size(81, 31);
            btn_cancelar.TabIndex = 23;
            btn_cancelar.Text = "Cancelar";
            btn_cancelar.UseVisualStyleBackColor = true;
            // 
            // btn_aplicar
            // 
            btn_aplicar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_aplicar.DialogResult = DialogResult.OK;
            btn_aplicar.Font = new Font("Segoe Print", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_aplicar.Location = new Point(85, 188);
            btn_aplicar.Name = "btn_aplicar";
            btn_aplicar.Size = new Size(81, 31);
            btn_aplicar.TabIndex = 22;
            btn_aplicar.Text = "Aplicar";
            btn_aplicar.UseVisualStyleBackColor = true;
            // 
            // rdb_filtroDisc
            // 
            rdb_filtroDisc.AutoSize = true;
            rdb_filtroDisc.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rdb_filtroDisc.Location = new Point(21, 69);
            rdb_filtroDisc.Name = "rdb_filtroDisc";
            rdb_filtroDisc.Size = new Size(196, 32);
            rdb_filtroDisc.TabIndex = 0;
            rdb_filtroDisc.TabStop = true;
            rdb_filtroDisc.Text = "Filtrar por disciplina";
            rdb_filtroDisc.UseVisualStyleBackColor = true;
            rdb_filtroDisc.CheckedChanged += rdb_filtroDisc_CheckedChanged;
            // 
            // cbox
            // 
            cbox.FormattingEnabled = true;
            cbox.Location = new Point(40, 107);
            cbox.Name = "cbox";
            cbox.Size = new Size(196, 23);
            cbox.TabIndex = 24;
            // 
            // rdb_todos
            // 
            rdb_todos.AutoSize = true;
            rdb_todos.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rdb_todos.Location = new Point(21, 22);
            rdb_todos.Name = "rdb_todos";
            rdb_todos.Size = new Size(77, 32);
            rdb_todos.TabIndex = 25;
            rdb_todos.TabStop = true;
            rdb_todos.Text = "Todos";
            rdb_todos.UseVisualStyleBackColor = true;
            rdb_todos.CheckedChanged += rdb_todos_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdb_todos);
            groupBox1.Controls.Add(rdb_filtroDisc);
            groupBox1.Controls.Add(cbox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(244, 160);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // TelaFiltroMateria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(268, 231);
            Controls.Add(groupBox1);
            Controls.Add(btn_cancelar);
            Controls.Add(btn_aplicar);
            Name = "TelaFiltroMateria";
            Text = "TelaFiltroMateria";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btn_cancelar;
        private Button btn_aplicar;
        private RadioButton rdb_filtroDisc;
        private ComboBox cbox;
        private RadioButton rdb_todos;
        private GroupBox groupBox1;
    }
}