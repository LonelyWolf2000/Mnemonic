using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mnemonic.View;

namespace Mnemonic
{
    public partial class MainForm : Form
    {
        private string fileName;

        public MainForm()
        {
            InitializeComponent();
            MyInit();
        }

        private void MyInit()
        {
            MainPanel.Controls.Add(TestingModeControl.Instance);
        }

        private void EditingMenuItem_Click(object sender, EventArgs e)
        {
            if (!MainPanel.Controls.Contains(EditModeControl.Instance))
                MainPanel.Controls.Add(EditModeControl.Instance);
            
            EditModeControl.Instance.BringToFront();
        }

        private void TestingMenuItem_Click(object sender, EventArgs e)
        {
            if (!MainPanel.Controls.Contains(TestingModeControl.Instance))
                MainPanel.Controls.Add(TestingModeControl.Instance);

            TestingModeControl.Instance.BringToFront();
        }

        private void CreateNew(object sender, EventArgs e)
        {
            _CreateNewEndSave();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog {Filter = @"XML-file (*.xml)|*.xml|All files (*.*)|(*.*)"};
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                ViewEditMode.Instance.OpenDataBase(fileName);
                if (!((ViewEditMode)ViewEditMode.Instance).IsDataBaseLoaded)
                    MessageBox.Show(@"Не удалось открыть файл.");
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                ViewEditMode.Instance.SaveFileDB(fileName);
                return;
            }
            _CreateNewEndSave();
        }

        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            _CreateNewEndSave();
        }
        private void _CreateNewEndSave()
        {
            var dialog = new SaveFileDialog { Filter = @"XML-file (*.xml)|*.xml" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                ViewEditMode.Instance.CreateNewBD(fileName);
            }
        }
    }
}
