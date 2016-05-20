using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileUpLoadClient
{
    public class ServerFileHelper
    {
        private readonly string api = "http://localhost:6841/api/files";

        public ServerFileHelper(string apiurl)
        {
            api = apiurl;
        }
        public IEnumerable<HDFile> UploadFiles(params string[] FullFileNames)
        {
            Uri server = new Uri(api);
            HttpClient httpClient = new HttpClient();

            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();

            foreach (string fullfilename in FullFileNames)
            {
                string filename = Path.GetFileName(fullfilename);
                string filenameWithoutExtension = Path.GetFileNameWithoutExtension(fullfilename);
                //这里会向服务器上传一个png图片和一个txt文件
                StreamContent streamConent = new StreamContent(new FileStream(fullfilename, FileMode.Open, FileAccess.Read, FileShare.Read));

                multipartFormDataContent.Add(streamConent, filenameWithoutExtension, filename);
            }

            HttpResponseMessage responseMessage = httpClient.PostAsync(server, multipartFormDataContent).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                IList<HDFile> hdFiles=null;

                string content = responseMessage.Content.ReadAsStringAsync().Result;
                hdFiles = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<HDFile>>(content);

                if (hdFiles.Count > 0)
                    return hdFiles;
                else
                    return null;


            }
            return null;
        }

        public bool DownLoad(string ServerFileName, string SaveFileName)
        {
            Uri server = new Uri(String.Format("{0}?filename={1}", api, ServerFileName));
            HttpClient httpClient = new HttpClient();

            string p = Path.GetDirectoryName(SaveFileName);

            if (!Directory.Exists(p))
                Directory.CreateDirectory(p);

            HttpResponseMessage responseMessage = httpClient.GetAsync(server).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                using (FileStream fs = File.Create(SaveFileName))
                {
                    Stream streamFromService = responseMessage.Content.ReadAsStreamAsync().Result;
                    streamFromService.CopyTo(fs);
                    return true;
                }
            }
            else
                return false;
        }
    }
}
