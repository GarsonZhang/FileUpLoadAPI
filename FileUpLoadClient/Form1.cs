using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileUpLoadClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public ServerFileHelper getServer()
        {
            ServerFileHelper sf = new ServerFileHelper(txt_API.Text);
            return sf;
        }

        //添加文件
        private void btn_AddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Multiselect = true;
            if (o.ShowDialog() == DialogResult.OK)
            {
                foreach (string str in o.FileNames)
                {
                    txt_FileNamesUpload.AppendText(str + System.Environment.NewLine);
                }
            }
        }

        //上传文件
        private void btn_UpLoad_Click(object sender, EventArgs e)
        {
            var sf = getServer();
            var v = sf.UploadFiles(txt_FileNamesUpload.Lines);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(v);
            txt_Result.Text = ConvertJsonString(json);
        }
                
        //下载文件
        private void btn_Down_Click(object sender, EventArgs e)
        {
            var sf = getServer();
            String FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "\\Downs\\" + txt_FileNameDown.Text);
            bool success = sf.DownLoad(txt_FileNameDown.Text, FileName);
            if (success == true)
            {
                if (MessageBox.Show("文件下载成功，要打开文件所在目录吗？", "提醒", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string path = Path.GetDirectoryName(FileName);
                    System.Diagnostics.Process.Start("explorer.exe", path);
                }
            }


        }


        private string ConvertJsonString(string str)
        {
            //格式化json字符串
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            TextReader tr = new StringReader(str);
            Newtonsoft.Json.JsonTextReader jtr = new Newtonsoft.Json.JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                Newtonsoft.Json.JsonTextWriter jsonWriter = new Newtonsoft.Json.JsonTextWriter(textWriter)
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }


    }
}
