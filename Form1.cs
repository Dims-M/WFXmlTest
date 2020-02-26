using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFXmlTest.JobXml;

namespace WFXmlTest
{
    public partial class Form1 : Form
    {
        JobInXml jobXml; 

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        //загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //кнопка прочитать файл
        private void button2_Click(object sender, EventArgs e)
        {
            jobXml = new JobInXml();


            //  tbShow.Text = jobXml.ReadingXml();
            String str = jobXml.ReadingXml();
            String[] strlist = str.Split(',');

            textBox1.Text = strlist[0];
            textBox2.Text = strlist[1];
            textBox3.Text = strlist[2];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //кнопка редактирования и  сохранения файлов
        private void button3_Click(object sender, EventArgs e)
        {
            jobXml = new JobInXml();

            // jobXml.CreateXmlDoc(); // создание нового xml файла

            jobXml.XmlDoc(textBox1.Text);
            jobXml.XmlDoc(textBox2.Text);
            jobXml.XmlDoc(textBox3.Text);


        }
    }
}
