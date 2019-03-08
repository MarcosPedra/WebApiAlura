using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LojaApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            String conteudo;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:59803/api/carrinho/1");
            request.Method = "POST";
            request.Accept = "application/xml";

            string json = "{'Produtos':[{'Id':6237,'Preco':2000.0,'Nome':'PSP','Quantidade':5}],'Endereco':'Rua Vergueiro 3185, 8 andar, Sao Paulo','Id':2}";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers["Location"]);
            Console.Read();
        }

        static void TestaPostXML()
        {
            String conteudo;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:59803/api/carrinho/1");
            request.Method = "POST";
            request.Accept = "application/xml";

            string json = "{'Produtos':[{'Id':6237,'Preco':2000.0,'Nome':'PSP','Quantidade':5}],'Endereco':'Rua Vergueiro 3185, 8 andar, Sao Paulo','Id':2}";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaGetXML()
        {
            String conteudo;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:59803/api/carrinho/1");
            request.Method = "GET";
            request.Accept = "application/xml";
            //request.Accept = "application/json"; por padrão o webapi irá retornar json, posso retornar xml ou forçar json

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }
    }
}
