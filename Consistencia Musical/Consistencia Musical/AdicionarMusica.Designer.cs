namespace Consistencia_Musical
{
    partial class AdicionarMusica
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            button1 = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 16);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(20, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(206, 23);
            textBox1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 72);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Artista:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(20, 90);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(206, 23);
            textBox2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(113, 182);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 3;
            label3.Text = "Aprendizado:";
            label3.Click += label3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(196, 178);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(29, 23);
            textBox3.TabIndex = 3;
            textBox3.Text = "50";
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox3.TextChanged += textBox3_TextChanged_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 181);
            label4.Name = "label4";
            label4.Size = new Size(21, 15);
            label4.TabIndex = 6;
            label4.Text = "ID:";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(43, 178);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(46, 23);
            textBox4.TabIndex = 7;
            textBox4.TabStop = false;
            textBox4.Text = "1";
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(67, 219);
            button1.Name = "button1";
            button1.Size = new Size(123, 45);
            button1.TabIndex = 4;
            button1.Text = "Cadastrar Música";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 284);
            label5.Name = "label5";
            label5.Size = new Size(238, 30);
            label5.TabIndex = 9;
            label5.Text = "OBS: não esquecer de validar se a música já \r\nestá inserida";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(228, 182);
            label6.Name = "label6";
            label6.Size = new Size(17, 15);
            label6.TabIndex = 10;
            label6.Text = "%";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 125);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 2;
            label7.Text = "Link Aula:";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(20, 146);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(206, 23);
            textBox5.TabIndex = 2;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // AdicionarMusica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(270, 370);
            Controls.Add(textBox5);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "AdicionarMusica";
            Text = "Adicionar Nova Musica";
            Load += AdicionarMusica_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Button button1;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox5;
    }
}