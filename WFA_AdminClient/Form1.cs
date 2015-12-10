using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xmlLib = XmlLib;
using excel = ExcelLib;
using ModeloDados;

namespace WFA_AdminClient
{
    public partial class Form1 : Form
    {
        string[] pathOfFiles;
        List<Titulo> listaGlobal;
        string pathSchema ="";
        string pathXML="";
        public Form1()
        {
            InitializeComponent();
            listaGlobal = new List<Titulo>();
            pathOfFiles = new string[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


            for (int i = 0; i < pathOfFiles.Length; i++)
            {
                List<Titulo> lista = excel.ExcelHandler.readFromExcelFile(pathOfFiles[i]);
                foreach (Titulo item in lista)
                {
                    listaGlobal.Add(item);
                }


            }
            xmlLib.XmlHandler.createXML(listaGlobal);
            MessageBox.Show("XML gerado com sucesso");
            }
            catch (Exception)
            {

                MessageBox.Show("Erro ao gerar xml");
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
            actualiza();
            openFileDialog1.Filter = "excel documents (.xlsx)|*.xlsx"; 
            openFileDialog1.ShowDialog();
            pathOfFiles = openFileDialog1.FileNames;
            actualiza();
            
            if (pathOfFiles.Length>0 && !pathOfFiles[0].Equals("openFileDialog1"))
            {
               button1.Enabled = true; 
            }
            
        }

        public void actualiza()

        {   StringBuilder texto = new StringBuilder();
            
            for (int i = 0; i < pathOfFiles.Length; i++)
            {
                texto.AppendLine(pathOfFiles[i]);
            }
            richTextBox1.Text = texto.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "xml documents (.xml)|*.xml";
            openFileDialog2.ShowDialog();            
            pathXML = openFileDialog2.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog3.Filter = "xsd documents (.xsd)|*.xsd"; 
            openFileDialog3.ShowDialog();
            pathSchema = openFileDialog3.FileName;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (pathXML.Equals("") || pathSchema.Equals("") || pathXML.Equals("openFileDialog2") || pathSchema.Equals("openFileDialog3"))
            {

                MessageBox.Show("Inválido");
            }
            else
            {
                if (xmlLib.XmlHandler.validate(pathXML, pathSchema))
                {
                    MessageBox.Show("Válido");
                }
                else
                {
                    MessageBox.Show("Inválido");
                }
            }
        }









        public void clear() 
        {
            pathOfFiles= new string[0];
            button1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
