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
            FillFormData();
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
                ChangeStatus();
            }
        }

        private void SaveQuestion_Click(object sender, EventArgs e)
        {//todo - тут проблема
            _viewController.SaveDataObject();
            _ReInitComboBox(_viewController.QuestionsList, listQuestions);
            //listQuestions.SelectedItem = _viewController.Question;
            ChangeStatus();
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

            FillFormData();
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

        private void FillFormData()
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

        private void ChangeStatus()
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
    }
}
