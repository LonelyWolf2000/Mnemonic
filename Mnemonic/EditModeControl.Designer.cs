namespace Mnemonic
{
    partial class EditModeControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listSubjects = new System.Windows.Forms.ComboBox();
            this.listQuestions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listThemes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Term = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Definition = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_Images = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_Audios = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.modeRepeat = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_customRepeat = new System.Windows.Forms.TextBox();
            this.rb_OnceAWeek = new System.Windows.Forms.RadioButton();
            this.rb_EveryOtherDay = new System.Windows.Forms.RadioButton();
            this.rb_OnceADay = new System.Windows.Forms.RadioButton();
            this.rb_Twice = new System.Windows.Forms.RadioButton();
            this.btn_SaveQuestion = new System.Windows.Forms.Button();
            this.btn_DeleteQuestion = new System.Windows.Forms.Button();
            this.btn_AddSubject = new System.Windows.Forms.Button();
            this.btn_RemoveSubject = new System.Windows.Forms.Button();
            this.btn_AddTheme = new System.Windows.Forms.Button();
            this.btn_AddImage = new System.Windows.Forms.Button();
            this.btn_RemoveTheme = new System.Windows.Forms.Button();
            this.btn_RemoveImage = new System.Windows.Forms.Button();
            this.btn_AddAudio = new System.Windows.Forms.Button();
            this.btn_RemoveAudio = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chb_complete = new System.Windows.Forms.CheckBox();
            this.chb_resetRating = new System.Windows.Forms.CheckBox();
            this.l_currentRating = new System.Windows.Forms.Label();
            this.l_status = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_random = new System.Windows.Forms.RadioButton();
            this.rb_writen = new System.Windows.Forms.RadioButton();
            this.rb_options = new System.Windows.Forms.RadioButton();
            this.EditingPanel = new System.Windows.Forms.Panel();
            this.l_errorPreview = new System.Windows.Forms.Label();
            this.btn_AddQuestion = new System.Windows.Forms.Button();
            this.previewPicture = new System.Windows.Forms.PictureBox();
            this.modeRepeat.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.EditingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // listSubjects
            // 
            this.listSubjects.AutoCompleteCustomSource.AddRange(new string[] {
            "Алгебра",
            "Геометрия",
            "Физика"});
            this.listSubjects.FormattingEnabled = true;
            this.listSubjects.Location = new System.Drawing.Point(3, 64);
            this.listSubjects.Name = "listSubjects";
            this.listSubjects.Size = new System.Drawing.Size(121, 21);
            this.listSubjects.TabIndex = 0;
            this.listSubjects.SelectedIndexChanged += new System.EventHandler(this.listSubjects_SelectedIndexChanged);
            // 
            // listQuestions
            // 
            this.listQuestions.AutoCompleteCustomSource.AddRange(new string[] {
            "Алгебра",
            "Геометрия",
            "Физика"});
            this.listQuestions.FormattingEnabled = true;
            this.listQuestions.Location = new System.Drawing.Point(3, 21);
            this.listQuestions.Name = "listQuestions";
            this.listQuestions.Size = new System.Drawing.Size(121, 21);
            this.listQuestions.TabIndex = 0;
            this.listQuestions.SelectedIndexChanged += new System.EventHandler(this.listQuestions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Предмет/Область:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Изучаемая порция информации:";
            // 
            // listThemes
            // 
            this.listThemes.AutoCompleteCustomSource.AddRange(new string[] {
            "Алгебра",
            "Геометрия",
            "Физика"});
            this.listThemes.FormattingEnabled = true;
            this.listThemes.Location = new System.Drawing.Point(165, 64);
            this.listThemes.Name = "listThemes";
            this.listThemes.Size = new System.Drawing.Size(121, 21);
            this.listThemes.TabIndex = 2;
            this.listThemes.SelectedIndexChanged += new System.EventHandler(this.listThemes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тема:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(334, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Режим редактирования";
            // 
            // tb_Term
            // 
            this.tb_Term.Location = new System.Drawing.Point(3, 159);
            this.tb_Term.Multiline = true;
            this.tb_Term.Name = "tb_Term";
            this.tb_Term.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_Term.Size = new System.Drawing.Size(289, 108);
            this.tb_Term.TabIndex = 5;
            this.tb_Term.TextChanged += new System.EventHandler(this.Term_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Термин/Понятие:";
            // 
            // tb_Definition
            // 
            this.tb_Definition.Location = new System.Drawing.Point(1, 290);
            this.tb_Definition.Multiline = true;
            this.tb_Definition.Name = "tb_Definition";
            this.tb_Definition.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_Definition.Size = new System.Drawing.Size(292, 163);
            this.tb_Definition.TabIndex = 7;
            this.tb_Definition.TextChanged += new System.EventHandler(this.Definition_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Определение:";
            // 
            // lb_Images
            // 
            this.lb_Images.FormattingEnabled = true;
            this.lb_Images.Location = new System.Drawing.Point(3, 107);
            this.lb_Images.Name = "lb_Images";
            this.lb_Images.Size = new System.Drawing.Size(122, 30);
            this.lb_Images.TabIndex = 9;
            this.lb_Images.SelectedValueChanged += new System.EventHandler(this.Images_SelectedValueChanged);
            this.lb_Images.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Images_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Графические материалы:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(552, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Превью:";
            // 
            // lb_Audios
            // 
            this.lb_Audios.FormattingEnabled = true;
            this.lb_Audios.Location = new System.Drawing.Point(165, 107);
            this.lb_Audios.Name = "lb_Audios";
            this.lb_Audios.Size = new System.Drawing.Size(122, 30);
            this.lb_Audios.TabIndex = 13;
            this.lb_Audios.SelectedValueChanged += new System.EventHandler(this.Audio_SelectedValueChanged);
            this.lb_Audios.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Audios_MouseDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Аудио материалы:";
            // 
            // modeRepeat
            // 
            this.modeRepeat.Controls.Add(this.label11);
            this.modeRepeat.Controls.Add(this.label10);
            this.modeRepeat.Controls.Add(this.tb_customRepeat);
            this.modeRepeat.Controls.Add(this.rb_OnceAWeek);
            this.modeRepeat.Controls.Add(this.rb_EveryOtherDay);
            this.modeRepeat.Controls.Add(this.rb_OnceADay);
            this.modeRepeat.Controls.Add(this.rb_Twice);
            this.modeRepeat.Location = new System.Drawing.Point(339, 64);
            this.modeRepeat.Name = "modeRepeat";
            this.modeRepeat.Size = new System.Drawing.Size(200, 140);
            this.modeRepeat.TabIndex = 15;
            this.modeRepeat.TabStop = false;
            this.modeRepeat.Text = "Задать режим повторения";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(100, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "часов";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Каждые";
            // 
            // tb_customRepeat
            // 
            this.tb_customRepeat.Location = new System.Drawing.Point(55, 110);
            this.tb_customRepeat.MaxLength = 4;
            this.tb_customRepeat.Name = "tb_customRepeat";
            this.tb_customRepeat.Size = new System.Drawing.Size(42, 20);
            this.tb_customRepeat.TabIndex = 1;
            this.tb_customRepeat.TextChanged += new System.EventHandler(this.CustomRepeat_TextChanged);
            this.tb_customRepeat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._BlockNoNumberSymbol);
            // 
            // rb_OnceAWeek
            // 
            this.rb_OnceAWeek.AutoSize = true;
            this.rb_OnceAWeek.Location = new System.Drawing.Point(7, 89);
            this.rb_OnceAWeek.Name = "rb_OnceAWeek";
            this.rb_OnceAWeek.Size = new System.Drawing.Size(102, 17);
            this.rb_OnceAWeek.TabIndex = 0;
            this.rb_OnceAWeek.TabStop = true;
            this.rb_OnceAWeek.Text = "1 раз в неделю";
            this.rb_OnceAWeek.UseVisualStyleBackColor = true;
            this.rb_OnceAWeek.CheckedChanged += new System.EventHandler(this.CheckedChanged_RepeatMode);
            // 
            // rb_EveryOtherDay
            // 
            this.rb_EveryOtherDay.AutoSize = true;
            this.rb_EveryOtherDay.Location = new System.Drawing.Point(7, 66);
            this.rb_EveryOtherDay.Name = "rb_EveryOtherDay";
            this.rb_EveryOtherDay.Size = new System.Drawing.Size(84, 17);
            this.rb_EveryOtherDay.TabIndex = 0;
            this.rb_EveryOtherDay.TabStop = true;
            this.rb_EveryOtherDay.Text = "Через день";
            this.rb_EveryOtherDay.UseVisualStyleBackColor = true;
            this.rb_EveryOtherDay.CheckedChanged += new System.EventHandler(this.CheckedChanged_RepeatMode);
            // 
            // rb_OnceADay
            // 
            this.rb_OnceADay.AutoSize = true;
            this.rb_OnceADay.Location = new System.Drawing.Point(7, 43);
            this.rb_OnceADay.Name = "rb_OnceADay";
            this.rb_OnceADay.Size = new System.Drawing.Size(88, 17);
            this.rb_OnceADay.TabIndex = 0;
            this.rb_OnceADay.TabStop = true;
            this.rb_OnceADay.Text = "1 раз в день";
            this.rb_OnceADay.UseVisualStyleBackColor = true;
            this.rb_OnceADay.CheckedChanged += new System.EventHandler(this.CheckedChanged_RepeatMode);
            // 
            // rb_Twice
            // 
            this.rb_Twice.AutoSize = true;
            this.rb_Twice.Location = new System.Drawing.Point(7, 20);
            this.rb_Twice.Name = "rb_Twice";
            this.rb_Twice.Size = new System.Drawing.Size(94, 17);
            this.rb_Twice.TabIndex = 0;
            this.rb_Twice.TabStop = true;
            this.rb_Twice.Text = "2 раза в день";
            this.rb_Twice.UseVisualStyleBackColor = true;
            this.rb_Twice.CheckedChanged += new System.EventHandler(this.CheckedChanged_RepeatMode);
            // 
            // btn_SaveQuestion
            // 
            this.btn_SaveQuestion.Enabled = false;
            this.btn_SaveQuestion.Location = new System.Drawing.Point(597, 417);
            this.btn_SaveQuestion.Name = "btn_SaveQuestion";
            this.btn_SaveQuestion.Size = new System.Drawing.Size(119, 28);
            this.btn_SaveQuestion.TabIndex = 16;
            this.btn_SaveQuestion.Text = "Сохранить запись";
            this.btn_SaveQuestion.UseVisualStyleBackColor = true;
            this.btn_SaveQuestion.Click += new System.EventHandler(this.SaveQuestion_Click);
            // 
            // btn_DeleteQuestion
            // 
            this.btn_DeleteQuestion.Enabled = false;
            this.btn_DeleteQuestion.Location = new System.Drawing.Point(732, 417);
            this.btn_DeleteQuestion.Name = "btn_DeleteQuestion";
            this.btn_DeleteQuestion.Size = new System.Drawing.Size(119, 28);
            this.btn_DeleteQuestion.TabIndex = 16;
            this.btn_DeleteQuestion.Text = "Удалить запись";
            this.btn_DeleteQuestion.UseVisualStyleBackColor = true;
            this.btn_DeleteQuestion.Click += new System.EventHandler(this.DeleteQuestion_Click);
            // 
            // btn_AddSubject
            // 
            this.btn_AddSubject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_AddSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_AddSubject.Location = new System.Drawing.Point(130, 62);
            this.btn_AddSubject.Name = "btn_AddSubject";
            this.btn_AddSubject.Size = new System.Drawing.Size(28, 13);
            this.btn_AddSubject.TabIndex = 17;
            this.btn_AddSubject.Text = "+";
            this.btn_AddSubject.UseVisualStyleBackColor = true;
            this.btn_AddSubject.Click += new System.EventHandler(this.AddSubject_Click);
            // 
            // btn_RemoveSubject
            // 
            this.btn_RemoveSubject.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_RemoveSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_RemoveSubject.Location = new System.Drawing.Point(130, 75);
            this.btn_RemoveSubject.Name = "btn_RemoveSubject";
            this.btn_RemoveSubject.Size = new System.Drawing.Size(28, 13);
            this.btn_RemoveSubject.TabIndex = 17;
            this.btn_RemoveSubject.Text = "-";
            this.btn_RemoveSubject.UseVisualStyleBackColor = true;
            this.btn_RemoveSubject.Click += new System.EventHandler(this.RemoveSubject_Click);
            // 
            // btn_AddTheme
            // 
            this.btn_AddTheme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_AddTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_AddTheme.Location = new System.Drawing.Point(292, 62);
            this.btn_AddTheme.Name = "btn_AddTheme";
            this.btn_AddTheme.Size = new System.Drawing.Size(28, 13);
            this.btn_AddTheme.TabIndex = 17;
            this.btn_AddTheme.Text = "+";
            this.btn_AddTheme.UseVisualStyleBackColor = true;
            this.btn_AddTheme.Click += new System.EventHandler(this.AddTheme_Click);
            // 
            // btn_AddImage
            // 
            this.btn_AddImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_AddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_AddImage.Location = new System.Drawing.Point(131, 109);
            this.btn_AddImage.Name = "btn_AddImage";
            this.btn_AddImage.Size = new System.Drawing.Size(28, 13);
            this.btn_AddImage.TabIndex = 17;
            this.btn_AddImage.Text = "+";
            this.btn_AddImage.UseVisualStyleBackColor = true;
            this.btn_AddImage.Click += new System.EventHandler(this.AddImage_Click);
            // 
            // btn_RemoveTheme
            // 
            this.btn_RemoveTheme.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_RemoveTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_RemoveTheme.Location = new System.Drawing.Point(292, 75);
            this.btn_RemoveTheme.Name = "btn_RemoveTheme";
            this.btn_RemoveTheme.Size = new System.Drawing.Size(28, 13);
            this.btn_RemoveTheme.TabIndex = 17;
            this.btn_RemoveTheme.Text = "-";
            this.btn_RemoveTheme.UseVisualStyleBackColor = true;
            this.btn_RemoveTheme.Click += new System.EventHandler(this.RemoveTheme_Click);
            // 
            // btn_RemoveImage
            // 
            this.btn_RemoveImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_RemoveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_RemoveImage.Location = new System.Drawing.Point(131, 122);
            this.btn_RemoveImage.Name = "btn_RemoveImage";
            this.btn_RemoveImage.Size = new System.Drawing.Size(28, 13);
            this.btn_RemoveImage.TabIndex = 17;
            this.btn_RemoveImage.Text = "-";
            this.btn_RemoveImage.UseVisualStyleBackColor = true;
            this.btn_RemoveImage.Click += new System.EventHandler(this.RemoveImage_Click);
            // 
            // btn_AddAudio
            // 
            this.btn_AddAudio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_AddAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_AddAudio.Location = new System.Drawing.Point(293, 109);
            this.btn_AddAudio.Name = "btn_AddAudio";
            this.btn_AddAudio.Size = new System.Drawing.Size(28, 13);
            this.btn_AddAudio.TabIndex = 17;
            this.btn_AddAudio.Text = "+";
            this.btn_AddAudio.UseVisualStyleBackColor = true;
            this.btn_AddAudio.Click += new System.EventHandler(this.AddAudio_Click);
            // 
            // btn_RemoveAudio
            // 
            this.btn_RemoveAudio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_RemoveAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_RemoveAudio.Location = new System.Drawing.Point(293, 122);
            this.btn_RemoveAudio.Name = "btn_RemoveAudio";
            this.btn_RemoveAudio.Size = new System.Drawing.Size(28, 13);
            this.btn_RemoveAudio.TabIndex = 17;
            this.btn_RemoveAudio.Text = "-";
            this.btn_RemoveAudio.UseVisualStyleBackColor = true;
            this.btn_RemoveAudio.Click += new System.EventHandler(this.RemoveAudio_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chb_complete);
            this.groupBox1.Controls.Add(this.chb_resetRating);
            this.groupBox1.Controls.Add(this.l_currentRating);
            this.groupBox1.Location = new System.Drawing.Point(339, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 104);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Уровень заученности";
            // 
            // chb_complete
            // 
            this.chb_complete.AutoSize = true;
            this.chb_complete.Location = new System.Drawing.Point(10, 80);
            this.chb_complete.Name = "chb_complete";
            this.chb_complete.Size = new System.Drawing.Size(185, 17);
            this.chb_complete.TabIndex = 3;
            this.chb_complete.Text = "Изучено (больше не повторять)";
            this.chb_complete.UseVisualStyleBackColor = true;
            this.chb_complete.CheckedChanged += new System.EventHandler(this.Complete_CheckedChanged);
            // 
            // chb_resetRating
            // 
            this.chb_resetRating.AutoSize = true;
            this.chb_resetRating.Location = new System.Drawing.Point(11, 56);
            this.chb_resetRating.Name = "chb_resetRating";
            this.chb_resetRating.Size = new System.Drawing.Size(101, 17);
            this.chb_resetRating.TabIndex = 2;
            this.chb_resetRating.Text = "Сбросить балл";
            this.chb_resetRating.UseVisualStyleBackColor = true;
            this.chb_resetRating.CheckedChanged += new System.EventHandler(this.ResetRating_CheckedChanged);
            // 
            // l_currentRating
            // 
            this.l_currentRating.AutoSize = true;
            this.l_currentRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_currentRating.Location = new System.Drawing.Point(7, 20);
            this.l_currentRating.Name = "l_currentRating";
            this.l_currentRating.Size = new System.Drawing.Size(154, 20);
            this.l_currentRating.TabIndex = 0;
            this.l_currentRating.Text = "Текущий балл:  X";
            // 
            // l_status
            // 
            this.l_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_status.ForeColor = System.Drawing.Color.Red;
            this.l_status.Location = new System.Drawing.Point(308, 420);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(262, 25);
            this.l_status.TabIndex = 19;
            this.l_status.Text = "База данных не загружена";
            this.l_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_random);
            this.groupBox2.Controls.Add(this.rb_writen);
            this.groupBox2.Controls.Add(this.rb_options);
            this.groupBox2.Location = new System.Drawing.Point(339, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 90);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Задать режим тестирования:";
            // 
            // rb_random
            // 
            this.rb_random.AutoSize = true;
            this.rb_random.Location = new System.Drawing.Point(10, 66);
            this.rb_random.Name = "rb_random";
            this.rb_random.Size = new System.Drawing.Size(117, 17);
            this.rb_random.TabIndex = 0;
            this.rb_random.TabStop = true;
            this.rb_random.Text = "Случайный режим";
            this.rb_random.UseVisualStyleBackColor = true;
            this.rb_random.CheckedChanged += new System.EventHandler(this.CheckedChanged_TestMode);
            // 
            // rb_writen
            // 
            this.rb_writen.AutoSize = true;
            this.rb_writen.Location = new System.Drawing.Point(11, 43);
            this.rb_writen.Name = "rb_writen";
            this.rb_writen.Size = new System.Drawing.Size(99, 17);
            this.rb_writen.TabIndex = 0;
            this.rb_writen.TabStop = true;
            this.rb_writen.Text = "Ручная запись";
            this.rb_writen.UseVisualStyleBackColor = true;
            this.rb_writen.CheckedChanged += new System.EventHandler(this.CheckedChanged_TestMode);
            // 
            // rb_options
            // 
            this.rb_options.AutoSize = true;
            this.rb_options.Location = new System.Drawing.Point(11, 20);
            this.rb_options.Name = "rb_options";
            this.rb_options.Size = new System.Drawing.Size(112, 17);
            this.rb_options.TabIndex = 0;
            this.rb_options.TabStop = true;
            this.rb_options.Text = "Варианты ответа";
            this.rb_options.UseVisualStyleBackColor = true;
            this.rb_options.CheckedChanged += new System.EventHandler(this.CheckedChanged_TestMode);
            // 
            // EditingPanel
            // 
            this.EditingPanel.Controls.Add(this.l_errorPreview);
            this.EditingPanel.Controls.Add(this.groupBox2);
            this.EditingPanel.Controls.Add(this.l_status);
            this.EditingPanel.Controls.Add(this.groupBox1);
            this.EditingPanel.Controls.Add(this.btn_RemoveAudio);
            this.EditingPanel.Controls.Add(this.btn_AddAudio);
            this.EditingPanel.Controls.Add(this.btn_RemoveImage);
            this.EditingPanel.Controls.Add(this.btn_RemoveTheme);
            this.EditingPanel.Controls.Add(this.btn_AddImage);
            this.EditingPanel.Controls.Add(this.btn_AddTheme);
            this.EditingPanel.Controls.Add(this.btn_RemoveSubject);
            this.EditingPanel.Controls.Add(this.btn_AddQuestion);
            this.EditingPanel.Controls.Add(this.btn_AddSubject);
            this.EditingPanel.Controls.Add(this.btn_DeleteQuestion);
            this.EditingPanel.Controls.Add(this.btn_SaveQuestion);
            this.EditingPanel.Controls.Add(this.modeRepeat);
            this.EditingPanel.Controls.Add(this.label8);
            this.EditingPanel.Controls.Add(this.lb_Audios);
            this.EditingPanel.Controls.Add(this.label7);
            this.EditingPanel.Controls.Add(this.previewPicture);
            this.EditingPanel.Controls.Add(this.label6);
            this.EditingPanel.Controls.Add(this.lb_Images);
            this.EditingPanel.Controls.Add(this.label5);
            this.EditingPanel.Controls.Add(this.tb_Definition);
            this.EditingPanel.Controls.Add(this.label4);
            this.EditingPanel.Controls.Add(this.tb_Term);
            this.EditingPanel.Controls.Add(this.label3);
            this.EditingPanel.Controls.Add(this.label2);
            this.EditingPanel.Controls.Add(this.listThemes);
            this.EditingPanel.Controls.Add(this.label9);
            this.EditingPanel.Controls.Add(this.label1);
            this.EditingPanel.Controls.Add(this.listQuestions);
            this.EditingPanel.Controls.Add(this.listSubjects);
            this.EditingPanel.Location = new System.Drawing.Point(0, 0);
            this.EditingPanel.Name = "EditingPanel";
            this.EditingPanel.Size = new System.Drawing.Size(905, 454);
            this.EditingPanel.TabIndex = 2;
            // 
            // l_errorPreview
            // 
            this.l_errorPreview.AutoSize = true;
            this.l_errorPreview.BackColor = System.Drawing.SystemColors.Control;
            this.l_errorPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_errorPreview.ForeColor = System.Drawing.Color.DarkGray;
            this.l_errorPreview.Location = new System.Drawing.Point(571, 230);
            this.l_errorPreview.Name = "l_errorPreview";
            this.l_errorPreview.Size = new System.Drawing.Size(312, 20);
            this.l_errorPreview.TabIndex = 21;
            this.l_errorPreview.Text = "Не удалось загрузить изображение";
            this.l_errorPreview.Visible = false;
            // 
            // btn_AddQuestion
            // 
            this.btn_AddQuestion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_AddQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.btn_AddQuestion.Location = new System.Drawing.Point(130, 21);
            this.btn_AddQuestion.Name = "btn_AddQuestion";
            this.btn_AddQuestion.Size = new System.Drawing.Size(28, 21);
            this.btn_AddQuestion.TabIndex = 17;
            this.btn_AddQuestion.Text = "+";
            this.btn_AddQuestion.UseVisualStyleBackColor = true;
            this.btn_AddQuestion.Click += new System.EventHandler(this.AddQuestion_Click);
            // 
            // previewPicture
            // 
            this.previewPicture.Location = new System.Drawing.Point(555, 71);
            this.previewPicture.Name = "previewPicture";
            this.previewPicture.Size = new System.Drawing.Size(340, 340);
            this.previewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewPicture.TabIndex = 11;
            this.previewPicture.TabStop = false;
            // 
            // EditModeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EditingPanel);
            this.Name = "EditModeControl";
            this.Size = new System.Drawing.Size(904, 454);
            this.modeRepeat.ResumeLayout(false);
            this.modeRepeat.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.EditingPanel.ResumeLayout(false);
            this.EditingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox listSubjects;
        private System.Windows.Forms.ComboBox listQuestions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox listThemes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Term;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Definition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lb_Images;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox previewPicture;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lb_Audios;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox modeRepeat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_customRepeat;
        private System.Windows.Forms.RadioButton rb_OnceAWeek;
        private System.Windows.Forms.RadioButton rb_EveryOtherDay;
        private System.Windows.Forms.RadioButton rb_OnceADay;
        private System.Windows.Forms.RadioButton rb_Twice;
        private System.Windows.Forms.Button btn_SaveQuestion;
        private System.Windows.Forms.Button btn_DeleteQuestion;
        private System.Windows.Forms.Button btn_AddSubject;
        private System.Windows.Forms.Button btn_RemoveSubject;
        private System.Windows.Forms.Button btn_AddTheme;
        private System.Windows.Forms.Button btn_AddImage;
        private System.Windows.Forms.Button btn_RemoveTheme;
        private System.Windows.Forms.Button btn_RemoveImage;
        private System.Windows.Forms.Button btn_AddAudio;
        private System.Windows.Forms.Button btn_RemoveAudio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label l_currentRating;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_random;
        private System.Windows.Forms.RadioButton rb_writen;
        private System.Windows.Forms.RadioButton rb_options;
        private System.Windows.Forms.Panel EditingPanel;
        private System.Windows.Forms.CheckBox chb_resetRating;
        private System.Windows.Forms.CheckBox chb_complete;
        private System.Windows.Forms.Button btn_AddQuestion;
        private System.Windows.Forms.Label l_errorPreview;
    }
}
