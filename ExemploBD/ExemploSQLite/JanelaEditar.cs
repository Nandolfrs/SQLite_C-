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
    public partial class JanelaEditar : Form
    {
        public JanelaEditar()
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

            //ID
            p.Id = Int16.Parse(label3.Text.Substring(4));

            //Nome
            if (nome.Length < 1)
            {
                saida += "Nome não pode ser nulo!\n";
            }

            //Idade
            try
            {
                idade = Int16.Parse(textBox2.Text.Trim());
                if (idade < 0)
                    saida += "Idade não pode ser menor que zero!\n";
            }
            catch (Exception ex)
            {
                saida += "Idade deve ser preenchido com números!\n";
            }

            //Alterando no banco
            if (saida.Equals(""))
            {
                p.Nome = nome;
                p.Idade = idade;
                bd.altera(p);

                MessageBox.Show("Pessoa alterada com sucesso!", "Aviso!");
                bd.close();
                this.Close();
            }
            else
            {
                MessageBox.Show(saida, "Erro!");
            }
        }
    }
}
