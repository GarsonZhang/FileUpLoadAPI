using FileUpLoadAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;

namespace FileUpLoadAPI.Controllers
{
    public class FilesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        private const string UploadFolder = "uploads";

        public HttpResponseMessage Get(string fileName)
        {
            HttpResponseMessage result = null;

            DirectoryInfo directoryInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/App_Data/" + UploadFolder));
            FileInfo foundFileInfo = directoryInfo.GetFiles().Where(x => x.Name == fileName).FirstOrDefault();
            if (foundFileInfo != null)
            {
                FileStream fs = new FileStream(foundFileInfo.FullName, FileMode.Open);

                result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StreamContent(fs);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = foundFileInfo.Name;
            }
            else
            {
                result = new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            return result;
        }

        public Task<IQueryable<HDFile>> Post()
        {
            try
            {
                //uploadFolderPath variable determines where the files should be temporarily uploaded into server. 
                //Remember to give full control permission to IUSER so that IIS can write file to that folder.
                string uploadFolderPath = HostingEnvironment.MapPath("~/App_Data/" + UploadFolder);

                //如果路径不存在，创建路径
                if (!Directory.Exists(uploadFolderPath))
                    Directory.CreateDirectory(uploadFolderPath);

                //#region CleaningUpPreviousFiles.InDevelopmentOnly
                //DirectoryInfo directoryInfo = new DirectoryInfo(uploadFolderPath);
                //foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                //	fileInfo.Delete();
                //#endregion

                if (Request.Content.IsMimeMultipartContent()) //If the request is correct, the binary data will be extracted from content and IIS stores files in specified location.
                {
                    var streamProvider = new WithExtensionMultipartFormDataStreamProvider(uploadFolderPath);
                    var task = Request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith<IQueryable<HDFile>>(t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                        {
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }

                        var fileInfo = streamProvider.FileData.Select(i =>
                        {
                            var info = new FileInfo(i.LocalFileName);
                            return new HDFile(info.Name, string.Format("{0}?filename={1}", Request.RequestUri.AbsoluteUri, info.Name), (info.Length / 1024).ToString());
                        });
                        return fileInfo.AsQueryable();
                    });

                    return task;
                }
                else
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }


        public class HDFile
        {
            public HDFile(string name, string url, string size)
            {
                Name = name;
                Url = url;
                Size = size;
            }

            public string Name { get; set; }

            public string Url { get; set; }

            public string Size { get; set; }
        }

    }

    
}
