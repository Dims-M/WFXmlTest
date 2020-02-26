using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFXmlTest.Views
{
    public partial class jobToXml : Form
    {
        public jobToXml()
        {
            InitializeComponent();
        }

        //кнопка добавить. Из текстбоксов перенос в таблицу
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Заполните все поля!!!!");
            }

            else
            {
                int n = dataGridView1.Rows.Add(); // создаем новую строку
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text; // столбец Name
                dataGridView1.Rows[n].Cells[1].Value = numericUpDown1.Value; // Age
                dataGridView1.Rows[n].Cells[2].Value = textBox2.Text; // Programmer
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
