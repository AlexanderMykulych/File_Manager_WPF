using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace FileManager_Lab2
{
    class ObjFolder : FileObject
    {
        List<FileObject> chiledFileObj;

        
        public ObjFolder(String Name)
        {
            this.Name = Name;
            chiledFileObj = new List<FileObject>();
        }
        public override void Delete() 
        {
            try
            {
                GetChiled();
                foreach(FileObject fo in chiledFileObj)
                {
                    fo.Delete();
                }
                System.IO.Directory.Delete(Name);
               // 
            }
            catch(System.IO.IOException e)
            {
                System.Windows.MessageBox.Show("Сталась помилка: " + e.Message);
            }
        }
        public override void Rename() 
        {
            String newName = InputDialog.Show("Введіть нове ім'я.");
            String dir = System.IO.Path.GetDirectoryName(Name);

            newName = dir + "\\" + newName;

            System.IO.Directory.Move(Name, newName);

            Name = newName;
        }

        public override void Properties() { }

        public override void Select() { }

        public override List<FileObject> GetChiled()
        {
            try
            {
                string[] path = System.IO.Directory.GetFiles(Name);

                string[] path1 = System.IO.Directory.GetDirectories(Name);
                string[] path2 = System.IO.Directory.GetFiles(Name);
                // string[] path = path1.Concat(path2).ToArray();

                List<FileObject> newFileObj1 = new List<FileObject>();
                pathToFileObject(path1, ref newFileObj1, 1);

                List<FileObject> newFileObj2 = new List<FileObject>();
                pathToFileObject(path2, ref newFileObj2, 2);

                newFileObj1.AddRange(newFileObj2);
                chiledFileObj = newFileObj1;

                return chiledFileObj;

            }

            catch (System.IO.IOException e)
            {
                System.Windows.MessageBox.Show("Помилка: " + e.Message);
            }
            return null;
        }

        private void pathToFileObject(string[] path, ref List<FileObject> fileObj, int id)
        {
            foreach (String p in path)
            {
                //System.Windows.MessageBox.Show(p);
                /// String p1 = System.IO.Path.GetFileName(p);
                FileObject fo;
                if (id == 1)
                    fo = new ObjFolder(p);
                else
                    fo = new ObjFile(p);

                fileObj.Add(fo);

            }
        }
        public override string Name
        {
            get
            {
                //throw new NotImplementedException();
                //return System.IO.Path.GetFileName(name);
                return name;
            }
            set 
            { 
                name = value;
            }
        }
    }
}
