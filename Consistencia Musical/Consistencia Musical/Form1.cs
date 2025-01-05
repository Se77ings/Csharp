namespace Consistencia_Musical
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void adicionarNovaMúsicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show(new AdicionarMusica());
        }
    }
}
