using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ExemploSQLite
{
    class Banco
    {
        private SQLiteConnection conn;
        private SQLiteCommand command;
        private SQLiteTransaction trans;

        //Construtor
        public Banco() {
            try
            {
                if(!System.IO.File.Exists("banco.db")){
                    System.Data.SQLite.SQLiteConnection.CreateFile("banco.db");
                }

                this.conn = new SQLiteConnection("Data Source=banco.db;Version=3;");
                this.conn.Open();

                this.command = conn.CreateCommand();
                string sql = @"CREATE TABLE IF NOT EXISTS Pessoas (id integer PRIMARY KEY NOT NULL, nome varchar(70), idade integer);";
                this.command.CommandText = sql;
                this.command.ExecuteNonQuery();                
                
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro!");
            }
        }

        //Função para inserir no banco
        public void insert(Pessoa p)
        {
            try
            {
                this.trans = conn.BeginTransaction();
                this.command = conn.CreateCommand();

                string sql = "INSERT INTO Pessoas (nome,idade) VALUES (?,?)";
                this.command.Parameters.Add(new SQLiteParameter("@nome",p.Nome));
                this.command.Parameters.Add(new SQLiteParameter("@idade",p.Idade));
                this.command.CommandText = sql;
                this.command.ExecuteNonQuery();
                
                this.trans.Commit();

            } catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Erro!");
            }
        }

        //Função para excluir do banco
        public void delete(int id)
        {
            try
            {
                this.command = conn.CreateCommand();

                string sql = "DELETE FROM Pessoas WHERE id = " +id;
                this.command.CommandText = sql;
                this.command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!");
            }
        }

        public void altera(Pessoa p)
        {
            try
            {
                this.command = conn.CreateCommand();

                string sql = "UPDATE Pessoas SET nome = ?, idade = ? WHERE id = " +p.Id;
                this.command.Parameters.Add(new SQLiteParameter("@nome", p.Nome));
                this.command.Parameters.Add(new SQLiteParameter("@idade", p.Idade));
                this.command.CommandText = sql;
                this.command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!");
            }
        }

        //Função que retorna uma pessoa cadastrada com o id fornecido
        public Pessoa retornaPessoa(int id)
        {
            try
            {
                Pessoa p = new Pessoa();
                SQLiteDataReader rs;
                this.command = conn.CreateCommand();

                string sql = "SELECT * FROM Pessoas WHERE id = " +id;
                this.command.CommandText = sql;
                rs = this.command.ExecuteReader();

                //Pegando valores
                rs.Read();
                p.Id = rs.GetInt16(0);
                p.Nome = rs.GetString(1);
                p.Idade = rs.GetInt16(2);

                //Retornando resultado
                rs.Close();
                return p;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!");
                return null;  
            }
        }

        //Função que retorna todas as pessoas cadastradas no banco em um ArrayList
        public ArrayList retornaPessoa()
        {
            try
            {
                Pessoa p = new Pessoa();
                Pessoa aux = null;
                ArrayList pessoas = new ArrayList();
                SQLiteDataReader rs;
                this.command = conn.CreateCommand();

                string sql = "SELECT * FROM Pessoas";
                this.command.CommandText = sql;
                rs = this.command.ExecuteReader();

                //Adicionando resultados no arraylist
                while (rs.Read())
                {
                    p.Id = rs.GetInt16(0);
                    p.Nome = rs.GetString(1);
                    p.Idade = rs.GetInt16(2);
                    aux = new Pessoa(p.Id, p.Nome, p.Idade);
                    pessoas.Add(aux);
                }

                //Retornando resultado
                rs.Close();
                return pessoas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!");
                return null;                
            }
        }

        //Função que retorna todas as pessoas cadastradas com um determinado
        public ArrayList retornaPessoa(string nome)
        {
            try
            {
                Pessoa p = new Pessoa();
                Pessoa aux = null;
                ArrayList pessoas = new ArrayList();
                SQLiteDataReader rs;
                this.command = conn.CreateCommand();

                string sql = "SELECT * FROM Pessoas WHERE nome = \'" +nome +"\'";
                this.command.CommandText = sql;
                rs = this.command.ExecuteReader();

                //Adicionando resultados no arraylist
                while (rs.Read())
                {
                    p.Id = rs.GetInt16(0);
                    p.Nome = rs.GetString(1);
                    p.Idade = rs.GetInt16(2);
                    aux = new Pessoa(p.Id, p.Nome, p.Idade);
                    pessoas.Add(aux);
                }

                //Retornando resultado
                rs.Close();
                return pessoas;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!");
                return null;
            }
        }

        public void select()
        {
            try
            {
                SQLiteDataReader rs;
                this.command = conn.CreateCommand();

                String sql = "SELECT * FROM Pessoas";
                this.command.CommandText = sql;
                rs = this.command.ExecuteReader();

                while(rs.Read())
                {
                    MessageBox.Show("Id: " + rs.GetValue(0) + "\nNome: " +rs.GetValue(1) + "\nIdade: " +rs.GetValue(2), "Aviso!");
                }
                rs.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!");
            }
        }

        public void initBD()
        {
            try
            {
                string sql = @"DROP TABLE IF EXISTS Pessoas";
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!");
            }
        }

        public void close()
        {
            try 
            {
                this.conn.Clone();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!");
            }
        }   

    }
}
