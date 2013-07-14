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
    public partial class JanelaEscolhaExcluir : Form
    {
        public JanelaEscolhaExcluir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            string item = "";
            int id;

            //Verificando se o valor do comboBox não é vazio
            if (comboBox1.SelectedIndex >= 0)
            {
                //Pegando id do item selecionado
                item = comboBox1.SelectedItem.ToString();
                item = item.Substring(0, item.IndexOf(" -"));
                id = Int16.Parse(item);

                //Excluindo do banco
                bd.delete(id);
                MessageBox.Show("Pessoa excluída com sucesso!", "Aviso!");
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
