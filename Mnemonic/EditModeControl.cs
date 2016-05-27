using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;
using Mnemonic.Model;
using Mnemonic.View;

namespace Mnemonic
{
    public partial class EditModeControl : UserControl
    {
        private const string _NOELEMENT = @"Нет элементов";
        private static EditModeControl _instance;
        private ViewEditMode _viewController;
        private bool _isChangedCurrentQuestion;
        private Audio _audioTrack;

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
            if(!_viewController.IsDataBaseLoaded) return;
            
            _ReInitComboBox(_viewController.SubjectsList, listSubjects);
            _ReInitComboBox(_viewController.ThemesList, listThemes);
            _ReInitComboBox(_viewController.QuestionsList, listQuestions);

            l_status.ForeColor = Color.Green;
            l_status.Text = @"База данных загружена";
        }

        private void OnChangeFieldsEvent_Handler()
        {
            _FillFormData();
        }

        private void _ReInitComboBox(string[] listValues, ComboBox target)
        {
            target.Items.Clear();
            if (listValues == null)
            {
                target.Text = _NOELEMENT;
                return;
            }
            
            target.Items.AddRange(listValues);
            target.SelectedIndex = 0;
        }

        private void AddQuestion_Click(object sender, EventArgs e)
        {
            if (listThemes.Items.Count < 1)
            {
                MessageBox.Show(@"Добавте сначала хотя бы одну тему.");
                return;
            }

            var dialog = new NameDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _viewController.NewDataObject();
                _viewController.Question = dialog.Value;
                listQuestions.Text = dialog.Value;
                _viewController.Subject = listSubjects.Text;
                _viewController.Theme = listThemes.Text;

                _viewController.SaveDataObject();
                _ReInitComboBox(_viewController.QuestionsList, listQuestions);
                listQuestions.SelectedItem = dialog.Value;
            }
        }

        private void SaveQuestion_Click(object sender, EventArgs e)
        {
            string newQuestion = _viewController.Question;
            _viewController.SaveDataObject();
            _ChangeStatus();
            _ReInitComboBox(_viewController.QuestionsList, listQuestions);
            listQuestions.SelectedItem = newQuestion;
        }
        
        private void Term_TextChanged(object sender, EventArgs e)
        {
            _viewController.Term = tb_Term.Text;
            if (!_isChangedCurrentQuestion && tb_Term.Focused)
                _ChangeStatus();
        }

        private void Definition_TextChanged(object sender, EventArgs e)
        {
            _viewController.Definition = tb_Definition.Text;
            if (!_isChangedCurrentQuestion && tb_Definition.Focused)
                _ChangeStatus();
        }

        private void CheckedChanged_RepeatMode(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton == null) return;

            if (radioButton.Name == "rb_Twice" && radioButton.Checked)
                _viewController.ModeRepeat = ModeRepeat.Twice_a_Day;
            else if (radioButton.Name == "rb_OnceADay" && radioButton.Checked)
                _viewController.ModeRepeat = ModeRepeat.Once_a_Day;
            else if (radioButton.Name == "rb_EveryOtherDay" && radioButton.Checked)
                _viewController.ModeRepeat = ModeRepeat.Every_Other_Day;
            else if (radioButton.Name == "rb_OnceAWeek" && radioButton.Checked)
                _viewController.ModeRepeat = ModeRepeat.Once_a_Week;
            
            if (!_isChangedCurrentQuestion && radioButton.Focused)
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

            if (!_isChangedCurrentQuestion && tb_customRepeat.Focused)
                _ChangeStatus();
        }

        private void CheckedChanged_TestMode(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if(radioButton == null) return;

            if(radioButton.Name == "rb_options" && radioButton.Checked)
                _viewController.ModeTest = ModeTest.Options;
            else if(radioButton.Name == "rb_writen" && radioButton.Checked)
                _viewController.ModeTest = ModeTest.Writen;
            else if (radioButton.Name == "rb_random" && radioButton.Checked)
                _viewController.ModeTest = ModeTest.RandomMode;

            if (!_isChangedCurrentQuestion && radioButton.Focused)
                _ChangeStatus();
        }

        private void ResetRating_CheckedChanged(object sender, EventArgs e)
        {
            _viewController.IsResetRaiting = chb_resetRating.Checked;
            if (!_isChangedCurrentQuestion && chb_complete.Focused)
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
            if(listQuestions.SelectedItem != null && MessageBox.Show(@"Вы уверены, что хотите удалить запись?", @"ВНИМАНИЕ", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
            if (listSubjects.Items.Count == 0 || MessageBox.Show(@"Вы уверены, что хотите удалить предмет со всем содержимым?", @"ВНИМАНИЕ", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            int i = listSubjects.SelectedIndex - 1;
            _viewController.DeleteSubject(listSubjects.Text);
            _ReInitComboBox(_viewController.SubjectsList, listSubjects);

            if (i == -1)
            {
                listThemes.Items.Clear();
                listThemes.Text = _NOELEMENT;
                listQuestions.Items.Clear();
                listQuestions.Text = _NOELEMENT;
            }
            else
                listSubjects.SelectedIndex = i;
        }

        private void AddTheme_Click(object sender, EventArgs e)
        {
            if (listSubjects.Items.Count < 1)
            {
                MessageBox.Show(@"Добавте сначала хотя бы один Предмет.");
                return;
            }

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
            if (listThemes.Items.Count == 0 || MessageBox.Show(@"Вы уверены, что хотите удалить тему со всем содержимым?", @"ВНИМАНИЕ", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            int i = listThemes.SelectedIndex - 1;
            _viewController.DeleteDataTheme(listSubjects.Text, listThemes.Text);
            _ReInitComboBox(_viewController.ThemesList, listThemes);

            if (i == -1)
            {
                listQuestions.Items.Clear();
                listQuestions.Text = _NOELEMENT;
            }
            else
                listThemes.SelectedIndex = i;
        }

        private void listQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isChangedCurrentQuestion)
            {
                DialogResult result = MessageBox.Show(@"Если вы перейдете, все не сохраненные изменения будут утрачены", @"ВНИМАНИЕ", MessageBoxButtons.OKCancel);
                if (result != DialogResult.Cancel)
                    _ChangeStatus();
                else
                    return;
            }

            _viewController.Subject = listSubjects.Text;
            _viewController.Theme = listThemes.Text;
            _viewController.SelectedQuestion(((ComboBox)sender).Text);

            _FillFormData();
            btn_DeleteQuestion.Enabled = true;
        }

        private void listSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ResetFields();
            _viewController.SelectedSubject(((ComboBox) sender).Text);
            _ReInitComboBox(_viewController.ThemesList, listThemes);
        }

        private void listThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ResetFields();
            _viewController.SelectedTheme(listSubjects.Text, ((ComboBox) sender).Text);
            _ReInitComboBox(_viewController.QuestionsList, listQuestions);
        }

        private void AddImage_Click(object sender, EventArgs e)
        {
            if(_viewController.Images == null)
                _viewController.Images = new Dictionary<string, string>();

            if(_AddItemInDictionary(_viewController.Images))
                lb_Images.Items.Add(_viewController.Images.Last().Key);

            if (!_isChangedCurrentQuestion)
                _ChangeStatus();
        }

        private void AddAudio_Click(object sender, EventArgs e)
        {
            if (_viewController.Audios == null)
                _viewController.Audios = new Dictionary<string, string>();

            if(_AddItemInDictionary(_viewController.Audios))
                lb_Audios.Items.Add(_viewController.Audios.Last().Key);

            if (!_isChangedCurrentQuestion)
                _ChangeStatus();
        }

        private void RemoveImage_Click(object sender, EventArgs e)
        {
            if (lb_Images.Items.Count > 0)
            {
                if (MessageBox.Show(@"Вы уверены, что хотите удалить ссылку на файл из БД?", @"ВНИМАНИЕ", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

                _viewController.Images?.Remove(Convert.ToString(lb_Images.SelectedItem));
                lb_Images.Items.Remove(lb_Images.SelectedItem);

                if (!_isChangedCurrentQuestion)
                    _ChangeStatus();
            }
        }

        private void RemoveAudio_Click(object sender, EventArgs e)
        {
            if (lb_Audios.Items.Count > 0)
            {
                if (MessageBox.Show(@"Вы уверены, что хотите удалить ссылку на файл из БД?", @"ВНИМАНИЕ", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

                _viewController.Audios?.Remove(Convert.ToString(lb_Audios.SelectedItem));
                lb_Audios.Items.Remove(lb_Audios.SelectedItem);

                if (!_isChangedCurrentQuestion)
                    _ChangeStatus();
            }
        }

        private void Images_SelectedValueChanged(object sender, EventArgs e)
        {
            string uri;
            _viewController.Images.TryGetValue(lb_Images.Text, out uri);
            previewPicture.Image = null;
            l_errorPreview.Visible = false;

            try
            {
                previewPicture.Load(uri);
            }
            catch (Exception)
            {
                l_errorPreview.Visible = true;
            }
        }

        private void Audio_SelectedValueChanged(object sender, EventArgs e)
        {
            string uri;
            _viewController.Audios.TryGetValue(lb_Audios.Text, out uri);

            try
            {
                _audioTrack = new Audio(@"E:\Project Visual Studio\MyProjects\C#\Mnemonic\Memonic\Mnemonic\Mnemonic\bin\Debug\audios\doktor_haus_-_glavniy_saundtrek.mp3");
                _audioTrack.Play();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void Images_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lb_Images.Items.Count < 1) return;

            if (_AddItemInDictionary(lb_Images.Text, _viewController.Images))
            {
                lb_Images.Items.Clear();
                lb_Images.Items.AddRange(_viewController.Images.Keys.ToArray());

                if (!_isChangedCurrentQuestion && lb_Images.Focused)
                    _ChangeStatus();
            }
        }

        private void Audios_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lb_Audios.Items.Count < 1) return;

            if (_AddItemInDictionary(lb_Audios.Text, _viewController.Audios))
            {
                lb_Audios.Items.Clear();
                lb_Audios.Items.AddRange(_viewController.Audios.Keys.ToArray());

                if (!_isChangedCurrentQuestion && lb_Audios.Focused)
                    _ChangeStatus();
            }
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            if (previewPicture.Image == null) return;

            Form f = new Form {FormBorderStyle = FormBorderStyle.FixedToolWindow, StartPosition = FormStartPosition.CenterParent};

            f.Controls.Add(new PictureBox { Dock = DockStyle.Fill, Image = previewPicture.Image });
            f.ClientSize = previewPicture.Image.Size;

            f.ShowDialog();
        }

        private void _FillFormData()
        {
            l_errorPreview.Visible = false;
            lb_Images.Items.Clear();
            lb_Audios.Items.Clear();

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
            if(listQuestions.SelectedItem == null) return;
            
            _isChangedCurrentQuestion = !_isChangedCurrentQuestion;
            btn_SaveQuestion.Enabled = !btn_SaveQuestion.Enabled;

            if (!_isChangedCurrentQuestion)
            {
                l_status.ForeColor = Color.Green;
                l_status.Text = @"Сохранено";
            }
            else
            {
                l_status.ForeColor = Color.Red;
                l_status.Text = @"Не сохранено";
            }
        }
        private bool _AddItemInDictionary(IDictionary<string, string> target)
        {
            var dialog = new ResDialog();

            while (true)
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return false;
                if (!target.ContainsKey(dialog.Description))
                    break;

                MessageBox.Show(@"Ссылка с таким описанием уже содежится в списке.");
            }

            target.Add(dialog.Description, dialog.Path);
            return true;
        }
        private bool _AddItemInDictionary(string descriptionOld, IDictionary<string, string> target)
        {
            var dialog = new ResDialog(descriptionOld, target[descriptionOld]);
            while (true)
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return false;
                if (dialog.Description == descriptionOld || !target.ContainsKey(dialog.Description))
                    break;

                MessageBox.Show(@"Ссылка с таким описанием уже содежится в списке.");
            }

            if (dialog.Description != descriptionOld)
            {
                target.Remove(descriptionOld);
                target.Add(dialog.Description, dialog.Path);
            }
            else
                target[descriptionOld] = dialog.Path;

            return true;
        }
        private void _BlockNoNumberSymbol(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) || e.KeyChar == '\b')
                e.Handled = true;
        }
        private void _ResetFields()
        {
            if (_isChangedCurrentQuestion)
            {
                DialogResult result = MessageBox.Show(@"Если вы перейдете, все не сохраненные изменения будут утрачены", @"ВНИМАНИЕ", MessageBoxButtons.OKCancel);
                if (result != DialogResult.Cancel)
                    _ChangeStatus();
                else
                    return;
            }

            listQuestions.Items.Clear();
            listQuestions.Text = _NOELEMENT;
            lb_Images.Items.Clear();
            lb_Audios.Items.Clear();
            tb_Term.Clear();
            tb_Definition.Clear();
        }
    }
}
