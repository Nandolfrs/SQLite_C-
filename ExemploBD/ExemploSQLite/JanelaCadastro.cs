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
    public partial class JanelaCadastro : Form
    {
        public JanelaCadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Banco bd = new Banco();
            Pessoa p = new Pessoa();
            string saida = "";
            string nome = textBox1.Text.Trim();
            int idade = 0;

            //Nome
            if(nome.Length < 1) 
            {
                saida += "Nome não pode ser nulo!\n";
            }

            //Idade
            try
            {
                idade = Int16.Parse(textBox2.Text.Trim());
                if(idade < 0)
                    saida += "Idade não pode ser menor que zero!\n";
            }
            catch(Exception ex)
            {
                saida += "Idade deve ser preenchido com números!\n";
            }
       
            //Inserindo no banco
            if (saida.Equals(""))
            {
                p.Nome = nome;
                p.Idade = idade;
                bd.insert(p);

                MessageBox.Show("Pessoa cadastrada com sucesso!", "Aviso!");
                bd.close();
                this.Close();
            }
            else
            {
                MessageBox.Show(saida,"Erro!");
            }

        }
    }
}
