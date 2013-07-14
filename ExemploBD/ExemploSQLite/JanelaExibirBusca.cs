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
    public partial class JanelaExibirBusca : Form
    {
        public JanelaExibirBusca()
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
            string nome = this.label1.Text.Substring(6);
            int posicao;

            //Pegando a posição seguinte
            posicao = Int16.Parse(this.label4.Text.Substring(0, 2));

            //Verificando se a próxima posição existe no array
            pessoas = bd.retornaPessoa(nome);
            if (posicao < pessoas.Count)
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

        private void button3_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            ArrayList pessoas = new ArrayList();
            string nome = this.label1.Text.Substring(6);
            int posicao;

            //Pegando a posição anterior
            posicao = Int16.Parse(this.label4.Text.Substring(0, 2));
            posicao = posicao - 2;

            //Verificando se a posição anterior é válida
            pessoas = bd.retornaPessoa(nome);
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
    }
}
