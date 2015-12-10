using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using ModeloDados;

namespace ExcelLib
{
    public class ExcelHandler
    {


        public static void createNewExcelFile(string path)
        {
            var excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            var excelWorkBook = excelApplication.Workbooks.Add();
            excelWorkBook.SaveAs(path, AccessMode: Excel.XlSaveAsAccessMode.xlNoChange);
            excelWorkBook.Close();
            excelApplication.Quit();
        }

        


        public static List<Titulo> readFromExcelFile(string path)
        {
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            Excel.Workbook excelWorkBook = excelApplication.Workbooks.Open(path);
            Excel.Worksheet excelWorkSheet = excelWorkBook.Worksheets.get_Item(1);

            List<Titulo> listaTitulos = new List<Titulo>();


            int numeroLinhasEmBranco = 1;     //inicia a variavel que conta o numero de linhas em branco até à tabela
            int numeroLinhasDoCabecalho = 1;  //inicia a variavel que conta o numero de linhas do cabecalho.
            int numeroSubTopicos = 1;         //inicia a variavel que conta o numero de titulos ou de subtopicos
            int numeroDeAnosNaTabela = 1;

            while ((excelWorkSheet.Cells[numeroLinhasEmBranco + 1, 1].Value + "").Equals("")) // conta o numero de linhas em branco ate a tabela de dados
            {
                string asss = excelWorkSheet.Cells[numeroLinhasEmBranco + numeroLinhasDoCabecalho + 1, 1].Value + "";
                numeroLinhasEmBranco++;
            }



            while ((excelWorkSheet.Cells[numeroLinhasEmBranco + numeroLinhasDoCabecalho + 1, 1].Value + "").Equals(""))
            {
                string asss = excelWorkSheet.Cells[numeroLinhasEmBranco + numeroLinhasDoCabecalho + 1, 1].Value + "";
                numeroLinhasDoCabecalho++;
            }

            while (!(excelWorkSheet.Cells[numeroLinhasEmBranco + numeroLinhasDoCabecalho + 1, numeroSubTopicos + 2].Value + "").Equals(""))
            {
                string asss=excelWorkSheet.Cells[numeroLinhasEmBranco + numeroLinhasDoCabecalho + 1, numeroSubTopicos + 2].Value + "";
                numeroSubTopicos++;
            }

            while (!(excelWorkSheet.Cells[numeroLinhasEmBranco + numeroLinhasDoCabecalho + numeroDeAnosNaTabela+1, 1].Value + "").Equals(""))
            {
                numeroDeAnosNaTabela++;
            }



            if (numeroLinhasDoCabecalho == 1)
            {
                    Titulo titulo;
                    titulo = new Titulo("");
                    for (int i = 0; i < numeroSubTopicos; i++)
                    {
                        SubTitulo subtitulo = new SubTitulo(excelWorkSheet.Cells[numeroLinhasEmBranco + 1, 2 + i].Value + "");
                        string[] valores = new string[numeroDeAnosNaTabela];
                        int[] anos = new int[numeroDeAnosNaTabela];

                        for (int z = 0; z < numeroDeAnosNaTabela; z++)
                        {
                            valores[z] = excelWorkSheet.Cells[numeroLinhasEmBranco + numeroLinhasDoCabecalho + z + 1, 2].Value + "";
                            string aaa = excelWorkSheet.Cells[numeroLinhasEmBranco + numeroLinhasDoCabecalho + z + 1, 1].Value + "";
                            anos[z] = Int16.Parse(aaa);
                        }
                        subtitulo.Valores = valores;
                        subtitulo.Anos=anos;
                        titulo.addSubtitulo(subtitulo);
                    }
                    listaTitulos.Add(titulo);
                

            }
            else
                if (numeroLinhasDoCabecalho == 2)
                {
                    
                    Titulo titulo;
                    titulo = new Titulo(excelWorkSheet.Cells[numeroLinhasEmBranco + 1, 2].Value + "");
                    for (int i = 0; i <numeroSubTopicos; i++)
                    {
                        SubTitulo subtitulo = new SubTitulo(excelWorkSheet.Cells[numeroLinhasEmBranco + 2, 2 + i].Value + "");
                        string[] valores = new string[numeroDeAnosNaTabela];
                        int[] anos = new int[numeroDeAnosNaTabela];

                        for (int z = 0; z < numeroDeAnosNaTabela; z++)
                        {
                            valores[z] = excelWorkSheet.Cells[numeroLinhasEmBranco + numeroLinhasDoCabecalho + z+1, 2].Value + "";
                            string aaa = excelWorkSheet.Cells[numeroLinhasEmBranco + numeroLinhasDoCabecalho + z+1, 1].Value + "";
                            anos[z] = Int16.Parse(aaa);
                        }
                        subtitulo.Valores = valores;
                        subtitulo.Anos = anos ;
                        titulo.addSubtitulo(subtitulo);


                        if (!(excelWorkSheet.Cells[numeroLinhasEmBranco + 1, 2 + i + 1].Value + "").Equals(""))
                        {
                            listaTitulos.Add(titulo);
                            titulo = new Titulo(excelWorkSheet.Cells[numeroLinhasEmBranco + 1, 2 + i+1].Value + "");
                        }

                    }
                    listaTitulos.Add(titulo);
                }



            excelWorkBook.Close();
            excelApplication.Quit();
            return listaTitulos;
        }
    }
}
