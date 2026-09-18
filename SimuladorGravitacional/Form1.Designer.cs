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
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(11, 93);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1237, 700);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint_1;
            // 
            // button1
            // 
            button1.Location = new Point(11, 16);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(207, 31);
            button1.TabIndex = 3;
            button1.Text = "Iniciar uma nova configuração";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1040, 16);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(207, 31);
            button2.TabIndex = 4;
            button2.Text = "Carregar uma configuração";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1040, 55);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(207, 31);
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
            Massa.Size = new Size(50, 20);
            Massa.TabIndex = 8;
            Massa.Text = "Massa";
            // 
            // Densidade
            // 
            Densidade.AutoSize = true;
            Densidade.Location = new Point(3, 0);
            Densidade.Name = "Densidade";
            Densidade.Size = new Size(72, 40);
            Densidade.TabIndex = 11;
            Densidade.Text = "Densidade";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(flowLayoutPanel3);
            flowLayoutPanel1.Controls.Add(numericUpDown1);
            flowLayoutPanel1.Controls.Add(numericUpDown2);
            flowLayoutPanel1.Location = new Point(701, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(274, 35);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(Massa);
            flowLayoutPanel3.Location = new Point(3, 4);
            flowLayoutPanel3.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(80, 27);
            flowLayoutPanel3.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(89, 4);
            numericUpDown1.Margin = new Padding(3, 4, 3, 4);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(85, 27);
            numericUpDown1.TabIndex = 9;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(180, 4);
            numericUpDown2.Margin = new Padding(3, 4, 3, 4);
            numericUpDown2.Maximum = new decimal(new int[] { 800, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(85, 27);
            numericUpDown2.TabIndex = 10;
            numericUpDown2.Value = new decimal(new int[] { 800, 0, 0, 0 });
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel2.Controls.Add(numericUpDown3);
            flowLayoutPanel2.Controls.Add(numericUpDown4);
            flowLayoutPanel2.Location = new Point(701, 53);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(274, 35);
            flowLayoutPanel2.TabIndex = 13;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(Densidade);
            flowLayoutPanel4.Location = new Point(3, 4);
            flowLayoutPanel4.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(80, 27);
            flowLayoutPanel4.TabIndex = 9;
            // 
            // numericUpDown3
            // 
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown3.Location = new Point(89, 4);
            numericUpDown3.Margin = new Padding(3, 4, 3, 4);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(85, 27);
            numericUpDown3.TabIndex = 11;
            numericUpDown3.Value = new decimal(new int[] { 9, 0, 0, 131072 });
            // 
            // numericUpDown4
            // 
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown4.Location = new Point(180, 4);
            numericUpDown4.Margin = new Padding(3, 4, 3, 4);
            numericUpDown4.Maximum = new decimal(new int[] { 2260, 0, 0, 131072 });
            numericUpDown4.Minimum = new decimal(new int[] { 9, 0, 0, 131072 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(85, 27);
            numericUpDown4.TabIndex = 12;
            numericUpDown4.Value = new decimal(new int[] { 2260, 0, 0, 131072 });
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(label1);
            flowLayoutPanel5.Controls.Add(numericUpDown5);
            flowLayoutPanel5.Location = new Point(498, 27);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(187, 41);
            flowLayoutPanel5.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 0;
            label1.Text = "Corpos";
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(65, 3);
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(102, 27);
            numericUpDown5.TabIndex = 1;
            numericUpDown5.ValueChanged += numericUpDown5_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 803);
            Controls.Add(flowLayoutPanel5);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
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
    }
}
