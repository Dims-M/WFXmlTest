using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WFXmlTest.JobXml
{
    /// <summary>
    /// Работа с  файлом XML
    /// </summary>
   public  class JobInXml
    {
        private string infa;

        public string ReadingXml()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("test.xml");

            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }
                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    //ищем нужные данные
                    if (childnode.Name == "FileVersion ")
                    {
                        infa += $"Версия файла: {childnode.InnerText}"+ Environment.NewLine;
                        //Console.WriteLine($"Компания: {childnode.InnerText}");
                    }


                    if (childnode.Name == "Name")
                    {
                        infa += $"Имя: {childnode.InnerText}"+ Environment.NewLine;
                        //Console.WriteLine($"Возраст: {childnode.InnerText}");
                    }

                    if (childnode.Name == "DateTime")
                    {
                        infa += $"Дата созднаия(изменения) файла:{childnode.InnerText}"+Environment.NewLine;
                        //  Console.WriteLine($"Возраст: {childnode.InnerText}");
                    }
                }

            }
            return infa;
        }

       
    }
}
