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
            domainUpDown1 = new DomainUpDown();
            domainUpDown2 = new DomainUpDown();
            Massa = new Label();
            domainUpDown3 = new DomainUpDown();
            domainUpDown4 = new DomainUpDown();
            Densidade = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(11, 94);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1236, 700);
            panel1.TabIndex = 2;
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
            // domainUpDown1
            // 
            domainUpDown1.Location = new Point(59, 3);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(108, 27);
            domainUpDown1.TabIndex = 6;
            domainUpDown1.Text = "0";
            domainUpDown1.SelectedItemChanged += domainUpDown1_SelectedItemChanged;
            // 
            // domainUpDown2
            // 
            domainUpDown2.Location = new Point(173, 3);
            domainUpDown2.Name = "domainUpDown2";
            domainUpDown2.Size = new Size(108, 27);
            domainUpDown2.TabIndex = 7;
            domainUpDown2.Text = "0";
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
            // domainUpDown3
            // 
            domainUpDown3.Location = new Point(89, 3);
            domainUpDown3.Name = "domainUpDown3";
            domainUpDown3.Size = new Size(108, 27);
            domainUpDown3.TabIndex = 9;
            domainUpDown3.Text = "0";
            // 
            // domainUpDown4
            // 
            domainUpDown4.Location = new Point(203, 3);
            domainUpDown4.Name = "domainUpDown4";
            domainUpDown4.Size = new Size(108, 27);
            domainUpDown4.TabIndex = 10;
            domainUpDown4.Text = "0";
            // 
            // Densidade
            // 
            Densidade.AutoSize = true;
            Densidade.Location = new Point(3, 0);
            Densidade.Name = "Densidade";
            Densidade.Size = new Size(80, 20);
            Densidade.TabIndex = 11;
            Densidade.Text = "Densidade";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(Massa);
            flowLayoutPanel1.Controls.Add(domainUpDown1);
            flowLayoutPanel1.Controls.Add(domainUpDown2);
            flowLayoutPanel1.Location = new Point(701, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(304, 35);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(Densidade);
            flowLayoutPanel2.Controls.Add(domainUpDown3);
            flowLayoutPanel2.Controls.Add(domainUpDown4);
            flowLayoutPanel2.Location = new Point(701, 53);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(333, 34);
            flowLayoutPanel2.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 803);
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
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button button2;
        private Button button3;
        private DomainUpDown domainUpDown1;
        private DomainUpDown domainUpDown2;
        private Label Massa;
        private DomainUpDown domainUpDown3;
        private DomainUpDown domainUpDown4;
        private Label Densidade;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}
