using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_Lab2
{
    class ObjFile : FileObject
    {

        public ObjFile(String Name)
        {
            this.Name = Name;
        }

        

        public override void Delete() 
        {
            try
            {
                System.IO.File.Delete(Name);
                System.Windows.MessageBox.Show("Файл видалено успішно=)");
            }
            catch(System.IO.IOException e)
            {
                System.Windows.MessageBox.Show("Сталась помилка: " + e.Message);
            }
        }
        public override void Rename() 
        {
            String newName = InputDialog.Show("Введіть нове ім'я.");

            String dirr = System.IO.Path.GetDirectoryName(Name);
            String Exp = System.IO.Path.GetExtension(Name);

            newName = dirr + newName + Exp;

            System.IO.File.Move(Name, newName);

            Name = newName;
        }

        public override void Properties() { }

        public override void Select() { }

        public override List<FileObject> GetChiled()
        {
            return null;
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
