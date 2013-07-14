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
    public partial class JanelaBusca : Form
    {
        public JanelaBusca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            ArrayList pessoas = new ArrayList();
            JanelaExibirBusca exibir = new JanelaExibirBusca();
            string nome = textBox1.Text.Trim();
                        
            //Verificando se o nome não é vazio
            if (nome != "")
            {
                //Verificando se existem pessoas cadastradas no banco com o nome
                pessoas = bd.retornaPessoa(nome);
                if (pessoas.Count > 0)
                {
                    //Adcionando informações no layout
                    p = (Pessoa)pessoas[0];
                    exibir.label4.Text = "1 de " + pessoas.Count;
                    exibir.label3.Text = "ID: " + p.Id;
                    exibir.label1.Text = "Nome: " + p.Nome;
                    exibir.label2.Text = "Idade: " + p.Idade;

                    //Abrindo janela
                    bd.close();
                    exibir.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nenhuma pessoa cadastrada com esse nome!", "Erro");
                    bd.close();
                }
            }
            else
            {
                MessageBox.Show("Insira um nome para buscar!", "Erro");
                bd.close();
            }
        }
    }
}
