using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFXmlTest.Properties;
using Ionic.Zip;
using System.Net;

namespace WFXmlTest.Update
{
        /// <summary>
        /// Класс отвечает за обновление программы и скачивания новой версии
        /// </summary>
    class UpdateApp
    {
            /// <summary>
            /// Получаем текущую версию приложения
            /// </summary>
            /// <returns></returns>
            public string getVersionApp()
            {
                return Application.ProductVersion.ToString();
            }

            /// <summary>
            /// Получаем текущую версию Сборки приложения
            /// </summary>
            /// <returns></returns>
            public string GetAssemblyVersionApp()
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }

            /// <summary>
            /// запись в текстовой файл. Журнал событий
            /// </summary>
            /// <param name="myText"></param>
        public void WrateText(string myText)
            {

                using (StreamWriter sw = new StreamWriter(@"LogUpdate.txt", true, System.Text.Encoding.Default))

                // using (StreamWriter sw = new StreamWriter(myPachDir + @"texLog.txt", true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись
                }
            }


            /// <summary>
            /// Удаление собственного экзешника и запуск новой версии
            /// </summary>
            public void StartBatDelete()
            {
                string absolitPath = Application.StartupPath;
                string extractPath = absolitPath + @"\new\WFXmlTest.exe";
                string finalPath = absolitPath + "\\" + @"WFXmlTest.exe";
                string path = Application.ExecutablePath;
                string commandCopy = $"/C copy {extractPath} {absolitPath}";
                string comandStart = $"/C start {path} /H";

                try
                {
                    Process.Start("cmd.exe", "/C del \"" + path + "\"");  //Удаление рабочего, текущего exe

                    Thread.Sleep(100);
                    Process.Start("cmd.exe", commandCopy);  //Копирование файла из папки new
                    Process.Start("cmd.exe", comandStart);  //Запуск обнолвенной версии

                }
                catch (Exception ex)
                {
                    WrateText($"Ошибка при попытки удаления старого файла{ex}");
                    MessageBox.Show($"Ошибка при попытки удаления старого файла{ex}");
                }


                Process.GetCurrentProcess().Kill(); // закрытие текущего приложения
            }


        
        /// <summary>
        /// Получение файла обновления 000webhostapp.com
        /// </summary>
        public bool GetFailUpdateApp()
        {
            string pathFile = Application.StartupPath + @"\new\UpdateApp.zip"; // загрузка обновления
            string serFtp = @"https://testkkm.000webhostapp.com/testUpdate/UpdateApp.zip";
            string absolitPath = Application.StartupPath;
            bool resul = false;

            using (var web = new WebClient())
            {
                try
                {   File.Delete(pathFile+ @"UpdateApp.zip");
                    // скачиваем откуда и куда
                    web.DownloadFile(serFtp, pathFile);
                    resul = true;

                }
                catch (Exception ex)
                {
                    WrateText("Ошибка при скачивании обновлений \t\n" + ex);
                    resul = false;
                }
            }

            return resul;
        }

        /// <summary>
        /// Распаковка zip архива скаченной версии обновленной версии
        /// </summary>
        public bool StartUptadeApp()
        {
            string absolitPath = Application.StartupPath;
            string zipPath = absolitPath + @"\new\UpdateApp.zip";
            string extractPath = absolitPath + @"\new\";
           // string tempPachh = absolitPath + @"\UtilKKM-Servis\OldApp\jj.zip";

            try
            {
                using (ZipFile zip = ZipFile.Read(zipPath))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently); // перезаписывать существующие
                    }
                }

                File.Move(zipPath, zipPath);

            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }
            return true;
        }

    }

}
