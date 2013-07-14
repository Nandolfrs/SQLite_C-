using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExemploSQLite
{
    class Pessoa
    {
        string nome;        
        int idade;
        int id;

        //Construtor vazio
        public Pessoa()
        {

        }

        //Construtor 2
        public Pessoa(string nome, int idade)
        {
            this.nome = nome;
            this.idade = idade;
        }

        //Construtor 3
        public Pessoa(int id, string nome, int idade)
        {
            this.id = id;
            this.nome = nome;
            this.idade = idade;
        }

        //GETS AND SETTERS

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
