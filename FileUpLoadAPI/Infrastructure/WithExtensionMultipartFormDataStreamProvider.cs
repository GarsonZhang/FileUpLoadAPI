using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FileUpLoadAPI.Infrastructure
{
    public class WithExtensionMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public WithExtensionMultipartFormDataStreamProvider(string rootPath)
            : base(rootPath)
        {
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string extension = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? Path.GetExtension(GetValidFileName(headers.ContentDisposition.FileName)) : "";
            return Guid.NewGuid().ToString() + extension;
        }

        private string GetValidFileName(string filePath)
        {
            char[] invalids = System.IO.Path.GetInvalidFileNameChars();
            return String.Join("_", filePath.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
        }
    }
}