using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsPres1
{
    [Serializable]
   public class dataXML
    {
        public string FileName;
        public string FilePath;
        public string FilePreview;
      
        public enum _FileType
        {
            Video,
            Image,
            Flash,
            Html,
            Edit
        }
        public _FileType FileType;
    }
}
