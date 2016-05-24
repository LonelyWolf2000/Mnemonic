using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mnemonic
{
    public partial class NameDialog : Form
    {
        private string _value;
        public NameDialog()
        {
            InitializeComponent();
        }

        public string Value
        {
            get { return _value; }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (TextBox.Text.Length < 1)
                MessageBox.Show(@"Поле не может быть пустым");

            _value = TextBox.Text;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
