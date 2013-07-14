using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExemploSQLite
{
    public partial class JanelaExibir : Form
    {
        public JanelaExibir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            ArrayList pessoas = new ArrayList();
            int posicao;

            //Pegando a posição seguinte
            posicao = Int16.Parse(this.label4.Text.Substring(0,2));            

            //Verificando se a próxima posição existe no array
            pessoas = bd.retornaPessoa();
            if (posicao < pessoas.Count)
            {
                //Adcionando informações no layout
                this.label4.Text = posicao+1 + " de " + pessoas.Count;
                p = (Pessoa)pessoas[posicao];
                this.label3.Text = "ID: " + p.Id;
                this.label1.Text = "Nome: " + p.Nome;
                this.label2.Text = "Idade: " + p.Idade;

                //Fechando banco
                bd.close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            ArrayList pessoas = new ArrayList();
            int posicao;

            //Pegando a posição anterior
            posicao = Int16.Parse(this.label4.Text.Substring(0, 2));
            posicao = posicao - 2;

            //Verificando se a posição anterior é válida
            pessoas = bd.retornaPessoa();
            if (posicao >= 0)
            {
                //Adcionando informações no layout
                this.label4.Text = posicao + 1 + " de " + pessoas.Count;
                p = (Pessoa)pessoas[posicao];
                this.label3.Text = "ID: " + p.Id;
                this.label1.Text = "Nome: " + p.Nome;
                this.label2.Text = "Idade: " + p.Idade;

                //Fechando banco
                bd.close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            ArrayList pessoas = new ArrayList();
            int posicao;

            //Pegando a posição atual
            posicao = Int16.Parse(this.label4.Text.Substring(0, 2));

            //Verificando se não estamos já na última posição
            pessoas = bd.retornaPessoa();
            if (posicao != pessoas.Count)
            {
                //Adcionando informações no layout
                this.label4.Text = pessoas.Count + " de " + pessoas.Count;
                p = (Pessoa)pessoas[pessoas.Count-1];
                this.label3.Text = "ID: " + p.Id;
                this.label1.Text = "Nome: " + p.Nome;
                this.label2.Text = "Idade: " + p.Idade;

                //Fechando banco
                bd.close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            ArrayList pessoas = new ArrayList();
            int posicao;

            //Pegando a posição atual
            posicao = Int16.Parse(this.label4.Text.Substring(0, 2));

            //Verificando se não estamos já na primeira posição
            pessoas = bd.retornaPessoa();
            if (posicao != 1)
            {
                //Adcionando informações no layout
                this.label4.Text = "1 de " + pessoas.Count;
                p = (Pessoa)pessoas[0];
                this.label3.Text = "ID: " + p.Id;
                this.label1.Text = "Nome: " + p.Nome;
                this.label2.Text = "Idade: " + p.Idade;

                //Fechando banco
                bd.close();
            }
        }
    }
}
