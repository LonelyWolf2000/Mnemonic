using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mnemonic
{
    public partial class ResDialog : Form
    {
        private string _description ="";
        private string _path = "";
        private const string _DESCRIPTION_CAP = @"Введите краткое описание файла";
        private const string _PATH_CAP = @"Укажите путь к файлу";

        public string Description
        {
            get { return _description; }
        }
        public string Path
        {
            get { return _path; }
        }

        public ResDialog()
        {
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (((Button)sender).DialogResult != DialogResult.OK)
                MessageBox.Show(@"Поля нужно заполнить");
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OpenRes_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _path = dialog.FileName;
                tb_Path.Text = Path;
                tb_Path.ForeColor = Color.Black;

                if(_description != null)
                    btn_OK.DialogResult = DialogResult.OK;
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(textBox.ForeColor == Color.Black) return;

            textBox.BackColor = Color.WhiteSmoke;
            textBox.ForeColor = Color.Black;
            textBox.Text = "";
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Name == "tb_Description")
            {
                if (textBox.Text.Length < 1)
                {
                    _description = "";
                    _SetCapTextBox(textBox, _DESCRIPTION_CAP);
                }
                else
                    _description = textBox.Text;
            }
            else
            {
                if (textBox.Text.Length < 1)
                {
                    _path = "";
                    _SetCapTextBox(textBox, _PATH_CAP);
                }
                else
                    _path = textBox.Text;
            }

            btn_OK.DialogResult = (_path != "" && _description != "") ? DialogResult.OK : DialogResult.None;
        }

        private void _SetCapTextBox(TextBox target, string cap)
        {
            target.Text = cap;
            target.ForeColor = Color.LightGray;
            target.BackColor = Color.LightCoral;
        }
    }
}