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

namespace WFXmlTest.Update
{
        /// <summary>
        /// Класс отвечает за обновление программы
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


        //Тестовые методы 
        /// <summary>
        /// Получение файла обновления ссайта 000webhostapp.com
        /// </summary>
        public bool GetFailSite()
        {

            string errorLog = $"{DateTime.Now.ToString()}\t\n";
            // string pathFile =  Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ $@"\UtilKKM-Servis\ОбновлениеВремени{errorLog}.zip"; // загрузка обновления
            //string pathFile = Application.ExecutablePath + $@"\UtilKKM-Servis\ОбновлениеВремени{errorLog}.zip"; // загрузка обновления
            // string pathFile = Application.StartupPath + @"\UtilKKM-Servis\ОбновлениеВремени.zip"; // загрузка обновления
            string pathFile = Application.StartupPath + @"\UtilKKM-Servis\ОбновлениеВремени.zip"; // загрузка обновления
            string serFtp = @"https://testkkm.000webhostapp.com/GetUpTime/TimeUpdatesWF.zip";
            string absolitPath = Application.StartupPath;
            bool resul = false;

            if (!Directory.Exists(absolitPath + @"\UtilKKM-Servis\")) ;
            {
                Directory.CreateDirectory(absolitPath + @"\UtilKKM-Servis\");
                Directory.CreateDirectory(absolitPath + @"\UtilKKM-Servis\OldApp\");

            }



            // File.Delete(pathFile);


            //if (System.IO.File.Exists(pathFile))
            //{
            //    errorLog += $"Данный файл уже существует \t\n{serFtp}\t\n";
            //    WrateText(errorLog);
            //    File.Delete(pathFile);
            //    errorLog += $"Старый файл был удален \t\n{serFtp}\t\n";
            //}

            //else 

            File.Delete(pathFile);
            using (var web = new WebClient())
            {
                try
                {
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
        /// Разорхивация файлов с указание что и куда орхивировать
        /// </summary>
        /// <param name="MyzipFail">Путь для файла.Откуда и какой архив</param>
        /// <param name="MyExtractPath">Куда распаковыватьы</param>
        public void ZipArhivMyPath(string MyzipFail, string MyExtractPath)
        {
            try
            {
                using (ZipFile zip = ZipFile.Read(MyzipFail))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(MyExtractPath, ExtractExistingFileAction.OverwriteSilently); // перезаписывать существующие
                    }
                }
                // ZipFile.ExtractToDirectory(MyzipFail, MyExtractPath);
            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }

            // File.Delete(MyzipFail);
        }


        /// <summary>
        /// Распаковка скаченой версии обновленной версии
        /// </summary>
        public bool StartUptadeApp()
        {
            string absolitPath = Application.StartupPath;
            string zipPath = absolitPath + @"\UtilKKM-Servis\ОбновлениеВремени.zip";
            string extractPath = absolitPath + @"\UtilKKM-Servis\ОбновлениеВремени\";
            string tempPachh = absolitPath + @"\UtilKKM-Servis\OldApp\jj.zip";

            try
            {
                using (ZipFile zip = ZipFile.Read(zipPath))
                {
                    foreach (ZipEntry e in zip)
                    {
                        e.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently); // перезаписывать существующие
                    }
                }

                File.Move(zipPath, tempPachh);
                // string tempPachh = extractPath + @"\OldApp\";// + $"Старая версияAPP{DateTime.Now}.zip";
                // FileInfo fileInf = new FileInfo(zipPath);
                // fileInf.MoveTo(tempPachh); // перенос старого файла

                //установка новой версии
                StartNewApliccation(extractPath + @"TimeUpdatesWF.msi");
            }

            catch (Exception ex)
            {
                WrateText("Ошибка при разорхивации архива EoU\n" + ex);
            }



            return true;
        }

    }

}
