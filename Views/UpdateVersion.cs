using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFXmlTest.Update;

namespace WFXmlTest.Views
{
    public partial class UpdateVersion : Form
    {
        UpdateApp updateApp;

        public UpdateVersion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Кнопка обновления программы
        private void button3_Click(object sender, EventArgs e)
        {
            updateApp = new UpdateApp();
            updateApp.StartBatDelete();
           
        }

        //Загрузка формы при запуске
        private void UpdateVersion_Load(object sender, EventArgs e)
        {
            UpdateApp updateApp = new UpdateApp();
            lbInfaVersion.Text = updateApp.getVersionApp();
            lbAssemblyApp.Text = updateApp.GetAssemblyVersionApp();


        }

        //Кнопка скачать обновление с инернета
        private void button2_Click(object sender, EventArgs e)
        {
            updateApp = new UpdateApp();
            bool temp = false;

            temp = updateApp.GetFailUpdateApp();
            updateApp.StartUptadeApp();

            if (temp == true )
            {
                MessageBox.Show("Обновление скачено. И Готово к установке! \n Нажмите кнопку \"Обновить программу из локального хранилища!\" ");
            }

            else
            {
                MessageBox.Show("Проблеммы при скачивании и установки обновления.\n Проверте интернет, Антивирус и смотриле лог ");

            }
        }
    }
}
