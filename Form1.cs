﻿using System;
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
            tbShow.Clear();

            jobXml = new JobInXml();
            tbShow.Text = jobXml.ReadingXml();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
