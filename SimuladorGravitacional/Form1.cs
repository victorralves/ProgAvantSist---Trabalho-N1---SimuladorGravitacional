using System.ComponentModel;

namespace SimuladorGravitacional
{
    public partial class Form1 : Form
    {
        Universo universo = new Universo(0, 0, 0, 0, 0, 0, 0);
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            foreach (Corpo corpo in universo.corpos)
            {
                e.Graphics.FillEllipse(Brushes.White,
                    (float)corpo.posX - (float)corpo.Raio(),
                    (float)corpo.posY - (float)corpo.Raio(),
                    (float)corpo.Raio() * 2,
                    (float)corpo.Raio() * 2);
            }

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            universo = new Universo((int)numericUpDown5.Value, panel1.Height, panel1.Width, (double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value, (double)numericUpDown4.Value);
            panel1.Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= numericUpDown2.Value)
            {
                numericUpDown2.Value = numericUpDown1.Value + 1;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value <= numericUpDown1.Value)
            {
                numericUpDown1.Value = numericUpDown2.Value - 1;
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value >= numericUpDown4.Value)
            {
                numericUpDown4.Value = numericUpDown3.Value + (decimal)0.01;
            }
        }
        
        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown4.Value <= numericUpDown3.Value)
            {
                numericUpDown3.Value = numericUpDown4.Value - (decimal)0.01;
            }
        }
    }
}
