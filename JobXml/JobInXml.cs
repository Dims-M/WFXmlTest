using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                     //   infa += $"Версия файла: {childnode.InnerText},"+ Environment.NewLine;
                        infa += $"{childnode.InnerText},"+ Environment.NewLine;
                        //Console.WriteLine($"Компания: {childnode.InnerText}");
                    }


                    if (childnode.Name == "Name")
                    {
                       // infa += $"Имя: {childnode.InnerText},"+ Environment.NewLine;
                        infa += $"{childnode.InnerText},"+ Environment.NewLine;
                        //Console.WriteLine($"Возраст: {childnode.InnerText}");
                    }

                    if (childnode.Name == "DateTime")
                    {
                        //infa += $"Дата созднаия(изменения) файла:{childnode.InnerText},"+Environment.NewLine;
                        infa += $"{childnode.InnerText},"+Environment.NewLine;
                        //  Console.WriteLine($"Возраст: {childnode.InnerText}");
                    }
                }

            }
            return infa;
        }

        public void CreateXmlDoc()
        {
            var xmlWriter = new XmlTextWriter("books.xml", null);

            xmlWriter.WriteStartDocument(true);                  // <?xml version="1.0" encoding="utf-8" ?>>
            xmlWriter.WriteStartElement("ListOfBooks");      // <ListOfBooks>
            xmlWriter.WriteStartElement("Book");             //      <Book>
            xmlWriter.WriteString("Title-1");                //                Title-1
            xmlWriter.WriteEndElement();                     //       </Book>
            xmlWriter.WriteStartElement("Book");             //       <Book>
            xmlWriter.WriteString("Title-2");                //                 Title-2
            xmlWriter.WriteEndElement();                     //       </Book>   
            xmlWriter.WriteEndElement();                     // </ListOfBooks>

            xmlWriter.Close();
        }
       
        public void XmlDoc(string item)
        {

            // загружаем файл
            var doc = new XmlDocument();
            doc.Load("test.xml");

            // меняем атрибут
            XmlNodeList adds = doc.GetElementsByTagName("Name");
            foreach (XmlNode add in adds) { 
                if (add.Attributes["key"].Value == "fileVersion")
                {
                    add.Attributes["value"].Value = item.ToString(); // новое значение
                    break;
                }
            if (add.Attributes["key"].Value == "Name")
            {
                add.Attributes["value"].Value = item.ToString(); // новое значение
                break;
            }
            
            }
            // сохраняем файл
            doc.Save("testМ.xml");
        }


        //запись в файл
        /// <summary>
        /// запись в текстовой файл. Журнал событий
        /// </summary>
        /// <param name="myText"></param>
        public void WrateText(string myText)
        {
          
            FileInfo dirInfo = new FileInfo(@"\LogJob.txt");
            
            try
            {
                //if (!dirInfo.Exists)
                //{
                //    dirInfo.Create();// создание файла
                //}

            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при записи лога \t\n " + ex);
            }

            using (StreamWriter sw = new StreamWriter("LogJob.txt", true, System.Text.Encoding.Default))

            // using (StreamWriter sw = new StreamWriter(myPachDir + @"texLog.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись
            }
        }

    }
}
