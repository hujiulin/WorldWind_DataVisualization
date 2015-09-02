/************************************************************************/
/* Author: Jiulin Hu*/
/* Description: folder operator*/
/************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace DBEngine
{
    class Folder
    {
        private string _FolderName;

        /// <summary>
        /// Initial a folder
        /// </summary>
        /// <param name="folderName"></param>
        public Folder(string folderName)
        {
            if (!Directory.Exists(folderName))
            {
                throw new Exception("Error: can not find folder " + folderName + ".\n" +
                                  "    Please create folder " + folderName);
            }
            _FolderName = folderName;
        }

        /// <summary>
        /// Get all files in folder and sub folder
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllFilesInFolders()
        {
            List<string> filesList = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(_FolderName);
            Queue<DirectoryInfo> dirsQueue = new Queue<DirectoryInfo>();
            dirsQueue.Enqueue(dirInfo);
            while (0 != dirsQueue.Count)
            {
                DirectoryInfo dirInfoTmp = dirsQueue.Dequeue();
                foreach (FileInfo fileInfoObj in dirInfoTmp.GetFiles())
                {
                    if ((FileAttributes.Hidden & fileInfoObj.Attributes) != FileAttributes.Hidden)
                    {
                        filesList.Add(fileInfoObj.FullName);
                    }
                }
                foreach (DirectoryInfo dirInfoObj in dirInfoTmp.GetDirectories())
                {
                    dirsQueue.Enqueue(dirInfoObj);
                }
            }
            return filesList;
        }

        /// <summary>
        /// Get all files with specified extension in folder and sub folder
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        public List<string> GetAllFilesInFoldersWithExtension(string ext)
        {
            List<string> filesList = GetAllFilesInFolders();
            for (int i = filesList.Count - 1; i >= 0;i--)
            {
                string file = filesList[i];
                if (!Path.GetExtension(file).Equals(ext, StringComparison.OrdinalIgnoreCase))
                {
                    filesList.Remove(file);
                }                
            }
            return filesList;
        }

        /// <summary>
        /// 
        /// </summary>
        public void unRARAll()
        {
            List<string> filesList = GetAllFilesInFolders();
            foreach (string file in filesList)
            {
                if (".rar" == Path.GetExtension(file).ToLower() || ".zip" == Path.GetExtension(file).ToLower())
                {
                    string rarPatch = Path.GetDirectoryName(file);
                    Console.WriteLine("Unpack " + rarPatch);
                    string unRarPatch = Path.Combine(rarPatch, Path.GetFileNameWithoutExtension(file));
                    string rarName = Path.GetFileName(file);
                    unRAR(unRarPatch, rarPatch, rarName);
                }
            }
        }

        /// <summary>
        /// unrar
        /// </summary>
        /// <param name="unRarPatch"></param>
        /// <param name="rarPatch"></param>
        /// <param name="rarName"></param>
        /// <returns></returns>
        public string unRAR(string unRarPatch, string rarPatch, string rarName)
        {
            string the_Info;
            try
            {
                if (Directory.Exists(unRarPatch) == false)
                {
                    Directory.CreateDirectory(unRarPatch);
                }
                the_Info = "x " + "\""+ rarName + "\"" + " " + "\"" + unRarPatch + "\"" + " -y";

                ProcessStartInfo the_StartInfo = new ProcessStartInfo();
                // TODO: hard code rar full filename
                // the_StartInfo.FileName = "\"F:\\Program Files (x86)\\WinRAR\\winrar.exe\\\"";
                the_StartInfo.FileName = "\"C:\\Program Files (x86)\\WinRAR\\winrar.exe\\\"";
                the_StartInfo.Arguments = the_Info;
                the_StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                the_StartInfo.WorkingDirectory = rarPatch;

                Process the_Process = new Process();
                the_Process.StartInfo = the_StartInfo;
                the_Process.Start();
                the_Process.WaitForExit();
                the_Process.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return unRarPatch;
        }
    }
}
