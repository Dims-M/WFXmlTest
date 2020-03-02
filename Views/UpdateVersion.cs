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
            UpdateApp updateApp = new UpdateApp();
            updateApp.StartBatDelete();
        }

        //Загрузка формы при запуске
        private void UpdateVersion_Load(object sender, EventArgs e)
        {
            UpdateApp updateApp = new UpdateApp();
            lbInfaVersion.Text = updateApp.getVersionApp();
            lbAssemblyApp.Text = updateApp.GetAssemblyVersionApp();


        }
    }
}
