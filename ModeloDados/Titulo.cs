using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDados
{
    public class Titulo
    {
        private string titulo;
        private List<SubTitulo> subTitulos;

public List<SubTitulo> SubTitulos
{
  get { return subTitulos; }
  set { subTitulos = value; }
}

   public string getTitulo(){
       return titulo;
   }


    public Titulo(string titulo)
    {
        this.titulo = titulo;
        this.subTitulos = new List<SubTitulo>();
    }

    public void addSubtitulo(SubTitulo subTitulo)
    {
        subTitulos.Add(subTitulo);
    }

    public override string ToString()
    {
        StringBuilder dados= new StringBuilder();
        foreach (SubTitulo item in SubTitulos)
        {
            dados.AppendLine(item.ToString());
        }
        return titulo + "/n" + dados;
    }

    }
    
}
