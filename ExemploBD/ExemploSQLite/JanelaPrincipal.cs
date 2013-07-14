using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ExemploSQLite
{
    public partial class JanelaPrincipal : Form
    {
        public JanelaPrincipal()
        {
            InitializeComponent();
        }

        //Botão Cadastrar
        private void button1_Click(object sender, EventArgs e)
        {
            JanelaCadastro cadastro = new JanelaCadastro();
            cadastro.ShowDialog();
        }

        //Botão Editar
        private void button2_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            ArrayList pessoas = new ArrayList();
            JanelaEscolhaEditar escolha = new JanelaEscolhaEditar();
            string nome;

            //Inserindo pessoas cadastradas no comboBox
            pessoas = bd.retornaPessoa();
            for (int i = 0; i < pessoas.Count; i++)
            {
                p = (Pessoa)pessoas[i];
                nome = p.Id +" - " +p.Nome;
                escolha.comboBox1.Items.Add(nome);
            }
            
            //Abrindo janela
            if (escolha.comboBox1.Items.Count > 0)
                escolha.comboBox1.SelectedIndex = 0;
            bd.close();
            escolha.ShowDialog();
        }

        //Botão Excluir
        private void button3_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            ArrayList pessoas = new ArrayList();
            JanelaEscolhaExcluir escolha = new JanelaEscolhaExcluir();
            string nome;

            //Inserindo pessoas cadastradas no comboBox
            pessoas = bd.retornaPessoa();
            for (int i = 0; i < pessoas.Count; i++)
            {
                p = (Pessoa)pessoas[i];
                nome = p.Id + " - " + p.Nome;
                escolha.comboBox1.Items.Add(nome);
            }

            //Abrindo janela
            if (escolha.comboBox1.Items.Count > 0)
                escolha.comboBox1.SelectedIndex = 0;
            bd.close();
            escolha.ShowDialog();
        }

        //Botão Sair
        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Botão Buscar
        private void button4_Click(object sender, EventArgs e)
        {
            JanelaBusca busca = new JanelaBusca();
            busca.ShowDialog();            
        }

        //Botão Listar
        private void button5_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            ArrayList pessoas = new ArrayList();
            JanelaExibir exibir = new JanelaExibir();

            //Verificando se existem pessoas cadastradas no banco
            pessoas = bd.retornaPessoa();
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
            }
            else
            {
                MessageBox.Show("Nenhuma pessoa cadastrada!","Erro");
                bd.close();
            }
        }
    }
}
