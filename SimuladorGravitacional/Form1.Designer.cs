namespace SimuladorGravitacional
{
    partial class Form1
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
            panel1 = new Panel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            Massa = new Label();
            Densidade = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel4 = new FlowLayoutPanel();
            numericUpDown3 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label1 = new Label();
            numericUpDown5 = new NumericUpDown();
            label2 = new Label();
            numericUpDown6 = new NumericUpDown();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel2 = new Panel();
            flowLayoutPanel8 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Desktop;
            panel1.Location = new Point(3, 79);
            panel1.Name = "panel1";
            panel1.Size = new Size(960, 535);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint_1;
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(181, 23);
            button1.TabIndex = 3;
            button1.Text = "Iniciar uma nova configuração";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(0, 2);
            button2.Name = "button2";
            button2.Size = new Size(181, 23);
            button2.TabIndex = 4;
            button2.Text = "Carregar uma configuração";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(0, 26);
            button3.Name = "button3";
            button3.Size = new Size(181, 23);
            button3.TabIndex = 5;
            button3.Text = "Salvar configuração atual";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button2_Click;
            // 
            // Massa
            // 
            Massa.AutoSize = true;
            Massa.Location = new Point(3, 0);
            Massa.Name = "Massa";
            Massa.Size = new Size(40, 15);
            Massa.TabIndex = 8;
            Massa.Text = "Massa";
            // 
            // Densidade
            // 
            Densidade.AutoSize = true;
            Densidade.Location = new Point(3, 0);
            Densidade.Name = "Densidade";
            Densidade.Size = new Size(62, 15);
            Densidade.TabIndex = 11;
            Densidade.Text = "Densidade";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel1.Controls.Add(numericUpDown1);
            flowLayoutPanel1.Controls.Add(numericUpDown2);
            flowLayoutPanel1.Location = new Point(3, 2);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(240, 26);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(Massa);
            flowLayoutPanel3.Location = new Point(3, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(70, 20);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(79, 3);
            numericUpDown1.Maximum = new decimal(new int[] { 49999, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 500, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(74, 23);
            numericUpDown1.TabIndex = 9;
            numericUpDown1.Value = new decimal(new int[] { 800, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(159, 3);
            numericUpDown2.Maximum = new decimal(new int[] { 50000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 501, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(74, 23);
            numericUpDown2.TabIndex = 10;
            numericUpDown2.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel2.Controls.Add(numericUpDown3);
            flowLayoutPanel2.Controls.Add(numericUpDown4);
            flowLayoutPanel2.Location = new Point(3, 32);
            flowLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(240, 26);
            flowLayoutPanel2.TabIndex = 13;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(Densidade);
            flowLayoutPanel4.Location = new Point(3, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(70, 20);
            flowLayoutPanel4.TabIndex = 9;
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Location = new Point(79, 3);
            numericUpDown3.Maximum = new decimal(new int[] { 2259, 0, 0, 131072 });
            numericUpDown3.Minimum = new decimal(new int[] { 9, 0, 0, 131072 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(74, 23);
            numericUpDown3.TabIndex = 11;
            numericUpDown3.Value = new decimal(new int[] { 539, 0, 0, 131072 });
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // numericUpDown4
            // 
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown4.Location = new Point(159, 3);
            numericUpDown4.Maximum = new decimal(new int[] { 2260, 0, 0, 131072 });
            numericUpDown4.Minimum = new decimal(new int[] { 10, 0, 0, 131072 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(74, 23);
            numericUpDown4.TabIndex = 12;
            numericUpDown4.Value = new decimal(new int[] { 226, 0, 0, 65536 });
            numericUpDown4.ValueChanged += numericUpDown4_ValueChanged;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(label1);
            flowLayoutPanel5.Controls.Add(numericUpDown5);
            flowLayoutPanel5.Controls.Add(label2);
            flowLayoutPanel5.Controls.Add(numericUpDown6);
            flowLayoutPanel5.Location = new Point(250, 2);
            flowLayoutPanel5.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(189, 66);
            flowLayoutPanel5.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Corpos";
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(54, 2);
            numericUpDown5.Margin = new Padding(3, 2, 3, 2);
            numericUpDown5.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(89, 23);
            numericUpDown5.TabIndex = 1;
            numericUpDown5.Value = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDown5.ValueChanged += numericUpDown5_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 27);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Iterações";
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(63, 30);
            numericUpDown6.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown6.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(80, 23);
            numericUpDown6.TabIndex = 3;
            numericUpDown6.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 76F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(966, 617);
            tableLayoutPanel1.TabIndex = 15;
            tableLayoutPanel1.Resize += tableLayoutPanel1_Resize;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 269F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 197F));
            tableLayoutPanel2.Controls.Add(button1, 0, 0);
            tableLayoutPanel2.Controls.Add(panel2, 3, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel8, 2, 0);
            tableLayoutPanel2.Controls.Add(flowLayoutPanel5, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(960, 70);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button3);
            panel2.Location = new Point(766, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(184, 53);
            panel2.TabIndex = 18;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel8.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel8.Location = new Point(497, 3);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(251, 58);
            flowLayoutPanel8.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 617);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            flowLayoutPanel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label Massa;
        private Label Densidade;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel3;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown4;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label label1;
        private NumericUpDown numericUpDown5;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel8;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel2;
        private Label label2;
        private NumericUpDown numericUpDown6;
    }
}
