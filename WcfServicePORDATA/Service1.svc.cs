using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Hosting;
using System.Xml;

namespace WcfServicePORDATA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        XmlDocument Dados;

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }


        // custo médio de um funcionário;
        public string GetCustoMedioFuncionario(String dataInicio, String dataFim)
        {

     //       XmlNodeList DespesasSNS = Dados.SelectNodes("//DespesadoSNS");
            return null;
        }


        public void GetDados(string dados)
        {
            Dados.Load(dados);

        }











    }
}
