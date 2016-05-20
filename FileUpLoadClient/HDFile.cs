using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUpLoadClient
{
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
