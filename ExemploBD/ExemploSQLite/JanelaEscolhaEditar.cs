using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExemploSQLite
{
    public partial class JanelaEscolhaEditar : Form
    {
        public JanelaEscolhaEditar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            string item = "";
            int id;

            //Verificando se o valor do comboBox não é vazio
            if (comboBox1.SelectedIndex >= 0)
            {
                //Pegando id do item selecionado
                item = comboBox1.SelectedItem.ToString();
                item = item.Substring(0, item.IndexOf(" -"));
                id = Int16.Parse(item);

                //Setando dados na janela de edição
                JanelaEditar editar = new JanelaEditar();
                p = bd.retornaPessoa(id);
                editar.label3.Text = "ID: " +p.Id;
                editar.textBox1.Text = p.Nome;
                editar.textBox2.Text = p.Idade.ToString();

                //Chamando janela de edição
                editar.ShowDialog();
                bd.close();
                this.Close();

            }
            else
            {
                MessageBox.Show("Nenhuma pessoa cadastrada!", "Erro!");
                bd.close();
                this.Close(); 
            }
        }
    }
}
