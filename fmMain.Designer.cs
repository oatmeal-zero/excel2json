namespace excel2json
{
    partial class fmMain
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
            this.ofdFileList = new System.Windows.Forms.OpenFileDialog();
            this.btnSelect = new System.Windows.Forms.Button();
            this.fileList = new System.Windows.Forms.ListBox();
            this.logText = new System.Windows.Forms.RichTextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ofdFileList
            // 
            this.ofdFileList.Filter = "Excel文件|*.xlsx";
            this.ofdFileList.Multiselect = true;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "选择文件";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // fileList
            // 
            this.fileList.FormattingEnabled = true;
            this.fileList.ItemHeight = 12;
            this.fileList.Location = new System.Drawing.Point(12, 43);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(335, 496);
            this.fileList.TabIndex = 1;
            // 
            // logText
            // 
            this.logText.Location = new System.Drawing.Point(367, 43);
            this.logText.Name = "logText";
            this.logText.Size = new System.Drawing.Size(431, 496);
            this.logText.TabIndex = 2;
            this.logText.Text = "";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(103, 12);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "开始转换";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 558);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.btnSelect);
            this.Name = "fmMain";
            this.Text = "Excel表格转换json工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdFileList;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ListBox fileList;
        private System.Windows.Forms.RichTextBox logText;
        private System.Windows.Forms.Button btnConvert;
    }
}