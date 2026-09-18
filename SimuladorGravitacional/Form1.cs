namespace SimuladorGravitacional
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int height = panel1.Height;
            int width = panel1.Width;
            double minMassa = (double)numericUpDown1.Value;
            double maxMassa = (double)numericUpDown2.Value;
            double minDensidade = (double)numericUpDown3.Value;
            double maxDensidade = (double)numericUpDown4.Value;
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

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
