namespace FileUpLoadClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_AddFile = new System.Windows.Forms.Button();
            this.btn_UpLoad = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.txt_FileNamesUpload = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Result = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_FileNameDown = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_API = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_AddFile
            // 
            this.btn_AddFile.Location = new System.Drawing.Point(69, 156);
            this.btn_AddFile.Name = "btn_AddFile";
            this.btn_AddFile.Size = new System.Drawing.Size(75, 23);
            this.btn_AddFile.TabIndex = 1;
            this.btn_AddFile.Text = "浏览";
            this.btn_AddFile.UseVisualStyleBackColor = true;
            this.btn_AddFile.Click += new System.EventHandler(this.btn_AddFile_Click);
            // 
            // btn_UpLoad
            // 
            this.btn_UpLoad.Location = new System.Drawing.Point(174, 156);
            this.btn_UpLoad.Name = "btn_UpLoad";
            this.btn_UpLoad.Size = new System.Drawing.Size(75, 23);
            this.btn_UpLoad.TabIndex = 2;
            this.btn_UpLoad.Text = "上传";
            this.btn_UpLoad.UseVisualStyleBackColor = true;
            this.btn_UpLoad.Click += new System.EventHandler(this.btn_UpLoad_Click);
            // 
            // btn_Down
            // 
            this.btn_Down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Down.Location = new System.Drawing.Point(612, 526);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(75, 23);
            this.btn_Down.TabIndex = 2;
            this.btn_Down.Text = "下载";
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // txt_FileNamesUpload
            // 
            this.txt_FileNamesUpload.Location = new System.Drawing.Point(69, 54);
            this.txt_FileNamesUpload.Name = "txt_FileNamesUpload";
            this.txt_FileNamesUpload.Size = new System.Drawing.Size(618, 96);
            this.txt_FileNamesUpload.TabIndex = 3;
            this.txt_FileNamesUpload.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "文件列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "返回结果";
            // 
            // txt_Result
            // 
            this.txt_Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Result.Location = new System.Drawing.Point(69, 191);
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.Size = new System.Drawing.Size(618, 316);
            this.txt_Result.TabIndex = 3;
            this.txt_Result.Text = "";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "文件名";
            // 
            // txt_FileNameDown
            // 
            this.txt_FileNameDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_FileNameDown.Location = new System.Drawing.Point(69, 528);
            this.txt_FileNameDown.Name = "txt_FileNameDown";
            this.txt_FileNameDown.Size = new System.Drawing.Size(537, 21);
            this.txt_FileNameDown.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "API接口";
            // 
            // txt_API
            // 
            this.txt_API.Location = new System.Drawing.Point(69, 6);
            this.txt_API.Name = "txt_API";
            this.txt_API.Size = new System.Drawing.Size(618, 21);
            this.txt_API.TabIndex = 5;
            this.txt_API.Text = "http://localhost:6841/api/files";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 571);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_API);
            this.Controls.Add(this.txt_FileNameDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.txt_FileNamesUpload);
            this.Controls.Add(this.btn_Down);
            this.Controls.Add(this.btn_UpLoad);
            this.Controls.Add(this.btn_AddFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_AddFile;
        private System.Windows.Forms.Button btn_UpLoad;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.RichTextBox txt_FileNamesUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txt_Result;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_FileNameDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_API;
    }
}

