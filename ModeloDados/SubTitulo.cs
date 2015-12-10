using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDados
{
    public class SubTitulo
    {
        private string titulo;
        private int[] anos;
        private string[] valores;

        public int[] Anos
        {
            get { return anos; }
            set { anos = value; }
        }
        

        public string[] Valores
        {
            get { return valores; }
            set { valores = value; }
        }


        public SubTitulo(string titulo)
        {
            this.titulo = titulo;
        }


        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public override string ToString()
        {
            StringBuilder dados = new StringBuilder();
            for (int i = 0; i < anos.Length; i++)
            {
                dados.AppendLine(anos[i] + ":" + valores[i]);
            }
            return titulo + "/n" +dados ;
        }
    }
}
