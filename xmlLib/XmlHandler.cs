using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ModeloDados;
using System.Xml.Schema;
using System.Xml.Linq;
using System.IO;

namespace XmlLib
{
    public class XmlHandler
    {
        public static void createXML(List<Titulo> listaExcel)
        {


            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);

            XmlElement root = doc.CreateElement("sns");
            //doc.AppendChild(root);
            XmlElement titulo = doc.CreateElement("nada");
            XmlElement subTitulo = doc.CreateElement("nada");
            for (int z = 0; z < listaExcel.Count; z++)
            {
                if (!listaExcel[z].getTitulo().Equals(""))
                {
                    titulo = doc.CreateElement(listaExcel[z].getTitulo().Replace(" ", string.Empty));
                }

                foreach (SubTitulo subcapitulo in listaExcel[z].SubTitulos)
                {
                    string tituloD = subcapitulo.Titulo.Replace(" ", string.Empty);
                    subTitulo = doc.CreateElement(tituloD);
                    XmlElement anos = doc.CreateElement("Anos");
                    for (int i = 0; i < subcapitulo.Anos.Length; i++)
                    {
                        XmlElement ano = doc.CreateElement("Ano");
                        ano.SetAttribute("ano", subcapitulo.Anos[i].ToString());
                        ano.InnerText = subcapitulo.Valores[i].ToString();
                        anos.AppendChild(ano);
                    }
                    subTitulo.AppendChild(anos);

                    if (titulo.Name.Equals("nada"))
                    {
                        root.AppendChild(subTitulo);
                    }
                    else
                    {
                        titulo.AppendChild(subTitulo);
                    }









                }
                if (titulo.Name.Equals("nada"))
                {
                    root.AppendChild(subTitulo);
                }
                else
                {
                    root.AppendChild(titulo);
                }


                doc.AppendChild(root);

            }


            string xmlOutput = doc.OuterXml;

            // OR save the XML in the disc
            doc.Save(@"ac.xml");
        }



        public static Boolean validate(string XmlPath, string SchemaPath)
        {
            //StringBuilder sb = new StringBuilder();
            //int counter = 0;
            //string line;

            //System.IO.StreamReader file = new System.IO.StreamReader(XmlPath);
            //while ((line = file.ReadLine()) != null)
            //{
            //    sb.Append(line);
            //    counter++;
            //}

            //file.Close();


            //StringBuilder sb2 = new StringBuilder();
            //int counter2 = 0;
            //string line2;

            //System.IO.StreamReader file2 = new System.IO.StreamReader(SchemaPath);
            //while ((line2 = file2.ReadLine()) != null)
            //{
            //    sb2.Append(line2);
            //    counter2++;
            //}

            //file2.Close();



            //XmlSchemaSet schemas = new XmlSchemaSet();
            //schemas.Add(sb.ToString(), sb2.ToString());

            //Console.WriteLine("Attempting to validate");


            //XDocument custOrdDoc = XDocument.Parse(sb.ToString());


            //try
            //{
            //    custOrdDoc.Validate(schemas, null);
            //    return true;

            //}
            //catch (XmlSchemaValidationException e)
            //{

            //    return false;

            //}



            var xdoc = XDocument.Load(XmlPath);
            var schemas = new XmlSchemaSet();
            try 
            {
            using(FileStream stream = File.OpenRead(SchemaPath)) 
            {
                schemas.Add(XmlSchema.Read(stream, (s, e) => 
                {
                    var x = e.Message;
                }));
            }

            StringBuilder sb = new StringBuilder();

                xdoc.Validate(schemas, null);
                //{
                //    Console.WriteLine(string.Format(" Line: {0}, Message: {1} ", 
                //                                e.Exception.LineNumber, e.Exception.Message));
                //});
                return true;
            } 
            catch (XmlSchemaValidationException w) 
            {
                return false;
            }
        }
        }

    }

