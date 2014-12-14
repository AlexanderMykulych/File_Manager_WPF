using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManager_Lab2
{
    class Merge
    {
        List<ObjFile> file;

        public Merge()
        {
            file = new List<ObjFile>();
        }

        public void AddFile(ObjFile file)
        {
            this.file.Add(file);
        }

        public void SaveMerge()
        {
            if (file.Count == 0)
            {
                System.Windows.MessageBox.Show("У злитті немає файлів!");
                return;
            }
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            Nullable<bool> result = dlg.ShowDialog();
            if(result == true)
            {
                try
                {
                    String path = dlg.FileName;
                    System.IO.FileStream s = new FileStream(path, FileMode.Append);


                    foreach (ObjFile f in file)
                    {
                        Byte[] bytePart = System.IO.File.ReadAllBytes(f.Name);

                        s.Write(bytePart, 0, bytePart.Length);

                    }
                    s.Close();
                }
                catch(System.IO.IOException e)
                {
                    System.Windows.MessageBox.Show("Сталась помилка: " + e.Message);

                }
                System.Windows.MessageBox.Show("Злиття успішно збережено!");
            }
            this.Clear();
        }


        

        public void Clear()
        {
            file.Clear();
        }        
    }
}
