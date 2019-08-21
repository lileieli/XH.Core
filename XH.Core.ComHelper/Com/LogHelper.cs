using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace XH.Core.ComHelper.ComHelper
{
    public class LogHelper
    {
        public static string LogFilePath = AppSetingHelper.APPSett.Address;

        private static object lockobj = new object();

       

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="fileName">文件名  例：log.txt</param>
        /// <param name="message">记录信息</param>
        /// <param name="ex">异常对象</param>
        public static void WriteLogFile( string message, Exception ex)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd")+".txt";
            DeleteBackup();
            string filePath = LogFilePath;
            if (!string.IsNullOrEmpty(fileName) && fileName.Contains("Controller"))
                filePath += "\\Controller";
            string path = filePath + "\\log.txt";
            if (!string.IsNullOrEmpty(fileName))
                path = filePath + "\\" + fileName;

            FileInfo fileInfo = new FileInfo(path);

            lock (lockobj)
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                if (!fileInfo.Exists)
                {
                    CreateFileAndLog(fileInfo, message, ex);
                    return;
                }

                if (fileInfo.Length > 1024 * 1024 * 10)
                {
                    File.Move(path, path.Insert(path.Length - 4, Guid.NewGuid().ToString()));
                    CreateFileAndLog(fileInfo, message, ex);
                    return;
                }

                using (FileStream fileStream = fileInfo.OpenWrite())
                {
                    WriteContent(fileStream, message, ex);
                    return;
                }
            }
        }

        private static void WriteContent(FileStream fileStream, string mes, Exception ex)
        {
            //TSysUserModel user = null;
            //try
            //{
            //    string sid = HttpContext.Current.Session.SessionID;
            //    user = HttpContext.Current.Application[sid] as TSysUserModel;
            //}
            //catch (Exception) { }
            StreamWriter write = new StreamWriter(fileStream);
            write.BaseStream.Seek(0, SeekOrigin.End);
            write.Write("\r\nLog Entry : ");
            //if (user != null)
            //write.Write(" {0} ", user.USER_C);
            write.Write(" {0} ", "admin");
            write.Write(" {0} {1} \r\n", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            write.Write(mes + "\r\n");
            if (ex != null)
            {
                write.Write("ExceptionMsg:" + ex.Message + "\r\n");
                write.Write("StackTrace:" + ex.StackTrace + "\r\n");
            }
            if (ex != null && ex.InnerException != null)
                write.Write("InnerMsg:" + ex.InnerException.Message + "\r\n");
            write.Write("-----------------------------------------------------------------------------------------------------\r\n");
            write.Flush();
            write.Close();
        }

        private static void CreateFileAndLog(FileInfo fileInfo, string mes, Exception ex)
        {
            using (FileStream fileStream = fileInfo.Create()) { WriteContent(fileStream, mes, ex); }
        }
        private static void DeleteBackup()
        {
            try
            {
                DirectoryInfo backupDirectory = new DirectoryInfo(LogFilePath);
                if (backupDirectory.Exists)
                {
                    foreach (DirectoryInfo sub in backupDirectory.GetDirectories())
                    {
                        if (!sub.FullName.Contains("backups") && sub.CreationTime < System.DateTime.Now.AddDays(-3))
                        {
                            if (Directory.Exists(LogFilePath + "\\" + sub.Name + "_backups"))
                                Directory.Delete(LogFilePath + "\\" + sub.Name + "_backups", true);
                            sub.MoveTo(LogFilePath + "\\" + sub.Name + "_backups\\");
                        }
                    }
                    foreach (FileInfo fi in backupDirectory.GetFiles())
                    {
                        if (fi.CreationTime < System.DateTime.Now.AddMonths(-2))
                        {
                            if (!Directory.Exists(LogFilePath + "\\log_backups"))
                                Directory.CreateDirectory(LogFilePath + "\\log_backups");
                            if (File.Exists(LogFilePath + "\\log_backups\\" + fi.Name))
                                File.Delete(LogFilePath + "\\log_backups\\" + fi.Name);
                            fi.MoveTo(LogFilePath + "\\log_backups\\" + fi.Name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                throw new Exception("日志配置出现问题，请联系管理员！");
                
            }

        }
    }
}