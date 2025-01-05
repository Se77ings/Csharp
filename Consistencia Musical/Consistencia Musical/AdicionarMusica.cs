using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Windows.Forms.VisualStyles;


namespace Consistencia_Musical
{
    public partial class AdicionarMusica : Form
    {
        public AdicionarMusica()
        {
            InitializeComponent();
        }

        private void AdicionarMusica_Load(object sender, EventArgs e)
        {
            var ultimoID = ListaMusicas.getLastId();
            textBox4.Text = (ultimoID + 1).ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox4.Text;
            string nome = textBox1.Text;
            string artista = textBox2.Text;
            string link = textBox5.Text;
            int aprendizado = Convert.ToInt32(textBox3.Text);

            if (nome == "" || artista == "" || link == "" || id == "")
            {
                MessageBox.Show("Preencha todos os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //cadastra.. transformar isso em uma função no método lista de musicas
            Musica nova = new Musica(Convert.ToInt32(id), nome, artista, aprendizado, link);
            //nova.exibeMusica();


            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../app_data/musicas.json");
            //Diretório funcionando..
            StreamWriter sw = new StreamWriter(path, true);


            //descomentar pra cadastrar outro
            sw.WriteLine(JsonSerializer.Serialize(nova));
            sw.Close();
            //depois validar se ja nao está cadastrado
            MessageBox.Show("Música cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpaCampos();



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //???
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            string aprendizadoStr = textBox3.Text;
            bool p = int.TryParse(aprendizadoStr, out int aprendizado);
            if (p)
            {
                if (aprendizado < 0 || aprendizado > 100)
                {
                    textBox3.Text = "0";
                    MessageBox.Show("Digite apenas números entre 0 e 100", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                textBox3.Text = "0";
                MessageBox.Show("Digite apenas números", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //métodos publicos
        public void limpaCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "50";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
