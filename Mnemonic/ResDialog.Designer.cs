namespace Mnemonic
{
    partial class ResDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tb_Description = new System.Windows.Forms.TextBox();
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.btn_OpenRes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(31, 66);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(201, 66);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tb_Description
            // 
            this.tb_Description.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Description.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tb_Description.Location = new System.Drawing.Point(13, 13);
            this.tb_Description.MaxLength = 128;
            this.tb_Description.Name = "tb_Description";
            this.tb_Description.Size = new System.Drawing.Size(281, 20);
            this.tb_Description.TabIndex = 2;
            this.tb_Description.Text = "Введите краткое описание файла";
            this.tb_Description.Enter += new System.EventHandler(this.TextBox_Enter);
            this.tb_Description.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // tb_Path
            // 
            this.tb_Path.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tb_Path.Location = new System.Drawing.Point(13, 40);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.Size = new System.Drawing.Size(281, 20);
            this.tb_Path.TabIndex = 3;
            this.tb_Path.Text = "Укажите путь к файлу";
            this.tb_Path.Enter += new System.EventHandler(this.TextBox_Enter);
            this.tb_Path.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // btn_OpenRes
            // 
            this.btn_OpenRes.Image = global::Mnemonic.Properties.Resources.folder;
            this.btn_OpenRes.Location = new System.Drawing.Point(300, 40);
            this.btn_OpenRes.Name = "btn_OpenRes";
            this.btn_OpenRes.Size = new System.Drawing.Size(26, 20);
            this.btn_OpenRes.TabIndex = 4;
            this.btn_OpenRes.UseVisualStyleBackColor = true;
            this.btn_OpenRes.Click += new System.EventHandler(this.btn_OpenRes_Click);
            // 
            // ResDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 98);
            this.Controls.Add(this.btn_OpenRes);
            this.Controls.Add(this.tb_Path);
            this.Controls.Add(this.tb_Description);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ResDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить ссылку на файл в БД";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox tb_Description;
        private System.Windows.Forms.TextBox tb_Path;
        private System.Windows.Forms.Button btn_OpenRes;
    }
}