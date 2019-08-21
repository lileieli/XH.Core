using System;
using System.IO;
using XH.Core.ComHelper.Com;
using XH.Core.ComHelper.ComHelper;

namespace XH.Core.ComHelper.Files
{
    public class Upload
    {
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="Files">文件流</param>
        /// <param name="format">格式 例如 .jpg .txt</param>
        /// <returns></returns>
        public static string UploadFile(string Files,string Format)
        { 
            byte[] bytes = null;
            bytes = System.Text.Encoding.Default.GetBytes(Files);

            string path = AppSetingHelper.APPSett.FilePath + "//" + DateTime.Now.ToString("yyyyMMdd");
            string FileName = DateTime.Now.ToString("yyyyMMdd") + RandomHelper.Random() + Format;
            
            string Newpath = Path.Combine(path, FileName);
            if (!Directory.Exists(Newpath))
            {
                Directory.CreateDirectory(Newpath);
            }
            FileStream fs = new FileStream(Newpath, FileMode.OpenOrCreate);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
            return Newpath;
        }
    }
}
