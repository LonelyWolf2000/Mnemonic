using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mnemonic.Model;
using Mnemonic.View;

namespace Mnemonic
{
    public partial class EditModeControl : UserControl
    {
        private static EditModeControl _instance;
        private ViewEditMode _viewController;
        private bool _isChangedCurrentQuestion;

        public static EditModeControl Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new EditModeControl();
                return _instance;
            }
        }
        public EditModeControl()
        {
            InitializeComponent();
            _viewController = ViewEditMode.Instance as ViewEditMode;
            _viewController.onFileLoadedEvent += OnFileLoadedEvent_Handler;
            _viewController.changeFieldsEvent += OnChangeFieldsEvent_Handler;
            OnFileLoadedEvent_Handler();
            _isChangedCurrentQuestion = false;
        }

        private void OnFileLoadedEvent_Handler()
        {
            _ReInitComboBox(_viewController.SubjectsList, listSubjects);
            _ReInitComboBox(_viewController.ThemesList, listThemes);
            _ReInitComboBox(_viewController.QuestionsList, listQuestions);
        }

        private void OnChangeFieldsEvent_Handler()
        {
            _FillFormData();
        }

        private void _ReInitComboBox(string[] listValues, ComboBox target)
        {
            if (listValues == null) return;
            
            target.Items.Clear();
            target.Items.AddRange(listValues);

            target.SelectedIndex = 0;
        }

        private void AddQuestion_Click(object sender, EventArgs e)
        {
            var dialog = new NameDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _viewController.NewDataObject();
                _viewController.Question = dialog.Value;
                listQuestions.Text = dialog.Value;
                _viewController.Subject = listSubjects.Text;
                _viewController.Theme = listThemes.Text;
                _ChangeStatus();
            }
        }

        private void SaveQuestion_Click(object sender, EventArgs e)
        {
            string newQuestion = _viewController.Question;
            _viewController.SaveDataObject();
            _ReInitComboBox(_viewController.QuestionsList, listQuestions);
            listQuestions.SelectedItem = newQuestion;
            _ChangeStatus();
        }
        
        private void Term_TextChanged(object sender, EventArgs e)
        {
            _viewController.Term = tb_Term.Text;
            if (!_isChangedCurrentQuestion)
                _ChangeStatus();
        }

        private void Definition_TextChanged(object sender, EventArgs e)
        {
            _viewController.Definition = tb_Definition.Text;
            if (!_isChangedCurrentQuestion)
                _ChangeStatus();
        }

        private void CheckedChanged_RepeatMode(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null) return;

            if (checkBox.Name == "rb_Twice" && checkBox.Checked)
                _viewController.ModeRepeat = ModeRepeat.Twice_a_Day;
            else if (checkBox.Name == "rb_OnceADay" && checkBox.Checked)
                _viewController.ModeRepeat = ModeRepeat.Once_a_Day;
            else if (checkBox.Name == "rb_EveryOtherDay" && checkBox.Checked)
                _viewController.ModeRepeat = ModeRepeat.Every_Other_Day;
            else if (checkBox.Name == "rb_OnceAWeek" && checkBox.Checked)
                _viewController.ModeRepeat = ModeRepeat.Once_a_Week;
            
            if (!_isChangedCurrentQuestion)
                _ChangeStatus();
        }

        private void CustomRepeat_TextChanged(object sender, EventArgs e)
        {
            if (tb_customRepeat.Text.Length != 0)
            {
                foreach (RadioButton rb in modeRepeat.Controls.OfType<RadioButton>())
                    rb.Checked = false;

                _viewController.ModeRepeat = ModeRepeat.Custom;
                _viewController.RepeatTime = new DateTime().Add(TimeSpan.FromHours(Convert.ToDouble(tb_customRepeat.Text)));
            }
            else
            {
                _viewController.RepeatTime = new DateTime();
                _viewController.ModeRepeat = ModeRepeat.Twice_a_Day;
            }

            if (!_isChangedCurrentQuestion)
                _ChangeStatus();
        }

        private void CheckedChanged_TestMode(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if(checkBox == null) return;

            if(checkBox.Name == "rb_options" && checkBox.Checked)
                _viewController.ModeTest = ModeTest.Options;
            else if(checkBox.Name == "rb_writen" && checkBox.Checked)
                _viewController.ModeTest = ModeTest.Writen;
            else if (checkBox.Name == "rb_random" && checkBox.Checked)
                _viewController.ModeTest = ModeTest.RandomMode;

            if (!_isChangedCurrentQuestion)
                _ChangeStatus();
        }

        private void ResetRating_CheckedChanged(object sender, EventArgs e)
        {
            _viewController.IsResetRaiting = chb_resetRating.Checked;
            if (!_isChangedCurrentQuestion)
                _ChangeStatus();
        }

        private void Complete_CheckedChanged(object sender, EventArgs e)
        {
            _viewController.IsCompleted = chb_complete.Checked;
            if(!_isChangedCurrentQuestion)
                _ChangeStatus();
        }

        private void DeleteQuestion_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(@"Вы уверены, что хотите удалить запись?", @"ВНИМАНИЕ", MessageBoxButtons.OKCancel) == DialogResult.OK)
                _viewController.DeleteDataObject(listQuestions.Text);
        }

        private void AddSubject_Click(object sender, EventArgs e)
        {
            var dialog = new NameDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _viewController.NewSubject(dialog.Value);
                _ReInitComboBox(_viewController.SubjectsList, listSubjects);
                listSubjects.SelectedIndex = listSubjects.FindStringExact(dialog.Value);
            }
        }

        private void RemoveSubject_Click(object sender, EventArgs e)
        {
            if (listSubjects.Text.Length != 0
                && MessageBox.Show(@"Вы уверены, что хотите удалить предмет со всем содержимым?", @"ВНИМАНИЕ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int i = listSubjects.SelectedIndex - 1;
                _viewController.DeleteSubject(listSubjects.Text);
                _ReInitComboBox(_viewController.SubjectsList, listSubjects);
                if(i > -1)
                    listSubjects.SelectedIndex = i;
            }
        }

        private void AddTheme_Click(object sender, EventArgs e)
        {
            if(listSubjects.Text.Length == 0) return;
            
            var dialog = new NameDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _viewController.NewTheme(listSubjects.Text, dialog.Value);
                _ReInitComboBox(_viewController.ThemesList, listThemes);
                listThemes.SelectedIndex = listThemes.FindStringExact(dialog.Value);
            }
        }

        private void RemoveTheme_Click(object sender, EventArgs e)
        {
            if (listThemes.Text.Length != 0 && listThemes.Text.Length != 0
                && MessageBox.Show(@"Вы уверены, что хотите удалить тему со всем содержимым?", @"ВНИМАНИЕ", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int i = listThemes.SelectedIndex - 1;
                _viewController.DeleteDataTheme(listSubjects.Text, listThemes.Text);
                _ReInitComboBox(_viewController.ThemesList, listThemes);
                if (i > -1)
                    listSubjects.SelectedIndex = i;
            }
        }

        private void listQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _viewController.Subject = listSubjects.Text;
            _viewController.Theme = listThemes.Text;
            _viewController.SelectedQuestion(((ComboBox)sender).Text);

            _FillFormData();
            btn_DeleteQuestion.Enabled = true;
        }

        private void listSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            _viewController.SelectedSubject(((ComboBox) sender).Text);
            _ReInitComboBox(_viewController.ThemesList, listThemes);
        }

        private void listThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _viewController.SelectedTheme(listSubjects.Text, ((ComboBox) sender).Text);
            _ReInitComboBox(_viewController.QuestionsList, listQuestions);
        }

        private void AddResousToDic_Click(object sender, EventArgs e)
        {
            var dialog = new ResDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;

            Button button = (Button)sender;
            if (button.Name == "btn_AddImage")
            {
                if (_viewController.Images == null)
                    _viewController.Images = new Dictionary<string, string>();

                _viewController.Images.Add(dialog.Description, dialog.Path);
                lb_Images.Items.Clear();
                lb_Images.Items.AddRange(_viewController.Images.Keys.ToArray());
            }
            if (button.Name == "btn_AddAudio")
            {
                if (_viewController.Audios == null)
                    _viewController.Audios = new Dictionary<string, string>();

                _viewController.Audios.Add(dialog.Description, dialog.Path);
                lb_Audios.Items.Clear();
                lb_Audios.Items.AddRange(_viewController.Audios.Keys.ToArray());
            }

            if (!_isChangedCurrentQuestion)
                _ChangeStatus();
        }

        private void RemoveResousToDic_Click(object sender, EventArgs e)
        {

        }

        private void _FillFormData()
        {
            tb_Term.Text = _viewController.Term;
            tb_Definition.Text = _viewController.Definition;
            l_currentRating.Text = @"Текущий балл: " + _viewController.Rating;
            chb_complete.Checked = _viewController.IsCompleted;

            if (_viewController.Images != null && _viewController.Images.Any())
                lb_Images.Items.AddRange(_viewController.Images.Keys.ToArray());
            if (_viewController.Audios != null && _viewController.Audios.Any())
                lb_Audios.Items.AddRange(_viewController.Audios.Keys.ToArray());

            switch (_viewController.ModeRepeat)
            {
                case ModeRepeat.Twice_a_Day:
                    rb_Twice.Checked = true;
                    break;
                case ModeRepeat.Once_a_Day:
                    rb_OnceADay.Checked = true;
                    break;
                case ModeRepeat.Every_Other_Day:
                    rb_EveryOtherDay.Checked = true;
                    break;
                case ModeRepeat.Once_a_Week:
                    rb_OnceAWeek.Checked = true;
                    break;
                case ModeRepeat.Custom:
                    tb_customRepeat.Text = Convert.ToString(_viewController.RepeatTime.Hour);
                    break;
            }

            switch (_viewController.ModeTest)
            {
                case ModeTest.Options:
                    rb_options.Checked = true;
                    break;
                case ModeTest.Writen:
                    rb_writen.Checked = true;
                    break;
                case ModeTest.RandomMode:
                    rb_random.Checked = true;
                    break;
            }
        }

        private void _ChangeStatus()
        {
            _isChangedCurrentQuestion = !_isChangedCurrentQuestion;
            btn_SaveQuestion.Enabled = !btn_SaveQuestion.Enabled;

            if (!_isChangedCurrentQuestion)
            {
                l_status.ForeColor = Color.Green;
                l_status.Text = "Сохранено";
            }
            else
            {
                l_status.ForeColor = Color.Red;
                l_status.Text = "Не сохранено";
            }
        }

        private void _BlockNoNumberSymbol(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) || e.KeyChar == '\b')
                e.Handled = true;
        }
    }
}
