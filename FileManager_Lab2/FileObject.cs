using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_Lab2
{
    enum FileObjectType {fot_Disk, fot_Folder, fot_File};
    public abstract class FileObject
    {

        public abstract void Delete();
        public abstract void Rename();

        public abstract void Properties();

        public abstract void Select();

        public abstract List<FileObject> GetChiled();
        public abstract String Name { set; get; }
        protected String name;
    }
}
