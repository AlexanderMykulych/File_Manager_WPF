using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_Lab2
{
    class TotalSystem : FileObject
    {
        public override void Delete() { }
        public override void Rename() { }

        public override void Properties() { }

        public override void Select() { }

        public override List<FileObject> GetChiled() { return null; }
        public override String Name { set{name = value;} get{return name;} }
    }
}
