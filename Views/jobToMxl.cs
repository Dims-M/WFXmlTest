using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFXmlTest.JobXml;

namespace WFXmlTest.Views
{
   
    public partial class jobToXml : Form
    { 
        
        JobInXml servis; 

        public jobToXml()
        {
            InitializeComponent();
        }

        //Действие при загрузке формы
        private void jobToXml_Load(object sender, EventArgs e)
        {
            button3.Enabled = false; //отключаем кнопку редактирования
        }


        //кнопка добавить. Из текстбоксов перенос в таблицу
        private void button2_Click(object sender, EventArgs e)
        {
            servis = new JobInXml();

            if (textBox1.Text == "" || numericUpDown1.Value <=1)
            {
                string tempLog = "[Заполните все поля, перед добавлением в таблицу вывода!!!!] \n";
                servis.WrateText(tempLog);
                MessageBox.Show(tempLog);
                ClearTextBox();
            }

            else
            {
                int n = dataGridView1.Rows.Add(); // создаем новую строку
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text; // столбец Name
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value; // Age
                dataGridView1.Rows[n].Cells[2].Value = textBox2.Text; // Programmer
                ClearTextBox();
                servis.WrateText("Данные добавлены в таблицу DataGridView");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Кнопка Сохранения файла в XML формат
        private void button5_Click(object sender, EventArgs e)
        {
            SaveXmlToFileDoc();
        }

        ///Кнопка загрузки файла Xml с диска
        private void button7_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
              
            // получаем выбранный файл
            string filename = openFileDialog1.SafeFileName;
          
            servis = new JobInXml();

            if (servis.RegFileXml(filename))
                {
                LoadToXml(filename);
            }

            else
            {
                MessageBox.Show("Файл xml не коректный..\nЗагрузите другой");
            }
          
        }

        //Кнопка редактирования и сохранения данных в dataGrid
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int n = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value;
                dataGridView1.Rows[n].Cells[2].Value = textBox2.Text;

                servis = new JobInXml();
                servis.WrateText("Строка с данными была [изменена]");

                dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Gray;

                label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
                label3.BorderStyle = System.Windows.Forms.BorderStyle.None;
                

            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования.", "Ошибка.");
            }
        }


        //Событие клика мышки по форме грида
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {

            int aa = dataGridView1.SelectedRows.Count;
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            numericUpDown1.Value = n;
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            button3.Enabled = true; // делаем кнопку редактирования активной


             label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
             label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
             label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            }
            catch (Exception ex)
            {
              //  MessageBox.Show($"Ошибка\n {ex}");
            }
            
        }



        //***Методы*****

        private void ClearTextBox()
        {
            textBox1.Text = "";
            numericUpDown1.Value = 0;
            textBox2.Text = "";
        }

        /// <summary>
        /// Метод создания и сохранения XML файла
        /// </summary>
        private void SaveXmlToFileDoc()
        {
            servis = new JobInXml();
            
            try
                {
                    DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                    ds.DataSetName = "root";
                    DataTable dt = new DataTable(); // создаем пока что пустую таблицу данных

                    dt.TableName = "File_FileVersion"; // название таблицы
                    dt.Columns.Add("Name"); // название колонок
                    dt.Columns.Add("DateTime");
                    dt.Columns.Add("Comment");
                    ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

                    foreach (DataGridViewRow r in dataGridView1.Rows) // пока в dataGridView1 есть строки
                    {
                        DataRow row = ds.Tables["File_FileVersion"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                        row["FileVersion"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                        row["Name"] = r.Cells[1].Value; // то же самое со вторыми столбцами
                        row["DateTime"] = r.Cells[2].Value; //то же самое с третьими столбцами
                        ds.Tables["File_FileVersion"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
                    }

                    ds.WriteXml("TestFile.xml"); // создание файла XML из  DataSet
                    servis.WrateText("[XML файл (TestFile.xml) успешно сохранен в папке с программой]");
                    MessageBox.Show("XML файл успешно сохранен.", "Выполнено.");
                }
                catch (Exception ex)
                {
                servis.WrateText("[Ошибка при создании(DataSet) и сохранении XML файл на жесткий диск] \n"+ ex);
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
                }
            
        }

        /// <summary>
        /// Загрузка файла в датагрид. Из формы
        /// </summary>
        private void LoadToXml( string pathFileXml)
        {
            servis = new JobInXml();

            try
            {

                //проверка на заполненность таблицы
                if (dataGridView1.Rows.Count > 0) //если в таблице больше нуля строк
                {
                    MessageBox.Show("Очистите поле перед загрузкой нового файла.", "Ошибка.");
                    servis.WrateText("Поля таблицы [Заполнены, требуется очистка]\n");
                }

                else
                {
                    if (File.Exists(pathFileXml)) // если существует данный файл
                    {
                        int a = 0;
                        DataSet ds = new DataSet(); // создаем новый пустой кэш данных
                        ds.ReadXml(pathFileXml); // записываем в него XML-данные из файла
                        
                        foreach (DataRow item in ds.Tables["File FileVersion"].Rows)
                        {
                            int n = dataGridView1.Rows.Add(); // добавляем новую сроку в dataGridView1

                            dataGridView1.Rows[n].Cells[0].Value = item["FileVersion"]; // заносим в первый столбец созданной строки данные из первого столбца таблицы ds.
                            dataGridView1.Rows[n].Cells[1].Value = item["Name"]; // то же самое со вторым столбцом
                            dataGridView1.Rows[n].Cells[2].Value = item["DateTime"]; // то же самое с третьим столбцом
                            a++;
                        }
                        servis.WrateText($"Были [загружены] данные из файла XML{a}.\n");
                    }
                    else
                    {
                        MessageBox.Show("XML файл не найден.", "Ошибка.");
                    }
                  //  datagridview1.Column[0].Visible = false;
                }
            }


            catch (Exception ex)
            {
                servis.WrateText("[Ошибки при загрузке файла] Xml\n" + ex);
            }
        }

        //Кнопка очистить table DG
        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                servis = new JobInXml();
                dataGridView1.Rows.Clear();
                servis.WrateText($"[Очистка] таблицы");
            }
            
        }

        //кнопка удалить
        private void button4_Click(object sender, EventArgs e)
        {
            servis = new JobInXml();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index); //удаление строки.
                servis.WrateText("Произошло [удаление] строки");
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка.");
                servis.WrateText("Ошибка при удалении строки");
            }
        }
    }
}
