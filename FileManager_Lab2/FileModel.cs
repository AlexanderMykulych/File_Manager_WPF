using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FileManager_Lab2
{
    class FileModel
    {
        private String fileName;
        

        public FileModel(String fileName)
        {
            SetFileName(fileName);
        }
        public FileModel()
        {
            fileName = "";
        }
        
        public void SetFileName(String fileName)
        {
            this.fileName = fileName;
        }

        public String GetFileName() 
        {
            return fileName;
        }

        public bool IsFileExist()
        {
            return (System.IO.File.Exists(fileName));
        }

        public static bool IsFileExist(String path)
        {
            return System.IO.File.Exists(path);
        }

        public String GetFileText()
        {
            if (!IsFileExist())
                return "";
            return System.IO.File.ReadAllText(fileName);            
        }

        public static String GetFileText(String path)
        {
            if (!IsFileExist(path))
                return "";
            return System.IO.File.ReadAllText(path);
        }

        public bool SetFileText(String fileText)
        {
            if (IsFileExist())
            {
                System.IO.File.WriteAllText(fileName, fileText);
                return true;
            }
            return false;
        }

        public bool CreateFile(String fileName)
        {
            if(!IsFileExist(fileName))
            {
                System.IO.FileStream fs = System.IO.File.Create(fileName);
                fs.Close();
                this.fileName = fileName;
                return true;
            }
            return false;
            
        }

    }
}
